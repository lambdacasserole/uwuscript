using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UwuScript
{ 
    /// <summary>
    /// Represents a Turing machine.
    /// </summary>
    public class TuringMachine
    { 
        /// <summary>
        /// The program this interpreter will execute.
        /// </summary>
        private IList<Token> program;

        /// <summary>
        /// The length of the program to execute.
        /// </summary>
        private int length;
        
        /// <summary>
        /// The program instruction pointer.
        /// </summary>
        private int programPointer;

        /// <summary>
        /// The interpreter's memory storage.
        /// </summary>
        private byte[] memory;

        /// <summary>
        /// The program memory pointer.
        /// </summary>
        private int memoryPointer;

        /// <summary>
        /// Initialises a new instance of a Turing machine set to execute the specified program.
        /// </summary>
        /// <param name="program">The list of instruction tokens to execute.</param>
        public TuringMachine(IList<Token> program)
        {
            // Initialise program and instruction pointer.
            this.program = program;
            length = this.program.Count;

            // Initialize memory.
            memoryPointer = 0;
            memory = new byte[32768]; // 32 kilobytes will do.
        }

        /// <summary>
        /// Jumps the program pointer to a matching character.
        /// </summary>
        /// <param name="forward">Whether or not to jump the pointer forward.</param>
        /// <param name="tokens">The tokens and their jump values.</param>
        private void Jump(bool forward, Dictionary<TokenType, int> tokens)
        {
            int l = 1;
            while (l > 0) {
                programPointer += forward ? 1 : -1;
                if (tokens.ContainsKey(program[programPointer].Type))
                {
                    l += tokens[program[programPointer].Type];
                }
            }
        }

        /// <summary>
        /// Runs the loaded program.
        /// </summary>
        public void Run()
        {
            // Loop through instructions.
            while (programPointer < length) {
                switch (program[programPointer].Type) {
                    case TokenType.MoveRight:
                        // Move to next memory cell.
                        memoryPointer++;
                        break;
                    case TokenType.MoveLeft:
                        // Move to previous memory cell.
                        memoryPointer--;
                        break;
                    case TokenType.Increment:
                        // Increment current memory cell.
                        memory[memoryPointer]++;
                        break;
                    case TokenType.Decrement:
                        // Decrement current memory cell.
                        memory[memoryPointer]--;
                        break;
                    case TokenType.StartLoop:
                        // If current memory cell is 0, jump past the matching ']' symbol.
                        Dictionary<TokenType, int> startJumpValues = new Dictionary<TokenType, int>
                        {
                            { TokenType.StartLoop, 1 },
                            { TokenType.EndLoop, -1 }
                        };
                        if (memory[memoryPointer] == 0) {
                            Jump(true, startJumpValues);
                        }
                        break;
                    case TokenType.EndLoop:
                        // If current memory cell is not 0, jump back to the matching '[' symbol.
                        Dictionary<TokenType, int> endJumpValues = new Dictionary<TokenType, int>
                        {
                            { TokenType.StartLoop, -1 },
                            { TokenType.EndLoop, 1 }
                        };
                        if (memory[memoryPointer] != 0) {
                            Jump(false, endJumpValues);
                        }
                        break;
                    case TokenType.Output:
                        // Output character.
                        Console.Write(Encoding.ASCII.GetChars(new byte[] { memory[memoryPointer] }));
                        break;
                    case TokenType.Input:
                        // Read character from input.
                        memory[memoryPointer] = (byte) Console.Read();
                        break;
                    default:
                        // Do nothing.
                        break;
                }
                programPointer++;
            }
        }
    }
}
