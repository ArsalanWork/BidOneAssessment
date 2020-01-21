using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BidOneAssessment.Application.Commands;
using BidOneAssessment.QuerySide;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BidOneAssessment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        public readonly IContactQueries _contactQueries;
        private readonly IMediator _mediator;
        public ContactsController(IContactQueries contactQueries, IMediator mediator)
        {
            this._contactQueries = contactQueries;
            this._mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<ContactViewModel>> Get(int page, int pageSize)
        {
            return await this._contactQueries.GetContactsAsync(page, pageSize);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]CreateContact command, [FromHeader(Name = "user-id")] string userId)
        {
            if (command == null) return BadRequest();

            if (Guid.TryParse(userId, out Guid guid) && guid != Guid.Empty)
            {
                command.TriggeredBy = guid;

                if (await _mediator.Send<bool>(command))
                {
                    return Ok();
                }
                return BadRequest();
            }

            return Unauthorized();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody]UpdateContact command, [FromHeader(Name = "user-id")] string userId)
        {
            if (command == null) return BadRequest();

            if (Guid.TryParse(userId, out Guid guid) && guid != Guid.Empty)
            {
                command.TriggeredBy = guid;

                if (await _mediator.Send<bool>(command))
                {
                    return Ok();
                }
                return BadRequest();
            }

            return Unauthorized();
        }

        [HttpPut("{id}/Unsubscribe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Unsubscribe(Guid id, [FromHeader(Name = "user-id")] string userId)
        {
            if (id == Guid.Empty) return BadRequest();

            if (Guid.TryParse(userId, out Guid guid) && guid != Guid.Empty)
            {
                var command = new UnsubscribeContact
                {
                    ContactId = id,
                    TriggeredBy = guid
                };

                if (await _mediator.Send<bool>(command))
                {
                    return Ok();
                }
                return BadRequest();
            }

            return Unauthorized();
        }

        [HttpPut("{id}/Subscribe")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Subscribe(Guid id, [FromHeader(Name = "user-id")] string userId)
        {
            if (id == Guid.Empty) return BadRequest();

            if (Guid.TryParse(userId, out Guid guid) && guid != Guid.Empty)
            {
                var command = new SubscribeContact
                {
                    ContactId = id,
                    TriggeredBy = guid
                };

                if (await _mediator.Send<bool>(command))
                {
                    return Ok();
                }
                return BadRequest();
            }

            return Unauthorized();
        }
    }
}