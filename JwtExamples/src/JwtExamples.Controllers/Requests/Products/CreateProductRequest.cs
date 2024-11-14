namespace JwtExamples.ControllerApi.Requests.Products;

public sealed record CreateProductRequest(string Name, string Description, decimal Price);
