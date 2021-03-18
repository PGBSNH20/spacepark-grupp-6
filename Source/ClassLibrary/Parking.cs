using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Parking
    {
        public int Id { get; set; }
        public int Fee { get; set; }
        public string MaxLength { get; set; }
        public bool Occupied { get; set; }
        public string User { get; set; }
    }
}
