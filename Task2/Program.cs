using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Task2
{
    //\d Определяет символы цифр. 
    //\D Определяет любой символ, который не является цифрой. 
    //\w Определяет любой символ цифры, буквы или подчеркивания.
    //\W Определяет любой символ, который не является цифрой, буквой или подчеркиванием.
    //\s Определяет любой непечатный символ, включая пробел. 
    //\S Определяет любой символ, кроме символов табуляции, новой строки и возврата каретки.
    // .Определяет любой символ кроме символа новой строки.
    //\.    Определяет символ точки.


    class Program
    {                                       
        static void Main(string[] args)
        {
            FileStream stream = new FileStream(@"D:\Пользователи\Documents\LivyantFriends.html", FileMode.Open, FileAccess.Read);
            var regex = new Regex(@"<a href=\u0022(?<id>\S+)\u0022 onclick=\u0022return nav.go\(this, event\);\u0022>(?<name>\S+)\s(?<surname>\S+)</a>" +
                @"|<a href=\u0022(?<id>\S+)\u0022>(?<name>\S+)\s(?<surname>\S+)</a>");
            StreamReader reader = new StreamReader(stream);
            FileStream stream1 = new FileStream(@"D:\Пользователи\Documents\TestOutPut.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(stream1);
            string inputString = reader.ReadToEnd();
            int index = 1;
            foreach (Match m in regex.Matches(inputString))
            {
               
                writer.WriteLine("{0}.id: {1,-50} fullname: {2} {3}", index, m.Groups["id"], m.Groups["name"], m.Groups["surname"]);
                Console.WriteLine("{0}.ID: {1,-40} Name: {2} {3}", index, m.Groups["id"], m.Groups["name"], m.Groups["surname"]);
                index++;
            }
            stream.Close();
            stream1.Close();


        }
    }
}
