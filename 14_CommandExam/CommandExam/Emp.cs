using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExam
{
    internal class Emp
    {
        public string? Ename {  get; set; }
        public string? Job { get; set; }
        public override string ToString()
        {
            return "[" + Ename + "," + Job + "]";
        }
    }
}
