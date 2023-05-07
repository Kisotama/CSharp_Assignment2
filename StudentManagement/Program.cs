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
        /// <summary>
        /// Dùng để vẽ phần header của khung
        /// </summary>
        /// <param name="Width">Bề rộng khung</param>
        /// <param name="Header">Nội dung Header</param>
        public static void DisplayHeader(int Width, string Header)
        {
            string s = "╔";
            for (int i = 0; i < (Width - Header.Length) / 2; i++)
                s += "═";
            s += Header;
            for (int i = 0; i < (Width - Header.Length) / 2; i++)

                s += "═";
            s += "╗" + "\n";
            Console.Write(s);
        }
        /// <summary>
        /// Dùng để vẽ footer của khung 
        /// </summary>
        /// <param name="Width">Bề rộng footer</param>
        public static void DisplayFooter(int Width)
        {
            string s = "╚";
            for (int i = 0; i < Width; i++)
                s += "═";
            s += "╝" + "\n";
            Console.Write(s);
        }
        /// <summary>
        /// Simulate the MessageBox.Show
        /// </summary>
        /// <param name="message"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        public static string m_messagebox(string message, string response)
        {
            string answer;
            do
            {
                Console.Write(message + " " + response);
                answer = Console.ReadLine();
            } while (response.IndexOf(answer.ToUpper()) == -1);
            return answer;
        }       
        static void m_showheader(int Width)
        {
            Console.ForegroundColor = ConsoleColor.Green;            
            string h1 = " ╔════════════════════════════════════════╗";
            string h2 = " ║       PROGRAM: STUDENT ATTENDANT       ║";
            string h3 = " ║------------------oOo-------------------║";
            string h4 = " ║    AUTHOR:Tran Nguyen Dong Quan        ║";
            string h5 = " ║    ASSESMENT: Advanced Programing      ║";
            string h6 = " ║---------- BRIDGE DESIGN PARTTEN -------║";
            string h7 = " ╚════════════════════════════════════════╝";
            string header = h1 + "\n" + h2 + "\n" + h3 + "\n" + h4 + "\n" + h5 + "\n" + h6 + "\n" + h7 + "\n";
            Console.WriteLine(header);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            header = " AUTHENTICATION ZONE ";
            string space = new string(' ', (Width - header.Length) / 2);
            Console.Write(space); Console.Write(header);Console.Write(space);
            Console.WriteLine();
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
        /// <summary>
        /// Input and check if user information provied is valid
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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
                m_showheader(40);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("         User Name: (type * to exit)");
                _username = Console.ReadLine();
                if (_username != "*")
                {
                    Console.Write("         Password: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    string _password = m_getPassword();
                    _select = f_checklogin(_username, _password);
                    COLE Ole = new COLE();
                    Program.sPersonid = Ole.m_getpersonid(_username);
                    string select;
                    int exit;
                    switch (_select)
                    {
                        case 0:
                            AbstractMenuControl StudentControl = new MenuControl(new StudentMenu());
                            do
                            {
                                exit = StudentControl.DisplayMenu();
                                select = StudentControl.SelectMenuItem();
                                StudentControl.PerformTask();
                            } while (select != exit.ToString());
                            Console.Clear();
                            break;
                        case 1:
                            AbstractMenuControl TeacherControl = new MenuControl(new TeacherMenu());
                            do
                            {
                                exit = TeacherControl.DisplayMenu();
                                select = TeacherControl.SelectMenuItem();
                                TeacherControl.PerformTask();
                            } while (select != exit.ToString());
                            Console.Clear();
                            break;
                        case 2:
                            AbstractMenuControl AdminControl = new MenuControl(new AdminMenu());
                            do
                            {
                                exit = AdminControl.DisplayMenu();
                                select = AdminControl.SelectMenuItem();
                                AdminControl.PerformTask();
                            } while (select != exit.ToString());
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
                }
                else
                    break;
            } while (_select != -1);
            
            Console.Clear();
        }
    }
}
