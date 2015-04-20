using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace File_Renamer
{
    class Validator
    {
        Command cmd = new Command();

        public bool isNumber(string a)
        {
            if (Regex.IsMatch(a, @"^[0-9]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isNotEmpty(string a)
        {
            if(a.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isLetter(string a)
        {
            if (Regex.IsMatch(a, @"^[a-zA-Z]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isLetterNumber(string a)
        {
            if (Regex.IsMatch(a, @"^[a-zA-Z0-9]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isLetterNumberUnderscore(string a)
        {
            if (Regex.IsMatch(a, @"^[a-zA-Z0-9_]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isAlphaLetterSpace(string a)
        {
            if (Regex.IsMatch(a, @"^[a-zA-Z0-9# ]+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }  
		public bool isValidateFree()
        {
            if (!cmd.cetakTanya("This program was developed by RHIT ! Solution, Do you Agree to distribute the program without commercial purposes ? "))
            {
                Environment.Exit(0);
                return false;
            }            
            else
            {
                return true;
            }

        }		
    }
}
