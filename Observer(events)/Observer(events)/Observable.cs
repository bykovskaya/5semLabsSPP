using System;
using System.Collections.Generic;
using System.Text;

namespace Observer_events_
{
    class Observable
    {
        public delegate void EventHandler(int eventNum);
        public event EventHandler onExpulsion;
        public event EventHandler onResit;
        public event EventHandler onCertificate;

        public void Expulsion()
        {
            Console.WriteLine("Начало отчислений");
            onExpulsion?.Invoke(0);
        }

        public void Resit()
        {
            Console.WriteLine("Выдача ведомостичек");
            onResit?.Invoke(1);
        }

        public void Certificate()
        {
            Console.WriteLine("Выдача справок");
            onCertificate?.Invoke(2);
        }
    }
}
