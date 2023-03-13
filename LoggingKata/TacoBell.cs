using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingKata
{
    public class TacoBell : ITrackable
    {
        public TacoBell(string name, Point location)
        {
            Name = name;
            Location = location;    
        }

        public string Name { get; set; }
        public Point Location { get; set; }

    }
}
