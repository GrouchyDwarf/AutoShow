using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutoShow
{
    class InputValidator
    {
        private static bool IsValid(string input, string template, ref string error)
        {
            if (!Regex.IsMatch(input, template))
            {   
                error = "";//ссылочный тип
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsValidName(string name, out string error)
        {
            error = "Имя и фамилия могут состоять только из русских и английских букв";
            return IsValid(name,"[^а-яА-Яa-zA-Z]", ref error);
        }
        public static bool IsValidPassword(string password, out string error)
        {
            error = "Пароль может состоять только из русских и английских букв,цифр,подчеркивания и тире";
            return IsValid(password, "[^а-яА-Яa-zA-Z0-9_-]", ref error);
        }
    }
}
