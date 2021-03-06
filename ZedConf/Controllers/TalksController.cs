﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZedConf.Core.DTO;
using ZedConf.Core.Response;
using ZedConf.Core.Services;
using ZedConf.Core.ViewModel;

namespace ZedConf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalksController : ControllerBase
    {
        private readonly ITalkService _talkService;
        private readonly ISpeakerService _speakerService;
        private readonly ILogger<TalksController> _logger;

        public TalksController(ITalkService talkService, 
                               ISpeakerService speakerService,
                               ILogger<TalksController> logger)
        {
            _talkService = talkService;
            _speakerService = speakerService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetTalks()
        {
            var talkDTos = await _talkService.GetTalksAsync();
            try
            {
                if (talkDTos == null)
                    return NotFound(new ApiResponse { Status = false, Message = "Not Found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Failed to pull request for Talks: {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
            }
            _logger.LogInformation("Successfully pulled request for Talks");
            return Ok(new ApiResponse { Status = true, Message = "Successful", Result = talkDTos });
        }

        [HttpGet("{title}")]
        public async Task<IActionResult> GetTalkByTilte(string title)
        {
            var talkDTo = await _talkService.GetTalkByTitleAsync(title);
            try
            {
                if (talkDTo == null)
                    return NotFound(new ApiResponse { Status = false, Message = "Not Found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Failed to pull request for Talks per Title ==> {title}: {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
            }
            _logger.LogInformation("Successfully pulled request for Talks per Title");
            return Ok(new ApiResponse { Status = true, Message = "Successful", Result = talkDTo });
        }

        [HttpPost]
        public async Task<IActionResult> AddTalk([FromBody]TalkDTO talkDTO)
        {
            try
            {
                if (talkDTO == null)
                    return BadRequest(new ApiResponse { Status = false, Message = "Bad Request" });

                await _talkService.AddTalkAsync(talkDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Failed to add Talk: {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
            }
            _logger.LogInformation("Successfully added Talk");
            return Created("",new ApiResponse { Status = true, Message = "Successful" });
        }

        [HttpGet(template: "speakers")]
        public async Task<IActionResult> GetSpeakers()
        {
            var speakerDTOs = await _speakerService.GetSpeakersAsync();
            try
            {
                if (speakerDTOs == null)
                    return NotFound(new ApiResponse { Status = false, Message = "Not Found" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Failed to fetch speakers: {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
            }
            _logger.LogInformation("Successfully fetched speakers");
            return Ok(new ApiResponse { Status = true, Message = "Successful", Result = speakerDTOs });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTalk(long talkID)
        {
            try
            {
                if (talkID > 0)
                    await _talkService.DeleteTalkAsync(talkID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Failed to delete talkID ==> {talkID}: {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
            }
            _logger.LogInformation("Talk was successfully deleted");
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddAttendeeForATalk([FromBody]TalkViewModel model)
        {
            try
            {
                if (model.TalkID > 0)
                    await _talkService.AddAttendeeForATalk(model);
                else
                    return BadRequest(new ApiResponse { Status = false, Message = "Attendee list is empty" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"Failed to add Attendee for a Talk: {DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
            }
            _logger.LogInformation("An Attendee was successfully added for a Talk");
            return NoContent();
        }
    }
}