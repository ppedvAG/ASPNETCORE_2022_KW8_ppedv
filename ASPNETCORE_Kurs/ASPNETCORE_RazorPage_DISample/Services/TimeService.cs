namespace ASPNETCORE_RazorPage_DISample.Services
{
    public class TimeService : ITimeService
    {
        private DateTime dateTime;

        public TimeService()
        {
            dateTime = DateTime.Now;
        }


        public string GetTime()
        {
            return dateTime.ToString();
        }
    }
}
