using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJob
{
    public class MatrixElement
    {
        public int Value{ get; set; }
        public string Marker { get; set; }
        public int before;

        public MatrixElement()
        {
            Value = 0;
            Marker = "none";
        }

        public MatrixElement(int value)
        {
            this.Value = value;
            this.Marker = "none";
        }

    }
}
