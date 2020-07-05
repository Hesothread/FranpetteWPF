using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FranpetteLib.Model
{
    public class FApplication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public FApplication()
        {

        }
        public FApplication(int id, string name, string description)
        {

        }
    }
}
