namespace UwuScript
{
    /// <summary>
    /// A token created by the <see cref="Tokenizer"/> class.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// Gets the token type.
        /// </summary>
        public TokenType Type { get; }
        
        /// <summary>
        /// Gets the sequence of characters in the token.
        /// </summary>
        public string Sequence { get; }

        /// <summary>
        /// Gets the column position of the token in the source.
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// Gets the line position of the token in the source.
        /// </summary>
        public int Line { get; }

        /// <summary>
        /// Initializes a new instance of a token.
        /// </summary>
        /// <param name="type">The token type.</param>
        /// <param name="sequence">The sequence of characters in the token.</param>
        /// <param name="column">The column position of the token in the source.</param>
        /// <param name="line">The line position of the token in the source.</param>
        public Token(TokenType type, string sequence, int column = -1, int line = -1)
        {
            Type = type;
            Sequence = sequence;
            Column = column;
            Line = line;
        }
    }
}
