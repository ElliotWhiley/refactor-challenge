using System;

namespace Review
{
    public interface IClock
    {
        DateTime Now();
        [Obsolete("NowOld is deprecated, use Now instead to ensure dates are in UTC")]
        DateTime NowOld();
        DateTime FifteenYearsAgo();
    }
}
