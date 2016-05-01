using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AspCourseProject.WebUI.Helpers
{
    public class WeekProvider: IWeekProvider
    {
        public int GetWeek()
        {
            var calendar = new GregorianCalendar();
            return calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
        }
    }
}