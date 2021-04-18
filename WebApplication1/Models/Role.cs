using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Role
    {
        //public TypeRegister()
        //{
        //    Registers = new HashSet<Register>();
        //}

        public int Id { get; set; }
        public string Type { get; set; }

        //public virtual ICollection<Register> Registers { get; set; }
    }
}
