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
using System.Windows.Shapes;
using System.Windows.Navigation;

using System.Data.Entity;
using System.Globalization;

namespace Wpf_Admin
{
    /// <summary>
    /// Interaction logic for Daily_reg.xaml
    /// </summary>
    public partial class Daily_reg : Window
    {
        public Daily_reg()
        {
            InitializeComponent();
            dtpicker.SelectedDate = DateTime.Today;
        }

        private void back_button_click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;//hide all windows except main
        }
        //input is sanitized against SQL Injection attacks.
        private String sanitize(String typedString)
        {
            return new String(typedString.Where(Char.IsLetterOrDigit).ToArray());
        }

        private void txtHours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;





        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ListBoxItem itm = new ListBoxItem();
            itm.Content = "Date: " + dtpicker.Text;
           /* itm.Content = "Name: " + cboxNames.Text +"hours attended: " + txtHours.Text + " Training_On: Programming" + "  Mentor Name: " + cboMentor.Text;*/
            itm.Content = "Name: " +cboxNames.Text +" Trained On: " + txtBox.Text +" hours attended: " + txtHours.Text ;  
            ListBobx.Items.Add(itm);

            MessageBox.Show("Do you want to save changes press OK");
        DbAdminEntities2 db = new DbAdminEntities2();
            List<string> names = new List<string>();
            string date = dtpicker.Text;
            var newDate = DateTime.Parse(date);
            

            using (var dbcontext = new DbAdminEntities2())
            {
               /* TimeSpan time = new TimeSpan();*/
              
                
                AttendanceDetail attTable = new AttendanceDetail()
                {AttendanceDetail_ID = 125,
                 
                Mentee_ID = 311313
                
                };
              

                try
                {
                    dbcontext.AttendanceDetail.Add(attTable);
                   
                    dbcontext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].Close();

            /*DialogResult = true;*/


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void getProfile(object sender, RoutedEventArgs e)
        {
         
            DbAdminEntities2 db = new DbAdminEntities2();
            List<string> names = new List<string>();

            //var select = db.Person.Select(x => new { Name = x.Name }).Distinct();
            //var pick = db.AttendanceDetail.Select(x => new { Hours = x.Hours }).Distinct();

            //foreach (var userDetail in select)
            //{
            //    names.Add(userDetail.Name);

            //}
            List<Person> person = (from x in db.Person
                                   where x.Role_ID == 1
                                   
                                   select x).ToList();
            foreach (var name in person )
            {
               // cboxNames.Items.Add(name.Name);
                cboMentor.Items.Add(name.Name);               

            }
            List<Person> person2 = (from x in db.Person
                                   where x.Role_ID == 2
                                   select x).ToList();
            foreach (var name in person2)
            {
                cboxNames.Items.Add(name.Name);
                //cboMentor.Items.Add(name.Name);
              

            }

            }

        

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
