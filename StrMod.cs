using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialKon
{
    class StrMod
    {
        public static List<string> Divide(string inp)
        {
            List<string> l = new List<string>();
            string buff = string.Empty;

            for (int i = 0; i < inp.Length; i++)
            {
                char c = inp[i];

                if (buff != string.Empty)
                {
                    if (c == ' ')
                    {
                        l.Add(buff);
                        buff = string.Empty;
                    }
                    else if (i == inp.Length - 1)
                    {
                        buff += c;
                        l.Add(buff);
                        buff = string.Empty;
                    }
                }
                else if (i == inp.Length - 1)
                {
                    l.Add(c.ToString());
                }

                if (c != ' ')
                {
                    buff += c;
                }
            }

            return l;
        }

        public static string Erase(string inp, string dic)
        {
            string buff = string.Empty;

            foreach (char a in inp)
            {
                bool add = true;

                foreach (char b in dic)
                {
                    if (a == b)
                        add = false;
                }

                if (add == true)
                    buff += a;
            }

            return buff;
        }

        public static string Alpha(string inp, int mode)
        {
            string buff = string.Empty;

            switch (mode)
            {
                case 0:
                    buff = inp.ToLower();
                    break;
                case 1:
                    buff = inp.ToUpper();
                    break;
            }

            return buff;
        }
    }
}
