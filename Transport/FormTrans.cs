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
        private Transport current;

        public FormTrans()
        {
            InitializeComponent();
            foreach (String type in Enum.GetValues(typeof(TransType)).Cast<TransType>().Select(v => v.ToString()).ToList())
            {
                comboBox2.Items.Add(type);
            }
            for (int i = 0; i < FormRoute.routes.Count(); i++)
            {
                if (FormRoute.routes[i] != null)
                    comboBox3.Items.Add(FormRoute.routes[i].Number);
            }
        }
        public FormTrans(Transport obj)
        {
            InitializeComponent();
            foreach (String type in Enum.GetValues(typeof(TransType)).Cast<TransType>().Select(v => v.ToString()).ToList())
            {
                comboBox2.Items.Add(type);
            }
            textBox1.Text = obj.Trans;
            for (int i = 0; i < FormRoute.routes.Count(); i++)
            {
                if (FormRoute.routes[i] != null)
                    comboBox3.Items.Add(FormRoute.routes[i].Number);
            }
            comboBox3.SelectedIndex = comboBox3.FindString(obj.CurrentRoute.Number);
            comboBox2.SelectedIndex = comboBox2.FindString(obj.Type.ToString());
            comboBox1.SelectedIndex = comboBox1.FindString(obj.Stop.Name_);
            current = obj;
        }
        private void FormTrans_Load(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Transport result = (current is null ? new Transport() : current);
            if((comboBox1.SelectedItem is null) || (comboBox2.SelectedItem is null) || (comboBox3.SelectedItem is null)) MessageBox.Show("Ошибка! Вы не ввели значение");
            else
            {
            if (textBox1.Text.Count() > 0)
                {
                    result.Trans = textBox1.Text;
                }
                else
                {
                    result.Trans = "";
                }
                result.CurrentRoute = FormRoute.routes[comboBox3.SelectedIndex];
                result.Type = (TransType)comboBox2.SelectedIndex;
                result.Stop = FormRoute.routes[comboBox3.SelectedIndex].Stops[comboBox1.SelectedIndex];
                save?.Invoke(this, result);
                Close();
            }
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
