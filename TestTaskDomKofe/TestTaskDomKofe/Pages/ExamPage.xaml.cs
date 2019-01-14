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
    public partial class ExamPage : Page
    {
        public ExamPage()
        {
            InitializeComponent();

        }   
        private void AddExam_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationPages.CheckValue(cbStudents,cbSubject,tbAssessment,txtError, "Выберите студента", "Выберите предмет", "Введите оценку студента"))
            {
                Exam exam = new Exam();
                exam.Students_id = Convert.ToInt32(cbStudents.SelectedValue);
                exam.Subjects_id = Convert.ToInt32(cbSubject.SelectedValue);
                exam.Assessment = Convert.ToInt32(tbAssessment.Text);
                ExamManager examManager = new ExamManager();
                int newClasseID = examManager.InsertExam(exam);
                Console.WriteLine(newClasseID);
                cbStudents.Text = null;
                cbSubject.Text = null;
                tbAssessment.Text = "";
                //обновить
                lstExam.ItemsSource = examManager.GetExamModel();
            }
        }
        private void UpdateExam_Click(object sender, RoutedEventArgs e)
        {
            if (tbExaId.Text !="" && ValidationPages.CheckValue(cbStudents, cbSubject, tbAssessment, txtError, "Выберите студента", "Выберите предмет", "Введите оценку студента"))
            {
                Exam exam = new Exam();
                exam.Id = Convert.ToInt32(tbExaId.Text);
                exam.Students_id = Convert.ToInt32(cbStudents.SelectedValue);
                exam.Subjects_id = Convert.ToInt32(cbSubject.SelectedValue);
                exam.Assessment = Convert.ToInt32(tbAssessment.Text);
                ExamManager examManager = new ExamManager();
                int newArticleID = examManager.UpdateExam(exam);
                Console.WriteLine(newArticleID);
                //обновить
                lstExam.ItemsSource = examManager.GetExamModel();
            }
        }
        private void DeleteExam_Click(object sender, RoutedEventArgs e)
        {
            if (tbExaId.Text!= "")
            {
                ExamManager examManager = new ExamManager();
                examManager.Delete("Exam", Convert.ToInt16(tbExaId.Text));
                //обновить
                lstExam.ItemsSource = examManager.GetExamModel();
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ExamManager examManager = new ExamManager();
            lstExam.ItemsSource = examManager.GetExamModel();
            SubjectsManager subjectsManager = new SubjectsManager();
            cbSubject.ItemsSource = subjectsManager.GetSubjects();
            StudentManager studentManager = new StudentManager();
            cbStudents.ItemsSource = studentManager.GetStudents();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
