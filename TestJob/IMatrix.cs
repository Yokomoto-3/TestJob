using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJob
{
    interface IMatrix
    {
        int M { get; set; }
        MatrixElement[,] elements { get; set; }
        void AutoFill();
    }
}
