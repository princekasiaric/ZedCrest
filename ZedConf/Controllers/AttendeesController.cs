using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZedConf.Core.DTO;
using ZedConf.Core.Response;
using ZedConf.Core.Services;

namespace ZedConf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeesController : ControllerBase
    {
        private readonly IAttendeeService _attendeeService;
        private readonly ILogger<AttendeesController> _logger;

        public AttendeesController(IAttendeeService attendeeService, ILogger<AttendeesController> logger)
        {
            _attendeeService = attendeeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendees()
        {
            var attendeeDTos = await _attendeeService.GetAttendeesAsync();
            try
            {
                if (attendeeDTos == null)
                    return NotFound(new ApiResponse { Status = false, Message = "Not Found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Failed to pull request: {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
            }
            _logger.LogInformation("Successfully pulled request for Attendees");
            return Ok(new ApiResponse { Status = true, Message = "Successful", Result = attendeeDTos });
        }

        [HttpGet("{talkID}")]
        public async Task<IActionResult> GetAttendeesByTalk(int talkID)
        {
            var talkDTo = await _attendeeService.GetAttendeesByTalkAsync(talkID);
            try
            {
                if (talkDTo == null)
                    return NotFound(new ApiResponse { Status = false, Message = "Not Found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Failed to pull request for Attendees per talkID '{talkID}': {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
            }
            _logger.LogInformation("Successfully pulled request for talks");
            return Ok(new ApiResponse { Status = true, Message = "Successful", Result = talkDTo });
        }

        [HttpPost]
        public async Task<IActionResult> AddAttendee([FromBody]AttendeeDTO attendeeDTO)
        {
            try
            {
                if (attendeeDTO == null)
                    return BadRequest(new ApiResponse { Status = false, Message = "Bad Request" });

                await _attendeeService.AddAttendeeAsynce(attendeeDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Failed to add Attendee: {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
            }
            _logger.LogInformation("Attendee was successfully added");
            return Created("", new ApiResponse { Status = true, Message = "Successful" });
        }
    }
}