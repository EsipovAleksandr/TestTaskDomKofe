using System;
using System.Collections.Generic;
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
using TestTaskDomKofe.Model;
using TestTaskDomKofe.Model.Entities;

namespace TestTaskDomKofe.Pages
{
    /// <summary>
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        public StudentsPage()
        {
            InitializeComponent();
        }

        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            if (txtFIO.Text != "")
            {
                Students students = new Students();
                students.FIO = txtFIO.Text;
                students.YearOfStudy = Convert.ToDateTime(txtDateOfBirth.Text);
                students.Address = txtAddress.Text;
                students.Phone = txtPhone.Text;
                students.Class_id = Convert.ToInt32(cbClass.SelectedValue);
                Console.WriteLine(txtFIO.Text + " " + txtDateOfBirth + " " + txtAddress.Text + " " + txtPhone.Text + " " + cbClass.SelectedValue);
                //Create a new Classe Manager that allows you to insert a new Class to database
                StudentManager studentManager = new StudentManager();
                int newClasseID = studentManager.InsertSubjects(students);
                Console.WriteLine(newClasseID);

                //обновить
                lstTeachers.ItemsSource = studentManager.GetStudents();
            }
        }

        private void UpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            if (txtStudentId.Text != "")
            {
                Students students = new Students();
                students.Id = Convert.ToInt16(txtStudentId.Text);
                students.FIO = txtFIO.Text;
                students.YearOfStudy = Convert.ToDateTime(txtDateOfBirth.Text);
                students.Address = txtAddress.Text;
                students.Phone = txtPhone.Text;
                students.Class_id = Convert.ToInt32(cbClass.SelectedValue);
                StudentManager studentManager = new StudentManager();
                int newArticleID = studentManager.UpdateStudents(students);
                Console.WriteLine(newArticleID);
                //обновить
                lstTeachers.ItemsSource = studentManager.GetStudents();
            }
        }

        private void deleteStudent(object sender, RoutedEventArgs e)
        {
            StudentManager studentManager = new StudentManager();

            studentManager.DeleteStudents(Convert.ToInt16(txtStudentId.Text));
            //обновить
            lstTeachers.ItemsSource = studentManager.GetStudents();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StudentManager studentManager = new StudentManager();

            lstTeachers.ItemsSource = studentManager.GetStudents();

            ClasseManager classeManager = new ClasseManager();
            cbClass.ItemsSource = classeManager.GetClasse();
        }
    }
}
