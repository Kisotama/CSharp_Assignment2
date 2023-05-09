    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan.Support_Classes
{
    public class CRecord
    {
        int _attendantid;
        double _grade;
        string _status;

        public int p_attendantid { get { return _attendantid; } set { _attendantid = value; } }
        public double p_grade { get { return _grade; } set { _grade = value; } }
        public string p_status { get { return _status; } set { _status = value; } }
        public void m_getattendid(string _courseid, string _teacherid, string _studentid)
        {
            COLE ole = new COLE();
            _attendantid = ole.m_getattendantid(_courseid, _teacherid, _studentid);
        }
        public void m_updatestatus()
        {
            COLE ole = new COLE();
            ole.m_saveabsent(_attendantid, _status);
        }
        public void m_updategrade()
        {
            COLE ole = new COLE();
            ole.m_savegrade(_attendantid, _grade);
        }

    }
}
