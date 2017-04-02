using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace SerialKon
{
    class Program
    {
        public static SerialPort port = new SerialPort();

        static void Main(string[] args)
        {
            while (true)
            {
                if (port.IsOpen)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(port.PortName);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("::");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(port.BaudRate);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("NoSerial");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(">> ");

                List<string> com = new List<string>();
                com = StrMod.Divide(Console.ReadLine());

                if (com.Count > 0)
                {
                    switch (com[0])
                    {
                        case "write":
                            if (port.IsOpen)
                            {
                                try
                                {
                                    int num = Convert.ToInt32(com[1]);
                                    if (num <= 255)
                                    {
                                        char a = Convert.ToChar(num);
                                        port.Write(a.ToString());
                                    }
                                    else
                                    {
                                        Console.WriteLine("\"{0}\" is bigger than 255.", com[1]);
                                    }
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("\"{0}\" is not an integral number.", com[1]);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Something is going wrong with the serial \"{0}\", it may not exist and/or be connected. \"serial help\" for more.", port.PortName);
                            }
                            break;

                        case "serial":
                            if (com.Count > 1)
                            {
                                switch (com[1])
                                {
                                    case "connect":
                                        connect();
                                        break;

                                    case "set":
                                        if (com.Count > 2)
                                        {
                                            if (com.Count > 3)
                                            {
                                                switch (com[2])
                                                {
                                                    case "name":
                                                        if (port.IsOpen)
                                                        {
                                                            port.Close();
                                                            Console.WriteLine("Serial disconnected.");
                                                        }
                                                        string portname = com[3];
                                                        port.PortName = portname;
                                                        break;

                                                    case "rate":
                                                        if (port.IsOpen)
                                                        {
                                                            port.Close();
                                                            Console.WriteLine("Serial disconnected.");
                                                        }
                                                        string rate = com[3];
                                                        try
                                                        {
                                                            port.BaudRate = Convert.ToInt32(rate);
                                                        }
                                                        catch (Exception e)
                                                        {
                                                            Console.WriteLine("\"{0}\" is not an integrer number.", com[3]);
                                                            break;
                                                        }
                                                        break;

                                                    default:
                                                        Console.WriteLine("Variable \"{0}\" does not exist in serial.", com[2]);
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Please specify the value to set the variable, \"serial help\" for more info.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Please specify the variable to set, \"serial help\" for more info.");
                                        }
                                        break;

                                    case "help":
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("\"serial help\"");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(": Displays this help.");

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("\"serial set\"");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(": Sets a serial variable like:");
                                        Console.WriteLine("     -name: \"serial set name COM1\".");
                                        Console.WriteLine("     -rate: \"serial set rate 9600\".");

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("\"serial connect\"");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(": Retries connection to serial.");

                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("\"serial close\"");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(": Closes connection to serial.");
                                        break;

                                    case "close":
                                        if (port.IsOpen)
                                        {
                                            port.Close();
                                        }
                                        else
                                        {
                                            Console.WriteLine("Serial is already closed.");
                                        }
                                        break;

                                    default:
                                        Console.WriteLine("\"{0}\" is not a serial command, try \"serial help\".", com[1]);
                                        break;
                                }
                            }
                            break;

                        case "clear":
                            Console.Clear();
                            break;

                        case "help":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\"help\"");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(": Displays this help.");

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\"serial\"");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(": Modifies the serial, for more help \"serial help\".");

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\"write\"");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(": Writes a number from 0 to 255 (Both included) to the serial.");

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("\"clear\"");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(": Clears the console.");
                            break;

                        default:
                            Console.WriteLine("Command \"{0}\" does not exist.", com[0]);
                            break;
                    }
                }
            }
        }

        static void connect()
        {
            Console.Write("Opening serial {0} {1}... ", port.PortName, port.BaudRate);

            try
            {
                port.Open();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DONE!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("FAIL");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
