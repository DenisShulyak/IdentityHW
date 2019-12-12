using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityLesson.Models
{
    public class Reference
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Disease { get; set; }
        public DateTime DateOfIssue { get; set; } = DateTime.Now;
    }
}
