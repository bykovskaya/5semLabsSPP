using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    class DeansOffice : IObservable
    {
        // 0 - список на отчисление
        // 1 - список на ведомостички
        // 2 - список на выдачу справок
        List<IObserver>[] observers = new List<IObserver>[3];
        string info;

        public DeansOffice()
        {
            for (int i = 0; i < observers.Length; i++)
            {
                observers[i] = new List<IObserver>();
            }
        }

        public void AddObserver(int eventNum, IObserver obs)
        {
            observers[eventNum].Add(obs);
        }
        public void RemoveObserver(int eventNum, IObserver obs)
        {
            observers[eventNum].Remove(obs);
        }
        public void NotifyObservers(int eventNum)
        {
            foreach (IObserver observer in observers[eventNum])
            {
                observer.Update(info);
            }
        }

        // Отчисления
        public void Expulsion()
        {
            info = "начало отчислений";
            Console.WriteLine("Начало отчислений");
            NotifyObservers(0);
        }

        // Пересдачи
        public void Resit()
        {
            info = "выдача ведомостичек";
            Console.WriteLine("Выдача ведомостичек");
            NotifyObservers(1);
        }

        // Справки
        public void Certificate()
        {
            info = "выдача справок";
            Console.WriteLine("Выдача справок");
            NotifyObservers(2);
        }
    }
}
