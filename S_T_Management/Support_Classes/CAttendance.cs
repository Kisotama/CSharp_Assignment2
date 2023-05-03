using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan.Support_Classes
{
    public class CAttendance
    {
        int _attendantid;
        public int p_attendantid { get { return _attendantid; } set { _attendantid = value; } }
        string _courseid;
        public string p_courseid { get { return _courseid; }  set { _courseid = value; } }
        string _studentid;
        public string p_studentid { get { return _studentid; } set { _studentid = value; } }
        string _teacherid;
        public string p_teacherid { get { return _teacherid; } set { _teacherid = value; } }
        public DataTable m_getinfo()
        {
            COLE Ole = new COLE();
            return Ole.m_listattendant(_teacherid);
        }
        public void m_addteacher()
        {
            COLE Ole = new COLE();
            Ole.m_addteacher2class(_courseid, _teacherid);            
        }
        public void m_addstudent()
        {
            COLE Ole = new COLE();
            Ole.m_addstudent2class(_courseid, _studentid);

        }

    }
}
