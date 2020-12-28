using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab5
{
    [Serializable]
    public class ToDo
    {
        public string[] Title { get; set; }
        public bool[] IsDone { get; set; }
        public ToDo(string[] Title, bool[] IsDone)
        {
            this.Title = Title;
            this.IsDone = IsDone;
        }
        public ToDo()
        {
            this.Title = null;
            this.IsDone = null;
        }

    }
}
