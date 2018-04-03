using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Microsoft.SqlServer;
class Attributes
{
    static void Main(string[] args)
    {
        string input = null;
        try
        {
            input = Console.ReadLine().ToLower().Trim();
            if ("" == input)
                throw new NullReferenceException("Input is empty");
        }
        catch (NullReferenceException e)
        {
            if (File.Exists("log.txt"))
            {
                File.AppendAllText("log.txt",
                    $"{Environment.NewLine}{new string('-', 60)}{Environment.NewLine}\t{DateTime.Now}{Environment.NewLine}{e.Message}{Environment.NewLine}" +
                    $"{e.StackTrace}");
            }
            else
            {
                File.WriteAllText("log.txt",
                    $"{new string('-', 60)}{Environment.NewLine}\t{DateTime.Now}{Environment.NewLine}{e.Message}{Environment.NewLine}" +
                    $"{e.StackTrace}");
            }
        }
        catch (Exception e)
        {
            if (File.Exists("log.txt"))
            {
                File.AppendAllText("log.txt",
                    $"{Environment.NewLine}{new string('-', 60)}{Environment.NewLine}\t{DateTime.Now}{Environment.NewLine}{e.Message}{Environment.NewLine}" +
                    $"{e.StackTrace}");
            }
            else
            {
                File.WriteAllText("log.txt",
                    $"{new string('-', 60)}{Environment.NewLine}\t{DateTime.Now}{Environment.NewLine}{e.Message}{Environment.NewLine}" +
                    $"{e.StackTrace}");
            }
        }
        char[] alphabet = new char[26];
        for (int i = 'a', j = 0; i <= 'z'; ++j, ++i)
        {
            alphabet[j] = (char)i;
        }
        Dictionary<char, int> alpha = new Dictionary<char, int>();
        foreach (var letter in alphabet)
        {
            alpha[letter] = Array.IndexOf(alphabet,letter);
        }
        foreach (var letter in input)
        {
            Console.WriteLine($"{letter} -> {alpha[letter]}");
            
        }//*/
        string[] str = new string[5];
        List<int> list = new List<int>();
        
        Assembly assem = Assembly.Load("Attributes");
        foreach (Type t in assem.GetTypes())
        {
            foreach (PropertyInfo pi in t.GetProperties())
            {
                foreach (Attribute att in pi.GetCustomAttributes(false))
                {
                    DBColumn dbc = att as DBColumn;
                    if (null != dbc)
                    {
                        //if(dbc.ColumnName == "student_id" || dbc.ColumnName == "first_name" || 
                          //  dbc.ColumnName == "last_name" || dbc.ColumnName == "address" || dbc.ColumnName == "num_courses")
                            Console.WriteLine($"{dbc.ColumnName} -> {dbc.ColumnType} -> {dbc.Nullable}");
                    }
                }
            }
        }
        Student Pesho = new Student();
        Pharmacy Phoenix = new Pharmacy();
        Console.WriteLine($"{GetQualifiedTableName(Pesho)}\n{GetQualifiedTableName(Phoenix)}");
    }

    public static int blq(int a, int b)
    {
        return ((a < b) ? -1 : (a > b) ? 1 : 0);
    }


    public static string GetQualifiedTableName(object obj)
    {
        Type t = obj.GetType();
        foreach (Attribute att in t.GetCustomAttributes(false))
        {
            DBTable dta = att as DBTable;
            if (null != dta)
            {
                return dta.TableOwner + "." + dta.TableName;
            }
        }
        throw new Exception("The DBTable attribute must be specified for the SQL generator to act on the object.");
        
    }

    public string GenerateSQLInsertStatement(object ob)
    {
        string strSQLStatement = "INSERT INTO";
        //get the type
        Type t = ob.GetType();
        //get the table name of the table we're inserting into
        string strTableName = GetQualifiedTableName(ob);
        // the statement me want to generate here is
        // INSER INTO TABLE_NAME(COL1,COL2) VALUES('1',3958)
        strSQLStatement += strTableName;
        strSQLStatement += " (";
        strSQLStatement += GetColumnList(ob) + ") VALUES (";
        strSQLStatement += GetValueList(ob) + ")";
        return strSQLStatement;
    }

    private string GetValueList(object obj)
    {
        Type t = obj.GetType();
        string strValueList = "";
        bool FirstColumn = true;
        foreach (PropertyInfo p in t.GetProperties())
        {
            foreach (Attribute att in p.GetCustomAttributes(false))
            {
                DBColumn dca = att as DBColumn;
                if (null != dca)
                {
                    // if this is not the first column we 
                    // have hit, then we need to preceed 
                    // the column with a comma.
                    if (!FirstColumn)
                    {
                        strValueList += ",";
                    }
                    else
                    {
                        FirstColumn = false;
                    }
                    // this sample code assumes properties 
                    // are not collecections of objects.
                    // this dummy array of objects is 
                    // required to satifsy the GetValue
                    // method.
                    object []objRetVal = new Object[0];
                    // append the value to the list
                    strValueList += "'" + p.GetValue(obj, objRetVal).ToString() + "'";
                }
            }
        }
        // return the list of columns.
        return strValueList;
    }

