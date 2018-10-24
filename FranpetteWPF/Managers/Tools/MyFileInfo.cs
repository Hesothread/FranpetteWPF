using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranpetteWPF.Managers.Tools
{
    class MyFileInfo
    {
        string _name;
        long _size;
        string _hash;
        string _last;

        public MyFileInfo(string name = "", int size = 0, string hash = "", string last = "")
        {
            _name = name;
            _size = size;
            _hash = hash;
            _last = last;
        }

        public string name { get; set; }
        public long size { get; set; }
        public string hash { get; set; }
        public string last { get; set; }
    }
}
