using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.DataObject.Observable
{
    public interface ISubject
    {
        public void Attach(IObserver obs);
        public void Detach(IObserver obs);
        public void Notify(Tour tour,ISubject subject);
    }
}
