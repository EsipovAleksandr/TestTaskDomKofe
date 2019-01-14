using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace TestTaskDomKofe.Pages.Validation
{
    public static class ValidationPages
    {
        //Валидация Teachers and Student
        public static bool CheckValue(DatePicker datePicker, TextBox textFio, TextBox textBoxPhone,
           TextBox textBoxAddress, ComboBox comboBoxSubject, TextBlock txtError,
           string datePickerText, string textBoxTextFio, string textBoxTextPhone,
           string textBoxTextAddress, string textBoxTextSubject)
        {
            bool one, two, three, four, five;
            txtError.Text = "";
            Regex regexData = new Regex(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d");
            Regex regexFIO = new Regex(@"(^[A-Z]{1}[a-z]{1,14} [A-Z]{1}[a-z]{1,14} [A-Z]{1}[a-z]{1,14}$)|(^[А-Я]{1}[а-я]{1,14} [А-Я]{1}[а-я]{1,14} [А-Я]{1}[а-я]{1,14}$)");
            Regex regexPhone = new Regex(@"^\+38[(]0\d{2}[)]\d{3}[-]\d{4}$");
            if (comboBoxSubject.SelectedValue != null)
            {
                five = true;
            }
            else
            {
                txtError.Text = textBoxTextSubject;
                five = false;
            }
            if (textBoxPhone.Text != "" && regexPhone.IsMatch(textBoxPhone.Text))
            {

                textBoxPhone.Background = Brushes.White;
                three = true;
            }
            else
            {
                txtError.Text = textBoxTextPhone;
                textBoxPhone.Background = Brushes.Crimson;
                three = false;
            }
            if (textBoxAddress.Text != "")
            {
                textBoxAddress.Background = Brushes.White;
                four = true;
            }
            else
            {
                txtError.Text = textBoxTextAddress;
                textBoxAddress.Background = Brushes.Crimson;
                four = false;
            }
            if (datePicker.Text != "" && regexData.IsMatch(datePicker.Text))
            {
                one = true;
            }
            else
            {
                txtError.Text = datePickerText;
                one = false;
            }
            if (textFio.Text != "" && regexFIO.IsMatch(textFio.Text))
            {

                textFio.Background = Brushes.White;
                two = true;
            }
            else
            {
                txtError.Text = textBoxTextFio;
                textFio.Background = Brushes.Crimson;
                two = false;
            }
            if (one == true && two == true && three == true && four == true && five == true)
            {
                return true;
            }
            return false;

        }
        //Валидация Exam
        public static bool CheckValue(ComboBox comboBoxStudents, ComboBox comboBoxSubject,
            TextBox textBox, TextBlock txtError, string comboBoxText1,
            string comboBoxText2, string textBoxText)
        {
            bool one, two, three;
            txtError.Text = "";
            Regex regex = new Regex(@"^[0-9]{1,2}$");
            if (comboBoxStudents.SelectedValue != null)
            {
                one = true;
            }
            else
            {
                txtError.Text = comboBoxText1;
                one = false;
            }
            if (comboBoxSubject.SelectedValue != null)
            {
                two = true;
            }
            else
            {
                txtError.Text = comboBoxText2;
                two = false;
            }
            if (textBox.Text != "" && regex.IsMatch(textBox.Text))
            {
                textBox.Background = Brushes.White;
                three = true;
            }
            else
            {
                txtError.Text = textBoxText;
                textBox.Background = Brushes.Crimson;
                three = false;
            }
            if (one == true && two == true && three == true)
            {
                return true;
            }
            return false;

        }
        //Валидация Classe
        public static bool CheckValue(ComboBox comboBoxTeacher_Id, TextBox textBoxNumbers, TextBlock txtError,
           string TextTeacher_Id, string TextNumbers)
        {
            bool one, two;
            txtError.Text = "";
            Regex regex = new Regex(@"^[0-9]{1}([0-9A-Z]{0,1})?([A-Z]{0,1})?$");
            if (comboBoxTeacher_Id.SelectedValue != null)
            {
                two = true;
            }
            else
            {
                txtError.Text = TextTeacher_Id;
                two = false;
            }
            if (textBoxNumbers.Text != "" && regex.IsMatch(textBoxNumbers.Text.ToUpper()))
            {

                textBoxNumbers.Background = Brushes.White;
                one = true;
            }
            else
            {
                txtError.Text = TextNumbers;
                textBoxNumbers.Background = Brushes.Crimson;
                one = false;
            }
            if (one == true && two == true)
            {
                return true;
            }
            return false;

        }
        //Валидация Subject
        public static bool CheckValue(TextBox txtSubject, TextBlock txtError,string TextSubject)
        {
            bool one;
            txtError.Text = "";
            if (txtSubject.Text != "")
            {
                txtSubject.Background = Brushes.White;
                one = true;
            }
            else
            {
                txtError.Text = TextSubject;
                txtSubject.Background = Brushes.Crimson;
                one = false;
            }         
            return one;
        }
    }
}
