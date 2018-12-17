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

namespace TestTaskDomKofe.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClassPage.xaml
    /// </summary>
    public partial class ClassPage : Page
    {
        public ClassPage()
        {
            InitializeComponent();
        }

        private void addClass_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumbers.Text != "")
            {
                Classe newClasse = new Classe();
                newClasse.Numbers = txtNumbers.Text;
                txtNumbers.Text = "";
                //Create a new Classe Manager that allows you to insert a new Class to database
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

        }

        private void deleteClass_Click(object sender, RoutedEventArgs e)
        {
            ClassManager articlesManager = new ClassManager();
           
            articlesManager.DeleteClasse(Convert.ToInt16(txtNumbersId.Text));
            //обновить
            lstClass.ItemsSource = articlesManager.GetClasse();
        }

        private void UpdateClass_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumbersId.Text != "" && txtNumbers.Text!= "")
            {
                Classe newArticle = new Classe();
                newArticle.Id = Convert.ToInt16(txtNumbersId.Text);
                newArticle.Numbers = txtNumbers.Text;
                ClassManager classeManager = new ClassManager();
                int newArticleID = classeManager.UpdateClasse(newArticle);
                Console.WriteLine(newArticleID);
                //обновить
                lstClass.ItemsSource = classeManager.GetClasse();
            }
            
        }

       
    }
}
