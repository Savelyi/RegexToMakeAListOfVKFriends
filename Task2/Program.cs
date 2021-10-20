using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace Task2
{
    // \ d Specifies numeral characters.
    // \ D Specifies any character that is not a digit.
    // \ w Specifies any digit, letter, or underscore character.
    // \ W Specifies any character that is not a number, letter, or underscore.
    // \ s Specifies any non-printable character, including space.
    // \ S Specifies any character except tab, newline, and carriage return.
    // \. Definition of the point symbol.

    /// <summary>
    /// Save <file>.html of the list of person's friends
    /// </summary>
    class Program
    {                                       
        static void Main(string[] args)
        {
            FileStream stream = new FileStream(@"SomePath\SomeFriend.html", FileMode.Open, FileAccess.Read);
            var regex = new Regex(@"<a href=\u0022(?<id>\S+)\u0022 onclick=\u0022return nav.go\(this, event\);\u0022>(?<name>\S+)\s(?<surname>\S+)</a>" +
                @"|<a href=\u0022(?<id>\S+)\u0022>(?<name>\S+)\s(?<surname>\S+)</a>");
            StreamReader reader = new StreamReader(stream);
            FileStream stream1 = new FileStream(@"SomePath\OutPut.txt", FileMode.Create, FileAccess.ReadWrite);
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
