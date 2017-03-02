using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WesturantRating.Model
{
    public class Note
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
