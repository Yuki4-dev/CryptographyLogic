#nullable enable

using CryptographyLogic.Core;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Execute(args);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            Console.Error.WriteLine(ex.StackTrace);
        }
    }

    private static void Execute(string[] args)
    {
        var arg = Argument.Create(args);
        if (arg.ExecuteType == ExecuteType.Help)
        {
            Console.WriteLine(CryptographyLogicConfig.DetailToString());
            return;
        }

        if (!File.Exists(arg.FilePath))
        {
            throw new ArgumentException($"{arg.FilePath} is Not Found.");
        }

        var text = File.ReadAllText(arg.FilePath, CryptographyLogicConfig.TEXT_ENCODING);
        var logic = new BasicCryptographyLogic();
        if (arg.ExecuteType == ExecuteType.EnCryptography)
        {
            Console.WriteLine(logic.EnCryptography(text, arg.Password));
        }
        else
        {
            Console.WriteLine(logic.DeCryptographyy(text, arg.Password));
        }
    }

    private class Argument
    {
        public ExecuteType ExecuteType { get; }

        public string Password { get; }

        public string FilePath { get; }

        public Argument()
        {
            ExecuteType = ExecuteType.Help;
            Password = string.Empty;
            FilePath = string.Empty;
        }

        public Argument(ExecuteType executeType, string password, string filePath)
        {
            ExecuteType = executeType;
            Password = password;
            FilePath = filePath;
        }

        public static Argument Create(string[] args)
        {
            if (args.Length < 1)
            {
                throw new ArgumentException("Argument is Nothing.");
            }

            var typeStr = args[0];
            if (typeStr == "-h")
            {
                return new Argument();
            }

            if (args.Length != 3)
            {
                throw new ArgumentException($"{string.Join(',', args)} is Invalid.");
            }

            var pass = args[1];
            var path = args[2];
            if (typeStr is not "-e" and not "-d")
            {
                throw new ArgumentException($"{string.Join(',', args)} is Invalid.");
            }

            var exeType = ExecuteType.EnCryptography;
            if (typeStr == "-d")
            {
                exeType = ExecuteType.DeCryptographyy;
            }

            return new Argument(exeType, pass, path);
        }
    }

    private enum ExecuteType
    {
        Help, EnCryptography, DeCryptographyy
    }
}