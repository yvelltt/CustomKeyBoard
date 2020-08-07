using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsFormsApp1
{
    public static class Global
    {
        private static string _globalVar = "";

        public static string GlobalVar
        {
            get { return _globalVar; }
            set { _globalVar = value; }
        }
    }
}
