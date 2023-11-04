using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DataObject.Observable
{
    public interface IObserver
    {
        public void Update(Tour tour,ISubject subject);
    }
}
