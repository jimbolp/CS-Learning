using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectedOrders
{
    public static class Helper
    {
        private const string connectionString = @"data source=DENU00CL0076\CYRGEN;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;";
        private static DbContext db = new DbContext(connectionString);
        public static (bool isFound, string dbName, int customerNo) GetBranch(string cust)
        {
            if (cust.Trim().Length >= 6)
            {
                if (Int32.TryParse(cust.Substring(0, 6), out int customerNo))
                {
                    if (customerNo > 200000 && customerNo < 300000)
                        return (true, "LibraSofia", customerNo);

                    else if (customerNo > 300000 && customerNo < 400000)
                        return (true, "LibraBurgas", customerNo);

                    else if (customerNo > 400000 && customerNo < 500000)
                        return (true, "LibraVarna", customerNo);

                    else if (customerNo > 500000 && customerNo < 600000)
                        return (true, "LibraPlovdiv", customerNo);

                    else if (customerNo > 700000 && customerNo < 800000)
                        return (true, "LibraVelikoTyrnovo", customerNo);
                    else
                        return (false, "", 0);
                }
                else
                    return (false, "", 0);
            }
            else
                return (false, "", 0);
        }
        public static List<int> GetToursFromDb(int customerID)
        {
            string dbName = GetBranch(customerID.ToString()).dbName;
            string query = $"select ID =                                                                    "
                         + $"case                                                                           "
                         + $"	when right(id,4) <= 900                                                     "
                         + $"       then concat(left(id, len(cast(id as int)) - 4), (2400 + right(id,4)))   "
                         + $"	when right(id,4) > 900 then id                                              "
                         + $"end                                                                            "
                         + $"from {dbName}.dbo.[Route] with(nolock)                                         "
                         + $"where recid in (                                                               "
                         + $"select RouteID from {dbName}.dbo.CustomerRoute with(nolock)                    "
                         + $"where CustomerID = {customerID / 10})                                          ";
            return db.Database.SqlQuery<int>(query).ToList(); 
        }

        public static List<LatestOrderTime> GetResultFromDb(string dbName, int customerNo)
        {
            var dateToFrom = GetDateIDs();
            string query = $"select s.Customerno, s.[Name], DayOfWeek, Max(maxOrderTime) 'MaxOrderTime' from                      "
                            + $" (                                                                                                "
                            + $"     select                                                                                       "
                            + $"         DayOfWeek =                                                                              "
                            + $"            case                                                                                  "
                            + $"             when DATEPART(dw, LibraCentral.dbo.fnDate(DocumentDateID)) = 1 then 'sunday'         "
                            + $"             when DATEPART(dw, LibraCentral.dbo.fnDate(DocumentDateID)) = 7 then 'saturday'       "
                            + $"            else 'weekday'                                                                        "
                            + $"            end,                                                                                  "
                            + $"         Max(std.OrderEndTime) as MaxOrderTime, std.CustomerNo, c.[Name]                          "
                            + $"     from LibraImport.dbo.PHARMOS_SalesTransactionData std with (nolock)                          "
                            + $"     left join {dbName}.dbo.Customer c on c.ID  = (std.Customerno /10)                            "
                            + $"     where std.DocumentDateID between {dateToFrom.dateFrom} and {dateToFrom.dateTo}               "
                            + $"         and std.CustomerNo = {ControlDigit(customerNo)}                                          "
                            + $"     group by DATEPART(dw, LibraCentral.dbo.fnDate(std.DocumentDateID)), std.CustomerNo, c.[Name] "
                            + $" ) as s                                                                                           "
                            + $" group by s.customerno, s.[Name], DayOfWeek                                                       "
                            + $" order by 1,3                                                                                     ";
            return db.Database.SqlQuery<LatestOrderTime>(query).ToList();
        }

        private static (string dateFrom, string dateTo) GetDateIDs()
        {
            DateTime from = DateTime.Now.AddMonths(-1);
            DateTime to = DateTime.Now;
            return (from.ToString("yyyyMMdd"), to.ToString("yyyyMMdd"));
        }

        private static string ControlDigit(int customerNo)
        {
            int result =
                7 * ((customerNo / 1) % 10) +
                6 * ((customerNo / 10) % 10) +
                5 * ((customerNo / 100) % 10) +
                4 * ((customerNo / 1000) % 10) +
                3 * ((customerNo / 10000) % 10) +
                2 * ((customerNo / 100000) % 10);
            if ((result % 11) == 10)
                result = customerNo * 10 + 0;
            else
                result = customerNo * 10 + (result % 11);
            return result.ToString();
        }
    }
}
