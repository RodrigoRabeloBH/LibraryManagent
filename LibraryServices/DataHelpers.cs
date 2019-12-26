using LibraryData.Models;
using System;
using System.Collections.Generic;

namespace LibraryServices
{
    public class DataHelpers
    {
        public static List<string> HumanizeBizHours(IEnumerable<BranchHours> branchHours)
        {
            var hours = new List<string>();

            foreach (var time in branchHours)
            {
                string day = HumanizeDay(time.DayOfWeek);
                string openTime = HumanizeTime(time.OpenTime);
                string closeTime = HumanizeTime(time.CloseTime);

                string timeEntry = $"{day} {openTime} to {closeTime}";
                hours.Add(timeEntry);
            }
            return hours;
        }

        public static string HumanizeDay(int dayOfWeek)
        {
            return Enum.GetName(typeof(DayOfWeek), dayOfWeek);
        }
        public static string HumanizeTime(int time)
        {
            return TimeSpan.FromHours(time).ToString("hh':'mm");
        }
    }
}
