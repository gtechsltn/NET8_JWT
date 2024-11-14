using JwtExamples.Business.Products.Create;
using JwtExamples.Business.Products.Delete;
using JwtExamples.Business.Products.GetAll;
using JwtExamples.Business.Products.GetById;
using JwtExamples.Business.Products.Update;
using JwtExamples.Business.Shared;
using JwtExamples.ControllerApi.Abstractions;
using JwtExamples.ControllerApi.Requests.Products;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtExamples.ControllerApi.Controllers;

[Authorize]
[Route("api/[controller]")]
public sealed class ProductsController : BaseController
{
    /// <summary>
    /// Create new product.
    /// </summary>
    /// <param name="request">The create product request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The product identifier.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Create(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<CreateProductCommand>();

        var response = await Sender.Send(command, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Create new product.
    /// </summary>
    /// <param name="request">The create product request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The product identifier.</returns>
    [HttpPut("{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> Update(Guid productId, UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<UpdateProductCommand>() with { Id = productId };

        await Sender.Send(command, cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Get product by specified identifier.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The product with the specified identifier.</returns>
    [HttpGet("{productId:guid}")]
    [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid productId, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(productId);

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }



    /// <summary>
    /// Gets all products.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>All Products.</returns>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllProductsQuery();

        var response = await Sender.Send(query, cancellationToken);

        return Ok(response);
    }

    /// <summary>
    /// Delete product with specified identifier.
    /// </summary>
    /// <param name="productId">The product identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>No Content</returns>
    [HttpDelete("{productId:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteOrder(Guid productId, CancellationToken cancellationToken)
    {
        var command = new DeleteProductCommand(productId);

        await Sender.Send(command, cancellationToken);

        return NoContent();
    }
}