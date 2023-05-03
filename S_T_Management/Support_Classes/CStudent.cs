using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan.Support_Classes
{
    public class CStudent : CPerson
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
        public override string p_address
        {
            get { return _address; }
            set { _address = value; }
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
        public override void m_getinfor()
        {

        }
        public override void m_saveinfor()
        {
            COLE oLe = new COLE();
            oLe.m_savestudent(this);
        }
             
    }
}
