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
            }
            comboBox3.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Transport result = new Transport();
            if(textBox1.Text.Count() > 0)
            {
                result.Trans = textBox1.Text;
            }
            else
            {
                result.Trans = "";
            }
            result.CurrentRoute = FormRoute.routes[comboBox3.SelectedIndex];
            result.Stop = FormRoute.routes[comboBox3.SelectedIndex].Stops[comboBox1.SelectedIndex];
            save?.Invoke(this, result);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox3.SelectedIndex;
            comboBox1.Items.Clear();
            foreach(var stop in FormRoute.routes[index].Stops)
            {
                comboBox1.Items.Add(stop.Name_);
            }
            comboBox1.SelectedIndex = 0;
        }
    }
}
