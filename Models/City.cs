using ExamApp.Classes.Abstact;
using System.Collections;
using System.Collections.Generic;

namespace Models
{
    public class City : Entity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Street> Streets { get; set; }
    }
}