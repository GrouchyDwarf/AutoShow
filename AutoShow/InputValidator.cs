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
        private static bool IsValid(in string input, in string template, ref string error)
        {
            if (!Regex.IsMatch(input, template))
            {   
                error = "";
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsValidName(in string name, out string error)
        {
            error = "Имя и фамилия могут состоять только из русских и английских букв";
            return IsValid(name,"[^а-яА-Яa-zA-Z]", ref error);
        }
        public static bool IsValidPassword(in string password, out string error)
        {
            error = "Пароль может состоять только из русских и английских букв,цифр,подчеркивания и тире";
            return IsValid(password, "[^а-яА-Яa-zA-Z0-9_-]", ref error);
        }
        //доделать
        /*
        public static bool IsValidEmail(in string email, out string error)
        {
            error = "Некорректный формат почты";
            //Simple regex for clarity
            return IsValid(email, @"[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+", ref error);
        }
        public static bool IsValidPhone(in string phone, out string error)
        {
            error = "Некорректный формат телефона";
            return IsValid(phone, @"/\+380\d{3}\d{2}\d{2}\d{2}$/", ref error);
        }*/
    }
}
