using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan.Support_Classes
{
    public class CCourse
    {
        string _id;
        string _name;
        public string p_id { get { return _id; } set { _id = value; } }
        public string p_name { get { return _name; } set { _name = value; } }
        public void m_getinfor()
        {
        }
        public void m_saveinfor()
        {
            COLE oLe = new COLE();
            oLe.m_savecourse(this);
        }
        public void m_setinfor(DataRow dr)
        {            
            _name= dr["coursename"].ToString();

        } 

    }
}
