namespace Cooking
{
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    using System;

    public static class Helper
    {
        public static string PropToString(object obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            string output = string.Empty;
            foreach (PropertyInfo propInfo in
                from pinfo in obj.GetType().GetProperties()
                where pinfo.GetCustomAttributes(typeof(ImportantPropertyAttribute), false).Length > 0
                select pinfo)
            {
                output += propInfo.Name + " = " + propInfo.GetValue(obj) + " | " + propInfo.GetCustomAttribute<ImportantPropertyAttribute>().Reason;
            }
            return output;
        }

        public static void PrintToConsole<T>(this IEnumerable<T> input, string str = "")
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\tBEGIN: " + str);
            Console.ResetColor();

            foreach (T item in input)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine('\t' + str + " END.\t(Press a key)");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
