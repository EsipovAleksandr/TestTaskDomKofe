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
    /// Логика взаимодействия для TeachersPage.xaml
    /// </summary>
    public partial class TeachersPage : Page
    {
        public TeachersPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TeachersManager teachersManagercs = new TeachersManager();
            lstTeachers.ItemsSource = teachersManagercs.GetTeachers();
            SubjectsManager subjectsManager = new SubjectsManager();
            cbSubject.ItemsSource = subjectsManager.GetSubjects();
        }

        private void addTeachers(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtFIO.Text != "" && txtDateOfBirth.Text != "" && txtAddress.Text != "" && cbSubject.Text != "")
                {
                    Teachers teachers = new Teachers();
                    teachers.FIO = txtFIO.Text;
                    teachers.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
                    teachers.Address = txtAddress.Text;
                    teachers.Phone = txtPhone.Text;
                    teachers.Subjects_id = Convert.ToInt32(cbSubject.SelectedValue);
                    Console.WriteLine(teachers.DateOfBirth.ToString("yyyy-MM-dd"));
                    //Create a new Classe Manager that allows you to insert a new Class to database
                    TeachersManager teachersManagercs = new TeachersManager();
                    int newClasseID = teachersManagercs.InsertSubjects(teachers);
                    Console.WriteLine(newClasseID);
                    //обновить
                    lstTeachers.ItemsSource = teachersManagercs.GetTeachers();
                }
                else
                {
                    MessageBox.Show("Не все поля заполнены!");

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void deleteTeachers(object sender, RoutedEventArgs e)
        {
         
            TeachersManager teachersManager = new TeachersManager();
            teachersManager.DeleteTeachers(Convert.ToInt16(txtTeachersId.Text));
            //обновить
            lstTeachers.ItemsSource = teachersManager.GetTeachers();
        }

        private void UpdateTeachers_Click(object sender, RoutedEventArgs e)
        {
            if (txtTeachersId.Text != "")
            {
                Teachers teachers = new Teachers();
                teachers.Id = Convert.ToInt32(txtTeachersId.Text);
                teachers.FIO = txtFIO.Text;
                teachers.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
                teachers.Address = txtAddress.Text;
                teachers.Phone = txtPhone.Text;
                teachers.Subjects_id = Convert.ToInt32(cbSubject.SelectedValue);
         
               
                TeachersManager teachersManagercs = new TeachersManager();
                int newArticleID = teachersManagercs.UpdateTeachers(teachers);
                Console.WriteLine(newArticleID);
                //обновить
                lstTeachers.ItemsSource = teachersManagercs.GetTeachers();
            }

        }

   
    }
}
