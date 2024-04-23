using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MPP_Csharp_Server_Client.FlightModel.domain;
using MPP_Csharp_Server_Client.FlightsServices;

namespace FlightClient
{
    public partial class Flights : Form, IObserver
    {
        private IService service;
        private User utilizator;
        private Login LoginForm;
        private string destination;
        private DateTime dataOra;
        public Flights(IService service)
        {
            InitializeComponent();
            this.service = service;
        }
        
        public void setUser(User user){
            this.utilizator = user;
        }
        public void setLoginForm(Login LoginForm){
            this.LoginForm = LoginForm;
        }
        
        private void SelectionChanged_ShowLocuri(object sender, EventArgs e)
        {
            /*
            //daca sunt selectate 0 sau >1 rows sa nu faca nimic
            if (dataGridView2.SelectedRows.Count != 1) 
                return;

            int idZbor = Int32.Parse(dataGridView2.SelectedRows[0].Cells[3].Value.ToString());
            //dataGridViewLocuri.DataSource = service.findAllLocuri(idCursa);

            List<Zbor> reservations = service.findAllFlights();
            Zbor zbor;
            foreach (Zbor z in reservations)
            {
                if (z.id == idZbor)
                     zbor = z;
            }*/

            dataGridView1.DataSource = service.findAllFlights();
            dataGridView2.DataSource = service.findFlight(destination, dataOra);
            
        }

        public void boughtTickets(List<Zbor> zbor)
        {
            dataGridView1.BeginInvoke((Action)delegate { SelectionChanged_ShowLocuri(null, null); });
            dataGridView2.BeginInvoke((Action)delegate { SelectionChanged_ShowLocuri(null, null); });
        }

        public void Flights_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = service.findAllFlights();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            destination = textBox5.Text;
            dataOra = dateTimePicker1.Value;
            List<Zbor> zboruri = service.findFlight(destination, dataOra);
            dataGridView2.DataSource = zboruri;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                int id_zbor = Convert.ToInt32(selectedRow.Cells[4].Value);
                string destinatie = Convert.ToString(selectedRow.Cells[0].Value);
                DateTime data_ora = Convert.ToDateTime(selectedRow.Cells[1].Value);
                string aeroport = Convert.ToString(selectedRow.Cells[2].Value);
                int locuri_1 = Convert.ToInt32(selectedRow.Cells[3].Value);
                Console.WriteLine(id_zbor);
                string nume = textBox1.Text;
                string turisti = textBox2.Text;
                string adresa = textBox3.Text;
                string locuri = textBox4.Text;
                int loc = Int32.Parse(locuri);
                Console.WriteLine(nume);
                Console.WriteLine(turisti);
                Console.WriteLine(adresa);
                Console.WriteLine(loc);
                List<string> turistiList = new List<string>(turisti.Split(','));
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                service.buyTicket(id_zbor, nume, adresa, loc, turistiList);
                //Console.WriteLine("okkk");*/
               /* List<Zbor> zboruri = new List<Zbor>();
                
                int loc_final = locuri_1 - loc;
                Zbor zbor = new Zbor(id_zbor, destinatie, data_ora, aeroport, loc_final);
                zboruri.Add(zbor);
                dataGridView2.DataSource = zboruri;*/
        }
    }
}