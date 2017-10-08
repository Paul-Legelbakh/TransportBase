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
        public StopView()
        {
            InitializeComponent();
        }

        public StopView(Route route)
        {
            InitializeComponent();
            this.label2.Text = route.Number;
            foreach(var stop in route.Stops)
            {
                this.dataGridView1.Rows.Add(stop.Name_, stop.Street);
            }
        }
    }
}
