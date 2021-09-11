using System;
using System.Linq;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


namespace TuringMachineConsole
{
    class Program
    {

        static void Main(string[] args)
        {
            int state = 1;
            string tape = "abb";
            string alhpabet = "_ab";          

            Dictionary<KeyValuePair<char, int>, string> configuration = new();
            configuration.Add(new KeyValuePair<char, int>('_', 2), "_L5");
            configuration.Add(new KeyValuePair<char, int>('_', 3), "_L5");
            configuration.Add(new KeyValuePair<char, int>('_', 4), "_L5");
            configuration.Add(new KeyValuePair<char, int>('_', 5), "_R7");
            configuration.Add(new KeyValuePair<char, int>('_', 6), "_N0");
            configuration.Add(new KeyValuePair<char, int>('a', 1), "aR2");
            configuration.Add(new KeyValuePair<char, int>('a', 2), "aR3");
            configuration.Add(new KeyValuePair<char, int>('a', 3), "aR4");
            configuration.Add(new KeyValuePair<char, int>('a', 4), "aR6");
            configuration.Add(new KeyValuePair<char, int>('a', 5), "_L5");
            configuration.Add(new KeyValuePair<char, int>('a', 6), "aR6");
            configuration.Add(new KeyValuePair<char, int>('b', 1), "bR2");
            configuration.Add(new KeyValuePair<char, int>('b', 2), "bR3");
            configuration.Add(new KeyValuePair<char, int>('b', 3), "bR4");
            configuration.Add(new KeyValuePair<char, int>('b', 4), "bR6");
            configuration.Add(new KeyValuePair<char, int>('b', 5), "_L5");
            configuration.Add(new KeyValuePair<char, int>('b', 6), "bR6");
            configuration.Add(new KeyValuePair<char, int>('_', 7), "aR6");


            //get simbol
            char carett = default;

            int position = 0;

            
            while (state != 0)
            {
                carett = tape[position];
                string command = "";
                if (!configuration.TryGetValue(new KeyValuePair<char, int>(carett, state), out command))
                {
                    Console.WriteLine("Undefined configuration");
                    break;
                }
                StringBuilder sb = new();
                sb.Append(tape);
                sb[position] = command[0];

                if (command[1] == 'R')
                {
                    position++;
                } else if (command[1] == 'L')
                {
                    position--;
                }

                if (position < 0)
                {
                    sb.Insert(0, '_');
                    position = 0;
                } else if (position == sb.Length)
                {
                    sb.Append('_');
                }
                state = int.Parse(command[2].ToString());

                tape = sb.ToString();
                Console.WriteLine(tape);
                sb.Clear();
            }
        }
    }
}
