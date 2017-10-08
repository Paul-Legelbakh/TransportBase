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
    public partial class StopEdit : UserControl
    {
        public StopEdit()
        {
            InitializeComponent();
        }

        public StopEdit(Route.Stop stop)
        {
            InitializeComponent();
            this.textBox1.Text = stop.Name_;
            this.textBox2.Text = stop.Street;
        }

        private void StopEdit_Load(object sender, EventArgs e)
        {

        }
    }
}
