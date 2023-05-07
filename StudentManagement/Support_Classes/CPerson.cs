using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan.Support_Classes
{
    public abstract class CPerson
    {
        protected string _personid;
        protected string _name;
        protected string _dateofbirth;
        protected string _gender;
        protected string _address;
        public abstract string p_personid { set; get; }
        public abstract string p_name { set; get; }
        public abstract string p_dateofbirth { set; get; }
        public abstract string p_gender { set; get; }
        public abstract string p_address { set; get; }
        public abstract void m_saveinfor();
        public abstract void m_getinfor();

    }
}
