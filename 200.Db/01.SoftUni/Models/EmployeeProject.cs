using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni.Models
{
    public class EmployeeProject
    {
        [Key]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public int ProjectId { get; set; }
        public virtual Project  Project { get; set; }
    }
}
