using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FranpetteLib.Model
{
    public class FNew
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public FNew()
        {

        }
        public FNew(int id, string description, DateTime date)
        {
            Id = id;
            Description = description;
            Date = date;
        }
    }
}
