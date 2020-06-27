using FranpetteLib.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace Franpette.Services.FUserServices.Models
{
    public enum UserStatus
    {
        Online = 1,
        Away = 2,
        Offline = 0
    }

    public class FUser
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Comment { get; set; }
        public UserStatus State { get; set; }
        public DateTime LastStateChanged { get; set; }
        public string LastIp { get; set; }

        public FUser()
        {

        }

        public FUser(string id, string name, string comment, UserStatus userState, DateTime lastStateChanged, string lastIp)
        {
            Id = id;
            Name = name;
            Comment = comment;
            State = userState;
            LastStateChanged = lastStateChanged;
            LastIp = lastIp;
        }

        public FUserDto ToDto()
        {
            return new FUserDto(Id, Name, Comment, (int)State, LastStateChanged, LastIp);
        }
    }
}
