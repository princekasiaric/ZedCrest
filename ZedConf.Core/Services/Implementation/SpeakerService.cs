using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Core.DTO;
using ZedConf.Persistence.UnitOfWork;

namespace ZedConf.Core.Services.Implementation
{
    public class SpeakerService : ISpeakerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SpeakerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<SpeakerDTO>> GetSpeakersAsync()
        {
            ICollection<SpeakerDTO> speakerDtos = null;
            try
            {
                var speakers = await _unitOfWork.SpeakerRepo.GetSpeakersAsync();
                if (speakers != null)
                    speakerDtos = _mapper.Map<ICollection<SpeakerDTO>>(speakers);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return speakerDtos;
        }
    }
}
