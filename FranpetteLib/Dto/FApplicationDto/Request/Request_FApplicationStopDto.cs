using FranpetteLib.Enum;
using System;

namespace FranpetteLib.Dto.FApplicationDto.Request
{
    public class Request_FApplicationStopDto
    {
        public string Id { get; set; }
        public string LastUserId { get; set; }
        public string LastIp { get; set; }

        public Request_FApplicationStopDto()
        {

        }
    }
}
