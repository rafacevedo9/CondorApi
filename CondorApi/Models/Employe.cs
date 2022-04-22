using System;
using System.Collections.Generic;

namespace CondorApi.Models
{
    public partial class Employe
    {
        public int Id { get; set; }
        public string TypeDocument { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateBirth { get; set; }
        public string Area { get; set; } = null!;
    }
}
