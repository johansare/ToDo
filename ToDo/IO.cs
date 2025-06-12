namespace ToDo
{
    internal class IO
    {
        public static void Clear() => Console.Clear();

        public static void Write(string text) => Console.Write(text);
        public static void Write(string text, ConsoleColor color)
        {
            var s = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = s;
        }

        public static void WriteLine(string text) => Console.WriteLine(text);

        public static void WriteLine(string text, ConsoleColor color)
        {
            var s = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = s;
        }
        public static ConsoleKeyInfo ReadKey(bool intercept = false) => Console.ReadKey(intercept);
        public static ConsoleKeyInfo ReadKey(
            string prompt,
            ConsoleColor color = ConsoleColor.DarkCyan,
            bool intercept = false)
        {
            IO.Write(prompt, color);
            return IO.ReadKey(intercept);
        }

        public static string? ReadLine() => Console.ReadLine();

        public static string ReadString(string prompt, bool allowEmpty = false)
        {
            string? input;
            do
            {
                IO.Write(prompt, ConsoleColor.DarkCyan);
                input = IO.ReadLine();
                if (string.IsNullOrEmpty(input) && allowEmpty)
                {
                    return "";
                }
            } while (string.IsNullOrEmpty(input));
            return input.Trim();
        }

        public static DateTime ReadDate(string prompt)
        {
            DateTime date;
            string? input;
            do
            {
                IO.Write(prompt, ConsoleColor.DarkCyan);
                input = IO.ReadLine();
            } while (!DateTime.TryParse(input, out date));
            return date;
        }

        public static int ReadIndex(string prompt)
        {
            int integer;
            string? input;
            do
            {
                IO.Write(prompt, ConsoleColor.DarkCyan);
                input = IO.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    return -1;
                }
            } while (!int.TryParse(input, out integer));
            return integer;
        }

        public static void WaitForAnyKey(
            string prompt = "\nPress Any Key: ",
            ConsoleColor color = ConsoleColor.DarkCyan
        )
        {
            IO.Write(prompt, color);
            IO.ReadKey(true);
        }
    }
}