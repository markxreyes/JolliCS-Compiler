/*
 * SyntaxTokenizer.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

namespace Syntax_Analyzer {

    /**
     * <remarks>A character stream tokenizer.</remarks>
     */
    public class SyntaxTokenizer : Tokenizer {

        /**
         * <summary>Creates a new tokenizer for the specified input
         * stream.</summary>
         *
         * <param name='input'>the input stream to read</param>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        public SyntaxTokenizer(TextReader input)
            : base(input, false) {

            CreatePatterns();
        }

        /**
         * <summary>Initializes the tokenizer by creating all the token
         * patterns.</summary>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        private void CreatePatterns() {
            TokenPattern  pattern;

            pattern = new TokenPattern((int) SyntaxConstants.BURGER,
                                       "BURGER",
                                       TokenPattern.PatternType.STRING,
                                       "burger");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.CHICKEN,
                                       "CHICKEN",
                                       TokenPattern.PatternType.STRING,
                                       "chicken");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.CHOCO,
                                       "CHOCO",
                                       TokenPattern.PatternType.STRING,
                                       "pielit");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.CREAM,
                                       "CREAM",
                                       TokenPattern.PatternType.STRING,
                                       "cream");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.CREAMICE,
                                       "CREAMICE",
                                       TokenPattern.PatternType.STRING,
                                       "creamice");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.DINEIN,
                                       "DINEIN",
                                       TokenPattern.PatternType.STRING,
                                       "dinein");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.EGG,
                                       "EGG",
                                       TokenPattern.PatternType.STRING,
                                       "egg");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.EXTRA,
                                       "EXTRA",
                                       TokenPattern.PatternType.STRING,
                                       "extra");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.FRENCH,
                                       "FRENCH",
                                       TokenPattern.PatternType.STRING,
                                       "french");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.FRIES,
                                       "FRIES",
                                       TokenPattern.PatternType.STRING,
                                       "fries");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.GETNUM,
                                       "GETNUM",
                                       TokenPattern.PatternType.STRING,
                                       "getnum");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.GRAVY,
                                       "GRAVY",
                                       TokenPattern.PatternType.STRING,
                                       "gravy");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.GOTO,
                                       "GOTO",
                                       TokenPattern.PatternType.STRING,
                                       "goto");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.ICE,
                                       "ICE",
                                       TokenPattern.PatternType.STRING,
                                       "ice");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.JOY,
                                       "JOY",
                                       TokenPattern.PatternType.STRING,
                                       "joy");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.MALLOW,
                                       "MALLOW",
                                       TokenPattern.PatternType.STRING,
                                       "pielit");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.MAMSIR,
                                       "MAMSIR",
                                       TokenPattern.PatternType.STRING,
                                       "mamsir");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.TEA,
                                       "TEA",
                                       TokenPattern.PatternType.STRING,
                                       "tea");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.VOID,
                                       "VOID",
                                       TokenPattern.PatternType.STRING,
                                       "void");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.POPO,
                                       "POPO",
                                       TokenPattern.PatternType.STRING,
                                       "popo");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.RICE,
                                       "RICE",
                                       TokenPattern.PatternType.STRING,
                                       "rice");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.TRAY,
                                       "TRAY",
                                       TokenPattern.PatternType.STRING,
                                       "tray");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.TAKEOUT,
                                       "TAKEOUT",
                                       TokenPattern.PatternType.STRING,
                                       "takeout");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.THANKS,
                                       "THANKS",
                                       TokenPattern.PatternType.STRING,
                                       "thanks");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.ID,
                                       "ID",
                                       TokenPattern.PatternType.STRING,
                                       "identifier");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.PIE,
                                       "PIE",
                                       TokenPattern.PatternType.STRING,
                                       "pie");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.NUM,
                                       "NUM",
                                       TokenPattern.PatternType.STRING,
                                       "num");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.SPAG,
                                       "SPAG",
                                       TokenPattern.PatternType.STRING,
                                       "spag");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.NUMLIT,
                                       "NUMLIT",
                                       TokenPattern.PatternType.STRING,
                                       "numlit");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.SPAGLIT,
                                       "SPAGLIT",
                                       TokenPattern.PatternType.STRING,
                                       "spaglit");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.PIELIT,
                                       "PIELIT",
                                       TokenPattern.PatternType.STRING,
                                       "pielit");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.COMMA,
                                       "COMMA",
                                       TokenPattern.PatternType.STRING,
                                       ",");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.OBR,
                                       "OBR",
                                       TokenPattern.PatternType.STRING,
                                       "{");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.CBR,
                                       "CBR",
                                       TokenPattern.PatternType.STRING,
                                       "}");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.OP,
                                       "OP",
                                       TokenPattern.PatternType.STRING,
                                       "(");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.CP,
                                       "CP",
                                       TokenPattern.PatternType.STRING,
                                       ")");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.OB,
                                       "OB",
                                       TokenPattern.PatternType.STRING,
                                       "[");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.CB,
                                       "CB",
                                       TokenPattern.PatternType.STRING,
                                       "]");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.COL,
                                       "COL",
                                       TokenPattern.PatternType.STRING,
                                       ":");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.NEG,
                                       "NEG",
                                       TokenPattern.PatternType.STRING,
                                       "~");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.EQ,
                                       "EQ",
                                       TokenPattern.PatternType.STRING,
                                       "=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.ADD,
                                       "ADD",
                                       TokenPattern.PatternType.STRING,
                                       "+");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.SUB,
                                       "SUB",
                                       TokenPattern.PatternType.STRING,
                                       "-");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.MUL,
                                       "MUL",
                                       TokenPattern.PatternType.STRING,
                                       "*");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.DIV,
                                       "DIV",
                                       TokenPattern.PatternType.STRING,
                                       "/");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.MOD,
                                       "MOD",
                                       TokenPattern.PatternType.STRING,
                                       "%");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.INC,
                                       "INC",
                                       TokenPattern.PatternType.STRING,
                                       "++");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.DEC,
                                       "DEC",
                                       TokenPattern.PatternType.STRING,
                                       "--");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.LESS,
                                       "LESS",
                                       TokenPattern.PatternType.STRING,
                                       "<");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.GREAT,
                                       "GREAT",
                                       TokenPattern.PatternType.STRING,
                                       ">");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.LEQ,
                                       "LEQ",
                                       TokenPattern.PatternType.STRING,
                                       "<=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.GEQ,
                                       "GEQ",
                                       TokenPattern.PatternType.STRING,
                                       ">=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.ISEQ,
                                       "ISEQ",
                                       TokenPattern.PatternType.STRING,
                                       "==");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.NOTEQ,
                                       "NOTEQ",
                                       TokenPattern.PatternType.STRING,
                                       "!=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.NOT,
                                       "NOT",
                                       TokenPattern.PatternType.STRING,
                                       "!");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.AND,
                                       "AND",
                                       TokenPattern.PatternType.STRING,
                                       "&&");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.OR,
                                       "OR",
                                       TokenPattern.PatternType.STRING,
                                       "||");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.TERM,
                                       "TERM",
                                       TokenPattern.PatternType.STRING,
                                       "$");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.EXT,
                                       "EXT",
                                       TokenPattern.PatternType.STRING,
                                       "//");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.COM1,
                                       "COM1",
                                       TokenPattern.PatternType.STRING,
                                       "'");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.COM2,
                                       "COM2",
                                       TokenPattern.PatternType.STRING,
                                       "'");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.WHITESPACE,
                                       "WHITESPACE",
                                       TokenPattern.PatternType.REGEXP,
                                       "[ \\t\\n\\r]+");
            pattern.Ignore = true;
            AddPattern(pattern);
        }
    }
}
