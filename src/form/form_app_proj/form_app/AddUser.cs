﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library.AppLogic;
using library.AppLogic.Interfaces;
using library.Database;


namespace form_app
{
    public partial class AddUser : Form
    {
        private Database instance = null;
        private IAppLogicFacade appLogic;

        public AddUser()
        {
            InitializeComponent();

            appLogic = new AppLogic();
            instance = Database.GetInstance();
        }
        

        private void buttonRegisterUserClick(object sender, EventArgs e)
        {
            bool isValid = true; // Track overall validation status
            string username = input_username.Text;
            string firstName = input_firstname.Text;
            string lastName = input_lastname.Text;

            // Validate name TextBox
            if (string.IsNullOrWhiteSpace(username))
            {
                errorUsername.SetError(input_username, "Username is required.");
                isValid = false;
            }
            else
            {
                errorUsername.SetError(input_username, ""); // Clear error message
            }

            // Validate firstname TextBox
            if (string.IsNullOrWhiteSpace(firstName))
            {
                errorFirstName.SetError(input_firstname, "First name is required.");
                isValid = false;
            }
            else
            {
                errorFirstName.SetError(input_firstname, ""); // Clear error message
            }

            // Validate last name TextBox
            if (string.IsNullOrWhiteSpace(lastName))
            {
                errorLastName.SetError(input_lastname, "Last name is required.");
                isValid = false;
            }
            else
            {
                errorLastName.SetError(input_lastname, ""); // Clear error message
            }

            if (isValid)
            {
                try {
                    appLogic.registerClient(username, firstName, lastName);
                    MessageBox.Show("Query executed successfully!");
                }
                catch (Exception ex) {
                    MessageBox.Show("Query did not execute successfully!");
                }

                this.Close();
            }
        }
    }
}