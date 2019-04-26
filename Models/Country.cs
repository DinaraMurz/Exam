using ExamApp.Classes.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Country : Entity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual ICollection<City> Cities { get; set; }

    }
}
