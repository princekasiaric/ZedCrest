using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Core.DTO;
using ZedConf.Core.ViewModel;
using ZedConf.Entities;
using ZedConf.Persistence.UnitOfWork;

namespace ZedConf.Core.Services.Implementation
{
    public class TalkService : ITalkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttendeeService _attendeeService;
        private readonly IMapper _mapper;

        public TalkService(IUnitOfWork unitOfWork, 
                           IAttendeeService attendeeService, 
                           IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _attendeeService = attendeeService;
            _mapper = mapper;
        }

        public async Task AddAttendeeForATalk(TalkViewModel model)
        {
            var talk = await _unitOfWork.TalkRepo.GetTalkAsync(model.TalkID);
            try
            {
                if (model.Attendees.Count > 0)
                {
                    foreach (var attendee in model.Attendees)
                    {
                        talk.Attendees.Add(attendee);
                    }
                    await _unitOfWork.TalkRepo.AddTalkAsync(talk);
                    await _unitOfWork.SaveAsync();
                    await _unitOfWork.CommitChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddTalkAsync(TalkDTO talkDTO)
        {
            var talk = _mapper.Map<Talk>(talkDTO);
            try
            {
                await _unitOfWork.TalkRepo.AddTalkAsync(talk);
                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task DeleteTalkAsync(long talkID)
        {
            try
            {
                var talk = await _unitOfWork.TalkRepo.GetTalkAsync(talkID);
                if (talk != null)
                {
                    _unitOfWork.TalkRepo.RemoveTalk(talk);
                    await _unitOfWork.SaveAsync();
                    await _unitOfWork.CommitChangesAsync();
                } 
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public async Task<TalkDTO> GetTalkByTitleAsync(string title)
        {
            TalkDTO talkDTO = null;
            try
            {
                var talk = await _unitOfWork.TalkRepo.GetTalkByTitle(title);
                if (talk != null)
                    talkDTO = _mapper.Map<TalkDTO>(talk);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return talkDTO;
        }

        public async Task<ICollection<TalkDTO>> GetTalksAsync()
        {
            var talkDTOs = new List<TalkDTO>();
            try
            {
                var talks = await _unitOfWork.TalkRepo.GetTalks();
                if (talks != null)
                    talkDTOs = _mapper.Map<List<TalkDTO>>(talks);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return talkDTOs;
        }
    }
}
