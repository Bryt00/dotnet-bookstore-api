

using bookapi_minimal.Contracts;
using bookapi_minimal.Interfaces;


namespace bookapi_minimal.Endpoints
{public static class BookEndpoint
{
    public static IEndpointRouteBuilder MapBookEndpoint(this IEndpointRouteBuilder app)
    {
        //var book = app.MapGroup("/api/books");

        app.MapGet("/books", async (IBookService bookService) =>
               {
                   var result = await bookService.GetAllBooksAsync();
                   return TypedResults.Ok(result);
               });


        app.MapPost("/books", async (CreateBookRequest createBookRequest, IBookService bookService) =>
        {
            var result = await bookService.CreateBookAsync(createBookRequest);
            return TypedResults.Created($"/books/{result.Id}", result);

        });


        app.MapGet("/books/{id:guid}", async (Guid id, IBookService bookService) =>
        {
            var result = await bookService.GetBookByIdAsync(id);
            return result != null ? Results.Ok(result) : Results.NotFound();

        });

       app.MapPut("/books/{id:guid}", async(Guid id, UpdateBookRequest updateBookRequest, IBookService bookService)=>
       {
           var result = await bookService.UpdateBookAsync(id, updateBookRequest);
           return result != null ? Results.Ok(result) : Results.NotFound();
       });

        app.MapDelete("/books/{id:guid}", async (Guid id, IBookService bookService) =>
        {
            var result = await bookService.DeleteBookAsync(id);
            return result ? Results.NoContent() : Results.NotFound();

        });
        return app;
    }
}}