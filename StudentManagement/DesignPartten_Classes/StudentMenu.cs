using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan.DesignPartten_Classes
{
    public class StudentMenu:MenuInterface
    {
        string SelectedItem;
        string _personid = Program.sPersonid; // Student's code got after loging 
        public void m_viewrecord(int Width)
        {
            string[] _activities = "View Record,Exit".Split(',');
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LISTING ATTENDANT");
            COLE Ole = new COLE();
            DataTable dt = Ole.m_liststudentattendant(_personid);
            _activities = new string[dt.Rows.Count];
            int order = 0;
            foreach (DataRow dr in dt.Rows)
            {
                _activities[order++] = dr["course_id"].ToString() + " " + dr["coursename"].ToString() + " " + dr["student_id"].ToString() + " " + dr["studentname"].ToString() + " " + dr["teacher_id"].ToString() + " " + dr["teachername"].ToString() + " " + dr["Status"] + " " + dr["grade"];
            }
            int Height = _activities.Length;

            Console.ForegroundColor = ConsoleColor.White;
            //----------------------------------------------------------------------------
            Program.DisplayHeader(Width, " Attendants List ");
            string s = "";
            foreach (string stext in _activities)
            {
                string item = "║ " + stext;
                s += item + new string(' ', Width - item.Length + 1) + "║" + "\n";
            }
            Console.Write(s);
            Program.DisplayFooter(Width);
            //----------------------------------------------------------------------------
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public int DisplayMenu()
        {
            string[] _activities = "View Record,Exit".Split(',');
            int Width = 40;
            int Height = _activities.Length;
            Console.Clear();
            //----------------------------------------------------------------------------
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
            //----------------------------------------------------------------------------

            Console.ForegroundColor = ConsoleColor.White;
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
                    m_viewrecord(80);
                    Console.ReadLine();
                    break;
            }
        }
    }
}
