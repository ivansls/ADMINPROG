using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ADMINPROG
{
    /// <summary>
    /// Логика взаимодействия для CRUD.xaml
    /// </summary>
    public partial class CRUD : Window
    {
        string sel = "";
        string salt = "";
        public CRUD(string text)
        {
            InitializeComponent();
            combo.ItemsSource = new List<string>() { "check_", "client_type", "discount_", "employee_", "job_title", "record_", "services_", "time_", "users" };
            salt = text;
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = combo.Items[combo.SelectedIndex] as string;
            sel = selected;


            if (selected == "check_")
            {
                var json = ApiHelper.getcheck(-1);
                var result = JsonConvert.DeserializeObject<List<check>>(json);
                Grd.ItemsSource =   result;
            }

            if (selected == "client_type")
            {
                var json = ApiHelper.getFourTable("client_type", "5001");
                var result = JsonConvert.DeserializeObject<List<client_type>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "discount_")
            {
                var json = ApiHelper.getFourTable("discount_", "5001");
                var result = JsonConvert.DeserializeObject<List<discount_>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "time_")
            {
                var json = ApiHelper.getFourTable("time_", "5001");
                var result = JsonConvert.DeserializeObject<List<time_>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "job_title")
            {
                var json = ApiHelper.getFourTable("job_title", "5001");
                var result = JsonConvert.DeserializeObject<List<job_title>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "employee_")
            {
                var json = ApiHelper.get_record_or_eployee("employee_", "5001");
                var result = JsonConvert.DeserializeObject<List<employee_or_record>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "record_")
            {
                var json = ApiHelper.get_record_or_eployee("record_", "5001");
                var result = JsonConvert.DeserializeObject<List<record_>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "services_")
            {
                var json = ApiHelper.getServices_id(5001);
                var result = JsonConvert.DeserializeObject<List<services_>>(json);
                Grd.ItemsSource = result;
            }

            if (selected == "users")
            {
                var json = ApiHelper.get_user("none");
                var result = JsonConvert.DeserializeObject<List<users>>(json);
                Grd.ItemsSource = result;
            }
        }

        private void Grd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {


                if (sel == "check_")
                {
                    check che = Grd.SelectedItem as check;
                    param1.Text = che.id_check.ToString();
                    param2.Text = che.record_id.ToString();
                    param3.Text = che.coast.ToString();
                    param4.Text = che.payment.ToString();
                }

                if (sel == "client_type")
                {
                    client_type che = Grd.SelectedItem as client_type;
                    param1.Text = che.id_client_type.ToString();
                    param2.Text = che.name.ToString();
                }

                if (sel == "discount_")
                {
                    discount_ che = Grd.SelectedItem as discount_;
                    param1.Text = che.id_discount.ToString();
                    param2.Text = che.value.ToString();
                }

                if (sel == "time_")
                {
                    time_ che = Grd.SelectedItem as time_;
                    param1.Text = che.id_time.ToString();
                    param2.Text = che.time.ToString();
                }

                if (sel == "job_title")
                {
                    job_title che = Grd.SelectedItem as job_title;
                    param1.Text = che.id_job_title.ToString();
                    param2.Text = che.name.ToString();
                }


                if (sel == "employee_")
                {
                    employee_or_record che = Grd.SelectedItem as employee_or_record;
                    param1.Text = che.id_employee.ToString();
                    param2.Text = che.login.ToString();
                    param3.Text = che.password.ToString();
                    param4.Text = che.name.ToString();
                    param5.Text = che.job_title_id.ToString();
                    param6.Text = che.exist.ToString();
                }

                if (sel == "record_")
                {
                    record_ che = Grd.SelectedItem as record_;
                    param1.Text = che.id_record.ToString();
                    param2.Text = che.service_id.ToString();
                    param3.Text = che.user_id.ToString();
                    param4.Text = che.employee_id.ToString();
                    param5.Text = che.time_id.ToString();
                    param6.Text = che.date_record.ToString();
                }

                if (sel == "services_")
                {
                    services_ che = Grd.SelectedItem as services_;
                    param1.Text = che.id_service.ToString();
                    param2.Text = che.name.ToString();
                    param3.Text = che.coast.ToString();
                }

                if (sel == "users")
                {
                    users che = Grd.SelectedItem as users;
                    param1.Text = che.id_user.ToString();
                    param2.Text = che.login.ToString();
                    param3.Text = che.password.ToString();
                    param4.Text = che.name.ToString();
                    param5.Text = che.client_type_id.ToString();
                    param6.Text = che.discount_id.ToString();
                    param7.Text = che.visit_numbers.ToString();
                    param8.Text = che.exist.ToString();
                }
            }
            catch
            {
                Grd.SelectedCells.Clear();
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (sel == "check_")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.add_check(json, param2.Text.ToString(), param3.Text.ToString(), param4.Text.ToString());
                MessageBox.Show(json2);
                combo.SelectedItem = "check_";
            }

            if (sel == "client_type")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.addFourTable(json,"client_type", param2.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "client_type";
            }

            if (sel == "discount_")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.addFourTable(json, "discount_", param2.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "discount_";
            }

            if (sel == "time_")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.addFourTable(json, "time_", param2.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "time_";
            }

            if (sel == "job_title")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.addFourTable(json, "job_title", param2.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "job_title";
            }

            if (sel == "employee_")
            {
                var json = "{\"STATUS\": YES}";
                
                var json2 = ApiHelper.add_record_or_eployee(json, "employee_", param2.Text, param3.Text, param4.Text, param5.Text, param6.Text, param7.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "employee_";
            }

            if (sel == "record_")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.add_record_or_eployee(json, "record_", param2.Text, param3.Text, param4.Text, param5.Text, param6.Text, "param7.Text");
                MessageBox.Show(json2);
                combo.SelectedItem = "record_";
            }

            if (sel == "services_")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.addServicesId(json, param2.Text, param3.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "services_";
            }



        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            if (sel == "check_")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.update_check(json, param1.Text ,param2.Text.ToString(), param3.Text.ToString(), param4.Text.ToString());
                MessageBox.Show(json2);
                combo.SelectedItem = "check_";
            }

            if (sel == "client_type")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.updateFourTable(json, "client_type", param1.Text, param2.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "client_type";
            }

            if (sel == "discount_")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.updateFourTable(json, "discount_", param1.Text, param2.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "discount_";
            }

            if (sel == "time_")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.updateFourTable(json, "time_",param1.Text, param2.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "time_";
            }

            if (sel == "job_title")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.updateFourTable(json, "job_title", param1.Text, param2.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "job_title";
            }

            if (sel == "employee_")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.update_record_or_eployee(json, "employee_", param1.Text,param2.Text, param3.Text, param4.Text, param5.Text, param6.Text, param7.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "employee_";
            }

            if (sel == "record_")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.update_record_or_eployee(json, "record_", param1.Text, param2.Text, param3.Text, param4.Text, param5.Text, param6.Text, "param7.Text");
                MessageBox.Show(json2);
                combo.SelectedItem = "record_";
            }

            if (sel == "services_")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.updateFourTable(json,  param1.Text, param2.Text, param3.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "services_";
            }

            if (sel == "users")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.update_user(json, param1.Text, param2.Text, param3.Text, param4.Text, param5.Text, param6.Text, param7.Text, param8.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "services_";
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if (sel == "check_")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.delete_check(param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "check_";
            }

            if (sel == "client_type")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.delFourTable("client_type", param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "client_type";
            }

            if (sel == "discount_")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.delFourTable("discount_", param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "discount_";
            }

            if (sel == "time_")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.delFourTable("time_", param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "time_";
            }

            if (sel == "job_title")
            {
                var json = "{\"STATUS\": YES}";
                var json2 = ApiHelper.delFourTable("job_title", param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "job_title";
            }

            if (sel == "employee_")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.delete_record_or_eployee( "employee_", param1.Text, "1");
                MessageBox.Show(json2);
                combo.SelectedItem = "employee_";
            }

            if (sel == "record_")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.delete_record_or_eployee("record_", param1.Text, "1");
                MessageBox.Show(json2);
                combo.SelectedItem = "record_";
            }

            if (sel == "deleteServicesId")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.deleteServicesId(param1.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "services_";
            }

            if (sel == "users")
            {
                var json = "{\"STATUS\": YES}";

                var json2 = ApiHelper.update_user(json, param1.Text, param2.Text, param3.Text, param4.Text, param5.Text, param6.Text, param7.Text, param8.Text);
                MessageBox.Show(json2);
                combo.SelectedItem = "services_";
            }
        }
    }
}
