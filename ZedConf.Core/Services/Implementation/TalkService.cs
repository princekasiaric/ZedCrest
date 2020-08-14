using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Core.DTO;
using ZedConf.Entities;
using ZedConf.Persistence.UnitOfWork;

namespace ZedConf.Core.Services.Implementation
{
    public class TalkService : ITalkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TalkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task AddAttendeeForATalk()
        {
            throw new NotImplementedException();
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

        public async Task DeleteTalkAsync(int talkID)
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
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Talk> GetTalkAsync(int talkID)
        {
            Talk talk;
            try
            {
                talk = await _unitOfWork.TalkRepo.GetTalkAsync(talkID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return talk;
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
            ICollection<TalkDTO> talkDTOs = null;
            try
            {
                var talks = await _unitOfWork.TalkRepo.GetTalks();
                if (talks != null)
                    talkDTOs = _mapper.Map<ICollection<TalkDTO>>(talks);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return talkDTOs;
        }
    }
}
