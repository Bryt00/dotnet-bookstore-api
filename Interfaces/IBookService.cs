using bookapi_minimal.Contracts;

namespace bookapi_minimal.Interfaces
{
    public interface IBookService
    {
        Task<BookResponse> CreateBookAsync(CreateBookRequest createBookRequest);
        Task<BookResponse> GetBookByIdAsync(Guid id);
        Task<IEnumerable<BookResponse>> GetAllBooksAsync();
        Task<BookResponse> UpdateBookAsync(Guid id, UpdateBookRequest updateBookRequest);
        Task<bool> DeleteBookAsync(Guid id);
    }
}