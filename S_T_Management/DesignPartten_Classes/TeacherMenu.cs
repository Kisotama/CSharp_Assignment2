using Quan.Support_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan.DesignPartten_Classes
{
    public class TeacherMenu:MenuInterface
    {
        string SelectedItem;
        string[] _activities;
        string _personid=Program.sPersonid;
        public string p_personid
        {
            set { _personid = value; }
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
            string Header = " Attendants List ";
            string s = "╔";
            string space = "";
            string temp = "";

            for (int i = 0; i < (Width - Header.Length) / 2; i++)
            {
                space += " ";
                s += "═";
            }
            s += Header;
            for (int i = 0; i < (Width - Header.Length) / 2 + 1; i++)
            {
                space += " ";
                s += "═";
            }
            s += "╗" + "\n";
            foreach (string stext in _activities)
            {
                string item = "║ " + stext;
                s += item + new string(' ', Width - item.Length + 1) + "║" + "\n";
            }
            s += temp + "╚";
            for (int i = 0; i < Width; i++)
                s += "═";

            s += "╝" + "\n";
            Console.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void m_viewrecord()
        {
            m_listattendant(80);
            Console.ReadLine();
        }
        public void m_updatestatus()
        {
            CRecord oRec = new CRecord();
            m_listattendant(80);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("UPDATE INFORMATION");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Course ID: ");
            string _course = Console.ReadLine();
            string _teacher = _personid;
            Console.Write("Student id: ");
            string _student = Console.ReadLine();
            char _status;
            do
            {
                Console.Write("Attendant Status (P/A)?");
                _status = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (Program.sStatus.IndexOf(_status.ToString().ToUpper()) == -1);
            oRec.m_getattendid(_course, _teacher, _student);
            oRec.p_status = _status.ToString();
            oRec.m_updatestatus();
            Console.WriteLine();
            Console.WriteLine("Update Record!");
            Console.ReadLine();
        }
        public void m_updategrade()
        {
            CRecord oRec = new CRecord();
            m_listattendant(80);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("UPDATE INFORMATION");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Course ID: ");
            string _course = Console.ReadLine();
            string _teacher = _personid;
            Console.Write("Student id: ");
            string _student = Console.ReadLine();
            Console.Write("Grade: ");
            string _value;
            do
            {
                _value = Console.ReadLine();
            }
            while (Program.sNumber.IndexOf(_value) == -1);
            double _grade = Convert.ToDouble(_value);
            oRec.m_getattendid(_course, _teacher, _student);
            oRec.p_grade = _grade;
            oRec.m_updategrade();
            Console.WriteLine("Update Record!");
            Console.ReadLine();
        }
        public void DisplayMenu()
        {
            string[] _activities = "View Record,Update Status,Update Grade,Exit".Split(',');
              int Width = 40;
            int Height = _activities.Length;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            string Header = " Menu ";
            string s = "╔";
            for (int i = 0; i < (Width - Header.Length) / 2; i++)
                s += "═";
            s += Header;
            for (int i = 0; i < (Width - Header.Length) / 2; i++)

                s += "═";
            s += "╗" + "\n";
            Console.Write(s);
            for (int i = 0; i < _activities.Length; i++)
            {
                string item = "║ " + (i + 1) + " - " + _activities[i];
                s = item + new string(' ', Width - item.Length + 1) + "║";
                Console.WriteLine(s);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            s = "╚";
            for (int i = 0; i < Width; i++)
                s += "═";
            s += "╝" + "\n";
            Console.WriteLine(s);
            Console.ForegroundColor = ConsoleColor.White;
        }        
        public string SelectMenuItem()
        {
            Console.WriteLine("Please select a task: ");
            SelectedItem = Console.ReadLine();
            return SelectedItem; 
            
        }
        public void PerformTask()
        {
           switch (SelectedItem)
                {
                    case "1":
                        m_viewrecord();
                        break;
                    case "2":
                        m_updatestatus();
                        break;
                    case "3":
                        m_updategrade();
                        break;
                }
        }
    }
}
