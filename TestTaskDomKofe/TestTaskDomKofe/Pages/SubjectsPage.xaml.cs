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
    public partial class SubjectsPage : Page
    {
        public SubjectsPage()
        {
            InitializeComponent();
        }
        private void AddSubjec_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationPages.CheckValue(tbSubject,txtError, "Введите название предмета"))
            {
                Subjects subjects = new Subjects();
                subjects.SubjectName = tbSubject.Text;
                tbSubjectId.Text = "";
                SubjectsManager subjectsManager = new SubjectsManager();
                int newSubjectId = subjectsManager.InsertSubjects(subjects);
                Console.WriteLine(newSubjectId);
                //обновить
                lstSubjects.ItemsSource = subjectsManager.GetSubjects();
            }
        }
        private void DeleteSubjec_Click(object sender, RoutedEventArgs e)
        {
            if (tbSubjectId.Text != "")
            {
                SubjectsManager subjectsManager = new SubjectsManager();
                subjectsManager.Delete("Subjects", Convert.ToInt16(tbSubjectId.Text));
                //обновить
                lstSubjects.ItemsSource = subjectsManager.GetSubjects();
            }
        }
        private void UpdateSubjec_Click(object sender, RoutedEventArgs e)
        {
            if (tbSubjectId.Text !=""&& ValidationPages.CheckValue(tbSubject, txtError, "Введите название предмета"))
            {
                Subjects subjects = new Subjects();
                subjects.Id = Convert.ToInt16(tbSubjectId.Text);
                subjects.SubjectName = tbSubject.Text;
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
        private void LettersValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
