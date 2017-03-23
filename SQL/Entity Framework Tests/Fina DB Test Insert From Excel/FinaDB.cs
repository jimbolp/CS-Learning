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

            var db = new FinaUsersDBContext();
            //var query = testdb.UserMasterDatas.Where(u => u.ID > 50).OrderBy(u => u.ID);

            /*Console.WriteLine(query.ToString());
            foreach (var row in query)
            {
                Console.WriteLine(row.ID + " - " + row.UserName + " -> "  + row.Email);
            }//*/

            var xlApp = new Application();
            var xlWorkBook = xlApp.Workbooks.Open(@"E:\Documents\GitHub\CS-Learning\SQL\Entity Framework Tests\Fina DB Test Insert From Excel\bin\Debug\user_account_new.xlsx");
            var xlSheets = xlWorkBook.Worksheets;
            /*Worksheet xlSheet22 = new Worksheet();
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
            Range ksc26Range = xlSheet26.UsedRange;//*/
            Range users = null;
            foreach (Worksheet sheet in xlSheets)
            {
                if (sheet.Name == "UsersAD")
                {
                    Range startCell = sheet.Cells[1, 1];
                    Range endCell = sheet.Cells[362, 17];
                    users = sheet.Range[startCell, endCell];
                }
            }
            
            //var usersDB = new FinaUsersDBContext();
            //
            //var masterData = usersDB.UserMasterDatas.ToList();

            int rowNumberADRange = users.Rows.Count;
            Dictionary<string, string> fullNameDict = new Dictionary<string, string>();
            
            for (int i = 2; i <= rowNumberADRange; ++i)
            {
                string fullName = Convert.ToString((users.Cells[i, 4] as Range).Value);
                //string firstName = Convert.ToString((users.Cells[i, 2] as Range).Value);
                //string lastName = Convert.ToString((users.Cells[i, 3] as Range).Value);
                
                string adUserName = Convert.ToString((users.Cells[i, 7] as Range).Value);
                string position = Convert.ToString((users.Cells[i, 5] as Range).Value);
                if (string.IsNullOrEmpty(position) || !db.Positions.Any(p => p.Position1 == position))
                {
                    continue;
                }
                string depot = Convert.ToString((users.Cells[i, 6] as Range).Value);
                if (depot == "Варна")
                    continue;
                string email = Convert.ToString((users.Cells[i, 8] as Range).Value);
                string pharmos = Convert.ToString((users.Cells[i, 11] as Range).Value);
                string giValue = Convert.ToString((users.Cells[i, 14] as Range).Value);
                string uadmName = Convert.ToString((users.Cells[i, 16] as Range).Value);
                
                bool haveGi = false;
                if (string.IsNullOrEmpty(giValue))
                    haveGi = false;
                else
                {
                    if (giValue.Length > 2)
                        haveGi = true;
                }

                string purchaseValue = Convert.ToString((users.Cells[i, 13] as Range).Value);
                bool havePurchase = false;
                if (string.IsNullOrEmpty(purchaseValue))
                    havePurchase = false;
                else
                {
                    if (purchaseValue.Length > 2)
                        havePurchase = true;
                }

                string tenderValue = Convert.ToString((users.Cells[i, 15] as Range).Value);
                bool haveTender = false;
                if (string.IsNullOrEmpty(tenderValue))
                    haveTender = false;
                else
                {
                    if (tenderValue.Length > 2)
                        haveTender = true;
                }

                if (!db.UserMasterDatas.Any(u => u.UserName == fullName))
                {
                    var newUser = new UserMasterData()
                    {
                        UserName = fullName,
                        BranchID = db.Branches.Where(b => b.BranchName == depot).Select(b => b.ID).FirstOrDefault(),
                        Email = email,
                        PharmosUserName = pharmos,
                        UADMUserName = uadmName,
                        PositionID = db.Positions.Where(p => p.Position1 == position).Select(p => p.ID).FirstOrDefault(),
                        GI = haveGi,
                        Purchase = havePurchase,
                        Tender = haveTender,
                        Active = true
                    };
                    db.UserMasterDatas.Add(newUser);
                    db.SaveChanges();
                }

                //If user with tha same name exists in the database check if
                //there isn't anything else different (for Drivers and Error Station users)
                if (db.UserMasterDatas.Any(u => u.UserName == fullName))
                {
                    /*foreach (var user in db.UserMasterDatas.Where(u => u.UserName == fullName))
                    {
                        int currentUserID = user.ID;
                        int currentUserPosID = user.PositionID??0;
                        if (string.IsNullOrEmpty(adUserName))
                        {
                            if (user.BranchID ==
                                db.Branches.Where(b => b.BranchName == depot).Select(b => b.ID).FirstOrDefault())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (
                                db.ADUsers.Where(a => a.UserID == currentUserID).Select(a => a.ADName).FirstOrDefault() !=
                                adUserName)
                            {
                                var newUser = new UserMasterData()
                                {
                                    UserName = fullName,
                                    BranchID = db.Branches.Where(b => b.BranchName == depot).Select(b => b.ID).FirstOrDefault(),
                                    Email = email,
                                    PharmosUserName = pharmos,
                                    UADMUserName = uadmName,
                                    PositionID = db.Positions.Where(p => p.Position1 == position).Select(p => p.ID).FirstOrDefault(),
                                    GI = haveGi,
                                    Purchase = havePurchase,
                                    Tender = haveTender,
                                    Active = true
                                };
                                db.UserMasterDatas.Add(newUser);
                                db.SaveChanges();
                            }
                        }
                        
                    }//*/
                    


                    //Add ADUser....
                    var userID = db.UserMasterDatas.Where(u => u.UserName == fullName).Select(u => u.ID).FirstOrDefault();
                    if (!db.ADUsers.Any(a => a.UserID == userID))
                    {
                        if (string.IsNullOrEmpty(adUserName))
                            continue;
                        if (adUserName.Length < 3)
                            continue;
                        var adUser = new ADUser()
                        {
                            UserID = userID,
                            ADName = adUserName
                        };
                        db.ADUsers.Add(adUser);
                        db.SaveChanges();
                    }
                }
            }

            /*foreach (var user in db.UserMasterDatas)
            {
                if (fullNameDict.ContainsKey(user.UserName))
                { 
                    //int userID = user.ID;
                    var newADUser = new ADUser()
                    {
                        UserID = user.ID,
                        ADName = fullNameDict[user.UserName]
                    };
                    db.ADUsers.Add(newADUser);
                }
            }
            db.SaveChanges();//*/

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
                }//*/
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
