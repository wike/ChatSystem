using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;

namespace ChatClient
{
    public class ClientController : IClientController
    {
        private static volatile ClientController instance;
        private static object syncRoot = new Object(); //for locking, to avoid deadlocks

        private IClientModel model;
        private IClientView view;

        private ClientController()
        {
            model = null;
        }

        public static ClientController Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ClientController();
                    }
                }
                return instance;
            }
        }

        public void connect(IPAddress ip, int port) {
            model.connect(ip, port);
            view.Hide();
            MainForm mainForm = new MainForm(this);
            this.setView(mainForm);
            mainForm.Show();
        }

        #region IClientController Members

        public void login(User user)
        {
            throw new NotImplementedException();
        }

        public void logout(User user)
        {
            throw new NotImplementedException();
        }

        public void requestUserList()
        {
            model.requestUserList();
        }

        public void send(Model.AbstractMessage message)
        {
            model.send(message);
        }

        public void setModel(IClientModel model)
        {
            this.model = model;
        }

        public void setView(IClientView view)
        {
            this.view = view;
        }

        #endregion
    }
}
