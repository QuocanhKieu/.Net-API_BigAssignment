using T2305M_API.DTO.UserEvent;

namespace T2305M_API.Repositories
{
    public interface IUserEventRepository
    {
        Task<BookmarkResponseDTO> CreateBookmark(BookmarkDTO BookmarkDTO);
        Task<BookmarkResponseDTO> RemoveBookmark(BookmarkDTO BookmarkDTO);
    }
}
