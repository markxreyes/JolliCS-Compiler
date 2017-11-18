using System;
using System.IO;
using System.Collections.Generic;
using Core.Library;

using TokenLibrary;

namespace Syntax_Analyzer
{
    public class SyntaxInitializer : SyntaxAnalyzer
    {
        public string Start(string tokens)
        {
            string result;
            Parser p;
            p = CreateParser(tokens);

            try
            {
                p.Parse();
                Fail("parsing succeeded");
                result = "Syntax Analyzer Succeeded...";
            }
            catch (ParserCreationException e)
            {
                Fail(e.Message);
                result = e.Message;
            }
            catch (ParserLogException e)
            {
                    string errormessage = e.GetError(0).ErrorMessage;
                    if(errormessage.Contains("unexpected token"))
                    {
                        errormessage = "";
                        foreach (var item in e.GetError(0).Details)
                        {
                            errormessage += item + ", "; 
                        }
                    }
                    if (errormessage == "unexpected end of file")
                        errormessage = "\".\"";
                result = e.Message;
            }
            return result;
        }

        private Parser CreateParser(string input)
        {
            Parser parser = null;
            try
            {
                parser = new SyntaxParser(new StringReader(input), this);
                parser.Prepare();

            }
            catch (ParserCreationException e)
            {
                Fail(e.Message);
            }
            return parser;
        }
        protected void Fail(string message)
        {
            if (message != "parsing succeeded")
                throw new Exception(message);
        }      
    }
}
