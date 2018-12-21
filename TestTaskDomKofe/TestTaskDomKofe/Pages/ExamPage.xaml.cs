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
    /// Логика взаимодействия для ExamPage.xaml
    /// </summary>
    public partial class ExamPage : Page
    {
        public ExamPage()
        {
            InitializeComponent();
        }

        private void UpdateExam_Click(object sender, RoutedEventArgs e)
        {
            if (tbExaId.Text != "")
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

        private void deleteExam_Click(object sender, RoutedEventArgs e)
        {
            ExamManager examManager = new ExamManager();
            examManager.DeleteExam(Convert.ToInt16(tbExaId.Text));
            //обновить
            lstExam.ItemsSource = examManager.GetExamModel();
        }

        private void addExam_Click(object sender, RoutedEventArgs e)
        {
            if (tbAssessment.Text != "")
            {
                Exam exam = new Exam();
                exam.Students_id = Convert.ToInt32(cbStudents.SelectedValue);
                exam.Subjects_id = Convert.ToInt32(cbSubject.SelectedValue);
                exam.Assessment = Convert.ToInt32(tbAssessment.Text);
                Console.WriteLine(cbStudents.SelectedValue + " " + cbSubject.SelectedValue + " " + tbAssessment.Text);
                //Create a new Classe Manager that allows you to insert a new Class to database
                ExamManager examManager = new ExamManager();
                int newClasseID = examManager.InsertExam(exam);
                Console.WriteLine(newClasseID);

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
    }
}
