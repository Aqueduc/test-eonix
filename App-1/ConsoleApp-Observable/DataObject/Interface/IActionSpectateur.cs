using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DataObject
{
    public interface IActionSpectateur
    {
        public string Applaudir(Singe singe);
        public string Siffler(Singe singe);
    }
}
