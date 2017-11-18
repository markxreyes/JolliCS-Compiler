namespace Core.Library
{
    public class PredictSets
    {
        string program = "Let, Array, Object, Var, Task, Lead";
        string global = "Let, Array, Object, Var, Task, Lead";
        string global_choice = "Let, Var, Array, Task, Object";
        string datatype = "Int, Double, Char, String, Boolean";
        string let_global = "Let";
        string values = "intlit, doublelit, stringlit, charlit, boollit";
        string vardec = "Var";
        string vardtype = "Int, Double, Char, String, Boolean";
        string varinitINT = "is, ;, .";
        string varinitDOUBLE = "is, ;, .";
        string varinitCHAR = "is, ;, .";
        string varinitSTRING = "is, ;, .";
        string varinitBOOLEAN = "is, ;, .";
        string vartailINT = ";,.";
        string vartailDOUBLE = ";,.";
        string vartailCHAR = ";,.";
        string vartailSTRING = ";,.";
        string vartailBOOLEAN = ";,.";
        string valueCHAR = "id, charlit";
        string valueSTRING = "id, stringlit";
        string valueBOOLEAN = "id, boollit";
        string id_tail = "@, [, (";
        string ids_tail = "@, [, =, ++, --, ;, ., +, -, *, /, %, )";
        string id_choices = "@, ]";
        string task_param = "intlit, doublelit, stringlit, charlit, boollit, id, )";
        string task_param_tail = ";, )";
        string value = "intlit, doublelit, stringlit, charlit, boollit, id";
        string index = "id, intlit";
        string indexop = "+, -";
        string add_min = "+, -";
        string index_value = "id, intlit";
        string index_tail = "[";
        string elements = "id";
        string elements_tail = "@, Start, ;, ), ,, ==, !=, >, >=, <, <=, =, ++, --, ., +, -, *, /, %";
        string array = "Array";
        string size_tail = "by, .";
        string task = "Task";
        string return_type = "Int, Double, Char, String, Boolean, Null";
        string parameters = "(, .";
        string param_tail = "), ;";
        string Object = "Object";
        string object_elem = "Var, Object";
        string object_elem_tail = "End, id";
        string object_var = "id, .";
        string object_var_tail = ";, .";
        string statements = "Object, Clear, Var, Read, Say, Option, Until, Do, For, Array, If, ++, --, id, Stop, End, Response";
        string functions = "Var, Array, Object, Read, Say, ++, --, Clear. Option, If, Until, Do, For, id";
        string io_statement = "Read, Say";
        string output_statement = "stringlit, id";
        string concat = "\",\", .";
        string pre_incdec = "++, --";
        string option = "Option";
        string option_choices = "intlit, charlit, stringlit";
        string optionINT = "intlit";
        string optionCHAR = "charlit";
        string optionSTRING = "stringlit";
        string stateINT = "State, Object, Clear, Var, Read, Say, Option, Until, Do, For, Array, If, ++, --, id, Default";
        string stateCHAR = "State, Object, Clear, Var, Read, Say, Option, Until, Do, For, Array, If, ++, --, id, Default";
        string stateSTRING = "State, Object, Clear, Var, Read, Say, Option, Until, Do, For, Array, If, ++, --, id, Default";
        string def = "Default, End";
        string conditions = "id, intlit, doublelit, stringlit, charlit, boollit, !, (";
        string condition_choices = "id, intlit, doublelit, stringlit, charlit, boollit";
        string condition_tail = "id, intlit, doublelit, stringlit, charlit, boollit";
        string condition_ids = "@, [, (";
        string logOp_tail = "&&, ||, )";
        string logOp_choices = "!, (, boollit";
        string relOp = "==, !=, >, >=, <, <=";
        string StartProgram = "Lead, Let, Array, Object, Var, Task";

        public string GetPredictSet(int code)
        {
            switch (code)
            {
                case 2001: return StartProgram;
                case 2002: return program;
                case 2003: return global;
                case 2004: return global_choice;
                case 2005: return datatype;
                case 2006: return let_global;
                case 2007: return values;
                case 2008: return vardec;
                case 2009: return vardtype;
                case 2010: return varinitINT;
                case 2011: return varinitDOUBLE;
                case 2012: return varinitCHAR;
                case 2013: return varinitSTRING;
                case 2014: return varinitBOOLEAN;
                case 2015: return vartailINT;
                case 2016: return vartailDOUBLE;
                case 2017: return vartailCHAR;
                case 2018: return vartailSTRING;
                case 2019: return vartailBOOLEAN;
                case 2020: return valueCHAR;
                case 2021: return valueSTRING;
                case 2022: return valueBOOLEAN;
                case 2023: return id_tail;
                case 2024: return ids_tail;
                case 2025: return id_choices;
                case 2026: return task_param;
                case 2027: return task_param_tail;
                case 2028: return value;
                case 2029: return index;
                case 2030: return indexop;
                case 2031: return add_min;
                case 2032: return index_value;
                case 2033: return index_tail;
                case 2034: return elements;
                case 2035: return elements_tail;
                case 2036: return array;
                case 2037: return size_tail;
                case 2038: return task;
                case 2039: return return_type;
                case 2040: return parameters;
                case 2041: return param_tail;
                case 2042: return Object;
                case 2043: return object_elem;
                case 2044: return object_elem_tail;
                case 2045: return object_var;
                case 2046: return object_var_tail;
                case 2047: return statements;
                case 2048: return functions;
                case 2049: return io_statement;
                case 2050: return output_statement;
                case 2051: return concat;
                case 2052: return pre_incdec;
                case 2053: return option;
                case 2054: return option_choices;
                case 2055: return optionINT;
                case 2056: return optionCHAR;
                case 2057: return optionSTRING;
                case 2058: return stateINT;
                case 2059: return stateCHAR;
                case 2060: return stateSTRING;
                case 2061: return def;
                case 2062: return conditions;
                case 2063: return condition_choices;
                case 2064: return condition_tail;
                case 2065: return condition_ids;
                case 2066: return logOp_tail;
                case 2067: return logOp_choices;
                case 2068: return relOp;
                default:
                    return "";
            }
        }
    }
    
}
