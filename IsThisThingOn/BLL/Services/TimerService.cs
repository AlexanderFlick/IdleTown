using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace BLL.Services
{
    public interface ITimerService
    {
        void Start(int interval);
    }
    public class TimerService : ITimerService
    {
        private static Timer timer;
        public void Start(int interval)
        {
            timer = new Timer();
            timer.Interval = 1000;
        }
    }
}
