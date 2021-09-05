using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine.Models
{
    internal class Rules
    {
        private string _AS;
        public string AS
        {
            get => _AS;
            set 
            {
                if (_AS != value)
                {
                    _AS = OnSetProperty(value);
                }
            } 
        }
        private string _Q1;
        public string Q1
        {
            get => _Q1;
            set
            {
                if (_Q1 != value)
                {
                    _Q1 = OnSetProperty(value);
                }
            }
        }
        private string _Q2;
        public string Q2
        {
            get => _Q2;
            set
            {
                if (_Q2 != value)
                {
                    _Q2 = OnSetProperty(value);
                }
            }
        }
        private string _Q3;
        public string Q3
        {
            get => _Q3;
            set
            {
                if (_Q3 != value)
                {
                    _Q3 = OnSetProperty(value);
                }
            }
        }
        private string _Q4;
        public string Q4
        {
            get => _Q4;
            set
            {
                if (_Q4 != value)
                {
                    _Q4 = OnSetProperty(value);
                }
            }
        }
        private string _Q5;
        public string Q5
        {
            get => _Q5;
            set
            {
                if (_Q5 != value)
                {
                    _Q5 = OnSetProperty(value);
                }
            }
        }
        private string _Q6;
        public string Q6
        {
            get => _Q6;
            set
            {
                if (_Q6 != value)
                {
                    _Q6 = OnSetProperty(value);
                }
            }
        }
        private string _Q7;
        public string Q7
        {
            get => _Q7;
            set
            {
                if (_Q7 != value)
                {
                    _Q7 = OnSetProperty(value);
                }
            }
        }
        private string _Q8;
        public string Q8
        {
            get => _Q8;
            set
            {
                if (_Q8 != value)
                {
                    _Q8 = OnSetProperty(value);
                }
            }
        }
        private string _Q9;
        public string Q9
        {
            get => _Q9;
            set
            {
                if (_Q9 != value)
                {
                    _Q9 = OnSetProperty(value);
                }
            }
        }
        private string _Q10;
        public string Q10
        {
            get => _Q10;
            set
            {
                if (_Q10 != value)
                {
                    _Q10 = OnSetProperty(value);
                }
            }
        }

        private string OnSetProperty(string property)
        {
           return property.Replace(">", "\u2192")
                .Replace("П", "\u2192")
                .Replace("<", "\u2190")
                .Replace("Л", "\u2190")
                .Replace(".", "\u26d4")
                .Replace("Н", "\u26d4")
                .Replace("_", "\u03BB");
        }
    }
}
