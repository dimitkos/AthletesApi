using Application.Commands.Players;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("GetAllPlayers")]
        //[ProducesResponseType(typeof(PlayerModel[]), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAllPlayers()
        //{
        //    PlayerModel[] players = await _mediator.Send(new GetAllPlayers());
        //    return Ok(palyers);
        //}

        //[HttpPost("GetStudents")]
        //[ProducesResponseType(typeof(StudentModel[]), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetStudents([FromBody] long[] studentIds)
        //{
        //    StudentModel[] students = await _mediator.Send(new GetStudents(studentIds));
        //    return Ok(students);
        //}

        //[HttpPost("AddPlayer")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> AddPlayer([FromBody] AddPlayerPayload payload)
        //{
        //    await _mediator.Send(new AddPlayer(payload));
        //    return Ok();
        //}
    }
}
