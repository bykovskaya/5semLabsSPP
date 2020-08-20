using System;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            DeansOffice deansOffice = new DeansOffice();

            // 0 - отчисления
            // 1 - выдача ведомостичек
            // 2 - выдача справок
            Student ira = new Student("Быковская Ирина Вадимовна", 751004, deansOffice, 0);
            Student alexey = new Student("Иванов Алексей Викторович", 753504, deansOffice, 0);
            Student dmitry = new Student("Петров Дмитрий Иванович", 641301, deansOffice, 0);

            deansOffice.Expulsion();   // отчисления
            alexey.Unsubscribe(deansOffice, 0);
            deansOffice.Expulsion();

            deansOffice.Resit();     // ведомостички
            deansOffice.Certificate();    // справки
        }
    }
}
