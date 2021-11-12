using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAI2.Models
{
    public class Lexeme
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public (int,int) Position { get; set; }
    }
}
