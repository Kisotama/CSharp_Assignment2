using Quan.DesignPartten_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan
{
    class Program
    {
        public static string sNumber = "012345678910";
        public static string sStatus = "AP";
        public static string sPersonid;        
        public static string m_messagebox(string message, string response)
        {
            string answer;
            do
            {
                Console.Write(message+" "+response);
                answer = Console.ReadLine();
            } while (response.IndexOf(answer.ToUpper()) == -1);            
            return answer;
        }
        static void f_showheader(string header, int Width)
        {
            for (int i = 0; i < (Width - header.Length) / 2; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(header);
            for (int i = 0; i < (Width - header.Length) / 2; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        static void m_showheader(int Width)
        {
            string h1 = new string(' ', Width) + "╔════════════════════════════════════════╗";
            string h2 = new string(' ', Width) + "║       PROGRAM: STUDENT ATTENDANT       ║";
            string h3 = new string(' ', Width) + "║------------------oOo-------------------║";
            string h4 = new string(' ', Width) + "║    AUTHOR:Tran Nguyen Dong Quan        ║";
            string h5 = new string(' ', Width) + "║    ASSESMENT: Advanced Programing      ║";
            string h6 = new string(' ', Width) + "║--------- BRIDGE DESIGN PARTTEN --------║";
            string h7 = new string(' ', Width) + "╚════════════════════════════════════════╝";
            string header = h1 + "\n" + h2 + "\n" + h3 + "\n" + h4 + "\n" + h5 + "\n" + h6 + "\n" + h7 + "\n";
            Console.WriteLine(header);
        }
        static void m_showauthenticate(int Width)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            m_showheader(1);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            f_showheader(" AUTHENTICATION ZONE", Width);
            Console.WriteLine("  " + new string('-', Width));
        }
        static string m_getPassword()
        {
            var pass = string.Empty;
            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            return pass;
        }
        static int f_checklogin(string username, string password)
        {
            COLE Ole = new COLE();
            DataTable dt = Ole.m_login(username, password);
            int role;
            if (dt.Rows.Count > 0)
            {
                role = Convert.ToInt16(dt.Rows[0]["role"]);
            }
            else
                role = -1;
            return role;
        }     
        static void Main(string[] args)
        {
            string _username;
            int _select = -1;
        
            do
            {
                m_showauthenticate(40);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("         User Name: ");
                _username = Console.ReadLine();                
                Console.Write("         Password: ");
                Console.ForegroundColor = ConsoleColor.Red;
                string _password = m_getPassword();
                _select = f_checklogin(_username, _password);
                COLE Ole = new COLE();
                Program.sPersonid = Ole.m_getpersonid(_username);
                string select;                
                switch (_select)
                {
                    case 0:
                        AbstractMenuControl StudentControl = new MenuControl(new StudentMenu());                        
                        do
                        {
                            StudentControl.DisplayMenu();
                            select = StudentControl.SelectMenuItem();
                            StudentControl.PerformTask();
                        } while (select != "2");
                        Console.Clear();
                        break;
                    case 1:
                        AbstractMenuControl TeacherControl = new MenuControl(new TeacherMenu());
                        do
                        {
                            TeacherControl.DisplayMenu();
                            select = TeacherControl.SelectMenuItem();
                            TeacherControl.PerformTask();
                        } while (select != "4");
                        Console.Clear();
                        break;
                    case 2:
                        AbstractMenuControl AdminControl = new MenuControl(new AdminMenu());
                        do
                        {
                            AdminControl.DisplayMenu();
                            select = AdminControl.SelectMenuItem();
                            AdminControl.PerformTask();
                        } while (select != "10");
                        Console.Clear();
                        break;
                    case -1:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine();
                        Console.WriteLine(" Invalid information provided!");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            } while (_select != -1);
            Console.Clear();
        }
    }
}
