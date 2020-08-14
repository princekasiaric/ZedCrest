using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Core.DTO;
using ZedConf.Entities;
using ZedConf.Persistence.UnitOfWork;

namespace ZedConf.Core.Services.Implementation
{
    public class AttendeeService : IAttendeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AttendeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAttendeeAsynce(AttendeeDTO attendeeDTO)
        {
            var attendee = _mapper.Map<Attendee>(attendeeDTO);
            try
            {
                await _unitOfWork.AttendeeRepo.AddAttendeeAsynce(attendee);
                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<AttendeeDTO>> GetAttendeesAsync()
        {
            ICollection<AttendeeDTO> attendeeDTOs = null;
            try
            {
                var attendees = await _unitOfWork.AttendeeRepo.GetAttendeesAsync();
                if (attendees != null)
                    attendeeDTOs = _mapper.Map<ICollection<AttendeeDTO>>(attendees);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return attendeeDTOs;
        }

        public async Task<ICollection<AttendeeDTO>> GetAttendeesByTalkAsync(int talkId)
        {
            ICollection<AttendeeDTO> attendeeDTOs = null;
            try
            {
                var attendees = await _unitOfWork.AttendeeRepo.GetAttendeesByTalkAsync(talkId);
                if (attendees != null)
                    attendeeDTOs = _mapper.Map<ICollection<AttendeeDTO>>(attendees);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return attendeeDTOs;
        }
    }
}
