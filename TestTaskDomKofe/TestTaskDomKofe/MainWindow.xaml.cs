using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestTaskDomKofe.Pages;

namespace TestTaskDomKofe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=DESKTOP-Q83O2OB;Initial Catalog=DomKofeDB;Integrated Security=True";
                cn.Open();
                // Работа с базой данных
                string strSQL = "SELECT Number FROM Class";
                SqlCommand myCommand = new SqlCommand(strSQL, cn);
                SqlDataReader dr = myCommand.ExecuteReader();
                while (dr.Read()) {
                    Console.WriteLine("Number: {0}", dr[0]);
                   // lab.Content = dr[0];
                }
                cn.Close();
            }
        }

        private void Teachersbtn_Click(object sender, RoutedEventArgs e)
        {
            MyContent.Content = new TeachersPage();
        }

        private void Studentsbtn_Click(object sender, RoutedEventArgs e)
        {
            MyContent.Content = new StudentsPage();
        }

        private void Classbtn_Click(object sender, RoutedEventArgs e)
        {
            MyContent.Content = new ClassPage();
        }

        private void Subjectsbtn_Click(object sender, RoutedEventArgs e)
        {
            MyContent.Content = new SubjectsPage();
        }

        private void Exambtn_Click(object sender, RoutedEventArgs e)
        {
            MyContent.Content = new ExamPage();
        }
    }
}
