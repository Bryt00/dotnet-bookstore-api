
using Microsoft.EntityFrameworkCore;

using bookapi_minimal.Models;
using bookapi_minimal.AppContext;
using bookapi_minimal.Interfaces;
using bookapi_minimal.Contracts;



namespace bookapi_minimal.Services
{public class BookService : IBookService
{
    private readonly ApplicationContext _context;
    private ILogger<BookService> _logger;

    public BookService(ApplicationContext context, ILogger<BookService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<BookResponse> CreateBookAsync(CreateBookRequest createBookRequest)
    {
        try
        {
            var book = new BookModel
            {
                Title = createBookRequest.Title,
                Author = createBookRequest.Author,
                Description = createBookRequest.Description,
                Category = createBookRequest.Category,
                Language = createBookRequest.Language,
                TotalPages = createBookRequest.TotalPages


            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Book added Successfully");

            return new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Category = book.Category,
                Language = book.Language,
                TotalPages = book.TotalPages,

            };

        }

        catch (Exception e)
        {
            _logger.LogError($"Error adding book: {e.Message}");
            throw;
        }
    }

    public async Task<bool> DeleteBookAsync(Guid id)
    {
        try
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                _logger.LogWarning($"Book with ID {id} not found ");
                return false;
            }
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Book with ID {id} successfully deleted");
            return true;

        }
        catch (Exception ex)
        {
            _logger.LogError($"Error deleting book: {ex.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<BookResponse>> GetAllBooksAsync()
    {
        try
        {
            var books = await _context.Books.ToListAsync();
            return books.Select(book => new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Category = book.Category,
                Language = book.Language,
                TotalPages = book.TotalPages,


            });
        }
        catch (Exception e)
        {
            _logger.LogError($"Error retrieving books: {e.Message}");
            throw;
        }
    }

    public async Task<BookResponse> GetBookByIdAsync(Guid id)
    {
        try
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                _logger.LogWarning($"Book with ID {id} not found");
                return null;
            }
            return new BookResponse
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Category = book.Category,
                Language = book.Language,
                TotalPages = book.TotalPages,

            };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error retrieving book: {e.Message}");
            throw;
        }
    }

    public async Task<BookResponse?> UpdateBookAsync(Guid id, UpdateBookRequest updateBookRequest)
    {
        try
        {
            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                _logger.LogWarning($"Book with ID {id} not found.");
                return null;
            }

            existingBook.Title = updateBookRequest.Title;
            existingBook.Author = updateBookRequest.Author;
            existingBook.Description = updateBookRequest.Description;
            existingBook.Category = updateBookRequest.Category;
            existingBook.Language = updateBookRequest.Language;
            existingBook.TotalPages = updateBookRequest.TotalPages;

            await _context.SaveChangesAsync();
            _logger.LogInformation($"Book with ID {id} updated successfully");

            return new BookResponse
            {
                Id = existingBook.Id,
                Title = existingBook.Title,
                Author = existingBook.Author,
                Description = existingBook.Description,
                Category = existingBook.Category,
                Language = existingBook.Language,
                TotalPages = existingBook.TotalPages
            };
        }
        catch (Exception e)
        {
            _logger.LogError($"Error updating book: {e.Message}");
            throw;
        }
    }
}}