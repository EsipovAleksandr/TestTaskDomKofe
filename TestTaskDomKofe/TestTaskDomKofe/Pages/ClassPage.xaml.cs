using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TestTaskDomKofe.Model;
using TestTaskDomKofe.Model.Entities;
using TestTaskDomKofe.Pages.Validation;

namespace TestTaskDomKofe.Pages
{
    public partial class ClassPage : Page
    {
        public ClassPage()
        {
            InitializeComponent();
        }      
        private void AddClass_Click(object sender, RoutedEventArgs e)
        {                     
            if (ValidationPages.CheckValue(cbTeacher_Id,tbNumbers,txtError, "Выберите преподавателя", "Введите номер класса"))
            {           
                    Classe newClasse = new Classe();
                    newClasse.Numbers = tbNumbers.Text.ToUpper();
                    newClasse.Teacher_Id = Convert.ToInt16(cbTeacher_Id.SelectedValue);
                    tbNumbers.Text = "";
                    cbTeacher_Id.SelectedValue = null;
                    ClassManager classeManager = new ClassManager();
                    int newClasseID = classeManager.InsertClass(newClasse);
                    Console.WriteLine(newClasseID);
                    //обновить
                    lstClass.ItemsSource = classeManager.GetClasse();            
            }                  
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ClassManager articlesManager = new ClassManager();
            lstClass.ItemsSource = articlesManager.GetClasse();
            TeachersManager teachersManager = new TeachersManager();
            cbTeacher_Id.ItemsSource = teachersManager.GetTeachers();

        }
        private void DeleteClass_Click(object sender, RoutedEventArgs e)
        {
            if (tbNumbersId.Text != "")
            {
                StudentManager studentManager = new StudentManager();
                var id = studentManager.GetStudents().Where(x => x.Class_id == Convert.ToInt32(tbNumbersId.Text)).FirstOrDefault();

                if (id == null)
                {
                    ClassManager articlesManager = new ClassManager();
                    articlesManager.Delete("Class", Convert.ToInt16(tbNumbersId.Text));
                    //обновить
                    lstClass.ItemsSource = articlesManager.GetClasse();
                    txtError.Text = "";
                }
                else
                {
                    txtError.Text = "Удалите сначало учеников с данного класса";
                }
            }
        }
        private void UpdateClass_Click(object sender, RoutedEventArgs e)
        {
            if (tbNumbersId.Text!=""&&ValidationPages.CheckValue(cbTeacher_Id, tbNumbers, txtError, "Выберите преподавателя", "введите номер класса") && cbTeacher_Id.SelectedValue != null)
            {
                Classe newClasse = new Classe();
                newClasse.Id = Convert.ToInt16(tbNumbersId.Text);
                newClasse.Numbers = tbNumbers.Text.ToUpper();
                newClasse.Teacher_Id = Convert.ToInt16(cbTeacher_Id.SelectedValue);
                ClassManager classeManager = new ClassManager();
                int newClasseID = classeManager.UpdateClasse(newClasse);
                Console.WriteLine(newClasseID);
                //обновить
                lstClass.ItemsSource = classeManager.GetClasse();
            }            
        }        
    }
}
