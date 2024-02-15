using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ControlsTutorial
{
    internal static class PatientDBHelper
    {
        private  static string ConnString = "Data Source=DESKTOP-8BL3MIG\\SQLEXPRESS;Initial Catalog=hms_db2;Integrated Security=True";
        public static List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConnString;
            sqlConnection.Open();

            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                string query = "Select * from Patient";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if ( sqlDataReader != null && sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        Patient patient = new Patient();
                        patient.Id = sqlDataReader.GetInt32(0);
                        patient.Name = sqlDataReader.GetString(1);
                        patient.DoB = sqlDataReader.GetDateTime(2);
                        patient.Gender = (GENDERTYPE) sqlDataReader.GetInt16(3);
                        patient.Email = sqlDataReader.GetString(4);
                        patients.Add(patient);

                    }

                }
            }


            sqlConnection.Close();
            return patients;

        }

        public static void AddPatient(Patient patient)
        {
            
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConnString;
            sqlConnection.Open();

            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                string query = "Insert into patient(id, name, dob, gender, email) values(@id, @name, @dob, @gender, @email)";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", patient.Id);
                sqlCommand.Parameters.AddWithValue("@name", patient.Name);
                sqlCommand.Parameters.AddWithValue("@dob", patient.DoB);
                sqlCommand.Parameters.AddWithValue("@gender", patient.Gender);
                sqlCommand.Parameters.AddWithValue("@email", patient.Email);

                int rowsAffected = sqlCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    System.Windows.Forms.MessageBox.Show("Operation Sucessful");
                } 





            }


            sqlConnection.Close();
           
        }

        public static void UpdatePatient(Patient patient)
        {

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConnString;
            sqlConnection.Open();

            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                string query = "Update Patient set name = @name, dob = @dob, gender = @gender, email = @email where id = @id";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", patient.Id);
                sqlCommand.Parameters.AddWithValue("@name", patient.Name);
                sqlCommand.Parameters.AddWithValue("@dob", patient.DoB);
                sqlCommand.Parameters.AddWithValue("@gender", patient.Gender);
                sqlCommand.Parameters.AddWithValue("@email", patient.Email);

                int rowsAffected = sqlCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    System.Windows.Forms.MessageBox.Show("Operation Sucessful");
                }





            }


            sqlConnection.Close();

        }

        public static void DeletePatient(Patient patient)
        {

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConnString;
            sqlConnection.Open();

            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                string query = "Delete from patient where id = @id";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.Parameters.AddWithValue("@id", patient.Id);
                

                int rowsAffected = sqlCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    System.Windows.Forms.MessageBox.Show("Operation Sucessful");
                }





            }


            sqlConnection.Close();

        }

        public static int GetNextId()
        {
            int maxId = 0;
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConnString;
            sqlConnection.Open();

            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                string query = "Select max(id) from Patient";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                object result  = sqlCommand.ExecuteScalar();

                if (result != null)
                {
                    maxId = (int)result;
                }


               




            }



            sqlConnection.Close();
            return maxId + 1;

        }



    }


}
