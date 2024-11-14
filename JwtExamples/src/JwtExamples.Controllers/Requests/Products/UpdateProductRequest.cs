namespace JwtExamples.ControllerApi.Requests.Products;

public sealed record UpdateProductRequest(string Name, string Description, decimal Price);