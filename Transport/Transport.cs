using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace Transport
{
    public enum TransType { Bus, Minibus, Trolleybus, Tram, Metro }
    public class Transport
    {
        public TransType Type { get; set; }
        public string Trans { get; set; }
        public Route CurrentRoute { get; set; }
        public Route.Stop Stop { get; set; }
        //public void input(FormTrans formTrans)
        //{
        //    foreach (Control i in formTrans.Controls)
        //    {
        //        if (i is TextBox)
        //        {
        //            TextBox text = (TextBox)i;
        //            PropertyInfo info = (typeof(Transport)).GetProperty(text.Name);
        //            if (info != null)
        //            {
        //                switch (info.PropertyType.Name)
        //                {
        //                    case "String":
        //                        info.SetValue(this, text.Text, null);
        //                        break;
        //                    case "Int32":
        //                        info.SetValue(this, Convert.ToInt32(text.Text), null);
        //                        break;
        //                }

        //            }
        //        }
        //    }
        //}
        //public void output(FormTrans formTrans)
        //{
        //    foreach (Control i in formTrans.Controls)
        //    {
        //        if (i is TextBox)
        //        {
        //            TextBox text = (TextBox)i;
        //            PropertyInfo info = (typeof(Transport)).GetProperty(text.Name);
        //            if (info != null)
        //            {
        //                switch (info.PropertyType.Name)
        //                {
        //                    case "String":
        //                        text.Text = (string)info.GetValue(this, null);
        //                        break;
        //                    case "Int32":
        //                        text.Text = Convert.ToString(info.GetValue(this, null));
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //}
    }

    public class Route
    {
        public Route()
        {
            Stops = new List<Stop>();
        }
        public struct Stop
        {
            public string Name_, Street;
            public Stop(string Name, string Street)
            {
                this.Name_ = Name;
                this.Street = Street;
            }
        }
        public string Number { get; set; }
        public List<Stop> Stops { get; private set; } 
        public void addStop(string Name, string Street)
        {
            Stops.Add(new Stop(Name, Street));
        }
    }
}
