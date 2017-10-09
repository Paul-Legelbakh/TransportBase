using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transport
{
    public partial class StopView : UserControl
    {
        private Route route;
        public StopView()
        {
            InitializeComponent();
        }

        public StopView(Route route)
        {
            InitializeComponent();
            this.route = route;
            label2.Text = route.Number;
            foreach(var stop in route.Stops)
            {
                dataGridView1.Rows.Add(stop.Street, stop.Name_);
            }
        }
        private void SaveEvent (object sender, Route route)
        {
            label2.Text = route.Number;
            dataGridView1.Rows.Clear();
            foreach (var stop in route.Stops)
            {
                dataGridView1.Rows.Add(stop.Street, stop.Name_);
            }
        }
        private void StopView_DoubleClick(object sender, EventArgs e)
        {
            FormRoute formRoute = new FormRoute(route);
            formRoute.saves = SaveEvent;
            formRoute.ShowDialog();
        }
    }
}
