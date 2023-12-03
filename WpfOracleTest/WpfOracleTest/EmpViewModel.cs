using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOracleTest
{
    class EmpViewModel
    {
        int empno = 0;
        string ename = string.Empty;
        string job = string.Empty;

        public int Empno 
        { 
            get {  return empno; } 
            set {  empno = value; } 
        }   
        public string Ename 
        { 
            get { return ename; }
            set { ename = value; } 
        }
        public string Job 
        { 
            get { return job; } 
            set { job = value; } 
        }
    }
}
