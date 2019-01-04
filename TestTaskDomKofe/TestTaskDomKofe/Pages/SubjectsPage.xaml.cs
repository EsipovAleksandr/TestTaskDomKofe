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
    public partial class SubjectsPage : Page
    {
        public SubjectsPage()
        {
            InitializeComponent();
        }

        private void addSubjec_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumbers.Text != "")
            {
                Subjects subjects = new Subjects();
                subjects.SubjectName = txtNumbers.Text;
                txtNumbers.Text = "";
                SubjectsManager subjectsManager = new SubjectsManager();
                int newSubjectId = subjectsManager.InsertSubjects(subjects);
                Console.WriteLine(newSubjectId);

                //обновить
                lstSubjects.ItemsSource = subjectsManager.GetSubjects();
            }
        }
        private void deleteSubjec_Click(object sender, RoutedEventArgs e)
        {
            SubjectsManager subjectsManager = new SubjectsManager();
            subjectsManager.Delete("Subjects",Convert.ToInt16(txtNumbersId.Text));
            //обновить
            lstSubjects.ItemsSource = subjectsManager.GetSubjects();
        }
        private void UpdateSubjec_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumbersId.Text != "" && txtNumbers.Text != "")
            {
                Subjects subjects = new Subjects();
                subjects.Id = Convert.ToInt16(txtNumbersId.Text);
                subjects.SubjectName = txtNumbers.Text;
                SubjectsManager subjectsManager = new SubjectsManager();
                int newArticleID = subjectsManager.UpdateSubjects(subjects);
                Console.WriteLine(newArticleID);
                //обновить
                lstSubjects.ItemsSource = subjectsManager.GetSubjects();
            }
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            SubjectsManager subjectsManager = new SubjectsManager();

            lstSubjects.ItemsSource = subjectsManager.GetSubjects();
        }
    }
}
