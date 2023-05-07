using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan.Support_Classes
{
    public class CTeacher : CPerson
    {
        public override string p_name
        {
            get { return _name; }
            set { _name = value; }
        }
        public override string p_personid
        {
            get { return _personid; }
            set { _personid = value; }
        }
        public override string p_dateofbirth
        {
            get { return _dateofbirth; }
            set { _dateofbirth = value; }
        }
        public override string p_gender
        {
            get { return _gender; }
            set { _gender = value; }
        }      
        public override string p_address
        {
            get { return _address; }
            set { _address = value; }
        }
        public override void m_getinfor()
        {
        }

        public override void m_saveinfor()
        {
            COLE oLe = new COLE();
            oLe.m_saveteacher(this);
        }
        public void m_setinfor(DataRow dr)
        {
            _name = dr["teachername"].ToString();
            _gender = dr["gender"].ToString();
            _address = dr["address"].ToString();
            _dateofbirth = dr["dateofbirth"].ToString();

        }
    }
}
