using System;
using System.IO;
using System.Collections.Generic;


namespace UwuScript
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a file name.");
            }

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
                Console.WriteLine("ERROR: File " + filepath + " does not exist.");
            } else
            {
                try
                {

                    string fText = File.ReadAllText(filepath);

                    // Tokenize source.
                    IList<Token> tokens = tokenizer.Tokenize(fText + "\r\n");

                    // Execute program.
                    TuringMachine machine = new TuringMachine(tokens);
                    machine.Run();
                } catch (ArgumentException a)
                {
                    Console.Error.WriteLine("ERROR: File " + filepath + " is invalid.");
                    Console.Error.WriteLine(a.Message);
                } catch (PathTooLongException p)
                {
                    Console.Error.WriteLine("ERROR: File path " + filepath + " is too long.");
                    Console.Error.WriteLine(p.Message);
                } catch (IOException i)
                {
                    Console.Error.WriteLine("ERROR: I/O Exception");
                    Console.Error.WriteLine(i.Message);
                } catch (UnauthorizedAccessException u)
                {
                    Console.Error.WriteLine("ERROR: Unauthorized Access");
                    Console.Error.WriteLine(u.Message);
                } catch (NotSupportedException n)
                {
                    Console.Error.WriteLine("ERROR: Read operation of file not supported");
                } catch (System.Security.SecurityException s)
                {
                    Console.Error.WriteLine("ERROR: SecurityException thrown");
                    Console.Error.WriteLine(s.Message);
                }
            }
        }
    }
}
