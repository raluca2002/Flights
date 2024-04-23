using System;
using System.Windows.Forms;
using MPP_Csharp_Server_Client.FlightModel.domain;
using MPP_Csharp_Server_Client.FlightsServices;

namespace FlightClient
{
    public partial class Login : Form
    {
        private IService service;

        public Login(IService service)
        {
            this.service = service;
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;

            Flights flights = new Flights(service);
            try
            {
                if (service.login(username, password, (IObserver)flights))
                {
                    //MessageBox.Show("ok");
                    flights.setUser(new User(0,username, password));
                    flights.setLoginForm(this);
                    this.Hide();
                    flights.Show();
                }
                else
                {
                    MessageBox.Show("Username and password don't match!", "Login failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }


        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}