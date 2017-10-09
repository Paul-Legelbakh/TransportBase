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
        public Transport()
        {
            ID = new Random().Next();
            Trans = "NULL";
        }
        public int ID { set; get; }
        public TransType Type { get; set; }
        public string Trans { get; set; }
        public Route CurrentRoute { get; set; }
        public Route.Stop Stop { get; set; }
    }

    public class Route
    {
        public Route()
        {
            Number = "NULL";
            ID = new Random().Next();
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
        };
        public int ID { set; get; }
        public string Number { get; set; }
        public List<Stop> Stops { get; private set; } 
        public void addStop(string Name, string Street)
        {
            Stops.Add(new Stop(Name, Street));
        }
    }
}
