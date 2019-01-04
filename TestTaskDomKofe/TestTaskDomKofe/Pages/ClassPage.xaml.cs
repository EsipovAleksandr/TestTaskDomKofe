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
    public partial class ClassPage : Page
    {
        public ClassPage()
        {
            InitializeComponent();
        }
        private void AddClass_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumbers.Text != "")           {
                Classe newClasse = new Classe();
                newClasse.Numbers = txtNumbers.Text;
                newClasse.Teacher_Id = Convert.ToInt16(cbTeacher_Id.SelectedValue);
                txtNumbers.Text = "";
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
            StudentManager studentManager =new StudentManager();
            var id = studentManager.GetStudents().Where(x => x.Class_id == Convert.ToInt32(txtNumbersId.Text)).FirstOrDefault();
            Console.WriteLine(id);          
          if (id==null)
            {
                ClassManager articlesManager = new ClassManager();
                articlesManager.Delete("Class",Convert.ToInt16(txtNumbersId.Text));
                //обновить
                 lstClass.ItemsSource = articlesManager.GetClasse();               
            }
            else
            {
                MessageBox.Show("Удалите сначало учеников с данного класса");
            }
        }
        private void UpdateClass_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumbersId.Text != "" && txtNumbers.Text!= "")
            {
                Classe newClasse = new Classe();
                newClasse.Id = Convert.ToInt16(txtNumbersId.Text);
                newClasse.Numbers = txtNumbers.Text;
                ClassManager classeManager = new ClassManager();
                int newClasseID = classeManager.UpdateClasse(newClasse);
                Console.WriteLine(newClasseID);
                //обновить
                lstClass.ItemsSource = classeManager.GetClasse();
            }
            
        }     
    }
}
