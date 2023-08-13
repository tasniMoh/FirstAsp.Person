﻿using static System.Net.Mime.MediaTypeNames;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FirstAsp.Person.Models
{
    public class Person
    {
        [Required]
        [MaxLength(50)]
        public int NationalCode { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}
