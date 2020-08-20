using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Observer
{
    class Student : IObserver
    {
        private string name;
        private int eventNum, group;
        IObservable DeansOffice;

        public Student(string name, int group, IObservable obs, params int[] eventNum)
        {
            this.name = name;
            this.group = group;
            DeansOffice = obs;
            for (int i = 0; i < eventNum.Length; i++)
            {
                if (eventNum[i] >= 0 && eventNum[i] < 3)
                {
                    this.eventNum = eventNum[i];
                    DeansOffice.AddObserver(this.eventNum, this);
                }
            }
        }

        public void Unsubscribe(IObservable obs, params int[] eventNum)
        {
            DeansOffice = obs;
            for (int i = 0; i < eventNum.Length; i++)
            {
                if (eventNum[i] >= 0 && eventNum[i] < 3)
                {
                    this.eventNum = eventNum[i];
                    DeansOffice.RemoveObserver(this.eventNum, this);
                }
            }
        }

        public void Update(string info)
        {
            string path = @"E:\5sem\СПП\Observer\Observer\file1.log";
            using (StreamWriter stream = new StreamWriter(path, true, Encoding.Default))
            {
                stream.WriteLine("ФИО: {0}, группа: {1}, событие: {2}", this.name, this.group, info);
            }
            Console.WriteLine("ФИО: {0}, группа: {1}, событие: {2}", this.name, this.group, info);
        }
    }
}
