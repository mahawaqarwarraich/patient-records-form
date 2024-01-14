using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsTutorial
{
    public partial class Form1 : Form
    {

        List<Patient> patients = new List<Patient>();
        int CurrentIndex;
        Patient CurrentPatient;
        public Form1()
        {
            InitializeComponent();
            patients.Add(new Patient("maha", 1, DateTime.Now, GENDERTYPE.FEMALE, "maha@gmail.com"));
            patients.Add(new Patient("ali", 2, DateTime.Now, GENDERTYPE.MALE, "ali@gmail.com"));
            patients.Add(new Patient("saira", 1, DateTime.Now, GENDERTYPE.FEMALE, "saira@gmail.com"));
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            CurrentIndex = 0;
            CurrentPatient = patients[CurrentIndex];
            FromDataToGUI();
           


        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (CurrentIndex < patients.Count - 1) {
                CurrentIndex++;
                CurrentPatient = patients[CurrentIndex];
            }

            FromDataToGUI();



        }

        private void FromDataToGUI()
        {
            // Showing the patient on form

            txtName.Text = CurrentPatient.Name;
            txtId.Text = CurrentPatient.Id.ToString();
            dtpDoB.Value = CurrentPatient.DoB;
            cmbGender.SelectedIndex = (int)CurrentPatient.Gender;
            txtEmail.Text = CurrentPatient.Email;

        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (CurrentIndex > 0)
            {
                CurrentIndex--;
                CurrentPatient = patients[CurrentIndex];
            }

            FromDataToGUI();

        }

        private void newBtn_Click(object sender, EventArgs e)
        {
            CurrentPatient = new Patient();
            CurrentPatient.Id = patients.Count + 1;
            FromDataToGUI();



        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            FromGUIToData();


            patients.Add(CurrentPatient);
            MessageBox.Show("Operation Successful!");


        }

        private void FromGUIToData()
        {
            CurrentPatient.Name = txtName.Text;
            CurrentPatient.Id = Convert.ToInt32(txtId.Text);
            CurrentPatient.DoB = dtpDoB.Value;
            CurrentPatient.Gender = (GENDERTYPE)cmbGender.SelectedIndex;
            CurrentPatient.Email = txtEmail.Text;

        }

        private void dltBtn_Click(object sender, EventArgs e)
        {
            patients.Remove(patients[CurrentIndex]);
            MessageBox.Show("Deleted Successfully!");
        }
    }
}
