using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestJob;

namespace UnitTestProject1
{
    [TestClass]
    public class TestJobTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Matrix actualMatrix = new Matrix(5);
            actualMatrix.elements = new TestJob.MatrixElement[5, 5];
            actualMatrix.elements[0, 0] = new MatrixElement(0);
            actualMatrix.elements[0, 1] = new MatrixElement(2);
            actualMatrix.elements[0, 2] = new MatrixElement(3);
            actualMatrix.elements[0, 3] = new MatrixElement(9);
            actualMatrix.elements[0, 4] = new MatrixElement(7);

            actualMatrix.elements[1, 0] = new MatrixElement(6);
            actualMatrix.elements[1, 1] = new MatrixElement(2);
            actualMatrix.elements[1, 2] = new MatrixElement(4);
            actualMatrix.elements[1, 3] = new MatrixElement(5);
            actualMatrix.elements[1, 4] = new MatrixElement(8);

            actualMatrix.elements[2, 0] = new MatrixElement(8);
            actualMatrix.elements[2, 1] = new MatrixElement(9);
            actualMatrix.elements[2, 2] = new MatrixElement(1);
            actualMatrix.elements[2, 3] = new MatrixElement(2);
            actualMatrix.elements[2, 4] = new MatrixElement(8);

            actualMatrix.elements[3, 0] = new MatrixElement(6);
            actualMatrix.elements[3, 1] = new MatrixElement(5);
            actualMatrix.elements[3, 2] = new MatrixElement(4);
            actualMatrix.elements[3, 3] = new MatrixElement(3);
            actualMatrix.elements[3, 4] = new MatrixElement(0);

            actualMatrix.elements[4, 0] = new MatrixElement(9);
            actualMatrix.elements[4, 1] = new MatrixElement(7);
            actualMatrix.elements[4, 2] = new MatrixElement(6);
            actualMatrix.elements[4, 3] = new MatrixElement(2);
            actualMatrix.elements[4, 4] = new MatrixElement(1);

            Matrix assertMatrix = new Matrix(5);
            assertMatrix.elements = new TestJob.MatrixElement[5, 5];
            assertMatrix.elements[0, 0] = new MatrixElement(0);
            assertMatrix.elements[0, 1] = new MatrixElement(4);
            assertMatrix.elements[0, 2] = new MatrixElement(3);
            assertMatrix.elements[0, 3] = new MatrixElement(9);
            assertMatrix.elements[0, 4] = new MatrixElement(7);

            assertMatrix.elements[1, 0] = new MatrixElement(12);
            assertMatrix.elements[1, 1] = new MatrixElement(4);
            assertMatrix.elements[1, 2] = new MatrixElement(8);
            assertMatrix.elements[1, 3] = new MatrixElement(5);
            assertMatrix.elements[1, 4] = new MatrixElement(16);

            assertMatrix.elements[2, 0] = new MatrixElement(16);
            assertMatrix.elements[2, 1] = new MatrixElement(9);
            assertMatrix.elements[2, 2] = new MatrixElement(1);
            assertMatrix.elements[2, 3] = new MatrixElement(4);
            assertMatrix.elements[2, 4] = new MatrixElement(32);

            assertMatrix.elements[3, 0] = new MatrixElement(12);
            assertMatrix.elements[3, 1] = new MatrixElement(5);
            assertMatrix.elements[3, 2] = new MatrixElement(8);
            assertMatrix.elements[3, 3] = new MatrixElement(3);
            assertMatrix.elements[3, 4] = new MatrixElement(0);

            assertMatrix.elements[4, 0] = new MatrixElement(9);
            assertMatrix.elements[4, 1] = new MatrixElement(7);
            assertMatrix.elements[4, 2] = new MatrixElement(6);
            assertMatrix.elements[4, 3] = new MatrixElement(4);
            assertMatrix.elements[4, 4] = new MatrixElement(1);

            Matrix myMatrix = new Matrix(5);
            myMatrix.elements = myMatrix.FillNewMatrix(actualMatrix);

            Assert.AreEqual(true, areSame(assertMatrix, myMatrix));
        }
        public bool areSame(Matrix matrixElements1, Matrix matrixElements2)
        {
            for (int i = 0; i < matrixElements1.M; i++)
            {
                for (int j = 0; j < matrixElements1.M; j++)
                {
                    if (matrixElements1.elements[i, j].Value != matrixElements2.elements[i, j].Value)
                    {
                        return false;
                    }

                }
            }
            return true;
        }

    }
}
