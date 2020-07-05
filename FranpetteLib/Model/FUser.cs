using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FranpetteLib.Model
{
    public class FUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public FUser()
        {

        }
        public FUser(int id, string name, DateTime lastConnexion)
        {
            Id = id;
            Name = name;
        }
    }
}
