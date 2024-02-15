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

        List<Patient> patients;
        int CurrentIndex;
        Patient CurrentPatient;
        bool IsNew = false;
        public Form1()
        {
            InitializeComponent();
            patients = PatientDBHelper.GetPatients();
           
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            if (patients != null && patients.Count > 0)
            {
                CurrentIndex = 0;
                CurrentPatient = patients[CurrentIndex];
                FromDataToGUI();
            }
           
           


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
            IsNew = true;
            
            CurrentPatient = new Patient();
            CurrentPatient.Id = PatientDBHelper.GetNextId();
            FromDataToGUI();



        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            FromGUIToData();
            if (IsNew)
            {
                PatientDBHelper.AddPatient(CurrentPatient);
                IsNew = false;
            } else
            {
                PatientDBHelper.UpdatePatient(CurrentPatient);
            }

            
            patients.Add(CurrentPatient);
            


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
            PatientDBHelper.DeletePatient(CurrentPatient);
            patients.Remove(patients[CurrentIndex]);

            
        }
    }
}
