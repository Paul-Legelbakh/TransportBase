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
    public partial class FormTrans : Form
    {
        public delegate void TransportSaveEventHandler(object sender, Transport trans);
        public TransportSaveEventHandler save;
        public FormTrans()
        {
            InitializeComponent();
            foreach (String type in Enum.GetValues(typeof(TransType)).Cast<TransType>().Select(v => v.ToString()).ToList())
            {
                this.comboBox2.Items.Add(type);
            }
        }
        public FormTrans(Transport obj)
        {
            InitializeComponent();
            this.textBox1.Text = "NULL";
            this.comboBox1.Text = "NULL";
            this.comboBox3.Text = "NULL";
            this.comboBox2.SelectedIndex = this.comboBox2.FindString(obj.Type.ToString());
        }
        private void FormTrans_Load(object sender, EventArgs e)
        {
            textBox1.Text = "NULL";
            for(int i = 0; i < FormRoute.routes.Count(); i++)
            {
                if(FormRoute.routes[i] != null)
                    comboBox3.Items.Add(FormRoute.routes[i].Number);
                    for (int j = 0; j < FormRoute.routes[i].Stops.Count(); j++)
                    {
                        if (FormRoute.routes[i] != null)
                            comboBox1.Items.Add(FormRoute.routes[i].Stops[j].Name_);
                    }
            }
        }
    }
}
