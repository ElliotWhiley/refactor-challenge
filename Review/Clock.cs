using System;

namespace Review
{
    public class Clock : IClock
    {
        public DateTime Now()
        {
            return DateTime.UtcNow;
        }

        [Obsolete("NowOld is deprecated, use Now instead to ensure dates are in UTC")]
        public DateTime NowOld()
        {
            return DateTime.Now;
        }

        public DateTime FifteenYearsAgo()
        {
            return Now().AddYears(-15);
        }
    }
}
