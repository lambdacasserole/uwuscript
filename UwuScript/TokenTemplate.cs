using System.Text.RegularExpressions;

namespace UwuScript
{
    /// <summary>
    /// Represents a regular expression template of a token type.
    /// </summary>
    public class TokenTemplate
    {
        /// <summary>
        /// Gets the regular expression that matches a token of this type.
        /// </summary>
        public Regex Pattern { get; private set; }

        /// <summary>
        /// Gets the token type that maps to the template pattern.
        /// </summary>
        public TokenType Type { get; private set; }

        /// <summary>
        /// Initializes a new instance of a regular expression template of a token type.
        /// </summary>
        /// <param name="pattern">The regular expression that matches a token of this type.</param>
        /// <param name="type">The token type that maps to the template pattern.</param>
        public TokenTemplate(Regex pattern, TokenType type)
        {
            Pattern = pattern;
            Type = type;
        }

        /// <summary>
        /// Initializes a new instance of a regular expression template of a token type.
        /// </summary>
        /// <param name="pattern">The regular expression string that matches a token of this type.</param>
        /// <param name="type">The token type that maps to the template pattern.</param>
        public TokenTemplate(string pattern, TokenType type)
            : this(new Regex(pattern, RegexOptions.Multiline), type)
        {
        }
    }
}
