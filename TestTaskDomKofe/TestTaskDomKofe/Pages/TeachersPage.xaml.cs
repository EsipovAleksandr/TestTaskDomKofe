using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestTaskDomKofe.Model;
using TestTaskDomKofe.Model.Entities;
using TestTaskDomKofe.Pages.Validation;

namespace TestTaskDomKofe.Pages
{
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
        private void AddTeachers(object sender, RoutedEventArgs e)
        {           
            if (ValidationPages.CheckValue(txtDateOfBirth,txtFIO,txtPhone,txtAddress,cbSubject,txtError,
                "Введите дату", "Введите Фамилию Имя Отчество",
                "Напишите свой номер телефона","Напишите адрес", "Выберите предмет")) { 
                    Teachers teachers = new Teachers();
                    teachers.FIO = txtFIO.Text;
                    teachers.DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text);
                    teachers.Address = txtAddress.Text;
                    teachers.Phone = txtPhone.Text;
                    teachers.Subjects_id = Convert.ToInt32(cbSubject.SelectedValue);
                    TeachersManager teachersManagercs = new TeachersManager();
                    int newClasseID = teachersManagercs.InsertSubjects(teachers);
                    Console.WriteLine(newClasseID);
                    //обновить
                    lstTeachers.ItemsSource = teachersManagercs.GetTeachers();
                }
             
        }
        private void DeleteTeachers(object sender, RoutedEventArgs e)
        {
            if (txtTeachersId.Text != "")
            {
                TeachersManager teachersManager = new TeachersManager();
                teachersManager.Delete("Teachers", Convert.ToInt32(txtTeachersId.Text));
                //обновить
                lstTeachers.ItemsSource = teachersManager.GetTeachers();
            }
        }
        private void UpdateTeachers_Click(object sender, RoutedEventArgs e)
        {
            if (txtTeachersId.Text != ""&& ValidationPages.CheckValue(txtDateOfBirth, txtFIO,
                txtPhone, txtAddress, cbSubject, txtError, "Введите дату",
                "Введите Фамилию Имя Отчество", "Напишите свой номер телефона",
                "Напишите адрес", "Выберите предмет"))
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
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {      
            Regex regex = new Regex("[^0-9.+]");
            e.Handled = regex.IsMatch(e.Text);
     
        }
    }
}
