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
        string _personid = Program.sPersonid;
        public void m_viewrecord(int Width)
        {
            string[] _activities = "View Record,Exit".Split(',');
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LISTING ATTENDANT");
            Console.ForegroundColor = ConsoleColor.White;
            COLE Ole = new COLE();
            DataTable dt = Ole.m_liststudentattendant(_personid);
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
        public void DisplayMenu()
        {
            string[] _activities = "View Record,Exit".Split(',');
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
                    m_viewrecord(80);
                    Console.ReadLine();
                    break;
            }
        }
    }
}
