using HR_Management.Application.DTOs.LeaveAllocation;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveAllocations.Request.Commands;
using HR_Management.Application.Features.LeaveAllocations.Request.Queries;
using HR_Management.Application.Features.LeaveTypes.Request.Commands;
using HR_Management.Application.Features.LeaveTypes.Request.Queries;
using HR_Management.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDTO>>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDTO>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailRequest { Id = id });
            return Ok(leaveAllocation);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateLeaveAllocationDTO leaveAllocation)
        {
            var command = new CreateLeaveAllocationCommand { LeaveAllocationDTO = leaveAllocation };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateLeaveAllocationDTO leaveAllocation)
        {
            var command = new UpdateLeaveAllocationCommand { LeaveAllocationDTO = leaveAllocation };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
