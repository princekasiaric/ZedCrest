using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        //[HttpPost]
        //public async Task<IActionResult> AddTalk([FromBody]TalkDTO talkDTO)
        //{
        //    try
        //    {
        //        if (talkDTO == null)
        //            return BadRequest(new ApiResponse { Status = false, Message = "Bad Request" });

        //        await _talkService.AddTalkAsync(talkDTO);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Failed to add Talk: {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")} : {ex.Message}");
        //    }
        //    _logger.LogInformation("Successfully added Talk");
        //    return Created("", new ApiResponse { Status = true, Message = "Successful" });
        //}
    }
}