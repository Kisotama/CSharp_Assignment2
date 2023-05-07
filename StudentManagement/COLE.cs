using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quan.Support_Classes;

namespace Quan
{

    public class COLE
    {
        DOLE_MYSQL ld00;
        public COLE()
        {
            ld00 = new DOLE_MYSQL();
            ld00.p_database = "studentattendant";
            ld00.p_server = "127.0.0.1";
            ld00.p_uid = "root";
            ld00.p_port = "3306";
            ld00.p_password = "haminhquan";
            ld00.Initialize();

        }
        public void m_savestudent(CStudent _student)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select * from Student where student_id=" + _student.p_personid;
            DataTable dt = ld00._RunQuery(mysql);
            if (dt.Rows.Count > 0)
                mysql = "Update Student set studentname='" + _student.p_name + "', gender='" + _student.p_gender + "',dateofbirth='" + _student.p_dateofbirth + "', address='" + _student.p_address + "' where student_id=" + _student.p_personid;
            else
                mysql = "INSERT INTO Student (student_id, studentname, gender,address, dateofbirth) VALUES('" + _student.p_personid + "','" + _student.p_name + "','" + _student.p_gender + "','" + _student.p_address + "','" + _student.p_dateofbirth + "')";
            ld00._RunQuery(mysql);
            ld00.CloseConnection();
        }
        public void m_saveteacher(CTeacher _teacher)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select * from Teacher where teacher_id=" + _teacher.p_personid;
            DataTable dt = ld00._RunQuery(mysql);
            if (dt.Rows.Count > 0)
                mysql = "Update Teacher set teachername='" + _teacher.p_name + "', gender='" + _teacher.p_gender + "',dateofbirth='" + _teacher.p_dateofbirth + "', address='" + _teacher.p_address + "' where teacher_id=" + _teacher.p_personid;
            else
                mysql = "INSERT INTO Teacher (teacher_id, teachername, gender,address, dateofbirth) VALUES('" + _teacher.p_personid + "','" + _teacher.p_name + "','" + _teacher.p_gender + "','" + _teacher.p_address + "','" + _teacher.p_dateofbirth + "')";
            ld00._RunQuery(mysql);
            ld00.CloseConnection();
        }
        public void m_savecourse(CCourse _course)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select * from Course where Course_id=" + _course.p_id;
            DataTable dt = ld00._RunQuery(mysql);
            if (dt.Rows.Count > 0)
                mysql = "Update Course set Coursename='" + _course.p_name + "' where Course_id=" + _course.p_id;
            else
                mysql = "INSERT INTO Course (Course_id, Coursename ) VALUES('" + _course.p_id + "',N'" + _course.p_name + "')";
            ld00._RunQuery(mysql);
            ld00.CloseConnection();
        }
        public DataTable m_listcourse()
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select * from Course ";
            DataTable dt = ld00._RunQuery(mysql);
            ld00.CloseConnection();
            return dt;
        }
        public void m_deletecourse(string courseid)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select attendant_id from attendant where course_id='" + courseid + "'";
            DataTable dt = ld00._RunQuery(mysql);
            foreach (DataRow dr in dt.Rows)
            {
                string _id = dr["attendant_id"].ToString();
                mysql = "Delete from record where attendant_id='" + _id + "'";
                ld00._RunQuery(mysql);
            }
            mysql = "Delete from attendant where course_id='" + courseid + "'";
            ld00._RunQuery(mysql);
            mysql = "Delete from course where teacher_id='" + courseid+ "'";
            ld00._RunQuery(mysql);
            ld00.CloseConnection();

        }
        public DataTable m_liststudent()
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select * from Student";
            DataTable dt = ld00._RunQuery(mysql);
            ld00.CloseConnection();
            return dt;
        }
        public void m_deletestudent(string studentid)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select attendant_id from attendant where student_id='" + studentid + "'";            
            DataTable dt = ld00._RunQuery(mysql);
            foreach(DataRow dr in dt.Rows)
            {
                string _id = dr["attendant_id"].ToString();
                mysql = "Delete from record where attendant_id='" + _id + "'";
                ld00._RunQuery(mysql);
            }
            mysql = "Delete from attendant where student_id='" + studentid + "'";
            ld00._RunQuery(mysql);
            mysql = "Delete from Student where student_id='" + studentid + "'";
            ld00._RunQuery(mysql);
            mysql = "Delete from member where personal_id='" + studentid + "'";
            ld00._RunQuery(mysql);
            ld00.CloseConnection();

        }
        public DataTable m_listteacher()
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select * from Teacher";
            DataTable dt = ld00._RunQuery(mysql);
            ld00.CloseConnection();
            return dt;
        }
        public void m_deleteteacher(string teacherid)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select attendant_id from attendant where teacher_id='" + teacherid + "'";
            DataTable dt = ld00._RunQuery(mysql);
            foreach (DataRow dr in dt.Rows)
            {
                string _id = dr["attendant_id"].ToString();
                mysql = "Delete from record where attendant_id='" + _id + "'";
                ld00._RunQuery(mysql);
            }
            mysql = "Delete from attendant where teacher_id='" + teacherid + "'";
            ld00._RunQuery(mysql);
            mysql = "Delete from teacher where teacher_id='" + teacherid + "'";
            ld00._RunQuery(mysql);
            mysql = "Delete from member where personal_id='" + teacherid + "'";
            ld00._RunQuery(mysql);
            ld00.CloseConnection();

        }
        public DataTable m_login(string _username, string _password)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select * from member where user_name='" + _username + "' and password='" + _password + "'";
            DataTable dt = ld00._RunQuery(mysql);
            ld00.CloseConnection();
            return dt;
        }
        public void m_addteacher2class(string _courseid, string _teacherid)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select * from attendant where course_id='" + _courseid + "'";
            DataTable dt = ld00._RunQuery(mysql);
            if (dt.Rows.Count == 0)
            {
                mysql = "INSERT INTO attendant (Course_id, Teacher_id) VALUES('" + _courseid + "','" + _teacherid + "')";
                ld00._RunQuery(mysql);
            }
            ld00.CloseConnection();
        }
        public void m_addstudent2class(string _courseid, string _studentid)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select * from attendant where course_id='" + _courseid + "' and teacher_id is not null ";
            DataTable dt = ld00._RunQuery(mysql);
            if (dt.Rows.Count > 0)
            {
                string _teacherid = dt.Rows[0]["teacher_id"].ToString();
                mysql = "Select * from attendant where course_id='" + _courseid + "' and student_id='" + _studentid + "'";
                dt = ld00._RunQuery(mysql);
                if (dt.Rows.Count == 0)
                {
                    mysql = "UPDATE attendant SET student_id= '" + _studentid + "' WHERE course_id='" + _courseid + "' and teacher_id='" + _teacherid + "'";
                    ld00._RunQuery(mysql);
                }
            }
            ld00.CloseConnection();
        }
        public DataTable m_getinforattent()
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "SELECT * from attendant";
            DataTable dt = ld00._RunQuery(mysql);
            ld00.CloseConnection();
            return dt;
        }
        public DataTable m_listattendant()
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "SELECT attendant.course_id, Course.courseName, attendant.Student_id,student.StudentName, attendant.Teacher_id, teacher.TeacherName FROM attendant INNER JOIN Student ON attendant.Student_id= Student.Student_id INNER JOIN Teacher ON attendant.Teacher_id= Teacher.Teacher_id INNER JOIN Course ON attendant.Course_id= Course.Course_id ORDER BY Course_ID, Student_Id";
            DataTable dt = ld00._RunQuery(mysql);
            ld00.CloseConnection();
            return dt;
        }
        public DataTable m_listattendant(string _teacherid)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "SELECT attendant.attendant_id, attendant.course_id, Course.courseName, attendant.Student_id,student.StudentName, attendant.Teacher_id, teacher.TeacherName, '  ' as status, 0 as grade FROM attendant INNER JOIN Student ON attendant.Student_id= Student.Student_id INNER JOIN Teacher ON attendant.Teacher_id= Teacher.Teacher_id INNER JOIN Course ON attendant.Course_id= Course.Course_id where attendant.Teacher_id='" + _teacherid + "' ORDER BY Course_ID, Student_Id";
            DataTable dt = ld00._RunQuery(mysql);
            dt.Columns["status"].ReadOnly = false;
            dt.Columns["grade"].ReadOnly = false;
            foreach (DataRow dr in dt.Rows)
            {
                mysql = "Select attendantstatus, grade from record where attendant_id=" + dr["attendant_id"];
                DataTable dt0 = ld00._RunQuery(mysql);
                if (dt0.Rows.Count > 0)
                {
                    dr[7] = dt0.Rows[0]["attendantstatus"].ToString();
                    dr["grade"] = "0" + dt0.Rows[0]["grade"];
                }
            }
            ld00.CloseConnection();
            return dt;
        }
        public DataTable m_liststudentattendant(string _studentid)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "SELECT attendant.attendant_id, attendant.course_id, Course.courseName, attendant.Student_id,student.StudentName, attendant.Teacher_id, teacher.TeacherName, '  ' as status, 0 as grade FROM attendant INNER JOIN Student ON attendant.Student_id= Student.Student_id INNER JOIN Teacher ON attendant.Teacher_id= Teacher.Teacher_id INNER JOIN Course ON attendant.Course_id= Course.Course_id where attendant.student_id='" + _studentid + "' ORDER BY Course_ID ";
            DataTable dt = ld00._RunQuery(mysql);
            dt.Columns["status"].ReadOnly = false;
            dt.Columns["grade"].ReadOnly = false;
            foreach (DataRow dr in dt.Rows)
            {
                mysql = "Select attendantstatus, grade from record where attendant_id=" + dr["attendant_id"];
                DataTable dt0 = ld00._RunQuery(mysql);
                if (dt0.Rows.Count > 0)
                {
                    dr[7] = dt0.Rows[0]["attendantstatus"].ToString();
                    dr["grade"] = "0" + dt0.Rows[0]["grade"];
                }
            }
            ld00.CloseConnection();
            return dt;
        }
        public int m_getattendantid(string _courseid, string _teacherid, string _studentid)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select * from attendant where course_id='" + _courseid + "' and student_id='" + _studentid + "' and teacher_id='" + _teacherid + "'";
            DataTable dt = ld00._RunQuery(mysql);
            int _id = 0;
            if (dt.Rows.Count > 0)
                _id = Convert.ToInt16(dt.Rows[0]["attendant_id"]);
            return _id;

        }
        public void m_saveabsent(int _attendid, string _absent)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select * from record where attendant_id=" + _attendid;
            DataTable dt = ld00._RunQuery(mysql);
            if (dt.Rows.Count == 0)
            {
                mysql = "INSERT INTO record (attendant_id, attendantstatus) VALUES(" + _attendid + ",'" + _absent + "')";
                ld00._RunQuery(mysql);
            }
            else
            {
                mysql = "Update record SET attendantstatus='" + _absent + "' WHERE attendant_id=" + _attendid;
                ld00._RunQuery(mysql);
            }
            ld00.CloseConnection();
        }
        public void m_savegrade(int _attendid, double _grade)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select * from record where attendant_id=" + _attendid;
            DataTable dt = ld00._RunQuery(mysql);
            if (dt.Rows.Count > 0)
            {
                mysql = "Update record SET grade=" + _grade + " WHERE attendant_id=" + _attendid;
                ld00._RunQuery(mysql);
            }
            ld00.CloseConnection();
        }
        public string m_getpersonid(string _username)
        {
            ld00.OpenConnection();
            string mysql;
            mysql = "Select personal_id from member where user_name='" + _username + "'";
            DataTable dt = ld00._RunQuery(mysql);
            string id = "";
            if (dt.Rows.Count > 0)
            {
                id = dt.Rows[0]["personal_id"].ToString();
            }
            ld00.CloseConnection();
            return id;
        }
    }
}
