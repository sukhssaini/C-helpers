using System;
using System.Text;
namespace ConsoleApplication1
{
    public class Config
    {
        public bool alphabets { get; set; }
        public bool numbers { get; set; }
        public bool specialCharacters { get; set; }
        public int length { get; set; }

        public Config()
        {
            alphabets = true;
            numbers = true;
            specialCharacters = true;
            length = 10;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Config config = new Config() { length=12 };
            var password=PasswordGenerator(config);
            Console.WriteLine(password);
            Console.ReadLine();
        }

        public static string PasswordGenerator(Config config)
        {
            if (config.length > 0)
            {
                const string alphabets = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
                const string number = "1234567890";
                const string specialChanracters = "!@#$%^&*()";
                StringBuilder passwordString = new StringBuilder(String.Empty);
                StringBuilder generatedPassword = new StringBuilder(String.Empty);
                try
                {
                    if (config.alphabets)
                    {
                        passwordString.Append(alphabets);
                    }
                    if (config.numbers)
                    {
                        passwordString.Append(number);
                    }
                    if (config.specialCharacters)
                    {
                        passwordString.Append(specialChanracters);
                    }

                    Random rnd = new Random();
                    int length = passwordString.Length - 1;
                    for (int i = 0; i < config.length; i++)
                    {
                        int randomNumber = rnd.Next(0, length);
                        generatedPassword.Append(passwordString[randomNumber]);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return generatedPassword.ToString();
            }
            throw new Exception("Length cannot be less than or equal to zero");
        }
    }
}
