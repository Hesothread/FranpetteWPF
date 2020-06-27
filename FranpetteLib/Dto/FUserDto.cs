using System;

namespace FranpetteLib.Dto
{
    public enum UserState
    {
        Online = 1,
        Away = 2,
        Offline = 0
    }

    public class FUserDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public UserState State { get; set; }
        public DateTime LastStateChanged { get; set; }
        public string LastIp { get; set; }

        public FUserDto()
        {

        }

        public FUserDto(string id, string name, string comment, int state, DateTime lastStateChanged, string lastIp)
        {
            Id = id;
            Name = name;
            Comment = comment;
            State = (UserState)state;
            LastStateChanged = lastStateChanged;
            LastIp = lastIp;

        }
    }
}
