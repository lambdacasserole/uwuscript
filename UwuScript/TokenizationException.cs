using System;

namespace UwuScript
{
    /// <summary>
    /// Represents an error encountered during source tokenization.
    /// </summary>
    public class TokenizationException : Exception
    {
        /// <summary>
        /// Gets the line position in the source at which the tokenizer encountered an error.
        /// </summary>
        public int Line { get; private set; }

        /// <summary>
        /// Gets the column position in the source at which the tokenizer encountered an error.
        /// </summary>
        public int Column { get; private set; }

        /// <summary>
        /// Initializes a new instance of an error encountered during source tokenization.
        /// </summary>
        /// <param name="message">The message to show.</param>
        /// <param name="line">The line position in the source at which the tokenizer encountered an error.</param>
        /// <param name="column">The column position in the source at which the tokenizer encountered an error.</param>
        public TokenizationException(string message, int line, int column) 
            : base(message)
        {
            Line = line;
            Column = column;
        }
    }
}