    private string GetColumnList(object obj)
    {
        Type t = obj.GetType();
        string strColumnList = "";
        bool FirstColumn = true;
        foreach (PropertyInfo p in t.GetProperties())
        {
            foreach (Attribute att in p.GetCustomAttributes(false))
            {
                DBColumn dca = att as DBColumn;
                if (null != dca)
                {
                    // if this is not the first column we 
                    // have hit, then we need to preceed 
                    // the column with a comma.
                    if (!FirstColumn)
                    {
                        strColumnList += ",";
                    }
                    else
                    {
                        FirstColumn = false;
                    }
                    // this sample code assumes properties 
                    // are not collecections of objects.
                    // this dummy array of objects is 
                    // required to satifsy the GetValue
                    // method.
                    //object[] objRetVal = new Object[0];
                    // append the column to the list
                    strColumnList += dca.ColumnName;
                }
            }
        }
        // return the list of columns.
        return strColumnList; ;
    }

    [AttributeUsage(AttributeTargets.Class, 
        AllowMultiple = false, Inherited = true)]
    public class DBTable : Attribute
    {
        protected string _tableName = "";
        protected string _tableOwner = "";

        public DBTable(string tableName, string tableOwner)
        {
            TableName = tableName;
            TableOwner = tableOwner;
        }

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        public string TableOwner
        {
            get { return _tableOwner; }
            set { _tableOwner = value; }
        }
    }

    [AttributeUsage(AttributeTargets.Property,
        AllowMultiple = false, Inherited = true)]
    public class DBColumn : Attribute
    {
        protected string _columnName = "";
        protected DbType _columnType = DbType.AnsiString;
        protected bool _nullable;

        public DBColumn(string columnName, DbType columnType, bool nullable)
        {
            ColumnName = columnName;
            ColumnType = columnType;
            Nullable = nullable;
        }

        public bool Nullable
        {
            get { return _nullable; }
            set { _nullable = value; }
        }

        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }

        public DbType ColumnType
        {
            get { return _columnType; }
            set { _columnType = value; }
        }
    }
    [AttributeUsage(AttributeTargets.Property,
        AllowMultiple = false, Inherited = true)]
    public class DBPrimaryKeyField : Attribute
    {
        protected string _columnName = "";
        protected DbType _columnType = DbType.AnsiString;

        public DBPrimaryKeyField(string columnName, DbType columnType)
        {
            ColumnName = columnName;
            ColumnType = columnType;
        }

        public DbType ColumnType
        {
            get { return _columnType; }
            set { _columnType = value; }
        }

        public string ColumnName
        {
            get { return _columnName; }
            set { _columnName = value; }
        }
    }
    
    [DBTable("Student", "dbo")]
    public class Student
    {
        private string _id; // id of the student
        private string _firstName; // first name
        private string _lastName; // last name
        private string _address; // address
        private int _numCourses; // number of courses

        [DBPrimaryKeyField("StudentID", DbType.String)]
        [DBColumn("student_id", DbType.Guid, false)]
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        [DBColumn("first_name", DbType.String, false)]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [DBColumn("last_name", DbType.String, false)]
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        [DBColumn("address", DbType.String, true)]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        [BugFixDetails("2", "Pesho", "promqna v imeto")]
        [DBColumn("num_courses", DbType.Int32, true)]
        public int NumberOfCourses
        {
            get { return _numCourses; }
            set { _numCourses = value; }
        }

    }

    [AttributeUsage(AttributeTargets.All,
        AllowMultiple = true, Inherited = true)]
    public class BugFixDetails : Attribute
    {
        protected string _issueID;
        protected string _programmerName;
        protected string _description;

        public string IssueID
        {
            get { return _issueID; }
            set { _issueID = value; }
        }

        public string ProgrammerName
        {
            get { return _programmerName; }
            set { _programmerName = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public BugFixDetails(string issueID, string programmerName, string description)
        {
            IssueID = issueID;
            ProgrammerName = programmerName;
            Description = description;
        }
    }

    [DBTable("Pharmacy", "dbo")]
    public class Pharmacy
    {
        private string _id;
        private string _articleName;
        private double _price;
        private string _description;

        [DBPrimaryKeyField("Article_ID", DbType.String)]
        [DBColumn("article_id", DbType.Guid, false)]
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        [DBColumn("article_name", DbType.String, false)]
        public string ArticleName
        {
            get { return _articleName; }
            set { _articleName = value; }
        }

        [DBColumn("price", DbType.UInt32, false)]
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        [DBColumn("description", DbType.String, true)]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

    }
    
}

