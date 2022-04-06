using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EfReverseSamples.Models
{
    public partial class Teacher
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        public string? FirstName { get; set; }
        [StringLength(10)]
        public string? LastName { get; set; }
        [StringLength(10)]
        public string CourseName { get; set; } = null!;
    }
}
