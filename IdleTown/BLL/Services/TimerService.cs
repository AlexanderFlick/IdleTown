namespace BLL.Services
{
    public interface ITimerService
    {
        void Start(int interval);
    }

    public class TimerService : ITimerService
    {
        public void Start(int interval)
        {
        }
    }
}