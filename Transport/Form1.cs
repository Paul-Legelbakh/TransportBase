using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transport
{

    public partial class Form1 : Form
    {
        public List<Route> routes;
        public List<Transport> transports;

        public Form1()
        {
            InitializeComponent();
            routes = new List<Route>();
            transports = new List<Transport>();
        }

        private void savedRoute(object sender, Route route)
        {
            routes.Add(route);
            ShowRoutes();
        }

        private void savedTransport(object sender, Transport transport)
        {
            transports.Add(transport);
            ShowTransports();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRoute formRoute = new FormRoute();
            formRoute.saves = savedRoute;
            formRoute.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTrans formTrans = new FormTrans();
            formTrans.save = savedTransport;
            formTrans.ShowDialog();
        }

        private void ShowTransports()
        {
            foreach(Transport tr in transports)
            {
                dataGridView1.Rows.Add
                (
                    tr.Trans,
                    tr.Type.ToString(),
                    tr.CurrentRoute.Number,
                    tr.Stop.Name_
                );
            }
        }

        private void ShowRoutes()
        {
            Point last = new Point();
            foreach(Route route in routes)
            {
                StopView stopView = new StopView(route);
                stopView.Location = last;
                panel1.Controls.Add(stopView);
                last.Y += stopView.Height;
            }
        }
    }
}
