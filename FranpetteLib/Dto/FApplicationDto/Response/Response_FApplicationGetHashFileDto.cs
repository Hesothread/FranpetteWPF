using FranpetteLib.Enum;
using System;

namespace FranpetteLib.Dto.FApplicationDto.Response
{
    public class Response_FApplicationGetHashFileDto
    {
        public string Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ApplicationState Status { get; set; }
        public DateTime LastStatusChanged { get; set; }
        public string LastUserId { get; set; }
        public string LastIp { get; set; }
        public int LastPort { get; set; }

        public Response_FApplicationGetHashFileDto()
        {

        }
    }
}
