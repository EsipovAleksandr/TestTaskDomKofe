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
