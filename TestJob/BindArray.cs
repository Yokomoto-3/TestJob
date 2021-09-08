using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TestJob
{
    class BindArray
    {
        public static DataView GetBindable2DArray(MatrixElement[,] array)
        {
            DataTable dataTable = new DataTable();
            for (int i = 0; i < array.GetLength(1); i++)
            {
                dataTable.Columns.Add(i.ToString(), typeof(MatrixElement));
            }
            for (int i = 0; i < array.GetLength(0); i++)
            {
                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.Add(dataRow);
            }
            DataView dataView = new DataView(dataTable);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    dataView[i][j] = array[i,j];
                }
            }
            return dataView;
        }
    }
}
