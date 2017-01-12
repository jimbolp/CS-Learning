using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace Fina_DB_Test_Insert_From_Excel
{
    class FinaDB
    {
        static void Main(string[] args)
        {

            var testdb = new FinaUsersDBContext();
            var query = testdb.UserMasterDatas.Where(u => u.ID > 50).OrderBy(u => u.ID);

            Console.WriteLine(query.ToString());
            foreach (var row in query)
            {
                Console.WriteLine(row.ID + " - " + row.UserName + " -> "  + row.Email);
            }
           /* var xlApp = new Application();
            var xlWorkBook = xlApp.Workbooks.Open(@"E:\Documents\GitHub\CS-Learning\SQL\Entity Framework Tests\Fina DB Test Insert From Excel\bin\Debug\user_account_new.xlsx");
            var xlSheets = xlWorkBook.Worksheets;
            Worksheet xlSheet22 = new Worksheet();
            Worksheet xlSheet23 = new Worksheet();
            Worksheet xlSheet25 = new Worksheet();
            Worksheet xlSheet26 = new Worksheet();
            Worksheet xlSheetAD = new Worksheet();
            foreach (Worksheet ws in xlSheets)
            {
                if (ws.Name == "KSC22")
                    xlSheet22 = ws;
                else if (ws.Name == "KSC23")
                    xlSheet23 = ws;
                else if (ws.Name == "KSC25")
                    xlSheet25 = ws;
                else if (ws.Name == "KSC26")
                    xlSheet26 = ws;
                else if (ws.Name == "UsersAD")
                    xlSheetAD = ws;
            }
            Range ksc22Range = xlSheet22.UsedRange;
            Range ksc23Range = xlSheet23.UsedRange;
            Range ksc25Range = xlSheet25.UsedRange;
            Range ksc26Range = xlSheet26.UsedRange;
            List<Range> kscRanges = new List<Range>()
            {
                ksc22Range,
                ksc23Range,
                ksc25Range,
                ksc26Range
            };
            Range userADRange = xlSheetAD.UsedRange;

            var usersDB = new FinaUsersDBContext();
            
            //var masterData = usersDB.UserMasterDatas.ToList();

            int rowNumberADRange = userADRange.Rows.Count;
            Dictionary<string, string> fullNameDict = new Dictionary<string, string>();
            for (int i = 3; i <= rowNumberADRange; ++i)
            {
                string firstName = Convert.ToString((userADRange.Cells[i, 2] as Range).Value);
                string lastName = Convert.ToString((userADRange.Cells[i, 3] as Range).Value);
                string adUserName = Convert.ToString((userADRange.Cells[i, 6] as Range).Value);
                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && 
                    (!string.IsNullOrEmpty(adUserName) && adUserName != "-"))
                {
                    fullNameDict[firstName.Trim() + " " + lastName.Trim()] = adUserName;
                }
            }

            foreach (var user in usersDB.UserMasterDatas)
            {
                if (fullNameDict.ContainsKey(user.UserName))
                { 
                    //int userID = user.ID;
                    var newADUser = new ADUser()
                    {
                        UserID = user.ID,
                        ADName = fullNameDict[user.UserName]
                    };
                    usersDB.ADUsers.Add(newADUser);
                }
            }
            usersDB.SaveChanges();//*/

            /*foreach (var branch in kscRanges)
            {
                int rowNumber = branch.Rows.Count;
                for (int i = 2; i < rowNumber; ++i)
                {
                    string name = Convert.ToString((branch.Cells[i, 3] as Range).Value);
                    if (!string.IsNullOrEmpty(name) && fullNameList.Contains(name.Trim()))
                    {
                        int branchNo = 0;
                        if (int.TryParse(Convert.ToString((branch.Cells[i, 1] as Range).Value), out branchNo))
                        {
                            string userName = Convert.ToString((branch.Cells[i, 2] as Range).Value);
                            if (!string.IsNullOrEmpty(userName))
                            {
                                string fullName = Convert.ToString((branch.Cells[i, 3] as Range).Value);
                                if (!string.IsNullOrEmpty(fullName))
                                {
                                    string termID = Convert.ToString((branch.Cells[i, 5] as Range).Value);
                                    int uid = 0;
                                    if (!string.IsNullOrEmpty(termID) &&
                                        int.TryParse(Convert.ToString((branch.Cells[i, 6] as Range).Value), out uid))
                                    {
                                        string fcS = Convert.ToString((branch.Cells[i, 7] as Range).Value);
                                        bool fc = fcS == "yes";
                                        if (fc || fcS == "no")
                                        {
                                            //var newKSCUser = new KSCUser(branchNo, userName, fullName, termID, uid, fc);
                                            int userID = 0;;
                                            try
                                            {
                                                userID = usersDB.UserMasterDatas
                                                    .Where(u => u.UserName.Trim() == fullName.Trim())
                                                    .Select(u => u.ID).ToArray()[0];
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.Message + Environment.NewLine + e.StackTrace);
                                                break;
                                            }
                                            var kscUser = new KSC()
                                            {
                                                AllowFC = fc,
                                                BranchID = branchNo,
                                                UserName = userName,
                                                UserID = userID,
                                                TermID = termID,
                                                UID = uid
                                            };
                                            usersDB.KSCs.Add(kscUser);
                                            usersDB.SaveChanges();
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
            }


            /*Dictionary<string, string> namesAndEmails = new Dictionary<string, string>();
                for (int i = 3; i <= rowNumber; ++i)
                {
                    string firstName = Convert.ToString((userADRange.Cells[i, 2] as Range).Value);
                    string lastName = Convert.ToString((userADRange.Cells[i, 3] as Range).Value);
                    string email = Convert.ToString((userADRange.Cells[i, 7] as Range).Value);
                    string fullName = "";
                    if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                    {
                        fullName = firstName.Trim() + " " + lastName.Trim();
                    }
                    if (!string.IsNullOrEmpty(email))
                        namesAndEmails[fullName] = email.ToLower();
                }
                foreach (var user in usersDB.UserMasterDatas)
                {
                    if (namesAndEmails.ContainsKey(user.UserName) && (string.IsNullOrEmpty(user.Email) || user.Email == "-"))
                    {
                        user.Email = namesAndEmails[user.UserName];
                    }
                }
                usersDB.SaveChanges();
                /*for (int i = 2; i <= rowNumber; ++i)
                {
                    string name = (Convert.ToString((ksc26Range.Cells[i, 3] as Range).Value));
                    int branch = 0;
                    if (int.TryParse(Convert.ToString((ksc26Range.Cells[i, 1] as Range).Value), out branch))
                    {
                        if (!(masterData.Select(u => u.UserName).ToList()).Contains(name))
                        {
                            var newUser = new UserMasterData()
                            {
                                BranchID = branch,
                                UserName = name
                            };
                            usersDB.UserMasterDatas.Add(newUser);
                            usersDB.SaveChanges();
                        }
                    }
                }
            xlWorkBook.Close(false);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);//*/
        }

        public class KSCUser
        {
            public int Branch { get; set; }
            public string UserName { get; set; }
            public string FullName { get; set; }
            public string TermID { get; set; }
            public int UID { get; set; }
            public bool AllowFC { get; set; }

            public KSCUser(int branch, string userName, string fullName, string termID, int uid, bool fc)
            {
                Branch = branch;
                UserName = userName;
                FullName = fullName;
                TermID = termID;
                UID = uid;
                AllowFC = fc;
            }
        }
    }
}
