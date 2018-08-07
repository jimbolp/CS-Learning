using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectedOrders
{
    public class LatestOrderTime
    {
        private string _maxOrderTime;
        public int CustomerNo { get; set; }
        public string Name { get; set; }
        public string DayOfWeek { get; set; }
        public int StartWorkTime {
            get
            {
                var dbName = Helper.GetBranch(CustomerNo.ToString()).dbName;

                switch (dbName)
                {
                    case "LibraSofia":
                        switch (DayOfWeek)
                        {
                            case "weekday":
                                return Properties.Settings.Default.SofiaWeekdayStart;
                            case "saturday":
                                return Properties.Settings.Default.SofiaSaturdayStart;
                            case "sunday":
                                return Properties.Settings.Default.SofiaSundayStart;
                            default:
                                return 0;
                        }
                    case "LibraBurgas":
                        switch (DayOfWeek)
                        {
                            case "weekday":
                                return Properties.Settings.Default.BurgasWeekdayStart;
                            case "saturday":
                                return Properties.Settings.Default.BurgasSaturdayStart;
                            case "sunday":
                                return Properties.Settings.Default.BurgasSundayStart;
                            default:
                                return 0;
                        }
                    case "LibraPlovdiv":
                        switch (DayOfWeek)
                        {
                            case "weekday":
                                return Properties.Settings.Default.PlovdivWeekdayStart;
                            case "saturday":
                                return Properties.Settings.Default.PlovdivSaturdayStart;
                            case "sunday":
                                return Properties.Settings.Default.PlovdivSundayStart;
                            default:
                                return 0;
                        }
                    case "LibraVarna":
                    case "LibraVelikoTyrnovo":
                        switch (DayOfWeek)
                        {
                            case "weekday":
                                return Properties.Settings.Default.VelikoTyrnovoWeekdayStart;
                            case "saturday":
                                return Properties.Settings.Default.VelikoTyrnovoSaturdayStart;
                            case "sunday":
                                return Properties.Settings.Default.VelikoTyrnovoSundayStart;
                            default:
                                return 0;
                        }
                    default:
                        return 0;
                }
            }
        }
        public string MaxWorkTime
        {
            get
            {
                var dbName = Helper.GetBranch(CustomerNo.ToString()).dbName;
                string time = "";
                
                switch (dbName)
                {
                    case "LibraSofia":
                        switch (DayOfWeek)
                        {
                            case "weekday":
                                time = DateTime.ParseExact(Properties.Settings.Default.SofiaWeekdayEnd.ToString(), "HHmm", CultureInfo.InvariantCulture).ToString("HHmm");
                                break;
                            case "saturday":
                                time = DateTime.ParseExact(Properties.Settings.Default.SofiaSaturdayEnd.ToString(), "HHmm", CultureInfo.InvariantCulture).ToString("HHmm");
                                break;
                            case "sunday":
                                time = DateTime.ParseExact(Properties.Settings.Default.SofiaSundayEnd.ToString(), "HHmm", CultureInfo.InvariantCulture).ToString("HHmm");
                                break;
                            default:
                                time = "";
                                break;

                        }
                        return time;
                    case "LibraBurgas":
                        switch (DayOfWeek)
                        {
                            case "weekday":
                                time = DateTime.ParseExact(Properties.Settings.Default.BurgasWeekdayEnd.ToString(), "HHmm", CultureInfo.InvariantCulture).ToString("HHmm");
                                break;
                            case "saturday":
                                time = DateTime.ParseExact(Properties.Settings.Default.BurgasSaturdayEnd.ToString(), "HHmm", CultureInfo.InvariantCulture).ToString("HHmm");
                                break;
                            case "sunday":
                                time = DateTime.ParseExact(Properties.Settings.Default.BurgasSundayEnd.ToString(), "HHmm", CultureInfo.InvariantCulture).ToString("HHmm");
                                break;
                            default:
                                time = "";
                                break;

                        }
                        return time;
                    case "LibraPlovdiv":
                        switch (DayOfWeek)
                        {
                            case "weekday":
                                time = DateTime.ParseExact(Properties.Settings.Default.PlovdivWeekdayEnd.ToString(), "HHmm", CultureInfo.InvariantCulture).ToString("HHmm");
                                break;
                            case "saturday":
                                time = DateTime.ParseExact(Properties.Settings.Default.PlovdivSaturdayEnd.ToString(), "HHmm", CultureInfo.InvariantCulture).ToString("HHmm");
                                break;
                            case "sunday":
                                time = DateTime.ParseExact(Properties.Settings.Default.PlovdivSundayEnd.ToString(), "HHmm", CultureInfo.InvariantCulture).ToString("HHmm");
                                break;
                            default:
                                time = "";
                                break;

                        }
                        return time;
                    case "LibraVarna":
                    case "LibraVelikoTyrnovo":
                        switch (DayOfWeek)
                        {
                            case "weekday":
                                time = DateTime.ParseExact(Properties.Settings.Default.VelikoTyrnovoWeekdayEnd.ToString(), "HHmm", CultureInfo.InvariantCulture).ToString("HHmm");
                                break;
                            case "saturday":
                                time = DateTime.ParseExact(Properties.Settings.Default.VelikoTyrnovoSaturdayEnd.ToString(), "HHmm", CultureInfo.InvariantCulture).ToString("HHmm");
                                break;
                            case "sunday":
                                time = DateTime.ParseExact(Properties.Settings.Default.VelikoTyrnovoSundayEnd.ToString(), "HHmm", CultureInfo.InvariantCulture).ToString("HHmm");
                                break;
                            default:
                                time = "";
                                break;
                        }
                        return time;
                    default:
                        return "";
                }
            }
        }
        public string MaxOrderTime
        {
            get
            {
                if (Int32.TryParse(_maxOrderTime, out int time))
                {
                    return _maxOrderTime.Substring(0, 2) + ":" + _maxOrderTime.Substring(2, 2);
                }
                else
                    return _maxOrderTime;
            }
            set
            {
                _maxOrderTime = value;
            }
        }
        public string TourIDs {
            get
            {
                string tours = "";
                List<string> tempList = Helper.GetToursFromDb(CustomerNo).Select(t => string.Format("{0:000000}", t)).ToList();
                foreach (string t in tempList)
                {
                    tours += t + "; ";
                }
                return tours;
            }
        }
        public string MinutesBeforeTour {
            get
            {
                string val = "";
                if (DateTime.TryParseExact(MaxWorkTime, "HHmm", CultureInfo.InvariantCulture,DateTimeStyles.None, out DateTime maxTime))
                {
                    string[] Tours = TourIDs.Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var tour in Tours)
                    {
                        if (Int32.TryParse(tour.Substring(2, 4),  out int tourTime))
                        {
                            if (tourTime < 2400)
                                continue;
                            int tourMinutes = (tourTime % 100) + (((tourTime % 10000) / 100) * 60);

                            int maxOrderTime = int.Parse(MaxOrderTime.Replace(":", ""));
                            int maxWorkTime = int.Parse(MaxWorkTime);
                            int maxTimeInMinutes = 0;
                            if (maxOrderTime > maxWorkTime || maxOrderTime <= StartWorkTime)
                            {
                                maxTimeInMinutes = (maxWorkTime % 100) + (((maxWorkTime % 10000) / 100) * 60);
                            }
                            else
                            {
                                maxTimeInMinutes = (maxOrderTime % 100) + (((maxOrderTime % 10000) / 100) * 60);
                            }

                            if(tourMinutes > maxTimeInMinutes)
                                val += tour + " => " + (tourMinutes - maxTimeInMinutes) + "; ";
                        }
                    }
                }
                return val;
            }
        }
        
    }
}
