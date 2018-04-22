using System;

namespace _355_Easy {
    public class ConsoleIOTool : IIOTool {
        public string Read() {
            return Console.ReadLine();
        }

        public void Write(string output) {
            Console.WriteLine(output);
        }
    }
}