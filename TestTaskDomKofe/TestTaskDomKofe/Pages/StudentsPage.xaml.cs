using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TestTaskDomKofe.Model;
using TestTaskDomKofe.Model.Entities;
using TestTaskDomKofe.Pages.Validation;

namespace TestTaskDomKofe.Pages
{
    public partial class StudentsPage : Page
    {
        public StudentsPage()
        {
            InitializeComponent();
        }
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationPages.CheckValue(txtDateOfBirth, txtFIO, txtPhone, txtAddress, cbClass, txtError,
                  "Введите дату", "Введите Фамилию Имя Отчество",
                  "Напишите свой номер телефона", "Напишите адрес", "Выберите класс"))
            {
                Students students = new Students();
                    students.FIO = txtFIO.Text;
                    students.YearOfStudy = Convert.ToDateTime(txtDateOfBirth.SelectedDate.Value);
                    students.Address = txtAddress.Text;
                    students.Phone = txtPhone.Text;
                    students.Class_id = Convert.ToInt32(cbClass.SelectedValue);      
                    StudentManager studentManager = new StudentManager();
                    int newClasseID = studentManager.InsertSubjects(students);
                    Console.WriteLine(newClasseID);
                    //обновить
                    lstStudent.ItemsSource = studentManager.GetStudents();
                }
             
        }
        private void UpdateStudent_Click(object sender, RoutedEventArgs e)
        {
            if (txtStudentId.Text != "" && ValidationPages.CheckValue(txtDateOfBirth, txtFIO, txtPhone, txtAddress, cbClass, txtError,
                   "Введите дату", "Введите Фамилию Имя Отчество",
                   "Напишите свой номер телефона", "Напишите адрес", "Выберите класс"))              
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
                lstStudent.ItemsSource = studentManager.GetStudents();
            }
        }
        private void DeleteStudent(object sender, RoutedEventArgs e)
        {
            if (txtStudentId.Text != "")
            {
                StudentManager studentManager = new StudentManager();
                studentManager.Delete("Students", Convert.ToInt16(txtStudentId.Text));
                //обновить
                lstStudent.ItemsSource = studentManager.GetStudents();
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            StudentManager studentManager = new StudentManager();
            lstStudent.ItemsSource = studentManager.GetStudents();
            ClassManager classeManager = new ClassManager();
            cbClass.ItemsSource = classeManager.GetClasse();
            cbClassFilter.ItemsSource = classeManager.GetClasse();
            //Учителя 
            TeachersManager teachersManager = new TeachersManager();
            cbTeachers.ItemsSource = teachersManager.GetTeachers();
            //Предметы
            SubjectsManager subjectsManager = new SubjectsManager();
            cbSubject.ItemsSource = subjectsManager.GetSubjects();
        }
        private void RadioButtonName_Checked(object sender, RoutedEventArgs e)
        {   
            StudentManager studentManager = new StudentManager();
            lstStudent.ItemsSource = studentManager.GetStudents().OrderBy(x => x.FIO);
        }
        private void RadioButtonYear_Checked(object sender, RoutedEventArgs e)
        {
            StudentManager studentManager = new StudentManager();
            lstStudent.ItemsSource = studentManager.GetStudents().OrderBy(x => x.YearOfStudy);
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            StudentManager studentManager = new StudentManager();
            lstStudent.ItemsSource = studentManager.GetStudents();
        }
        private void RadioButtonСlass_Checked(object sender, RoutedEventArgs e)
        {
            StudentManager studentManager = new StudentManager();
            lstStudent.ItemsSource = studentManager.GetStudents().OrderBy(x => x.Class_id);
        }   
        private void lstStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ////Узнаем средний балл
                ExamManager examManager = new ExamManager();
                var MiddlleAssessment = examManager.GetExam().Where(c => c.Students_id == Convert.ToInt32(txtStudentId.Text)).Select(y => y.Assessment);
                var result = 0;
                if (MiddlleAssessment.Count() > 0)
                {
                    result = MiddlleAssessment.Sum() / MiddlleAssessment.Count();
                }
                txMiddle.Text = result.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void cbTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //StudentManager studentManager = new StudentManager();
            //ClassManager classManager = new ClassManager();
            //TeachersManager teachersManager = new TeachersManager();
            //var result = from student in studentManager.GetStudents()
            //             from classe in classManager.GetClasse()
            //             from teachers in teachersManager.GetTeachers()
            //             where student.Class_id == classe.Id && classe.Teacher_Id == teachers.Id && teachers.Id ==1
            //             select student;
            StudentManager studentManager = new StudentManager();
            var result = studentManager.GetTeachers(Convert.ToInt32(cbTeachers.SelectedValue));
            lstStudent.ItemsSource = result;
        }
        private void cbClassFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StudentManager studentManager = new StudentManager();
            var result = studentManager.GetStudents().Where(x => x.Class_id == Convert.ToInt32(cbClassFilter.SelectedValue));
            lstStudent.ItemsSource = result;
        }
        private void cbSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StudentManager studentManager = new StudentManager();
            var result = studentManager.GetSubjects(Convert.ToInt32(cbSubject.SelectedValue));
            lstStudent.ItemsSource = result;
        }     
    }
}
