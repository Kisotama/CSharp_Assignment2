using Quan.Support_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan.DesignPartten_Classes
{
    public class TeacherMenu : MenuInterface
    {
        string SelectedItem;
        string[] _activities;
        string _personid = Program.sPersonid; // Teacher's code got after loging 
        DataTable _dsStudent;
        DataTable _dsCourse;
        DataTable _dsAttend;
        public string p_personid
        {
            set { _personid = value; }
        }
        public void m_findstudent()
        {
            int Width = 80;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("FINDING STUDENT");
            Console.ForegroundColor = ConsoleColor.White;
            COLE Ole = new COLE();
            DataTable dt = Ole.m_liststudent();
            Console.Write("Student id: ");
            string studentid = Console.ReadLine();
            if (!string.IsNullOrEmpty(studentid))
            {
                DataRow[] drs = dt.Select("student_id='" + studentid + "'", "");
                if (drs.Length > 0)
                {
                    string _gen = drs[0]["gender"].ToString() == "M" ? "Male" : "Female";

                    //-----------------------------------------------------------
                    Program.DisplayHeader(80, "Student Information ");
                    string s = "";
                    string item = "║ " + "Code: " + drs[0]["student_id"];
                    s += item + new string(' ', Width - item.Length + 1) + "║" + "\n";
                    item = "║ " + "Fullname: " + drs[0]["studentname"];
                    s += item + new string(' ', Width - item.Length + 1) + "║" + "\n";
                    item = "║ " + "Gender: " + _gen;
                    s += item + new string(' ', Width - item.Length + 1) + "║" + "\n";
                    item = "║ " + "Birthdate: " + drs[0]["dateofbirth"];
                    s += item + new string(' ', Width - item.Length + 1) + "║" + "\n";
                    item = "║ " + "Address: " + drs[0]["Address"];
                    s += item + new string(' ', Width - item.Length + 1) + "║" + "\n";
                    Console.Write(s);
                    Program.DisplayFooter(80);
                    //-----------------------------------------------------------

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This student does not exist!");
                }
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.ReadLine();
        }
        public void m_listattendant(int Width)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LISTING ATTENDANT");
            Console.ForegroundColor = ConsoleColor.White;
            COLE Ole = new COLE();
            DataTable dt = Ole.m_listattendant(_personid);
            _activities = new string[dt.Rows.Count];
            int order = 0;
            foreach (DataRow dr in dt.Rows)
            {
                _activities[order++] = dr["course_id"].ToString() + " " + dr["coursename"].ToString() + " " + dr["student_id"].ToString() + " " + dr["studentname"].ToString() + " " + dr["teacher_id"].ToString() + " " + dr["teachername"].ToString() + " " + dr["Status"] + " " + dr["grade"];
            }
            int Height = _activities.Length;

            //-----------------------------------------------------------
            Program.DisplayHeader(Width, " Attendants List  ");
            string s = "";
            foreach (string stext in _activities)
            {
                string item = "║ " + stext;
                s += item + new string(' ', Width - item.Length + 1) + "║" + "\n";
            }
            Console.Write(s);
            Program.DisplayFooter(Width);
            //-----------------------------------------------------------

            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void m_viewrecord()
        {
            m_listattendant(80);
            Console.ReadLine();
        }
        public void m_updatestatus()
        {
            CRecord oRec = new CRecord();
            Console.ForegroundColor = ConsoleColor.Green;
            m_listattendant(80);
            Console.WriteLine("UPDATE INFORMATION");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Course ID: ");
            string _course = Console.ReadLine();
            if (!string.IsNullOrEmpty(_course))
            {
                DataRow[] drs = _dsCourse.Select("Course_id='" + _course + "'");
                if (drs.Length > 0)
                {
                    Console.Write("Student id: ");
                    string _student = Console.ReadLine();
                    if (!string.IsNullOrEmpty(_student))
                    {
                        DataRow[] dr1s = _dsStudent.Select("Student_id='" + _student + "'");
                        if (dr1s.Length > 0)
                        {
                            char _status;
                            do
                            {
                                Console.Write("Attendant Status (P/A)?");
                                _status = Console.ReadKey().KeyChar;
                                Console.WriteLine();
                            } while (Program.sStatus.IndexOf(_status.ToString().ToUpper()) == -1);
                            oRec.m_getattendid(_course, _personid, _student);
                            oRec.p_status = _status.ToString();
                            oRec.m_updatestatus();
                            Console.WriteLine();
                            Console.WriteLine("Update Record!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("This student does not exist !");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("This course does not exist !");
                        Console.ReadLine();
                    }
                }
            }
        }
        public void m_updategrade()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            CRecord oRec = new CRecord();
            m_listattendant(80);
            Console.WriteLine("UPDATE INFORMATION");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Course ID: ");
            string _course = Console.ReadLine();
            if (!string.IsNullOrEmpty(_course))
            {
                DataRow[] drs = _dsCourse.Select("Course_id='" + _course + "'");
                if (drs.Length > 0)
                {
                    Console.Write("Student id: ");
                    string _student = Console.ReadLine();
                    if (!string.IsNullOrEmpty(_student))
                    {
                        DataRow[] dr1s = _dsStudent.Select("Student_id='" + _student + "'");
                        if (dr1s.Length > 0)
                        {
                            Console.Write("Grade: ");
                            string _value;
                            do
                            {
                                _value = Console.ReadLine();
                            }
                            while (Program.sNumber.IndexOf(_value) == -1);
                            double _grade = Convert.ToDouble(_value);
                            oRec.m_getattendid(_course, _personid, _student);
                            oRec.p_grade = _grade;
                            oRec.m_updategrade();
                            Console.WriteLine("Update Record!");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("This student does not exist !");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("This course does not exist !");
                        Console.ReadLine();
                    }
                }
            }
                
        }
        public int DisplayMenu()
        {
            string[] _activities = "Find student,View Record,Update Status,Update Grade,Exit".Split(',');
            int Width = 40;
            int Height = _activities.Length;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Program.DisplayHeader(40, " Menu ");
            string s = "";
            for (int i = 0; i < _activities.Length; i++)
            {
                string item = "║ " + (i + 1) + " - " + _activities[i];
                s = item + new string(' ', Width - item.Length + 1) + "║";
                Console.WriteLine(s);
            }
            Program.DisplayFooter(40);
            Console.ForegroundColor = ConsoleColor.White;
            COLE Ole = new COLE();
            _dsStudent = Ole.m_liststudent();
            _dsCourse = Ole.m_listcourse();
            _dsAttend = Ole.m_listattendant();
            return _activities.Length;
        }
        public string SelectMenuItem()
        {
            Console.Write("Please select a task: ");
            SelectedItem = Console.ReadLine();
            return SelectedItem;

        }
        public void PerformTask()
        {
            switch (SelectedItem)
            {
                case "1":
                    m_findstudent();
                    break;
                case "2":
                    m_viewrecord();
                    break;
                case "3":
                    m_updatestatus();
                    break;
                case "4":
                    m_updategrade();
                    break;
            }
        }
    }
}
