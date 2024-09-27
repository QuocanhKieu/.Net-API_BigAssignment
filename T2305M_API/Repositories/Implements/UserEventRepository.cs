using Microsoft.EntityFrameworkCore;
using T2305M_API.DTO.Event;
using T2305M_API.DTO.UserEvent;
using T2305M_API.Entities;

namespace T2305M_API.Repositories.Implements
{
    public class UserEventRepository : IUserEventRepository
    {
        private readonly T2305mApiContext _context;
        private readonly IWebHostEnvironment _env;

        public UserEventRepository(T2305mApiContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<BookmarkResponseDTO> CreateBookmark(BookmarkDTO bookmarkDTO)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Check if User exists
                    var user = await _context.User.FindAsync(bookmarkDTO.UserId);
                    if (user == null)
                    {
                        throw new KeyNotFoundException($"User with ID {bookmarkDTO.UserId} not found.");
                    }

                    // Check if Event exists
                    var eventEntity = await _context.Event.FindAsync(bookmarkDTO.EventId);
                    if (eventEntity == null)
                    {
                        throw new KeyNotFoundException($"Event with ID {bookmarkDTO.EventId} not found.");
                    }

                    // Check if the bookmark already exists (to prevent duplicates)
                    var existingBookmark = await _context.UserEvent
                        .FirstOrDefaultAsync(ue => ue.UserId == bookmarkDTO.UserId && ue.EventId == bookmarkDTO.EventId);

                    if (existingBookmark != null)
                    {
                        throw new InvalidOperationException("Bookmark already exists for this user and event.");
                    }

                    // Create new bookmark (UserEvent)
                    var newUserEvent = new UserEvent
                    {
                        UserId = bookmarkDTO.UserId,
                        EventId = bookmarkDTO.EventId,
                    };

                    _context.UserEvent.Add(newUserEvent);
                    await _context.SaveChangesAsync();

                    // Commit the transaction
                    await transaction.CommitAsync();

                    // Return success response
                    return new BookmarkResponseDTO
                    {
                        EventId = bookmarkDTO.EventId,
                        UserId = bookmarkDTO.UserId,
                        Message = "Bookmark added successfully"
                    };
                }
                catch (KeyNotFoundException ex) // Handle missing user/event errors
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex.Message); // Throw specific exception for missing keys
                }
                catch (InvalidOperationException ex) // Handle already existing bookmark case
                {
                    await transaction.RollbackAsync();
                    throw new InvalidOperationException(ex.Message); // Throw for duplicate bookmark
                }
                catch (DbUpdateException dbEx) // Handle database-specific errors
                {
                    await transaction.RollbackAsync();
                    throw new DbUpdateException("Database update failed during bookmark creation: " + dbEx.Message, dbEx);
                }
                catch (Exception ex) // Handle all other errors
                {
                    await transaction.RollbackAsync();
                    throw new Exception("An error occurred while creating the bookmark: " + ex.Message, ex);
                }
            }
        }

        public async Task<BookmarkResponseDTO> RemoveBookmark(BookmarkDTO bookmarkDTO)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // Check if User exists
                    var user = await _context.User.FindAsync(bookmarkDTO.UserId);
                    if (user == null)
                    {
                        throw new KeyNotFoundException($"User with ID {bookmarkDTO.UserId} not found.");
                    }

                    // Check if Event exists
                    var eventEntity = await _context.Event.FindAsync(bookmarkDTO.EventId);
                    if (eventEntity == null)
                    {
                        throw new KeyNotFoundException($"Event with ID {bookmarkDTO.EventId} not found.");
                    }

                    // Check if the bookmark already exists
                    var existingBookmark = await _context.UserEvent
                        .FirstOrDefaultAsync(ue => ue.UserId == bookmarkDTO.UserId && ue.EventId == bookmarkDTO.EventId);

                    // If no bookmark exists, throw an exception
                    if (existingBookmark == null)
                    {
                        throw new InvalidOperationException("Bookmark does not exist for this user and event.");
                    }

                    // Remove the bookmark
                    _context.UserEvent.Remove(existingBookmark);
                    await _context.SaveChangesAsync();

                    // Commit the transaction
                    await transaction.CommitAsync();

                    return new BookmarkResponseDTO
                    {
                        EventId = bookmarkDTO.EventId,
                        UserId = bookmarkDTO.UserId,
                        Message = "Bookmark removed successfully"
                    };
                }
                catch (KeyNotFoundException ex)
                {
                    await transaction.RollbackAsync();
                    throw new ArgumentException(ex.Message);
                }
                catch (InvalidOperationException ex)
                {
                    await transaction.RollbackAsync();
                    throw new InvalidOperationException(ex.Message);
                }
                catch (DbUpdateException dbEx)
                {
                    await transaction.RollbackAsync();
                    throw new DbUpdateException("Database update failed: " + dbEx.Message, dbEx);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("An error occurred: " + ex.Message, ex);
                }
            }
        }




    }
}
