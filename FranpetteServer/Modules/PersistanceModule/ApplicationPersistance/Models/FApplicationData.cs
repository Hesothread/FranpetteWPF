using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FranpetteServer.Modules.PersistanceModule.FApplicationPersistance.Models
{
    public enum ApplicationStatus
    {
        Online = 1,
        Offline = 0,
        Crashed = 2
    }
    public class FApplicationData
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public int Version { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public ApplicationStatus Status { get; set; }
        public DateTime LastStatusChanged { get; set; }
        public string LastUserId { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public FApplicationData()
        {

        }
        public FApplicationData(string id, int version, string name, string description, ApplicationStatus status, DateTime lastStatusChanged, string lastUserId, string ip, int port)
        {
            Id = id;
            Version = version;
            Name = name;
            Description = description;
            Status = status;
            LastStatusChanged = lastStatusChanged;
            LastUserId = lastUserId;
            Ip = ip;
            Port = port;
        }
    }
}
