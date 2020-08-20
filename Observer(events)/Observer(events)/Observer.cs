using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Observer_events_
{
    class Observer
    {
        private string name;
        private int group;

        public Observer(string name, int group, Observable obs, params int[] eventNum)
        {
            this.name = name;
            this.group = group;
            for (int i = 0; i < eventNum.Length; i++)
            {
                switch (eventNum[i])
                {
                    case 0:
                        obs.onExpulsion += Handler;
                        break;
                    case 1:
                        obs.onResit += Handler;
                        break;
                    case 2:
                        obs.onCertificate += Handler;
                        break;
                }
            }
        }

        public void Unsubscribe(Observable obs, params int[] eventNum)
        {
            for (int i = 0; i < eventNum.Length; i++)
            {
                switch (eventNum[i])
                {
                    case 0:
                        obs.onExpulsion -= Handler;
                        break;
                    case 1:
                        obs.onResit -= Handler;
                        break;
                    case 2:
                        obs.onCertificate -= Handler;
                        break;
                }
            }
        }

        public void Handler(int eventNum)
        {
            string eventName = "";
            switch (eventNum)
            {
                case 0:
                    eventName = "начало отчислений";
                    break;
                case 1:
                    eventName = "выдача ведомостичек";
                    break;
                case 2:
                    eventName = "выдача справок";
                    break;
            }

            string path = @"E:\5sem\СПП\Observer(events)\Observer(events)\file2.log";
            using (StreamWriter stream = new StreamWriter(path, true, Encoding.Default))
            {
                stream.WriteLine("ФИО: {0}, группа: {1}, событие: {2}", this.name, this.group, eventName);
            }
            
            Console.WriteLine("ФИО: {0}, группа: {1}, событие: {2}", this.name, this.group, eventName);
        }
    }
}
