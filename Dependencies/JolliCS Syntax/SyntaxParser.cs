/*
 * SyntaxParser.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

namespace Syntax_Analyzer {

    /**
     * <remarks>A token stream parser.</remarks>
     */
    public class SyntaxParser : RecursiveDescentParser {

        /**
         * <summary>An enumeration with the generated production node
         * identity constants.</summary>
         */
        private enum SynteticPatterns {
        }

        /**
         * <summary>Creates a new parser with a default analyzer.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public SyntaxParser(TextReader input)
            : base(input) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new parser.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <param name='analyzer'>the analyzer to parse with</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public SyntaxParser(TextReader input, SyntaxAnalyzer analyzer)
            : base(input, analyzer) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new tokenizer for this parser. Can be overridden
         * by a subclass to provide a custom implementation.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <returns>the tokenizer created</returns>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        protected override Tokenizer NewTokenizer(TextReader input) {
            return new SyntaxTokenizer(input);
        }

        /**
         * <summary>Initializes the parser by creating all the production
         * patterns.</summary>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        private void CreatePatterns() {
            ProductionPattern             pattern;
            ProductionPatternAlternative  alt;

            pattern = new ProductionPattern((int) SyntaxConstants.P_JOLLICS_START,
                                            "P_JOLLICS_START");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.MAMSIR, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_GLOBAL, 0, 1);
            alt.AddToken((int) SyntaxConstants.TRAY, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 0, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_FUNCTION, 0, 1);
            alt.AddToken((int) SyntaxConstants.THANKS, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_GLOBAL,
                                            "P_GLOBAL");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_GLOBAL_C, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_GLOBAL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_GLOBAL_C,
                                            "P_GLOBAL_C");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_VARDEC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_CONSTDEC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_FUNCDEC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_STRUCT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_VARDEC,
                                            "P_VARDEC");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_DTYPE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_IDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_VARDECTAIL, 0, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_DTYPE,
                                            "P_DTYPE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SPAG, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.PIE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_IDENTI,
                                            "P_IDENTI");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_ARRAY, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_ARRAY,
                                            "P_ARRAY");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OB, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CTR, 1, 1);
            alt.AddToken((int) SyntaxConstants.OB, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_ARRAY2, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_ARRAY2,
                                            "P_ARRAY2");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OB, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CTR, 1, 1);
            alt.AddToken((int) SyntaxConstants.CB, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CTR,
                                            "P_CTR");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_CALC, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_VARDECTAIL,
                                            "P_VARDECTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_IDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_VARDECTAIL, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_ARRAYTAIL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_VALUE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_IDENTI, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_ARRAYTAIL,
                                            "P_ARRAYTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_ARRAYTAIL2, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_ARRAYTAIL2,
                                            "P_ARRAYTAIL2");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_VALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_VALUETAIL, 0, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_ARRAYTAIL3, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_ARRAYTAIL3,
                                            "P_ARRAYTAIL3");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_ARRAYTAIL2, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_VALUE,
                                            "P_VALUE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SPAGLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.PIELIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_NUM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_NUM,
                                            "P_NUM");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GETNUM, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_GETN, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_GETN,
                                            "P_GETN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_IDENTI, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_VALUETAIL,
                                            "P_VALUETAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_VALUE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_VAL,
                                            "P_VAL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CONSTDEC,
                                            "P_CONSTDEC");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.TEA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_DTYPE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_IDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CONSTDECTAIL, 0, 1);
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CONSTVAL, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CONSTDECTAIL,
                                            "P_CONSTDECTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_IDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CONSTDECTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CONSTVAL,
                                            "P_CONSTVAL");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_ARRAYTAIL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_VALUE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_STRUCT,
                                            "P_STRUCT");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BURGER, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_VARDEC, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_FUNCDEC,
                                            "P_FUNCDEC");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_FTYPE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_PARAM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_FTYPE,
                                            "P_FTYPE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.VOID, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_NUM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_PARAM,
                                            "P_PARAM");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_DTYPE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_PARAMTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_PARAMTAIL,
                                            "P_PARAMTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_PARAM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.BODY,
                                            "BODY");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODYCHOICE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GOTO, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_VARDEC, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_DINEIN, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_TAKEOUT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_POPO, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_CHICKENJOY, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_ICECREAM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_FRENCHFRIES, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.BODYCHOICE,
                                            "BODYCHOICE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_ARRAY, 0, 1);
            alt.AddProduction((int) SyntaxConstants.P_MATHCHOICE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_CALLFUNC, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_MATHCHOICE,
                                            "P_MATHCHOICE");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_MATH, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_OP1, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CALLFUNC,
                                            "P_CALLFUNC");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_PASS, 0, 1);
            alt.AddProduction((int) SyntaxConstants.P_PASS1, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_PASS,
                                            "P_PASS");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_PASS1,
                                            "P_PASS1");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_PASS1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_MATH,
                                            "P_MATH");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CALC, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CALC,
                                            "P_CALC");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_VAL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_MATHOP, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_VAL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_MATHOP, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_MATHOP,
                                            "P_MATHOP");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CALC1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CALC1,
                                            "P_CALC1");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_CALC, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_OP,
                                            "P_OP");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ADD, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SUB, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.MUL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DIV, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.MOD, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_INCDEC,
                                            "P_INCDEC");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_IDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_OP1, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_OP1,
                                            "P_OP1");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DEC, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_LOGICAL,
                                            "P_LOGICAL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.AND, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NOT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_LOGICON,
                                            "P_LOGICON");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COND, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_LOGICAL, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COND, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_LOGICONTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_LOGICONTAIL,
                                            "P_LOGICONTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_LOGICAL, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COND, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_COND,
                                            "P_COND");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_COMP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CEX, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COMP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_COMP,
                                            "P_COMP");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_MATHOP, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GETNUM, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_GETN, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_VAL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_MATHOP, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_IDCHOICE1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_IDCHOICE1,
                                            "P_IDCHOICE1");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_MATHOP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_ARRAY, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CEX,
                                            "P_CEX");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ISEQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NOTEQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GREAT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LESS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GEQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LEQ, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_DINEIN,
                                            "P_DINEIN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DINEIN, 1, 1);
            alt.AddToken((int) SyntaxConstants.EXT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_IDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_IN, 0, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_IN,
                                            "P_IN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EXT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_IDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_IN, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_TAKEOUT,
                                            "P_TAKEOUT");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.TAKEOUT, 1, 1);
            alt.AddToken((int) SyntaxConstants.EXT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_OUT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_OUTTAIL, 0, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_OUT,
                                            "P_OUT");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_IDENTI, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SPAGLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_OUTTAIL,
                                            "P_OUTTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EXT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_OUT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_OUTTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_POPO,
                                            "P_POPO");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.POPO, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_INITIAL, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COND, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_INCDEC, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_INITIAL,
                                            "P_INITIAL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUM, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_FRENCHFRIES,
                                            "P_FRENCHFRIES");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.FRIES, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COND, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.FRENCH, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            alt.AddToken((int) SyntaxConstants.FRIES, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COND, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CHOICE,
                                            "P_CHOICE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SPAGLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CHICKENJOY,
                                            "P_CHICKENJOY");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHICKEN, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_JOY, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_YUM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_JOY,
                                            "P_JOY");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.JOY, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CHOICE, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.GRAVY, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_JOY1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_JOY1,
                                            "P_JOY1");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_JOY, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_YUM,
                                            "P_YUM");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.GRAVY, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_ICECREAM,
                                            "P_ICECREAM");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_ICE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CREAMICE, 0, 1);
            alt.AddProduction((int) SyntaxConstants.P_CREAM, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_ICE,
                                            "P_ICE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ICE, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CONDITION, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CONDITION,
                                            "P_CONDITION");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_MATHOP, 0, 1);
            alt.AddProduction((int) SyntaxConstants.P_CEX, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COMP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GETNUM, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_GETN, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CEX, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COMP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_IDCHOICE1, 0, 1);
            alt.AddProduction((int) SyntaxConstants.P_CEX, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COMP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_OPCHOICE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_OPCHOICE,
                                            "P_OPCHOICE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GETNUM, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_GETN, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CONDTAIL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_VAL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_MATHOP, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CONDTAIL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_MATHOP, 0, 1);
            alt.AddProduction((int) SyntaxConstants.P_NUMLITCHOICE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_IDCHOICE2, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_VALTAIL,
                                            "P_VALTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CEX, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COMP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CONDTAIL,
                                            "P_CONDTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_LOGICAL, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COND, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_LOGICONTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_NUMLITCHOICE,
                                            "P_NUMLITCHOICE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_NUMLITTAIL, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_NUMLITTAIL,
                                            "P_NUMLITTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_CEX, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COMP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_LOGICAL, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COND, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_LOGICONTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_IDCHOICE2,
                                            "P_IDCHOICE2");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_IDCHOICE3, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_IDCHOICE3,
                                            "P_IDCHOICE3");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_NUMLITCHOICE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_MATHOP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_NUMLITCHOICE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_ARRAY, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_CONDTAIL, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CREAMICE,
                                            "P_CREAMICE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CREAMICE, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_COND, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_CREAM,
                                            "P_CREAM");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CREAM, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_FUNCTION,
                                            "P_FUNCTION");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_PARAM, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.BODY, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_RETURN, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_RETURN,
                                            "P_RETURN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EXTRA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.P_RET, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.P_RET,
                                            "P_RET");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.P_CTR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.PIELIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);
        }
    }
}
