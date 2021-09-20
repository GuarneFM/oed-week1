using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerLibrary.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Given a date time round down to the closest quarter
        /// </summary> 
        /// <param name="dateTime">Base datetime object to round down</param>
        /// <returns>Rounded datetime to closes quarter</returns>
        public static DateTime RoundDown15Minutes(this DateTime dateTime) 
            => new (dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, (dateTime.Minute / 15) * 15, 0);

        /// <summary>
        /// Round up by minutes DateTime.Now.RoundUp(TimeSpan.FromMinutes(15))
        /// </summary>
        /// <param name="dateTime">Base datetime object to round up.</param>
        /// <param name="timeSpan">Timespan interval for rounding</param>
        /// <returns>Rounded datetime</returns>
        public static DateTime RoundUp(this DateTime dateTime, TimeSpan timeSpan) 
            => new ((dateTime.Ticks + timeSpan.Ticks - 1) / timeSpan.Ticks * timeSpan.Ticks, dateTime.Kind);

        /// <summary>
        /// Truncate to current hour
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime TruncateToHourStart(this DateTime dateTime) 
            => new (dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0);

        /// <summary>
        /// Truncate to current minute
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime TruncateToMinuteStart(this DateTime dateTime) 
            => new (dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0);

        /// <summary>
        /// Combine date and time
        /// </summary>
        /// <param name="day">Valid Initialized DateTime</param>
        /// <param name="time">Valid initialized TimeSpan</param>
        /// <returns></returns>
        public static DateTime At(this DateTime day, TimeSpan time) 
            => new DateTime(day.Year, day.Month, day.Day, 0, 0, 0).Add(time);

        /// <summary>
        /// Combine date and time
        /// </summary>
        /// <param name="day">Valid Initialized DateTime</param>
        /// <param name="time">Valid initialized TimeSpan</param>
        /// <returns></returns>
        public static DateTime And(this DateTime day, TimeSpan time) => day.Add(time);
    }
}
