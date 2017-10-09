﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transport;

namespace Transport
{
    public partial class FormRoute : Form
    {
        public static List<Route> routes = new List<Route>();
        public delegate void RouteSaveEventHandler(object sender, Route trans);
        public RouteSaveEventHandler saves;
        private Route current;
        public FormRoute()
        {
            InitializeComponent();
        }

        public FormRoute(Route route)
        {
            InitializeComponent();
            current = route;
            textBox1.Text = route.Number;
            Point last = new Point();
            foreach(Route.Stop stop in route.Stops)
            {
                StopEdit stopEdit = new StopEdit(stop)
                {
                    Location = last
                };
                panel1.Controls.Add(stopEdit);
                last.Y += stopEdit.Height;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StopEdit stop = new StopEdit();
            if (panel1.Controls.Count > 0)
            {
                Point loc = panel1.Controls[panel1.Controls.Count - 1].Location;
                loc.Y += stop.Height;
                stop.Location = loc;
            }
            panel1.Controls.Add(stop);
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && panel1.Controls.Count > 0)
            {
                Route obj = (current is null ? new Route() : current);
                obj.Number = textBox1.Text;
                obj.Stops.Clear();
                foreach (Control x in panel1.Controls)
                {
                    if (x is StopEdit edit)
                    {
                        if (edit.textBox1.Text != "" && edit.textBox2.Text != "")
                        {
                            Route.Stop stop = new Route.Stop()
                            {
                                Street = edit.textBox1.Text,
                                Name_ = edit.textBox2.Text
                            };
                            obj.Stops.Add(stop);
                        }
                    }
                }
                saves?.Invoke(this, obj);
                if(routes.Find(x => x.ID == obj.ID) is null) routes.Add(obj);
            }
            Close();
        }
    }
}
