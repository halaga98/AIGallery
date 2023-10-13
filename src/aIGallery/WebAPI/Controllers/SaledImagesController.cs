using Application.Features.SaledImages.Commands.Create;
using Application.Features.SaledImages.Commands.Delete;
using Application.Features.SaledImages.Commands.Update;
using Application.Features.SaledImages.Queries.GetById;
using Application.Features.SaledImages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SaledImagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSaledImageCommand createSaledImageCommand)
    {
        CreatedSaledImageResponse response = await Mediator.Send(createSaledImageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSaledImageCommand updateSaledImageCommand)
    {
        UpdatedSaledImageResponse response = await Mediator.Send(updateSaledImageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedSaledImageResponse response = await Mediator.Send(new DeleteSaledImageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdSaledImageResponse response = await Mediator.Send(new GetByIdSaledImageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSaledImageQuery getListSaledImageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSaledImageListItemDto> response = await Mediator.Send(getListSaledImageQuery);
        return Ok(response);
    }
}