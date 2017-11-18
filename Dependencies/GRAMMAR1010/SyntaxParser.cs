
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

            pattern = new ProductionPattern((int) SyntaxConstants.PJOLLICS,
                                            "PJOLLICS");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.MAMSIR, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PGLOBAL, 0, 1);
            alt.AddToken((int) SyntaxConstants.TRAY, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PFUNCTION, 0, 1);
            alt.AddToken((int) SyntaxConstants.THANKS, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PGLOBAL,
                                            "PGLOBAL");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PGLOBALC, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PGLOBAL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PGLOBALC,
                                            "PGLOBALC");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PVARDEC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PCONSTDEC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PFUNCDEC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PSTRUCT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PVARDEC,
                                            "PVARDEC");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PDTYPE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PIDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PVARDECTAIL, 0, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PDTYPE,
                                            "PDTYPE");
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

            pattern = new ProductionPattern((int) SyntaxConstants.PIDENTI,
                                            "PIDENTI");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PARRAY, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PARRAY,
                                            "PARRAY");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OB, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCTR, 1, 1);
            alt.AddToken((int) SyntaxConstants.CB, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PARRAY2, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PARRAY2,
                                            "PARRAY2");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OB, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCTR, 1, 1);
            alt.AddToken((int) SyntaxConstants.CB, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCTR,
                                            "PCTR");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCTRCHOICE, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PIDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCTRCHOICE, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCTRCHOICE,
                                            "PCTRCHOICE");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.POP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCALC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.POP1, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PVARDECTAIL,
                                            "PVARDECTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PIDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PVARDECTAIL, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PVTCHOICE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PVTCHOICE,
                                            "PVTCHOICE");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PARRAYTAIL2, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PVALUE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PARRAYTAIL,
                                            "PARRAYTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PARRAYTAIL2, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PARRAYTAIL2,
                                            "PARRAYTAIL2");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PVALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PVALUETAIL, 0, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PARRAYTAIL3, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PARRAYTAIL3,
                                            "PARRAYTAIL3");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PARRAYTAIL2, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PVALUE,
                                            "PVALUE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SPAGLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.PIELIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PNUM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EGG, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PNUM,
                                            "PNUM");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GETNUM, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCTR, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PVALUETAIL,
                                            "PVALUETAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PVALUE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PVALUETAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCONSTDEC,
                                            "PCONSTDEC");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.TEA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PDTYPE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PIDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCONSTDECTAIL, 0, 1);
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCONSTVAL, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCONSTDECTAIL,
                                            "PCONSTDECTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PIDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCONSTDECTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCONSTVAL,
                                            "PCONSTVAL");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PARRAYTAIL2, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PVALUE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PSTRUCT,
                                            "PSTRUCT");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.BURGER, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PVARDEC, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PFUNCDEC,
                                            "PFUNCDEC");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PFTYPE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PPARAM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PFTYPE,
                                            "PFTYPE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.VOID, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PDTYPE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PPARAM,
                                            "PPARAM");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PDTYPE, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PPARAMTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PPARAMTAIL,
                                            "PPARAMTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PPARAM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PPARAMTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PBODY,
                                            "PBODY");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODYCHOICE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GOTO, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PVARDEC, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PDINEIN, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PTAKEOUT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PPOPO, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PCHICKENJOY, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PICECREAM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PFRENCHFRIES, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PBODYCHOICE,
                                            "PBODYCHOICE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COL, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PARRAY, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PMATHCHOICE, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PCALLFUNC, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PMATHCHOICE,
                                            "PMATHCHOICE");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.POP1, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PMATH, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCALLFUNC,
                                            "PCALLFUNC");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PPASS, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PPASS1, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PPASS,
                                            "PPASS");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PPASS1,
                                            "PPASS1");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.COMMA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PPASS, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PPASS1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PMATH,
                                            "PMATH");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCALC, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCALC,
                                            "PCALC");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PVAL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PMATHOP, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PVAL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PMATHOP, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PMATHOP,
                                            "PMATHOP");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.POP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCALC1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCALC1,
                                            "PCALC1");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PCALC, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.POP,
                                            "POP");
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

            pattern = new ProductionPattern((int) SyntaxConstants.PINCDEC,
                                            "PINCDEC");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PIDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.POP1, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.POP1,
                                            "POP1");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.INC, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DEC, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PLOGICAL,
                                            "PLOGICAL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.AND, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PLOGICAL1,
                                            "PLOGICAL1");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NOT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PLOGICON,
                                            "PLOGICON");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCOND, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PLOGICAL, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCOND, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PLOGICONTAIL, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PLOGICAL1, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCOND, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PLOGICONTAIL,
                                            "PLOGICONTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PLOGICAL, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCOND, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PLOGICONTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCOND,
                                            "PCOND");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PCOMP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCEX, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCOMP, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SPAGLIT, 1, 1);
            alt.AddToken((int) SyntaxConstants.ISEQ, 1, 1);
            alt.AddToken((int) SyntaxConstants.SPAGLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.PIELIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCOMP,
                                            "PCOMP");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PMATHOP, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GETNUM, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCTR, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PMATHOP, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PIDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PMATHOP, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PVAL,
                                            "PVAL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PNUM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCEX,
                                            "PCEX");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ISEQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LESS, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GREAT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.LEQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.GEQ, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NOTEQ, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PDINEIN,
                                            "PDINEIN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.DINEIN, 1, 1);
            alt.AddToken((int) SyntaxConstants.EXT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PIDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PIN, 0, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PIN,
                                            "PIN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EXT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PIDENTI, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PIN, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PTAKEOUT,
                                            "PTAKEOUT");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.TAKEOUT, 1, 1);
            alt.AddToken((int) SyntaxConstants.EXT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.POUT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.POUTTAIL, 0, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.POUT,
                                            "POUT");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PCTR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCTRCHOICE, 0, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SPAGLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCTR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCTRCHOICE, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.POUTTAIL,
                                            "POUTTAIL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EXT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.POUT, 1, 1);
            alt.AddProduction((int) SyntaxConstants.POUTTAIL, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PPOPO,
                                            "PPOPO");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.POPO, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PINITIAL, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCONDCHOICE, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PINCDEC, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PINITIAL,
                                            "PINITIAL");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUM, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.EQ, 1, 1);
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PFRENCHFRIES,
                                            "PFRENCHFRIES");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.FRIES, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCONDCHOICE, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.FRENCH, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            alt.AddToken((int) SyntaxConstants.FRIES, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCONDCHOICE, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCHICKENJOY,
                                            "PCHICKENJOY");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CHICKEN, 1, 1);
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PJOY, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PYUM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PJOY,
                                            "PJOY");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.JOY, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCHOICE, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            alt.AddToken((int) SyntaxConstants.GRAVY, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PJOY1, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PJOY1,
                                            "PJOY1");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PJOY, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCHOICE,
                                            "PCHOICE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SPAGLIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.NUMLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PYUM,
                                            "PYUM");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.YUM, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            alt.AddToken((int) SyntaxConstants.GRAVY, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PICECREAM,
                                            "PICECREAM");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PICE, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCREAMICE, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PCREAM, 0, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PICE,
                                            "PICE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ICE, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCONDCHOICE, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCONDCHOICE,
                                            "PCONDCHOICE");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PCOND, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PLOGICON, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCREAMICE,
                                            "PCREAMICE");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CREAMICE, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PCONDCHOICE, 1, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PCREAM,
                                            "PCREAM");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.CREAM, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PFUNCTION,
                                            "PFUNCTION");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.ID, 1, 1);
            alt.AddToken((int) SyntaxConstants.OP, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PPARAM, 0, 1);
            alt.AddToken((int) SyntaxConstants.CP, 1, 1);
            alt.AddToken((int) SyntaxConstants.OBR, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PBODY, 0, 1);
            alt.AddProduction((int) SyntaxConstants.PRETURN, 1, 1);
            alt.AddToken((int) SyntaxConstants.CBR, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PRETURN,
                                            "PRETURN");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.EXTRA, 1, 1);
            alt.AddProduction((int) SyntaxConstants.PRET, 1, 1);
            alt.AddToken((int) SyntaxConstants.TERM, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) SyntaxConstants.PRET,
                                            "PRET");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) SyntaxConstants.PCTR, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.PIELIT, 1, 1);
            pattern.AddAlternative(alt);
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) SyntaxConstants.SPAGLIT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);
        }
    }
}
