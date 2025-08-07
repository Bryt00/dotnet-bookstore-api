namespace bookapi_minimal.Exceptions
{public class BookDoesNotExistException : Exception
{
    private int id { set; get; }
     public BookDoesNotExistException(int id) : base($"Book with id {id} does not exist")
        {
            this.id = id;
        } 
}}