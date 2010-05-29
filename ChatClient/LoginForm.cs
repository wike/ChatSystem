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
using System.Net;
using Model;

namespace ChatClient
{
    public partial class LoginForm : Form, IClientView
    {
        private IClientController controller;
        private IClientModel model;

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
            IPAddress ipAddress = null;
            int port = 0;
            if (tbUsername.Text.Trim().Length == 0)
            {
                errors += "Username not entered\n";
            }

            try {
                ipAddress = IPAddress.Parse(tbServerIp.Text.Trim());
            }catch(FormatException exception){
                errors += "Server IP address is not valid\n";
                Console.WriteLine("Exception in btnLogin.click: {0}", exception.Message);
            }catch(ArgumentNullException exception){
                errors += "Server IP address is not valid\n";
                Console.WriteLine("Exception in btnLogin.click: tbServerIp.Text == null; {0}", exception.Message);
            }
            
            try{
                if (!Int32.TryParse(tbServerPort.Text, out port))
                {
                        errors += "Server port is not valid\n";
                }
            } 
            catch(Exception exception) {
                Console.WriteLine(exception.Message);
            }
           
            if (errors.Length > 0){
                MessageBox.Show(errors);
                return;
            }else{
                //try to connect to the server and authenticate
                try{
                    controller.connect(ipAddress, port);
                    User user = new User();
                    user.name = tbUsername.Text;
                    user.password = tbPassword.Text;
                    controller.login(user);
                }
                catch (SocketException) {
                    MessageBox.Show("There was a problem while connecting to the server.\nPlease check your connection and connection settings.");
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.StackTrace, "Exception");
                }
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        #region IClientView Members

        public void setUserList(System.Collections.Generic.LinkedList<Model.User> userList)
        {
            throw new System.NotImplementedException();
        }

        public void receiveMessage(AbstractMessage message)
        {
            throw new System.NotImplementedException();
        }

        public void update(Model.AbstractMessage message)
        {
            throw new System.NotImplementedException();
        }

        public void setModelController(IClientModel model, IClientController controller)
        {
            this.model = model;
            this.controller = controller;
        }

        #endregion
    }
}
