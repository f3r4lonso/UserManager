// API/Controllers/UsersController.cs
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManager.Application.Commands;

namespace UserManager.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UsersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var userId = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetById), new { id = userId }, userId);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			// Implementación de GetById si es necesario
			return Ok();
		}
	}
}
