﻿using AutoMapper;
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

        public async Task<TalkDTO> AddTalkAsync(TalkDTO talkDTO)
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
            return _mapper.Map<TalkDTO>(talk);
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