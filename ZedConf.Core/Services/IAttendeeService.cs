﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ZedConf.Core.DTO;

namespace ZedConf.Core.Services
{
    public interface IAttendeeService
    {
        Task<AttendeeDTO> AddAttendeeAsynce(AttendeeDTO attendeeDTO);
        Task<ICollection<AttendeeDTO>> GetAttendeesAsync();
        Task<ICollection<AttendeeDTO>> GetAttendeesByTalkAsync(int talkId);
    }
}
