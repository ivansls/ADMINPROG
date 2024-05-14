using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADMINPROG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void in_Click(object sender, RoutedEventArgs e)
        {
            var json = ApiHelper.get_record_or_eployee("employee_", "501");
            var result = JsonConvert.DeserializeObject<List<employee_or_record>>(json);



            foreach (var record in result)
            {
                if (login.Text == record.login)
                {
                    /*CRUD cRUD = new CRUD();
                    cRUD.Show();
                    this.Close();*/

                    var json2 = ApiHelper.getHash(password.Text, salt.Text);
                    //var result2 = JsonConvert.DeserializeObject<string>(json);
                    string n = json2.Substring(1, (json2.Length - 2));
                    if (record.password == n)
                    {
                        CRUD cRUD = new CRUD(salt.Text);
                        cRUD.Show();
                        this.Close();
                    }

                }
            }




        }

        
    }
}