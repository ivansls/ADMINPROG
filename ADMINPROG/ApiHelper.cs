using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ADMINPROG
{
    internal class ApiHelper
    {
        private static string Url = "http://127.0.0.1:8000";


        //--Record_employee_----------------------------
        public static string update_record_or_eployee(string json, string table, string id, string service_id_or_login, string user_id_or_password, string employee_id_or_name, string time_id_or_job_title_id, string date_record_or_exist, string salt)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = client.PutAsync(Url + "/" + table + "/" + id + "/" + service_id_or_login + "/" + user_id_or_password + "/" + employee_id_or_name + "/" + time_id_or_job_title_id + "/" + date_record_or_exist + "/" + salt, content).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string get_record_or_eployee(string table, string id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url + "/get_record_or_eployee" + "/" + table + "/" + id).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public static string add_record_or_eployee(string json, string table, string service_id_or_login, string user_id_or_password, string employee_id_or_name, string time_id_or_job_title_id, string date_record_or_exist, string salt)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = client.PostAsync(Url + "/add_record_or_eployee/" + table + "/" + service_id_or_login + "/" + user_id_or_password + "/" + employee_id_or_name + "/" + time_id_or_job_title_id + "/" + date_record_or_exist + "/" + salt, content).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string delete_record_or_eployee(string table, string id, string dopparam)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.DeleteAsync(Url + "/delete_record_or_eployee/" + table + "/" + id + "/" + dopparam).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //--Record_employee_----------------------------


        public static string get_user(string login)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url + "/get_user" + "/" + login).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string update_user(string json, string id, string login,  string password, string salt, string name, string client_type, string discount_id, string exist)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = client.PutAsync(Url + "/update_user" + "/" + id + "/" + login + "/" +  password + "/" + salt + "/" + name + "/" + client_type + "/" + discount_id + "/" + exist, content).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        //--Client_type--discount_--time_--job_title

        public static string getFourTable(string table, string id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url + "/get" + "/" + table +"/" + id).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string addFourTable(string json ,string table, string input_text)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = client.PostAsync(Url + "/add" + "/" + table + "/" + input_text, content).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string delFourTable(string table, string id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.DeleteAsync(Url + "/dell" + "/" + table + "/" + id).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string updateFourTable(string json, string table, string id, string value)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = client.PutAsync(Url + "/update" + "/" + table + "/" + id + "/" + value, content).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        //--services_


        public static string getServices(int page, string size)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url + $"/getServices?page={page}&size={size}").Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string getServices_id(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url + "/getServices_id/" +id ).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string addServicesId(string json, string name, string coast)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = client.PostAsync(Url + "/addServices" + "/" + name + "/" + coast, content).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string updateServicesId(string json, string id, string name, string coast)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = client.PostAsync(Url + "/updateServices" + "/" + id + "/" + name + "/" + coast, content).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string deleteServicesId(string id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.DeleteAsync(Url + "/deleteServices" + "/" + id).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        //--check_----

        public static string getcheck(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url + "/get_check/" + id).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string add_check(string json, string record_id, string coast, string payment)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = client.PostAsync(Url + "/add_check" + "/" + record_id + "/" + coast + "/" + payment, content).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string update_check(string json, string id ,string record_id, string coast, string payment)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage message = client.PutAsync(Url + "/add_check" + "/" + record_id + "/" + coast + "/" + payment, content).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static string delete_check(string id)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.DeleteAsync(Url + "/delete_check" + "/" + id).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public static string getHash(string pass, string salt)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage message = client.GetAsync(Url + "/getHash/" + pass + "/" + salt).Result;
                return message.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
