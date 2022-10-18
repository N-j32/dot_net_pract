using System;
using System.Collections.Generic;

namespace WebApplication2.Models
{
    public partial class TblStudent
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Fname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Mobile { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
