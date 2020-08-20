using System;

namespace Observer_events_
{
    class Program
    {
        static void Main(string[] args)
        {
            Observable observable = new Observable();
           
            Observer ekaterina = new Observer("Зорина Екатерина Владимировна", 751004, observable, 2);
            Observer alexey = new Observer("Иванов Алексей Викторович", 751005, observable, 0);
            Observer dmitry = new Observer("Петров Дмитрий Алексеевич", 753504, observable, 0, 1);

            observable.Certificate();  // 2
            ekaterina.Unsubscribe(observable, 2);
            observable.Certificate();

            observable.Expulsion();  // 0
            observable.Resit();  // 1

        }
    }
}
