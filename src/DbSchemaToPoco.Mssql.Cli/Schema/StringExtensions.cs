using System;
using System.Text.RegularExpressions;

namespace DbSchemaToPoco.Mssql.Cli.Schema
{
    internal static class StringExtensions
    {
        private static readonly Regex NonAlphanumericRegex = new Regex("[^a-zA-Z0-9]");
        private static readonly Regex NumberRegex = new Regex("[0-9]");
        private const string EscapeCharacter = "_";

        internal static string EscapeIllegalCsharpClassSymbols(this string obj)
        {
            var result = obj;
            var firstCharacterIsIllegalChar = NumberRegex.Match(obj.AsSpan(0, 1).ToString()).Success;
            if (firstCharacterIsIllegalChar)
            {
                result = EscapeCharacter + result;
            }
            return NonAlphanumericRegex.Replace(result, EscapeCharacter);
        }
    }
}