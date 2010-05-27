using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net.Sockets;

namespace ChatClient
{
    public partial class LoginForm : Form
    {
        private ClientController controller;

        private LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(ClientController controller) : this(){
            this.controller = controller;
        }
        /// method to validate an IP address
        /// using regular expressions. The pattern
        /// being used will validate an ip address
        /// with the range of 1.0.0.0 to 255.255.255.255
        /// </summary>
        /// <param name="addr">Address to validate</param>
        /// <returns></returns>
        public bool IsValidIP(string addr)
        {
            //create our match pattern
            string pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            //create our Regular Expression object
            Regex check = new Regex(pattern);
            //boolean variable to hold the status
            bool valid = false;
            //check to make sure an ip address was provided
            if (addr == "")
            {
                //no address provided so return false
                valid = false;
            }
            else
            {
                //address provided so use the IsMatch Method
                //of the Regular Expression object
                valid = check.IsMatch(addr, 0);
            }
            //return the results
            return valid;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            /// test user entered fields
            String errors = "";
            int port = 0;
            if (tbUsername.Text.Trim().Length == 0)
            {
                errors += "Username not entered\n";
            }
            if (!IsValidIP(tbServerIp.Text))
            {
                errors += "Server IP address is not valid\n";
            }
            if (tbServerPort.Text.Trim().Length == 0)
            {
                errors += "Server port is not valid\n";
            }
            else
            {
                try{
                    if (!Int32.TryParse(tbServerPort.Text, out port))
                    {
                        errors += "Server port has to be a number";
                    }
                }
                catch { }
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors);
                return;
            }
            else {
                //try to connect to the server and authenticate
                try
                {
                    ClientConnection client = new ClientConnection(tbServerIp.Text, port);
                    this.Hide();
                    MainForm mainForm = new MainForm(controller);
                    mainForm.Show();
                }
                catch (SocketException) {
                    MessageBox.Show("There was a problem while connecting to the server.\nPlease check your connection and connection settings.");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Wooooops!\n {0}", exception.Message);
                }
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
