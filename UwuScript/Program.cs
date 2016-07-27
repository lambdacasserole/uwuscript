using System;
using System.IO;

namespace UwuScript
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure tokenizer.
            var tokenizer = new Tokenizer();
            tokenizer.Add(@">w>", TokenType.MoveRight);
            tokenizer.Add(@"<w<", TokenType.MoveLeft);
            tokenizer.Add(@"uwu", TokenType.Increment);
            tokenizer.Add(@"nwn", TokenType.Decrement);
            tokenizer.Add(@"owo", TokenType.Output);
            tokenizer.Add(@"-w-", TokenType.Input);
            tokenizer.Add(@"ow<", TokenType.StartLoop);
            tokenizer.Add(@">wo", TokenType.EndLoop);
            tokenizer.Add(@"\s+?", TokenType.Whitespace);
            tokenizer.Add(@"\*w\*.+?\n", TokenType.Comment);

            // Check file exists.
            var filepath = args[0];
            if (!File.Exists(filepath))
            {
                Console.WriteLine("Error opening input file.");
                return;
            }

            // Tokenize source.
            var tokens = tokenizer.Tokenize(File.ReadAllText(filepath) + "\r\n");

            // Execute program.
            var machine = new TuringMachine(tokens);
            machine.Run();
        }
    }
}
