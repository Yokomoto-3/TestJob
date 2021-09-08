using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestJob
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int arraySize = 0;
        Matrix matrix;
        Matrix newMatrix;
        Matrix temp1left;
        Matrix temp2left;
        Matrix temp3left;
        Matrix temp1right;
        Matrix temp2right;
        Matrix temp3right;

        public MainWindow()
        {
            InitializeComponent();
        }


        private void LeftMatrix_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            e.Column.HeaderStyle = new Style(typeof(DataGridColumnHeader));
            e.Column.HeaderStyle.Setters.Add(new Setter(HorizontalContentAlignmentProperty, HorizontalAlignment.Center));
            DataGridTextColumn column = e.Column as DataGridTextColumn;
            Binding binding = column.Binding as Binding;
            binding.Path = new PropertyPath(binding.Path.Path + ".Value");
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            matrix = new Matrix(arraySize);
            matrix.AutoFill();
            leftMatrix.ItemsSource = BindArray.GetBindable2DArray(matrix.elements);
            Button_Algorithm.IsEnabled = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            arraySize = Int32.Parse(tb_arraySize.Text);
        }

        private void Algorithm_Click(object sender, RoutedEventArgs e)
        {
            bool notNull = true;
            foreach (var elem in matrix.elements)
            {
                if (elem == null) notNull = false;
            }
            if (notNull)
            {
                newMatrix = new Matrix(arraySize);
                newMatrix.elements = newMatrix.FillNewMatrix(matrix);
                rigthMatrix.ItemsSource = BindArray.GetBindable2DArray(newMatrix.elements);
                Button_SaveToTemp1.IsEnabled = true;
                Button_SaveToTemp2.IsEnabled = true;
                Button_SaveToTemp3.IsEnabled = true;
                Button_SendEmail.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Fill left matrix");
            }
        }

        private void LeftMatrix_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            matrix.elements[e.Column.DisplayIndex, e.Row.GetIndex()].Value = Int32.Parse(((System.Windows.Controls.TextBox)e.EditingElement).Text);
        }

        private void Create_Empty_Click(object sender, RoutedEventArgs e)
        {
            matrix = new Matrix(arraySize);
            leftMatrix.ItemsSource = BindArray.GetBindable2DArray(matrix.elements);
            Button_Algorithm.IsEnabled = true;
        }

        private void Send_Email_Click(object sender, RoutedEventArgs e)
        {
            MailAddress from = new MailAddress("myEmail@gmail.com");
            MailAddress to = new MailAddress("myEmail@gmail.com");
            MailMessage m = new MailMessage(from, to)
            {
                Subject = "Тест"
            };
            string message = "Исходный массив:\n";

            for (int i = 0; i < matrix.M; i++)
            {
                for (int j = 0; j < matrix.M; j++)
                {
                    message += String.Format("{0}\t", matrix.elements[i, j].Value) ;
                }
                message += "\n";
            }
            message += "Результирующий массив:\n";
            for (int i = 0; i < newMatrix.M; i++)
            {
                for (int j = 0; j < newMatrix.M; j++)
                {
                    message += String.Format("{0}\t", newMatrix.elements[i, j].Value) ;
                }
                message += "\n";
            }
            m.Body = message;
            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("myEmail", "password")
            };
            smtp.Send(m);
            Console.WriteLine("Письмо отправлено");
        }

        private void Save_to_Temp1_Click(object sender, RoutedEventArgs e)
        {
            temp1left = matrix;
            temp1leftMatrix.ItemsSource = BindArray.GetBindable2DArray(matrix.elements);
            temp1right = newMatrix;
            temp1rigthMatrix.ItemsSource = BindArray.GetBindable2DArray(newMatrix.elements);
        }

        private void Save_to_Temp2_Click(object sender, RoutedEventArgs e)
        {
            temp2left = matrix;
            temp2leftMatrix.ItemsSource = BindArray.GetBindable2DArray(matrix.elements);
            temp2right = newMatrix;
            temp2rigthMatrix.ItemsSource = BindArray.GetBindable2DArray(newMatrix.elements);
        }

        private void Save_to_Temp3_Click(object sender, RoutedEventArgs e)
        {
            temp3left = matrix;
            temp3leftMatrix.ItemsSource = BindArray.GetBindable2DArray(matrix.elements);
            temp3right = newMatrix;
            temp3rigthMatrix.ItemsSource = BindArray.GetBindable2DArray(newMatrix.elements);
        }

        private void tb_arraySize_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
