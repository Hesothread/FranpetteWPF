using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FranpetteServer.Modules.PersistanceModule.FUserPersistance.Models
{
    public class FUserData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public FUserData()
        {

        }
        public FUserData(int id, string name, DateTime lastConnexion)
        {
            Id = id;
            Name = name;
        }
    }
}
