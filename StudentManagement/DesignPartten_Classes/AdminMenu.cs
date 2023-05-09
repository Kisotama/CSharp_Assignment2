using Quan.Support_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan.DesignPartten_Classes
{
    public class AdminMenu : MenuInterface
    {
        string SelectedItem;
        string[] _activities;
        string _personid;
        DataTable _dsStudent;
        DataTable _dsTeacher;
        DataTable _dsCourse;
        DataTable _dsAttend;
        public string p_personid
        {
            set { _personid = value; }
        }
        public void m_liststudent(int Width)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LISTING STUDENTS");
            Console.ForegroundColor = ConsoleColor.White;
            _activities = new string[_dsStudent.Rows.Count];
            int order = 0;
            foreach (DataRow dr in _dsStudent.Rows)
            {
                _activities[order++] = dr["student_id"].ToString() + " " + dr["studentname"].ToString() + " " + dr["gender"].ToString(); ;
            }
            int Height = _activities.Length;

            //---------------------------------------------------------------------
            Program.DisplayHeader(Width, " Student List ");
            string s = "";
            foreach (string stext in _activities)
            {
                string item = "║ " + stext;
                s += item + new string(' ', Width - item.Length + 1) + "║" + "\n";
            }
            Console.Write(s);
            Program.DisplayFooter(Width);
            //---------------------------------------------------------------------

            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void m_addstudent()
        {
            m_liststudent(60);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ADD/DELETE STUDENT");
            Console.ForegroundColor = ConsoleColor.White;
            CStudent oStudent = new CStudent();
            Console.Write("Student id: ");
            oStudent.p_personid = Console.ReadLine();
            if (!string.IsNullOrEmpty(oStudent.p_personid))
            {
                DataRow[] drs = _dsStudent.Select("Student_id='" + oStudent.p_personid + "'");
                if (drs.Length > 0)
                {
                    Console.WriteLine("This student has existed [" + drs[0]["StudentName"] + "," + drs[0]["Gender"] + "," + drs[0]["Address"] + "," + drs[0]["DateOfBirth"] + "]");
                    string answer = Program.m_messagebox("Do you want to update or delete student's information? ", "U/D");
                    string value;
                    if (answer.ToUpper() == "U")
                    {
                        oStudent.m_setinfor(drs[0]);
                        Console.Write("Student name: ");
                        value = Console.ReadLine();
                        if (!string.IsNullOrEmpty(value))
                            oStudent.p_name = value;
                        Console.Write("Gender(M/F): ");
                        value = Console.ReadLine();
                        if (!string.IsNullOrEmpty(value))
                            oStudent.p_gender = value;
                        Console.Write("Address: ");
                        value = Console.ReadLine();
                        if (!string.IsNullOrEmpty(value))
                            oStudent.p_address = value;
                        Console.Write("Birth date(mm/dd/yyyy): ");
                        value = Console.ReadLine();
                        if (!string.IsNullOrEmpty(value))
                            oStudent.p_dateofbirth = value;
                        oStudent.m_saveinfor();
                        COLE Ole = new COLE();
                        _dsStudent = Ole.m_liststudent();
                        Console.WriteLine("Updated student!");
                    }
                    else
                        if (answer.ToUpper() == "D")
                        {
                            answer = Program.m_messagebox("Do you want to delete this student? ", "Y/N");
                            if (answer.ToUpper() == "Y")
                            {
                                COLE Ole = new COLE();
                                Ole.m_deletestudent(oStudent.p_personid);
                                _dsStudent = Ole.m_liststudent();
                                Console.WriteLine("Deleted student!");
                            }

                        }
                }
                else
                {
                    Console.Write("Student name: ");
                    oStudent.p_name = Console.ReadLine();
                    Console.Write("Gender(M/F): ");
                    oStudent.p_gender = Console.ReadLine();
                    Console.Write("Address: ");
                    oStudent.p_address = Console.ReadLine();
                    Console.Write("Birth date(mm/dd/yyyy): ");
                    oStudent.p_dateofbirth = Console.ReadLine();
                    oStudent.m_saveinfor();
                    COLE Ole = new COLE();
                    _dsStudent = Ole.m_liststudent();
                    Console.WriteLine("Added student!");
                }
            }
        }
        public void m_addteacher()
        {
            m_listteacher(60);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ADD/DELETE TEACHER");
            Console.ForegroundColor = ConsoleColor.White;
            CTeacher oTeacher = new CTeacher();
            Console.Write("Teacher id: ");
            oTeacher.p_personid = Console.ReadLine();
            if (!string.IsNullOrEmpty(oTeacher.p_personid))
            {
                DataRow[] drs = _dsTeacher.Select("Teacher_id='" + oTeacher.p_personid + "'");
                if (drs.Length > 0)
                {
                    Console.WriteLine("This teacher has existed [" + drs[0]["teacherName"] + "," + drs[0]["Gender"] + "," + drs[0]["Address"] + "," + drs[0]["dateofbirth"] + "]");
                    string answer = Program.m_messagebox("Do you want to update or delete teacher's information? ", "U/D");
                    string value;
                    if (answer.ToUpper() == "U")
                    {
                        oTeacher.m_setinfor(drs[0]);
                        Console.Write("Teacher name: ");
                        value = Console.ReadLine();
                        if (!string.IsNullOrEmpty(value))
                            oTeacher.p_name = value;
                        Console.Write("Gender(M/F): ");
                        value = Console.ReadLine();
                        if (!string.IsNullOrEmpty(value))
                            oTeacher.p_gender = value;
                        Console.Write("Address: ");
                        value = Console.ReadLine();
                        if (!string.IsNullOrEmpty(value))
                            oTeacher.p_address = value;
                        Console.Write("Birth date(mm/dd/yyyy): ");
                        value = Console.ReadLine();
                        if (!string.IsNullOrEmpty(value))
                            oTeacher.p_dateofbirth = value;
                        oTeacher.m_saveinfor();
                        COLE Ole = new COLE();
                        _dsTeacher = Ole.m_listteacher();
                        Console.WriteLine("Updated Teacher!");
                    }
                    else
                        if (answer.ToUpper() == "D")
                        {
                            answer = Program.m_messagebox("Do you want to delete this teacher? ", "Y/N");
                            if (answer.ToUpper() == "Y")
                            {
                                COLE Ole = new COLE();
                                Ole.m_deleteteacher(oTeacher.p_personid);
                                _dsTeacher = Ole.m_listteacher();
                                Console.WriteLine("Deleted teacher!");
                            }

                        }
                }
                else
                {
                    Console.Write("Teacher name: ");
                    oTeacher.p_name = Console.ReadLine();
                    Console.Write("Gender(M/F): ");
                    oTeacher.p_gender = Console.ReadLine();
                    Console.Write("Address: ");
                    oTeacher.p_address = Console.ReadLine();
                    Console.Write("Birth date(mm/dd/yyyy): ");
                    oTeacher.p_dateofbirth = Console.ReadLine();
                    oTeacher.m_saveinfor();
                    COLE Ole = new COLE();
                    _dsTeacher = Ole.m_listteacher();
                    Console.WriteLine("Added Teacher!");
                }
            }

        }
        public void m_createcourse()
        {
            m_listcourse(60);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ADD/DELETE COURSE");
            Console.ForegroundColor = ConsoleColor.White;
            CCourse oCourse = new CCourse();
            Console.Write("Course id: ");
            oCourse.p_id = Console.ReadLine();
            if (!string.IsNullOrEmpty(oCourse.p_id))
            {
                DataRow[] drs = _dsCourse.Select("Course_id='" + oCourse.p_id + "'");
                if (drs.Length > 0)
                {
                    Console.WriteLine("This course has existed [" + drs[0]["CourseName"] + "]");
                    string answer = Program.m_messagebox("Do you want to update or delete course's information? ", "U/D");
                    string value;
                    if (answer.ToUpper() == "U")
                    {
                        oCourse.m_setinfor(drs[0]);
                        Console.Write("Course name: ");
                        value = Console.ReadLine();
                        if (!string.IsNullOrEmpty(value))
                            oCourse.p_name = value;
                        oCourse.m_saveinfor();
                        COLE Ole = new COLE();
                        _dsCourse = Ole.m_listcourse();
                        Console.WriteLine("Updated Course!");
                    }
                    else
                        if (answer.ToUpper() == "D")
                        {
                            answer = Program.m_messagebox("Do you want to delete this course? ", "Y/N");
                            if (answer.ToUpper() == "Y")
                            {
                                COLE Ole = new COLE();
                                Ole.m_deletecourse(oCourse.p_id);
                                _dsCourse = Ole.m_listcourse();
                                Console.WriteLine("Deleted teacher!");
                            }

                        }
                }
                else
                {
                    oCourse.p_id = Console.ReadLine();
                    Console.Write("Course name: ");
                    oCourse.p_name = Console.ReadLine();
                    oCourse.m_saveinfor();
                    COLE Ole = new COLE();
                    _dsCourse = Ole.m_listcourse();
                    Console.WriteLine("Added Course!");
                }
            }

        }
        public void m_listcourse(int Width)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LISTING COURSES");
            Console.ForegroundColor = ConsoleColor.White;
            COLE Ole = new COLE();
            _dsCourse = Ole.m_listcourse();
            _activities = new string[_dsCourse.Rows.Count];
            int order = 0;
            foreach (DataRow dr in _dsCourse.Rows)
            {
                _activities[order++] = dr["course_id"].ToString() + " " + dr["coursename"].ToString();
            }
            int Height = _activities.Length;

            //---------------------------------------------------------------------

            Program.DisplayHeader(Width, " Courses List ");
            string s = "";
            foreach (string stext in _activities)
            {
                string item = "║ " + stext;
                s += item + new string(' ', Width - item.Length + 1) + "║" + "\n";
            }
            Console.Write(s);
            Program.DisplayFooter(Width);
            //---------------------------------------------------------------------

            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void m_listteacher(int Width)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LISTING TEACHERS");
            Console.ForegroundColor = ConsoleColor.White;
            _activities = new string[_dsTeacher.Rows.Count];
            int order = 0;
            foreach (DataRow dr in _dsTeacher.Rows)
            {
                _activities[order++] = dr["teacher_id"].ToString() + " " + dr["teachername"].ToString() + " " + dr["gender"].ToString(); ;
            }
            int Height = _activities.Length;

            //---------------------------------------------------------------------
            Program.DisplayHeader(Width, " Teacher List ");
            string s = "";
            foreach (string stext in _activities)
            {
                string item = "║ " + stext;
                s += item + new string(' ', Width - item.Length + 1) + "║" + "\n";
            }
            Console.Write(s);
            Program.DisplayFooter(Width);
            //---------------------------------------------------------------------
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void m_listattendant(int Width)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LISTING ATTENDANT");
            Console.ForegroundColor = ConsoleColor.White;
            COLE Ole = new COLE();
            _dsAttend = Ole.m_listattendant();
            _activities = new string[_dsAttend.Rows.Count];
            int order = 0;
            foreach (DataRow dr in _dsAttend.Rows)
            {
                _activities[order++] = dr["course_id"].ToString() + " " + dr["coursename"].ToString() + " " + " Student " + dr["studentname"].ToString() + " "+ " ID:"+dr["student_id"].ToString() + " " +  " Teacher " + dr["teachername"].ToString() + " ID:" +dr["teacher_id"].ToString() + " ";
            }
            int Height = _activities.Length;

            //---------------------------------------------------------------------
            Program.DisplayHeader(Width, " Attendants List  ");
            string s = "";
            foreach (string stext in _activities)
            {
                string item = "║ " + stext;
                s += item + new string(' ', Width - item.Length + 1) + "║" + "\n";
            }
            Console.Write(s);
            Program.DisplayFooter(Width);
            //---------------------------------------------------------------------

            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void m_addteachertoclass()
        {
            CAttendance oAtt = new CAttendance();
            DataTable dt = oAtt.m_getinfo();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ADDING TEACHER TO CLASS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Teacher id: ");
            oAtt.p_teacherid = Console.ReadLine();
            DataRow[] drs = _dsTeacher.Select("teacher_id='" + oAtt.p_teacherid + "'");
            if (drs.Length == 0)
            {
                Console.WriteLine("This teacher does not exist!");
                Console.ReadLine();
            }
            else
            {
                Console.Write("Course id: ");
                oAtt.p_courseid = Console.ReadLine();
                DataRow[] dr0s = _dsCourse.Select("Course_id='" + oAtt.p_courseid + "'");
                if (dr0s.Length == 0)
                {
                    Console.WriteLine("This course does not exist!");
                    Console.ReadLine();
                }
                else
                {
                    DataRow[] dr1s = _dsAttend.Select("Course_id='" + oAtt.p_courseid + "' and teacher_id='" + oAtt.p_teacherid + "'");
                    if (dr1s.Length > 0)
                    {
                        Console.WriteLine("This course and teacher has scheduled!");
                        Console.ReadLine();
                    }
                    else
                    {
                        oAtt.m_addteacher();
                        COLE Ole = new COLE();
                        _dsAttend = Ole.m_listattendant();
                        Console.WriteLine("Added Teacher!");
                        Console.ReadLine();
                    }
                }
            }

        }
        public void m_addstudenttoclass()
        {
            CAttendance oAtt = new CAttendance();
            DataTable dt = oAtt.m_getinfo();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ADDING STUDENT TO CLASS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Student id: ");
            oAtt.p_studentid = Console.ReadLine();
            DataRow[] drs = _dsStudent.Select("Student_id='" + oAtt.p_studentid + "'");
            if (drs.Length == 0)
            {
                Console.WriteLine("This student does not exist!");
                Console.ReadLine();
            }
            else
            {
                Console.Write("Course id: ");
                oAtt.p_courseid = Console.ReadLine();
                DataRow[] dr0s = _dsCourse.Select("Course_id='" + oAtt.p_courseid + "'");
                if (dr0s.Length == 0)
                {
                    Console.WriteLine("This course does not exist!");
                    Console.ReadLine();
                }
                else
                {
                    DataRow[] dr1s = dt.Select("Course_id='" + oAtt.p_courseid + "' and teacher_id is not null");
                    if (dr1s.Length == 0)
                    {
                        Console.WriteLine("This course is not scheduled so you could not add student to!");
                        Console.ReadLine();
                    }
                    else
                    {
                        oAtt.m_addstudent();
                        COLE Ole = new COLE();
                        _dsAttend = Ole.m_listattendant();
                        Console.WriteLine("Added Student!");
                        Console.ReadLine();
                    }
                }
            }

        }
        public int DisplayMenu()
        {
            string[] _activities = "Add/Delete Student,Add/Delete Teacher,Add/Delete Course,List Student,List Teacher,List Course,Add Student To Class,Add Teacher To Class,List Attendant,Exit".Split(',');
            int Width = 40;
            int Height = _activities.Length;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            //---------------------------------------------------------------------
            Program.DisplayHeader(40, " Menu ");
            string s = "";
            for (int i = 0; i < _activities.Length; i++)
            {
                string item = "║ " + (i + 1) + " - " + _activities[i];
                s = item + new string(' ', Width - item.Length + 1) + "║";
                Console.WriteLine(s);
            }
            Program.DisplayFooter(40);
            //---------------------------------------------------------------------

            Console.ForegroundColor = ConsoleColor.Green;
            COLE Ole = new COLE();
            _dsStudent = Ole.m_liststudent();
            _dsTeacher = Ole.m_listteacher();
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
                    m_addstudent();
                    break;
                case "2":
                    m_addteacher();
                    break;
                case "3":
                    m_createcourse();
                    break;
                case "4":
                    m_liststudent(60);
                    Console.ReadLine();
                    break;
                case "5":
                    m_listteacher(60);
                    Console.ReadLine();
                    break;
                case "6":
                    m_listcourse(60);
                    Console.ReadLine();
                    break;
                case "7":
                    m_addstudenttoclass();
                    break;
                case "8":
                    m_addteachertoclass();
                    break;
                case "9":
                    m_listattendant(80);
                    Console.ReadLine();
                    break;
            }
        }
    }
}
