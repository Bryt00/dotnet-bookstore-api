namespace bookapi_minimal.Contracts
{public record CreateBookRequest
{
    public required String Title { get; init; }
    public required String Author { get; init; }
    public required String Description { get; init; }
    public required String Category { get; init; }
    public required String Language { get; init; }
    public int TotalPages{ get; init; }
    
}}