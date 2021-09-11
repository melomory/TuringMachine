using System.Collections.Generic;
using System.Text;

namespace TuringMachine.Models
{
    internal class TMachine
    {
        public List<string> Report;

        private int state = 1;
        private int position = 0;
        private string tape = "";
        private char carett = default;
        private readonly char left = '\u2192'; // >
        private readonly char right = '\u2190'; // <
        private readonly char emptyValue = '\u03BB';


        private Dictionary<KeyValuePair<char, int>, string> configuration;

        public TMachine(Dictionary<KeyValuePair<char, int>, string> c, string t)
        {
            configuration = c;
            Report = new();
            tape = t;
        }

        public void Run()
        {
            while (state != 0)
            {
                if (tape.Length == 0)
                {
                    Report.Add("Given empty string. Undefined configuration");
                    break;
                }
                carett = tape[position];
                string command = "";
                if (!configuration.TryGetValue(new KeyValuePair<char, int>(carett, state), out command))
                {
                    Report.Add("Undefined configuration");
                    break;
                }
                StringBuilder sb = new();
                sb.Append(tape);
                sb[position] = command[0];

                if (command[1] == right)
                {
                    position++;
                }
                else if (command[1] == left)
                {
                    position--;
                }

                if (position < 0)
                {
                    sb.Insert(0, emptyValue);
                    position = 0;
                }
                else if (position == sb.Length)
                {
                    sb.Append(emptyValue);
                }
                state = int.Parse(command[2].ToString());

                tape = sb.ToString();
                Report.Add(tape);
                sb.Clear();
            }
        }
    }
}
