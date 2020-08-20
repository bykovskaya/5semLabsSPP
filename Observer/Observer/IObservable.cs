using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    interface IObservable
    {
        void AddObserver(int eventNum, IObserver obs);
        void RemoveObserver(int eventNum, IObserver obs);
        void NotifyObservers(int eventNum);
    }
}
