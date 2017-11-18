Imports System.Text.RegularExpressions
Imports Syntax_Analyzer
Imports Sema
Imports PerCederberg.Grammatica.Runtime
Imports TokenLibrary

Public Class Form1

#Region "declaration"
    Dim var As Char
    Dim ctr As Integer
    Dim id As New Regex("^[a-zA-Z]{1}[a-zA-Z0-9]{0,15}$") ' For Identifier
    Dim int As New Regex("^[~]{0,1}[0-9]{0,10}$") ' For Integer 
    Dim dec As New Regex("^[~]{0,1}[0-9]{0,10}[.]{1}[0-9]{0,4}$") ' For Float
    'Dim int As New Regex("^[-+]?[0-9]*\.?[0-9]+$")

    'Delete if mali
    'Hindi ko pa pinalitan yung nasa baba iba pala kasi yung nasa td sa nandito di ko alam ano tama hahahaa
    ' pero eto na yung pagkakaintindi ko sa comment nila palitan if ever na lang

    'choco mallow
    Dim Rd_bool1() As String = {":", "{", Chr(34), "}"}

    'Void,Joy, Goto, Num
    Dim Wsp1() As String = {" "}

    'Gravy, return
    Dim Rd_group1() As String = {"$", " "}

    'ice,popo
    Dim Rd_par1() As String = {" ", "("}

    'mamsir
    Dim Rd_mtg1() As String = {ControlChars.Lf, " "}

    ')
    Dim rsd_51() As String = {")", " ", "+", "*", "-", "/", "(", "{", "}", "$"}

    '}
    Dim rsd_slowercase1() As String = {" ", "$", "}", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}

    '++
    Dim Rsd_91() As String = {">", "<", "==", "<=", ">=", "!=", "&&", "||", "!", " ", ControlChars.Lf}

    '//
    Dim Rsd_31() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}



    Dim rsd_slowercase() As String = {ControlChars.Lf, " ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "{", "}", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "~", "$", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W",
                                    "X", "Y", "Z"}
    ' Dim rsd_2() As String = {" ", "(", ")", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
    '     "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
    Dim rd_id() As String = {" ", ControlChars.Lf, ",", ">", "<", "==", "<=", ">=", "!=", "+", "-", "*", "/", "%", "(", ")", "{", "]", "[", "=", "++", "--", "$"} ' For Identifier 
    Dim rd_numlit() As String = {ControlChars.Lf, " ", "+", "-", "*", "/", "%", ")", ">", "<", "==", "<=", ">=", "!=", "++", "--", ",", "}", "]", "$"}

    Dim rd_int() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "~", "."} ' For Integer
    Dim Rsd_string() As String = {" ", ControlChars.Lf, "#", "`", "@", "$", "%", "_", ";", "?", ".", ">", "=", "<", "=", "+", "-", "*", "/", "\", "^", ")", "(", "[", "]", "{",
                                    "}", ",", "?", "~", "!", "@", "$", "%", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
                                    "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W",
                                    "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"} ' For String
    Dim Rsd_Com1() As String = {Chr(34), "`", "@", "$", "%", "_", ";", "?", " ", ".", ">", "=", "<", "=", "+", "-", "*", "/", "\", "^", ")", "(", "[", "]", "{", "}", ",", "?", "~", "!", "@", "$", "%", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"} ' For One Line Comment
    'Dim Rsd_Com1() As String = {"<-"}
    'func07-Com2 null
    Dim Rsd_num() As String = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
    Dim Rsd_Com2() As String = {" ", Chr(34), "`", "@", "$", "%", "_", ";", "?", " ", ControlChars.Lf, ".", ">", "=", "<", "=", "+", "-", "*", "/", "\", "^", ")", "(", "[", "]", "{", "}", ",", "?", "~", "!", "@", "$", "%", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"} ' For Many Line Comment
    'Dim Rsd_Com2() As String = {"->"}
    'func08 null
    Dim Rsd_Char() As String = {" ", Chr(34), "`", "@", "$", "%", "_", ";", "?", " ", ".", ">", "=", "<", "=", "+", "-", "*", "/", "\", "^", ")", "(", "[", "]", "{", "}", ",", "?", "~", "!", "@", "$", "%", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " "} ' For One Line Comment
    Dim Rsd_io() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", Chr(34), "+"}
    Dim Alpha() As String = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
    Dim alphaC() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
    Dim alphaR() As String = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
    Dim alphanumR() As String = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
    Dim Operations() As String = {"+", "-", "/", "*", "%"}
    Dim Wsp() As String = {" ", ControlChars.Lf, ControlChars.NullChar}
    Dim Space() As String = {" ", ControlChars.Lf}
    Dim Rd_group() As String = {ControlChars.Lf, " ", "{"}
    Dim Rd_par() As String = {ControlChars.Lf, " ", "("}
    Dim Rd_io() As String = {ControlChars.Lf, " ", "/", ""}
    Dim Rd_bool() As String = {ControlChars.Lf, " ", ")", "$"}

    Dim Rd_gotocon() As String = {ControlChars.Lf, " ", ":"}

    Dim Rd_mtg() As String = {ControlChars.Lf, " ", "$"}
    Dim Rd_joy() As String = {ControlChars.Lf, "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " ", Chr(34)}
    Dim Rd_term() As String = {ControlChars.Lf, " ", "(", ")"}
    Dim rs_rel() As String = {ControlChars.Lf, " ", ">", "<", "==", "<=", ">=", "!="}

    Dim rs_com() As String = {"->"}
    Dim rs_com2() As String = {"<-"}
    'Dim Rsd_22() As String = {" ", "(", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}
    'Dim Rsd_2_1() As String = {"(", " ", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
    Dim Rsd_3() As String = {" ", Chr(34), "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
    Dim Rsd_4() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D",
                                "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "~", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "("}
    Dim Rsd_9() As String = {")", "$", ">", "<", "==", "<=", ">=", "!=", " ", ControlChars.Lf}
    Dim Rsd_5() As String = {ControlChars.Lf, "+", "-", "/", "*", "%", " ", ">", "<", "==", "<=", ">=", "!=", "{", "&&", "||", "$"}
    Dim Rsd_6() As String = {"[", ",", Chr(34), "+", "-", "/", "*", "%", " ", ">", "<", "==", "<=", ">=", "!=", "$", "++", "--", "==", "="}
    Dim Rsd_7() As String = {" ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D",
                                "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "~", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "(", ")", ""}
    Dim rsd_8() As String = {ControlChars.Lf, Chr(34), " ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"}



    Dim linecount As Integer
    Dim rowcount As String
    Dim return2 As Boolean
    Dim linecount2 As Integer
#End Region

    Private Sub LexicalAnalyzerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LexicalAnalyzerButton.Click
        DataGridView1.Rows.Clear()
        LexicalErrorBox.Clear()

        'Dim column_value As String
        'column_value = DataGridView1.Item(0).Cells(0).Text

        'Dim ch As Char

        linecount = 1
        ctr = 0

        SyntaxErrorBox.Clear()

        Dim token As String
        token = TextBox1.Text
        Dim flag As Integer
        flag = 0

        Do While (ctr < TextBox1.Text.Length)
            var = TextBox1.Text(ctr)

            ' RESERVED WORDS
            ' IDENTIFIERS
            ' DELIMETERS


#Region "b reserved words"
            If var = "b" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "u" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "r" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "g" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "e" Then
                                                ctr = ctr + 1
                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If var = "r" Then
                                                        ctr = ctr + 1
                                                        If ctr < TextBox1.Text.Length Then
                                                            var = TextBox1.Text(ctr)
                                                            If Space.Contains(var) Then
                                                                DataGridView1.Rows.Add("burger", "burger", linecount)
                                                            ElseIf alphanumR.Contains(var) Then
                                                                JOLLY("burger", linecount, flag)
                                                            Else
                                                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") burger; space or new line expected" & Environment.NewLine)
                                                                flag = flag + 1
                                                                Continue Do
                                                            End If
                                                        Else
                                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") burger; space or new line expected" & Environment.NewLine)
                                                            flag = flag + 1
                                                            Continue Do
                                                        End If
                                                    ElseIf Wsp.Contains(var) Then
                                                        JOLLY("burge", linecount, flag)
                                                    ElseIf id.IsMatch("burge") Then
                                                        DataGridView1.Rows.Add("burge", "identifier", linecount)
                                                    End If
                                                Else
                                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier burge delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("burg", linecount, flag)
                                            ElseIf id.IsMatch("burg") Then
                                                DataGridView1.Rows.Add("burg", "identifier", linecount)
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier burg delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("bur", linecount, flag)
                                    ElseIf id.IsMatch("bur") Then
                                        DataGridView1.Rows.Add("bur", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier bur delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("bu", linecount, flag)
                            ElseIf id.IsMatch("bu") Then
                                DataGridView1.Rows.Add("bu", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier bu delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("b", linecount, flag)
                    ElseIf id.IsMatch("b") Then
                        DataGridView1.Rows.Add("b", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier b delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

#End Region
#Region "d reserved words"
            If var = "d" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "i" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "n" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "e" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "i" Then
                                                ctr = ctr + 1
                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If var = "n" Then
                                                        ctr = ctr + 1
                                                        If ctr < TextBox1.Text.Length Then
                                                            var = TextBox1.Text(ctr)
                                                            If Rd_io.Contains(var) Then
                                                                DataGridView1.Rows.Add("dinein", "dinein", linecount)
                                                            ElseIf alphanumR.Contains(var) Then
                                                                JOLLY("dinein", linecount, flag)
                                                            Else
                                                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ")  dinein; space or newline or // expected." & Environment.NewLine)
                                                                flag = flag + 1
                                                                Continue Do
                                                            End If
                                                        Else
                                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ")  dinein; space or newline or // expected." & Environment.NewLine)
                                                            flag = flag + 1
                                                            Continue Do
                                                        End If
                                                    ElseIf Wsp.Contains(var) Then
                                                        JOLLY("dinei", linecount, flag)
                                                    ElseIf id.IsMatch("dinei") Then
                                                        DataGridView1.Rows.Add("dinei", "identifier", linecount)
                                                    End If
                                                Else
                                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier dinei delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("dine", linecount, flag)
                                            ElseIf id.IsMatch("dine") Then
                                                DataGridView1.Rows.Add("dine", "identifier", linecount)
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier dine delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("din", linecount, flag)
                                    ElseIf id.IsMatch("din") Then
                                        DataGridView1.Rows.Add("din", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier din delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("di", linecount, flag)
                            ElseIf id.IsMatch("di") Then
                                DataGridView1.Rows.Add("di", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier di delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("d", linecount, flag)
                    ElseIf id.IsMatch("d") Then
                        DataGridView1.Rows.Add("d", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier d delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
#End Region


#Region "c reserved words"
            If var = "c" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "h" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "i" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "c" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "k" Then
                                                ctr = ctr + 1
                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If var = "e" Then
                                                        ctr = ctr + 1
                                                        If ctr < TextBox1.Text.Length Then
                                                            var = TextBox1.Text(ctr)
                                                            If var = "n" Then
                                                                ctr = ctr + 1
                                                                If ctr < TextBox1.Text.Length Then
                                                                    var = TextBox1.Text(ctr)
                                                                    If Wsp.Contains(var) Then
                                                                        DataGridView1.Rows.Add("chicken", "chicken", linecount)
                                                                    ElseIf alphanumR.Contains(var) Then
                                                                        JOLLY("chicken", linecount, flag)
                                                                    Else
                                                                        LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ")  chicken; space or newline expected." + ControlChars.Lf
                                                                        flag = flag + 1
                                                                        Continue Do
                                                                    End If
                                                                Else
                                                                    LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ")  chicken; space or newline expected." + ControlChars.Lf
                                                                    flag = flag + 1
                                                                    Continue Do
                                                                End If
                                                            ElseIf alphanumR.Contains(var) Then
                                                                JOLLY("chicke", linecount, flag)
                                                            ElseIf id.IsMatch("chicke") Then
                                                                DataGridView1.Rows.Add("chicke", "identifier", linecount)
                                                            End If
                                                        Else
                                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier chicke" & Environment.NewLine)
                                                            flag = flag + 1
                                                            Continue Do
                                                        End If
                                                    ElseIf alphanumR.Contains(var) Then
                                                        JOLLY("chick", linecount, flag)
                                                    ElseIf id.IsMatch("chick") Then
                                                        DataGridView1.Rows.Add("chick", "identifier", linecount)
                                                    End If
                                                Else
                                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier chick" & Environment.NewLine)
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("chic", linecount, flag)
                                            ElseIf id.IsMatch("chic") Then
                                                DataGridView1.Rows.Add("chic", "identifier", linecount)
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier chic" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("chi", linecount, flag)
                                    ElseIf id.IsMatch("chi") Then
                                        DataGridView1.Rows.Add("chi", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier chi" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf var = "o" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "c" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "o" Then
                                                ctr = ctr + 1
                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If Rd_bool.Contains(var) Then
                                                        DataGridView1.Rows.Add("choco", "pielit", linecount)
                                                    ElseIf alphanumR.Contains(var) Then
                                                        JOLLY("choco", linecount, flag)
                                                    Else
                                                        LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") choco; space, ), or $ expected." + ControlChars.Lf
                                                        flag = flag + 1
                                                        Continue Do
                                                    End If
                                                Else
                                                    LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") choco; space, ), or $ expected." + ControlChars.Lf
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("choc", linecount, flag)
                                            ElseIf id.IsMatch("choc") Then
                                                DataGridView1.Rows.Add("Char", "identifier", linecount)
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier choc" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("cho", linecount, flag)
                                    ElseIf id.IsMatch("cho") Then
                                        DataGridView1.Rows.Add("cho", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier cho" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If


                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("ch", linecount, flag)
                            ElseIf id.IsMatch("ch") Then
                                DataGridView1.Rows.Add("ch", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier ch" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf var = "r" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "e" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "a" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "m" Then
                                                ctr = ctr + 1
                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If Rd_group.Contains(var) Then
                                                        DataGridView1.Rows.Add("cream", "cream", linecount)
                                                    ElseIf var = "i" Then
                                                        ctr = ctr + 1
                                                        If ctr < TextBox1.Text.Length Then
                                                            var = TextBox1.Text(ctr)
                                                            If var = "c" Then
                                                                ctr = ctr + 1
                                                                If ctr < TextBox1.Text.Length Then
                                                                    var = TextBox1.Text(ctr)
                                                                    If var = "e" Then
                                                                        ctr = ctr + 1
                                                                        If ctr < TextBox1.Text.Length Then
                                                                            var = TextBox1.Text(ctr)
                                                                            If Rd_par.Contains(var) Then
                                                                                DataGridView1.Rows.Add("creamice", "creamice", linecount)
                                                                            ElseIf alphanumR.Contains(var) Then
                                                                                JOLLY("creamice", linecount, flag)
                                                                            Else
                                                                                LexicalErrorBox.Text = "Lexical Error:  creamice; space or newline or ( expected." + ControlChars.Lf
                                                                                flag = flag + 1
                                                                                Continue Do
                                                                            End If
                                                                        Else
                                                                            LexicalErrorBox.Text = "Lexical Error:  creamice; space or newline or ( expected." + ControlChars.Lf
                                                                            flag = flag + 1
                                                                            Continue Do

                                                                        End If

                                                                    ElseIf alphanumR.Contains(var) Then
                                                                    ElseIf id.IsMatch("creamic") Then
                                                                        DataGridView1.Rows.Add("creamic", "identifier", linecount)
                                                                    End If
                                                                Else
                                                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier creamic delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                                                    flag = flag + 1
                                                                End If
                                                            ElseIf alphanumR.Contains(var) Then
                                                            ElseIf id.IsMatch("creami") Then
                                                                DataGridView1.Rows.Add("creami", "identifier", linecount)
                                                            End If
                                                        Else
                                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier creami delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                                            flag = flag + 1
                                                        End If
                                                    ElseIf alphanumR.Contains(var) Then
                                                        JOLLY("cream", linecount, flag)
                                                    Else
                                                        LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ")cream; space or newline or ( expected." + ControlChars.Lf
                                                        flag = flag + 1
                                                        Continue Do
                                                    End If
                                                Else
                                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") cream; space or newline or ( expected." & Environment.NewLine)
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("crea", linecount, flag)
                                            ElseIf id.IsMatch("crea") Then
                                                DataGridView1.Rows.Add("crea", "identifier", linecount)
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier crea delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("cre", linecount, flag)
                                    ElseIf id.IsMatch("cre") Then
                                        DataGridView1.Rows.Add("cre", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier cre delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("cr", linecount, flag)
                            ElseIf id.IsMatch("cr") Then
                                DataGridView1.Rows.Add("cr", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier cr delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                        End If
                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("c", linecount, flag)
                    ElseIf id.IsMatch("c") Then
                        DataGridView1.Rows.Add("c", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier c delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
#End Region

#Region "g reserved words"
            If var = "g" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "o" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "t" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "o" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If Rd_gotocon.Contains(var) Then
                                                DataGridView1.Rows.Add("goto", "goto", linecount)
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("goto", linecount, flag)
                                            Else
                                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") goto" & Environment.NewLine)
                                                flag = flag + 1
                                                Continue Do
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") goto" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("got", linecount, flag)
                                    ElseIf id.IsMatch("got") Then
                                        DataGridView1.Rows.Add("got", "identifier", linecount)
                                    End If

                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier got delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("go", linecount, flag)
                            ElseIf id.IsMatch("go") Then
                                DataGridView1.Rows.Add("go", "identifier", linecount)
                            End If

                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier go delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                        End If
                    ElseIf var = "r" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "a" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "v" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "y" Then
                                                ctr = ctr + 1
                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If Rd_mtg.Contains(var) Then
                                                        DataGridView1.Rows.Add("gravy", "gravy", linecount)
                                                    ElseIf alphanumR.Contains(var) Then
                                                        JOLLY("gravy", linecount, flag)
                                                    Else
                                                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") gravy; space or $ expected." & Environment.NewLine)
                                                        flag = flag + 1
                                                        Continue Do
                                                    End If
                                                Else
                                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") gravy; space or $ expected." & Environment.NewLine)
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("grav", linecount, flag)
                                            ElseIf id.IsMatch("grav") Then
                                                DataGridView1.Rows.Add("grav", "identifier", linecount)
                                            End If

                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier grav delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                            flag = flag + 1
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("gra", linecount, flag)
                                    ElseIf id.IsMatch("gra") Then
                                        DataGridView1.Rows.Add("gra", "identifier", linecount)
                                    End If

                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier gra delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("gr", linecount, flag)
                            ElseIf id.IsMatch("gr") Then
                                DataGridView1.Rows.Add("gr", "identifier", linecount)
                            End If

                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier gr delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                        End If
                    ElseIf var = "e" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "t" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "n" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "u" Then
                                                ctr = ctr + 1
                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If var = "m" Then
                                                        ctr = ctr + 1
                                                        If ctr < TextBox1.Text.Length Then
                                                            var = TextBox1.Text(ctr)
                                                            If Rd_par.Contains(var) Then
                                                                DataGridView1.Rows.Add("getnum", "getnum", linecount)
                                                            ElseIf alphanumR.Contains(var) Then
                                                                JOLLY("getnum", linecount, flag)
                                                            Else
                                                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") getnum" & Environment.NewLine)
                                                                flag = flag + 1
                                                                Continue Do
                                                            End If
                                                        Else
                                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") getnum" & Environment.NewLine)
                                                            flag = flag + 1
                                                            Continue Do
                                                        End If
                                                    ElseIf alphanumR.Contains(var) Then
                                                        JOLLY("getnu", linecount, flag)
                                                    ElseIf id.IsMatch("getnu") Then
                                                        DataGridView1.Rows.Add("getnu", "identifier", linecount)
                                                    End If
                                                Else
                                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier getnu delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("getn", linecount, flag)
                                            ElseIf id.IsMatch("getn") Then
                                                DataGridView1.Rows.Add("getn", "identifier", linecount)
                                            End If

                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier getn delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("get", linecount, flag)
                                    ElseIf id.IsMatch("get") Then
                                        DataGridView1.Rows.Add("get", "identifier", linecount)
                                    End If

                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier g delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("ge", linecount, flag)
                            ElseIf id.IsMatch("ge") Then
                                DataGridView1.Rows.Add("ge", "identifier", linecount)
                            End If

                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier ge delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If


                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("g", linecount, flag)
                    ElseIf id.IsMatch("g") Then
                        DataGridView1.Rows.Add("g", "identifier", linecount)
                    End If

                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier g delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
#End Region


#Region "f reserved words"
            If var = "f" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "r" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "e" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "n" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "c" Then
                                                ctr = ctr + 1
                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If var = "h" Then
                                                        ctr = ctr + 1
                                                        If ctr < TextBox1.Text.Length Then
                                                            var = TextBox1.Text(ctr)
                                                            If Rd_group.Contains(var) Then
                                                                DataGridView1.Rows.Add("french", "french", linecount)
                                                            ElseIf alphanumR.Contains(var) Then
                                                                JOLLY("french", linecount, flag)
                                                            Else
                                                                LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") french;  space, newline or { expected." + ControlChars.Lf
                                                                flag = flag + 1
                                                                Continue Do
                                                            End If
                                                        Else
                                                            LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") french;  space, newline or { expected." + ControlChars.Lf
                                                            flag = flag + 1
                                                            Continue Do
                                                        End If
                                                    ElseIf alphanumR.Contains(var) Then
                                                        JOLLY("frenc", linecount, flag)
                                                    ElseIf id.IsMatch("french") Then
                                                        DataGridView1.Rows.Add("frenc", "identifier", linecount)
                                                    End If

                                                Else
                                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & "identifier frenc delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("fren", linecount, flag)
                                            ElseIf id.IsMatch("fren") Then
                                                DataGridView1.Rows.Add("fren", "identifier", linecount)
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & "identifier fren delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("fre", linecount, flag)
                                    ElseIf id.IsMatch("fre") Then
                                        DataGridView1.Rows.Add("fre", "identifier", linecount)
                                    End If

                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & "identifier fre delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf var = "i" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "e" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "s" Then
                                                ctr = ctr + 1
                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If Rd_par.Contains(var) Then
                                                        DataGridView1.Rows.Add("fries", "fries", linecount)
                                                    ElseIf alphanumR.Contains(var) Then
                                                        JOLLY("fries", linecount, flag)
                                                    Else
                                                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") fries;   space, newline or ( expected. " & Environment.NewLine)
                                                        flag = flag + 1
                                                        Continue Do
                                                    End If
                                                Else
                                                    LexicalErrorBox.Text = "Lexical Error: fries;   space, newline or ( expected. " + ControlChars.Lf
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("frie", linecount, flag)
                                            ElseIf id.IsMatch("frie") Then
                                                DataGridView1.Rows.Add("frie", "identifier", linecount)
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier frie delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("fri", linecount, flag)
                                    ElseIf id.IsMatch("fri") Then
                                        DataGridView1.Rows.Add("fri", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier fri delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("fr", linecount, flag)
                            ElseIf id.IsMatch("fr") Then
                                DataGridView1.Rows.Add("fr", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier fr delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If

                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("f", linecount, flag)
                    ElseIf id.IsMatch("f") Then
                        DataGridView1.Rows.Add("f", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier f delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
#End Region

#Region "m reserved words"
            If var = "m" Then
                ctr = ctr + 1
                var = TextBox1.Text(ctr)
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "a" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "l" Then
                                ctr = ctr + 1

                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    var = TextBox1.Text(ctr)
                                    If var = "l" Then
                                        ctr = ctr + 1
                                        var = TextBox1.Text(ctr)

                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "o" Then
                                                ctr = ctr + 1


                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If var = "w" Then
                                                        ctr = ctr + 1
                                                        If ctr < TextBox1.Text.Length Then
                                                            var = TextBox1.Text(ctr)
                                                            If Rd_bool.Contains(var) Then
                                                                DataGridView1.Rows.Add("mallow", "pielit", linecount)
                                                            ElseIf alphanumR.Contains(var) Then
                                                                JOLLY("mallow", linecount, flag)

                                                            Else
                                                                LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ")  mallow; space or $ expected." + ControlChars.Lf
                                                                flag = flag + 1
                                                                Continue Do
                                                            End If
                                                        Else
                                                            LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ")  mallow; space or $ expected." + ControlChars.Lf
                                                            flag = flag + 1
                                                            Continue Do
                                                        End If
                                                    ElseIf alphanumR.Contains(var) Then
                                                        JOLLY("mallo", linecount, flag)
                                                    ElseIf id.IsMatch("mallo") Then
                                                        DataGridView1.Rows.Add("mamsi", "identifier", linecount)
                                                    End If
                                                Else
                                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier mallo delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("mall", linecount, flag)
                                            ElseIf id.IsMatch("mall") Then
                                                DataGridView1.Rows.Add("mall", "identifier", linecount)
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier mall delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("mal", linecount, flag)
                                    ElseIf id.IsMatch("mal") Then
                                        DataGridView1.Rows.Add("mal", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier mal delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf var = "m" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "s" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "i" Then
                                                ctr = ctr + 1
                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If var = "r" Then
                                                        ctr = ctr + 1
                                                        If ctr < TextBox1.Text.Length Then
                                                            var = TextBox1.Text(ctr)

                                                            If Rd_mtg.Contains(var) Then
                                                                DataGridView1.Rows.Add("mamsir", "mamsir", linecount)
                                                            ElseIf alphanumR.Contains(var) Then
                                                                JOLLY("mamsir", linecount, flag)


                                                            Else
                                                                LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") mamsir; space , newline or $ expected." + ControlChars.Lf
                                                                flag = flag + 1
                                                                Continue Do
                                                            End If
                                                        Else
                                                            LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") mamsir; space , newline or $ expected." + ControlChars.Lf
                                                            flag = flag + 1
                                                            Continue Do
                                                        End If
                                                    ElseIf alphanumR.Contains(var) Then
                                                        JOLLY("mamsi", linecount, flag)
                                                    ElseIf id.IsMatch("mamsi") Then
                                                        DataGridView1.Rows.Add("mamsi", "identifier", linecount)
                                                    End If
                                                Else
                                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier mamsi delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("mams", linecount, flag)
                                            ElseIf id.IsMatch("mams") Then
                                                DataGridView1.Rows.Add("mamsi", "identifier", linecount)
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier mams delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("mam", linecount, flag)
                                    ElseIf id.IsMatch("mams") Then
                                        DataGridView1.Rows.Add("mamsi", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier mam delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("ma", linecount, flag)
                            ElseIf id.IsMatch("ma") Then
                                DataGridView1.Rows.Add("ma", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier ma delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("m", linecount, flag)
                    ElseIf id.IsMatch("m") Then
                        DataGridView1.Rows.Add("m", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier m delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
#End Region

#Region "t reserved words"

            If var = "t" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "a" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "k" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "e" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "o" Then
                                                ctr = ctr + 1
                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If var = "u" Then
                                                        ctr = ctr + 1
                                                        If ctr < TextBox1.Text.Length Then
                                                            var = TextBox1.Text(ctr)
                                                            If var = "t" Then
                                                                ctr = ctr + 1
                                                                If ctr < TextBox1.Text.Length Then
                                                                    var = TextBox1.Text(ctr)
                                                                    If Rd_io.Contains(var) Then
                                                                        DataGridView1.Rows.Add("takeout", "takeout", linecount)
                                                                    ElseIf alphanumR.Contains(var) Then
                                                                        JOLLY("takeout", linecount, flag)
                                                                    Else
                                                                        LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") takeout; space or newline or / expected." + ControlChars.Lf
                                                                        flag = flag + 1
                                                                        Continue Do
                                                                    End If
                                                                Else
                                                                    LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") takeout; space or newline or / expected." + ControlChars.Lf
                                                                    flag = flag + 1
                                                                    Continue Do
                                                                End If
                                                            ElseIf alphanumR.Contains(var) Then
                                                                JOLLY("takeou", linecount, flag)
                                                            ElseIf id.IsMatch("takeou") Then
                                                                DataGridView1.Rows.Add("takeou", "identifier", linecount)
                                                            End If
                                                        Else
                                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier takeou delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                                            flag = flag + 1
                                                            Continue Do
                                                        End If
                                                    ElseIf alphanumR.Contains(var) Then
                                                        JOLLY("takeo", linecount, flag)
                                                    ElseIf id.IsMatch("takeo") Then
                                                        DataGridView1.Rows.Add("takeo", "identifier", linecount)
                                                    End If
                                                Else
                                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier takeo delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("take", linecount, flag)
                                            ElseIf id.IsMatch("take") Then
                                                DataGridView1.Rows.Add("take", "identifier", linecount)
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier take delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("tak", linecount, flag)
                                    ElseIf id.IsMatch("tak") Then
                                        DataGridView1.Rows.Add("tak", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier tak delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If

                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("ta", linecount, flag)
                            ElseIf id.IsMatch("ta") Then
                                DataGridView1.Rows.Add("ta", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier ta delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf var = "e" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "a" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If Wsp.Contains(var) Then
                                        DataGridView1.Rows.Add("tea", "tea", linecount)
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("tea", linecount, flag)
                                        Continue Do
                                    Else
                                        LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ")  tea; space or newline expected" + ControlChars.Lf
                                        flag = flag + 1
                                        Continue Do
                                    End If
                                Else
                                    LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ")  tea; space or newline expected" + ControlChars.Lf
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("te", linecount, flag)
                            ElseIf id.IsMatch("te") Then
                                DataGridView1.Rows.Add("te", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier te delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf var = "h" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "a" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "n" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "k" Then
                                                ctr = ctr + 1
                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If var = "s" Then
                                                        ctr = ctr + 1
                                                        If ctr < TextBox1.Text.Length Then
                                                            var = TextBox1.Text(ctr)
                                                            If Rd_mtg.Contains(var) Then
                                                                DataGridView1.Rows.Add("thanks", "thanks", linecount)
                                                                Continue Do
                                                            ElseIf alphanumR.Contains(var) Then
                                                                JOLLY("thanks", linecount, flag)
                                                                Continue Do
                                                            Else
                                                                LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") thanks; space or newline or $ expected." + ControlChars.Lf
                                                                flag = flag + 1
                                                                Continue Do
                                                            End If
                                                        Else
                                                            LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") thanks; space or newline or $ expected." + ControlChars.Lf
                                                            flag = flag + 1
                                                            Continue Do
                                                        End If
                                                    ElseIf alphanumR.Contains(var) Then
                                                        JOLLY("thank", linecount, flag)
                                                    ElseIf id.IsMatch("thank") Then
                                                        DataGridView1.Rows.Add("thank", "identifier", linecount)
                                                    End If
                                                Else
                                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier thank delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("than", linecount, flag)
                                            ElseIf id.IsMatch("than") Then
                                                DataGridView1.Rows.Add("than", "identifier", linecount)
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier than delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("tha", linecount, flag)
                                    ElseIf id.IsMatch("tha") Then
                                        DataGridView1.Rows.Add("tha", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier tha delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("th", linecount, flag)
                            ElseIf id.IsMatch("th") Then
                                DataGridView1.Rows.Add("th", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier th delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf var = "r" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "a" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "y" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If Rd_par.Contains(var) Then
                                                DataGridView1.Rows.Add("tray", "tray", linecount)

                                                Continue Do
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("tray", linecount, flag)
                                                Continue Do
                                            Else
                                                LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") tray; space, newline or ( expected." + ControlChars.Lf
                                                flag = flag + 1
                                                Continue Do
                                            End If

                                        Else
                                            LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") tray; space, newline or ( expected." + ControlChars.Lf
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("tra", linecount, flag)
                                    ElseIf id.IsMatch("tra") Then
                                        DataGridView1.Rows.Add("tra", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier tra delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("tr", linecount, flag)
                            ElseIf id.IsMatch("tr") Then
                                DataGridView1.Rows.Add("tr", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier tr delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("t", linecount, flag)
                    ElseIf id.IsMatch("t") Then
                        DataGridView1.Rows.Add("t", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier t delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If

            End If
#End Region


#Region "n reserved words"
            If var = "n" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "u" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)

                            If var = "m" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If Wsp.Contains(var) Then
                                        DataGridView1.Rows.Add("num", "num", linecount)
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("num", linecount, flag)
                                        Continue Do
                                    Else
                                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") space expected" & Environment.NewLine)
                                        flag = flag + 1
                                        Continue Do
                                    End If
                                Else
                                    LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") num" + ControlChars.Lf
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("nu", linecount, flag)
                            ElseIf id.IsMatch("nu") Then
                                DataGridView1.Rows.Add("nu", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier nu delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("n", linecount, flag)
                    ElseIf id.IsMatch("n") Then
                        DataGridView1.Rows.Add("n", "identifier", linecount)
                    End If

                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier n delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
#End Region

#Region "e reserved words"
            If var = "e" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "g" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)

                            If var = "g" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If Rd_bool.Contains(var) Then
                                        DataGridView1.Rows.Add("egg", "egg", linecount)
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("egg", linecount, flag)
                                        Continue Do

                                    Else
                                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ")egg; space or ) or newline or $ expected." & Environment.NewLine)
                                        flag = flag + 1
                                        Continue Do
                                    End If
                                Else
                                    LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ") egg; space or ) newline or $ expected." + ControlChars.Lf
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("eg", linecount, flag)
                            ElseIf id.IsMatch("eg") Then
                                DataGridView1.Rows.Add("eg", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier eg delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1

                            Continue Do
                        End If
                    ElseIf var = "x" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)

                            If var = "t" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "r" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If var = "a" Then
                                                ctr = ctr + 1
                                                If ctr < TextBox1.Text.Length Then
                                                    var = TextBox1.Text(ctr)
                                                    If Wsp.Contains(var) Then
                                                        DataGridView1.Rows.Add("extra", "extra", linecount)
                                                    ElseIf alphanumR.Contains(var) Then
                                                        JOLLY("extra", linecount, flag)
                                                        Continue Do
                                                    Else
                                                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ")extra; space expected." & Environment.NewLine)
                                                        flag = flag + 1
                                                        Continue Do
                                                    End If
                                                Else
                                                    LexicalErrorBox.Text = "Lexical Error:(Line # " & linecount & ")extra; space expected." + ControlChars.Lf
                                                    flag = flag + 1
                                                    Continue Do
                                                End If
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("extr", linecount, flag)
                                            ElseIf id.IsMatch("extr") Then
                                                DataGridView1.Rows.Add("extr", "identifier", linecount)
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier extr delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("ext", linecount, flag)
                                    ElseIf id.IsMatch("ext") Then
                                        DataGridView1.Rows.Add("ext", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier ext delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("ex", linecount, flag)
                            ElseIf id.IsMatch("ex") Then
                                DataGridView1.Rows.Add("ex", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier ex delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("e", linecount, flag)
                    ElseIf id.IsMatch("e") Then
                        DataGridView1.Rows.Add("e", "identifier", linecount)
                    End If

                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier e delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
#End Region


#Region "p reserved words"

            If var = "p" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "i" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "e" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If Space.Contains(var) Then
                                        DataGridView1.Rows.Add("pie", "pie", linecount)
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("pie", linecount, flag)
                                        Continue Do
                                    Else
                                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") pie; space or newline expected" & Environment.NewLine)
                                        flag = flag + 1
                                        Continue Do
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") pie; space or newline expected" & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("pi", linecount, flag)
                            ElseIf id.IsMatch("pi") Then
                                DataGridView1.Rows.Add("pi", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier pi delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                        End If
                    ElseIf var = "o" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "p" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "o" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If Rd_par.Contains(var) Then
                                                DataGridView1.Rows.Add("popo", "popo", linecount)
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("popo", linecount, flag)
                                                Continue Do
                                            Else
                                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") popo; space or newline or ( expected." & Environment.NewLine)
                                                flag = flag + 1
                                                Continue Do
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") popo; space or newline or ( expected." & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("pop", linecount, flag)
                                    ElseIf id.IsMatch("pop") Then
                                        DataGridView1.Rows.Add("pop", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier pop delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("po", linecount, flag)
                            ElseIf id.IsMatch("po") Then
                                DataGridView1.Rows.Add("po", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier po delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                        End If
                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("p", linecount, flag)
                    ElseIf id.IsMatch("p") Then
                        DataGridView1.Rows.Add("p", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier p delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                End If

            End If
#End Region



#Region "s reserved words"
            If var = "s" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "p" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)

                            If var = "a" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "g" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If Space.Contains(var) Then
                                                DataGridView1.Rows.Add("spag", "spag", linecount)
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("spag", linecount, flag)
                                                Continue Do

                                            Else
                                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") spag; space or newline expected" & Environment.NewLine)
                                                flag = flag + 1
                                                Continue Do
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") spag; space or newline expected" & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("spa", linecount, flag)
                                    ElseIf id.IsMatch("spa") Then
                                        DataGridView1.Rows.Add("spa", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier spa delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                End If

                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("sp", linecount, flag)
                            ElseIf id.IsMatch("sp") Then
                                DataGridView1.Rows.Add("sp", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier sp delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                        End If

                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("s", linecount, flag)
                    ElseIf id.IsMatch("s") Then
                        DataGridView1.Rows.Add("s", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier s delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                End If
            End If
#End Region




#Region "v reserved words"

            If var = "v" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "o" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "i" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If var = "d" Then
                                        ctr = ctr + 1
                                        If ctr < TextBox1.Text.Length Then
                                            var = TextBox1.Text(ctr)
                                            If Wsp.Contains(var) Then
                                                DataGridView1.Rows.Add("void", "void", linecount)
                                            ElseIf alphanumR.Contains(var) Then
                                                JOLLY("void", linecount, flag)
                                            Else
                                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") void; space or newline expected." & Environment.NewLine)
                                                flag = flag + 1
                                                Continue Do
                                            End If
                                        Else
                                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") void; space or newline expected." & Environment.NewLine)
                                            flag = flag + 1
                                            Continue Do
                                        End If
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("voi", linecount, flag)
                                    ElseIf id.IsMatch("voi") Then
                                        DataGridView1.Rows.Add("voi", "identifier", linecount)
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier voi delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                                    flag = flag + 1
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("vo", linecount, flag)
                            ElseIf id.IsMatch("vo") Then
                                DataGridView1.Rows.Add("vo", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier vo delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                        End If
                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("v", linecount, flag)
                    ElseIf id.IsMatch("v") Then
                        DataGridView1.Rows.Add("v", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier v delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                End If

            End If

            If var = "y" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "u" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "m" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If Rd_group.Contains(var) Then
                                        DataGridView1.Rows.Add("yum", "yum", linecount)

                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("yum", linecount, flag)
                                    Else
                                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") yum; space or newline or { expected." & Environment.NewLine)
                                        flag = flag + 1
                                        Continue Do
                                    End If
                                End If
                            Else
                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") yum; space or newline or { expected." & Environment.NewLine)
                                flag = flag + 1
                                Continue Do
                            End If
                        ElseIf alphanumR.Contains(var) Then
                            JOLLY("yu", linecount, flag)
                        ElseIf id.IsMatch("yu") Then
                            DataGridView1.Rows.Add("yu", "identifier", linecount)
                        End If
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier yu delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                        flag = flag + 1
                    End If
                End If
            End If
#End Region


#Region "i reserved words"
            If var = "i" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "c" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "e" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If Rd_par.Contains(var) Then
                                        DataGridView1.Rows.Add("ice", "ice", linecount)
                                        'ElseIf alphanumR.Contains(var) Then
                                        '   JOLLY("ice", linecount, flag)
                                    Else
                                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") ice; space, newline or ( expected." & Environment.NewLine)
                                        flag = flag + 1
                                        Continue Do
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") ice; space, newline or ( expected." & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("ic", linecount, flag)
                            ElseIf id.IsMatch("ic") Then
                                DataGridView1.Rows.Add("ic", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier ic delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                        End If
                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("i", linecount, flag)
                    ElseIf id.IsMatch("i") Then
                        DataGridView1.Rows.Add("i", "identifier", linecount)
                    End If

                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier i delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                End If

            End If

#End Region


#Region "j reserved words"
            If var = "j" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "o" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If var = "y" Then
                                ctr = ctr + 1
                                If ctr < TextBox1.Text.Length Then
                                    var = TextBox1.Text(ctr)
                                    If Rd_joy.Contains(var) Then
                                        DataGridView1.Rows.Add("joy", "joy", linecount)
                                    ElseIf alphanumR.Contains(var) Then
                                        JOLLY("joy", linecount, flag)
                                    Else
                                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") joy; space or newline or numlit or double quote expected." & Environment.NewLine)
                                        flag = flag + 1
                                        Continue Do
                                    End If
                                Else
                                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") joy; space or newline or numlit or double quote expected." & Environment.NewLine)
                                    flag = flag + 1
                                    Continue Do
                                End If
                            ElseIf alphanumR.Contains(var) Then
                                JOLLY("jo", linecount, flag)
                            ElseIf id.IsMatch("jo") Then
                                DataGridView1.Rows.Add("jo", "identifier", linecount)
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier jo delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                            flag = flag + 1
                        End If
                    ElseIf alphanumR.Contains(var) Then
                        JOLLY("j", linecount, flag)
                    ElseIf id.IsMatch("j") Then
                        DataGridView1.Rows.Add("j", "identifier", linecount)
                    End If

                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier j delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                End If

            End If
#End Region

            'IDENTIFIERS
            'DELIMETERS
#Region "Letters A-Z, a-z, id"
            If var = "A" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("A", linecount, flag)
                    ElseIf id.IsMatch("A") Then
                        DataGridView1.Rows.Add("A", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier A delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "B" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("B", linecount, flag)
                    ElseIf id.IsMatch("B") Then
                        DataGridView1.Rows.Add("B", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier B delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "C" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("C", linecount, flag)
                    ElseIf id.IsMatch("C") Then
                        DataGridView1.Rows.Add("C", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier C delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If

            ElseIf var = "D" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("D", linecount, flag)
                    ElseIf id.IsMatch("D") Then
                        DataGridView1.Rows.Add("D", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier D delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "E" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("E", linecount, flag)
                    ElseIf id.IsMatch("E") Then
                        DataGridView1.Rows.Add("H", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier E delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If

            ElseIf var = "F" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("F", linecount, flag)
                    ElseIf id.IsMatch("F") Then
                        DataGridView1.Rows.Add("F", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier F delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If

            ElseIf var = "G" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("G", linecount, flag)
                    ElseIf id.IsMatch("G") Then
                        DataGridView1.Rows.Add("G", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier G delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If


            ElseIf var = "H" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("H", linecount, flag)
                    ElseIf id.IsMatch("H") Then
                        DataGridView1.Rows.Add("H", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier H delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "I" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("I", linecount, flag)
                    ElseIf id.IsMatch("I") Then
                        DataGridView1.Rows.Add("I", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier I delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If

            ElseIf var = "J" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("J", linecount, flag)
                    ElseIf id.IsMatch("J") Then
                        DataGridView1.Rows.Add("J", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier J delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "K" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("K", linecount, flag)
                    ElseIf id.IsMatch("K") Then
                        DataGridView1.Rows.Add("K", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier K delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "L" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("L", linecount, flag)
                    ElseIf id.IsMatch("L") Then
                        DataGridView1.Rows.Add("L", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier L delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "M" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("M", linecount, flag)
                    ElseIf id.IsMatch("M") Then
                        DataGridView1.Rows.Add("M", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier M delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If

            ElseIf var = "N" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("N", linecount, flag)
                    ElseIf id.IsMatch("N") Then
                        DataGridView1.Rows.Add("N", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier N delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "O" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("O", linecount, flag)
                    ElseIf id.IsMatch("O") Then
                        DataGridView1.Rows.Add("O", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier O delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "P" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("P", linecount, flag)
                    ElseIf id.IsMatch("P") Then
                        DataGridView1.Rows.Add("P", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier P delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If



            ElseIf var = "Q" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("Q", linecount, flag)
                    ElseIf id.IsMatch("Q") Then
                        DataGridView1.Rows.Add("Q", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier Q delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "R" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("R", linecount, flag)
                    ElseIf id.IsMatch("R") Then
                        DataGridView1.Rows.Add("R", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier R delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "S" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("S", linecount, flag)
                    ElseIf id.IsMatch("S") Then
                        DataGridView1.Rows.Add("S", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier S delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "T" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("T", linecount, flag)
                    ElseIf id.IsMatch("T") Then
                        DataGridView1.Rows.Add("T", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier T delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If

            ElseIf var = "U" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("U", linecount, flag)
                    ElseIf id.IsMatch("U") Then
                        DataGridView1.Rows.Add("U", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier U delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "V" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("V", linecount, flag)
                    ElseIf id.IsMatch("V") Then
                        DataGridView1.Rows.Add("V", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier V delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "W" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("W", linecount, flag)
                    ElseIf id.IsMatch("W") Then
                        DataGridView1.Rows.Add("W", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier W delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "X" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("X", linecount, flag)
                    ElseIf id.IsMatch("X") Then
                        DataGridView1.Rows.Add("X", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier X delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "Y" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("Y", linecount, flag)
                    ElseIf id.IsMatch("Y") Then
                        DataGridView1.Rows.Add("Y", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier Y delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "Z" Then
                ctr = ctr + 1

                MsgBox("Z")
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("Z", linecount, flag)
                    ElseIf id.IsMatch("Z") Then
                        DataGridView1.Rows.Add("Z", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier Z delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "a" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("a", linecount, flag)
                    ElseIf id.IsMatch("a") Then
                        DataGridView1.Rows.Add("a", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier a delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "b" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("b", linecount, flag)
                    ElseIf id.IsMatch("b") Then
                        DataGridView1.Rows.Add("b", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier b delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "c" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("c", linecount, flag)
                    ElseIf id.IsMatch("c") Then
                        DataGridView1.Rows.Add("c", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier c delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "d" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("d", linecount, flag)
                    ElseIf id.IsMatch("d") Then
                        DataGridView1.Rows.Add("d", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier d delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "e" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("e", linecount, flag)
                    ElseIf id.IsMatch("e") Then
                        DataGridView1.Rows.Add("e", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier e delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "f" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("f", linecount, flag)
                    ElseIf id.IsMatch("f") Then
                        DataGridView1.Rows.Add("f", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier f delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "g" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("g", linecount, flag)
                    ElseIf id.IsMatch("g") Then
                        DataGridView1.Rows.Add("g", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier g delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "h" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("h", linecount, flag)
                    ElseIf id.IsMatch("h") Then
                        DataGridView1.Rows.Add("h", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier h delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "i" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("i", linecount, flag)
                    ElseIf id.IsMatch("i") Then
                        DataGridView1.Rows.Add("i", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier i delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "j" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("j", linecount, flag)
                    ElseIf id.IsMatch("j") Then
                        DataGridView1.Rows.Add("j", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier j delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "k" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("k", linecount, flag)
                    ElseIf id.IsMatch("k") Then
                        DataGridView1.Rows.Add("k", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier k delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "l" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("l", linecount, flag)
                    ElseIf id.IsMatch("l") Then
                        DataGridView1.Rows.Add("l", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier l delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
                'ElseIf var = "m" Then
                ''   ctr = ctr + 1
                ' If ctr < TextBox1.Text.Length Then
                'var = TextBox1.Text(ctr)
                'If alphanumR.Contains(var) Then
                'JOLLY("m", linecount, flag)
                'ElseIf id.IsMatch("m") Then
                '   DataGridView1.Rows.Add("m", "identifier", linecount)
                'End If
                'Else
                '   LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier m delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                '  flag = flag + 1
                ' Continue Do
                'End If
            ElseIf var = "n" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("n", linecount, flag)
                    ElseIf id.IsMatch("n") Then
                        DataGridView1.Rows.Add("n", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier n delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "o" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("o", linecount, flag)
                    ElseIf id.IsMatch("o") Then
                        DataGridView1.Rows.Add("o", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier o delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "p" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("p", linecount, flag)
                    ElseIf id.IsMatch("p") Then
                        DataGridView1.Rows.Add("p", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier p delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "q" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("q", linecount, flag)
                    ElseIf id.IsMatch("q") Then
                        DataGridView1.Rows.Add("q", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier q delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "r" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("r", linecount, flag)
                    ElseIf id.IsMatch("r") Then
                        DataGridView1.Rows.Add("r", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier r delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "s" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("s", linecount, flag)
                    ElseIf id.IsMatch("s") Then
                        DataGridView1.Rows.Add("s", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier s delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "t" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("t", linecount, flag)
                    ElseIf id.IsMatch("t") Then
                        DataGridView1.Rows.Add("t", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier t delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "u" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("u", linecount, flag)
                    ElseIf id.IsMatch("u") Then
                        DataGridView1.Rows.Add("u", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier u delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "v" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("v", linecount, flag)
                    ElseIf id.IsMatch("v") Then
                        DataGridView1.Rows.Add("v", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier v delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "w" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("w", linecount, flag)
                    ElseIf id.IsMatch("w") Then
                        DataGridView1.Rows.Add("w", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier w delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "x" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("x", linecount, flag)
                    ElseIf id.IsMatch("x") Then
                        DataGridView1.Rows.Add("x", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier x delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "y" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("y", linecount, flag)
                    ElseIf id.IsMatch("y") Then
                        DataGridView1.Rows.Add("y", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier y delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "z" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If alphanumR.Contains(var) Then
                        JOLLY("z", linecount, flag)
                    ElseIf id.IsMatch("z") Then
                        DataGridView1.Rows.Add("z", "identifier", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier z delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

#End Region

            ' INTEGER DATA VALUE
            ' DELIMETERS

#Region "~numbers"
            If var = "0" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rd_int.Contains(var) Then
                        JOLLYINTEGER("0", linecount, flag)
                    ElseIf int.IsMatch("0") And rd_numlit.Contains(var) Then
                        DataGridView1.Rows.Add("0", "numlit", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 0 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 0 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "~" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rd_int.Contains(var) Then
                        JOLLYINTEGER("~", linecount, flag)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") ~ delimeter num expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "1" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rd_int.Contains(var) Then
                        JOLLYINTEGER("1", linecount, flag)
                    ElseIf int.IsMatch("1") And rd_numlit.Contains(var) Then
                        DataGridView1.Rows.Add("1", "numlit", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 1 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 1 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "2" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rd_int.Contains(var) Then
                        JOLLYINTEGER("2", linecount, flag)
                    ElseIf int.IsMatch("2") And rd_numlit.Contains(var) Then
                        DataGridView1.Rows.Add("2", "numlit", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 2 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 2 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "3" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rd_int.Contains(var) Then
                        JOLLYINTEGER("3", linecount, flag)
                    ElseIf int.IsMatch("3") Then
                        DataGridView1.Rows.Add("3", "numlit", linecount)

                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 3 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 3 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "4" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rd_int.Contains(var) Then
                        JOLLYINTEGER("4", linecount, flag)
                    ElseIf int.IsMatch("4") And rd_numlit.Contains(var) Then
                        DataGridView1.Rows.Add("4", "numlit", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 4 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 4 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "5" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rd_int.Contains(var) Then
                        JOLLYINTEGER("5", linecount, flag)
                    ElseIf int.IsMatch("5") And rd_numlit.Contains(var) Then
                        DataGridView1.Rows.Add("5", "numlit", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 5 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 5 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "6" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rd_int.Contains(var) Then
                        JOLLYINTEGER("6", linecount, flag)
                    ElseIf int.IsMatch("6") And rd_numlit.Contains(var) Then
                        DataGridView1.Rows.Add("6", "numlit", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 6 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 6 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "7" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rd_int.Contains(var) Then
                        JOLLYINTEGER("7", linecount, flag)
                    ElseIf int.IsMatch("7") And rd_numlit.Contains(var) Then
                        DataGridView1.Rows.Add("7", "numlit", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 7 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 7 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "8" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rd_int.Contains(var) Then
                        JOLLYINTEGER("8", linecount, flag)
                    ElseIf int.IsMatch("8") And rd_numlit.Contains(var) Then
                        DataGridView1.Rows.Add("8", "numlit", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 8 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 8 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            ElseIf var = "9" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rd_int.Contains(var) Then
                        JOLLYINTEGER("9", linecount, flag)
                    ElseIf int.IsMatch("9") And rd_numlit.Contains(var) Then
                        DataGridView1.Rows.Add("9", "numlit", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 9 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num 9 delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
#End Region


            ' RESERVED SYMBOLS
            ' DELIMETERS
#Region "symbols"
            If var = "$" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If Wsp.Contains(var) Or alphanumR.Contains(var) Or var = ")" Or var = "(" Then
                        DataGridView1.Rows.Add("$", "$", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") $ delimeter space expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    DataGridView1.Rows.Add("$", "$", linecount)
                End If
            End If

            If var = "+" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "+" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If Rsd_9.Contains(var) Then
                                DataGridView1.Rows.Add("++", "++", linecount)
                            Else
                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") ++ delimeter ), $, >, <, ==, <=, >=, or != expected" & Environment.NewLine)
                                flag = flag + 1
                                Continue Do
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") ++ delimeter ), $, >, <, ==, <=, >=, or != expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf Rsd_4.Contains(var) Then
                        DataGridView1.Rows.Add("+", "+")
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") + delimeter space or ( or num data value expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = "-" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "-" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If Rsd_9.Contains(var) Then
                                DataGridView1.Rows.Add("--", "--", linecount)
                            Else
                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") -- delimeter ), $, >, <, ==, <=, >=, or != expected" & Environment.NewLine)
                                flag = flag + 1
                                Continue Do
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") -- delimeter ), $, >, <, ==, <=, >=, or != expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf Rsd_4.Contains(var) Then
                        DataGridView1.Rows.Add("-", "-", linecount)
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") - delimeter space or ( or num or letter expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = "*" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If Rsd_4.Contains(var) Then
                        DataGridView1.Rows.Add("*", "*", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") * delimeter space or ( or num or letter expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") * delimeter space or ( or num or letter expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
            If var = "%" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If Rsd_4.Contains(var) Then
                        DataGridView1.Rows.Add("%", "%", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") % delimeter space or ( or num or letter expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") % delimeter space or ( or num or letter expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If


            If var = "/" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If Rsd_4.Contains(var) Then
                        DataGridView1.Rows.Add("/", "/", linecount)
                    ElseIf var = "/" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If Rsd_3.Contains(var) Then
                                DataGridView1.Rows.Add("//", "//", linecount)
                            Else
                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") / delimeter space or ( or num or letter expected" & Environment.NewLine)
                                flag = flag + 1
                                Continue Do
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") / delimeter space or ( or num or letter expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") / delimeter space or or another / or ( or num or letter expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") / delimeter space or or another / or ( or num or letter expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If




            If var = ">" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "=" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If Rsd_4.Contains(var) Then
                                DataGridView1.Rows.Add(">=", ">=", linecount)
                            Else
                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") <= delimeter space or ( or num or letter expected" & Environment.NewLine)
                                flag = flag + 1
                                Continue Do
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") <= delimeter space or ( or num or letter expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf Rsd_4.Contains(var) Then
                        DataGridView1.Rows.Add(">", ">", linecount
                                              )
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") > delimeter space or ( or num or letter expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") > delimeter space or ( or num or letter expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = "<" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "=" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If Rsd_4.Contains(var) Then
                                DataGridView1.Rows.Add("<=", "<=", linecount)
                            Else
                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") <= delimeter space or ( or num or letter expected" & Environment.NewLine)
                                flag = flag + 1
                                Continue Do
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") <= delimeter space or ( or num or letter expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf Rsd_4.Contains(var) Then
                        DataGridView1.Rows.Add("<", "<", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") < delimeter space or ( or num or letter expected" & Environment.NewLine)
                        flag = flag + 1S
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") < delimeter space or ( or num or letter expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = "=" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "=" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If Rsd_4.Contains(var) Then
                                DataGridView1.Rows.Add("==", "==", linecount)
                            Else
                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") == delimeter space or ( or num or letter expected" & Environment.NewLine)
                                flag = flag + 1
                                Continue Do
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") == delimeter space or ( or num or letter expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf Rsd_4.Contains(var) Then
                        DataGridView1.Rows.Add("=", "=", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") = delimeter space or ( or num or letter expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") = delimeter space or ( or num or letter expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = "!" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "=" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If Rsd_4.Contains(var) Then
                                DataGridView1.Rows.Add("!=", "!=", linecount)
                            Else
                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") != delimeter space or ( or num or letter expected" & Environment.NewLine)
                                flag = flag + 1
                                Continue Do
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") != delimeter space or ( or num or letter expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    ElseIf Rd_group.Contains(var) Then
                        DataGridView1.Rows.Add("!", "!", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") ! delimeter space, numlit, id, = expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ")  ! delimeter space, numlit, id, = expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = "&" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "&" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If Rd_group.Contains(var) Then
                                DataGridView1.Rows.Add("&&", "&&", linecount)
                            Else
                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") && delimeter space or ( expected" & Environment.NewLine)
                                flag = flag + 1
                                Continue Do
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") && delimeter space or ( expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") & another & expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") & another & expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If

            End If


            If var = "|" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If var = "|" Then
                        ctr = ctr + 1
                        If ctr < TextBox1.Text.Length Then
                            var = TextBox1.Text(ctr)
                            If Rd_group.Contains(var) Then
                                DataGridView1.Rows.Add("||", "||", linecount)
                            Else
                                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") || delimeter space or ( expected" & Environment.NewLine)
                                flag = flag + 1
                                Continue Do
                            End If
                        Else
                            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") || delimeter space or ( expected" & Environment.NewLine)
                            flag = flag + 1
                            Continue Do
                        End If
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") | another | expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") | another | expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If

            End If

            If var = ":" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If Wsp.Contains(var) Then
                        DataGridView1.Rows.Add(":", ":", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") : delimeter space or new line expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") : delimeter space or new line expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If



            '            If var = "." Then
            '           ctr = ctr + 1
            '          If ctr < TextBox1.Text.Length Then
            '         var = TextBox1.Text(ctr)
            '        If alphanumR.Contains(var) Then
            '       DataGridView1.Rows.Add(".", ".")
            '
            'Else
            'LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") ... delimeter space or new line expected" & Environment.NewLine)
            'flag = flag + 1
            'Continue Do
            'End If
            'Else
            'LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") .. another . expected" & Environment.NewLine)
            'flag = flag + 1
            'Continue Do
            'End If
            'End If

            If var = "," Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rsd_8.Contains(var) Then
                        DataGridView1.Rows.Add(",", ",", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") , delimeter space or " & Chr(34) & " or letter or num expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") , delimeter space or " & Chr(34) & " or letter or num expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
            If var = "(" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If Rsd_7.Contains(var) Then
                        DataGridView1.Rows.Add("(", "(", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") ( delimeter space or ( or ) or ~ or identifier or num expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") ( delimeter space or ( or ) or ~ or identifier or num expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = ")" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If Rsd_5.Contains(var) Then
                        DataGridView1.Rows.Add(")", ")", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") ) delimeter space or new line or mathematical operator or logical operator or relational operator expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") ) delimeter space or new line or mathematical operator or logical operator or relational operator expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = "[" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If Rsd_4.Contains(var) Then
                        DataGridView1.Rows.Add("[", "[", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") [ delimeter space or ( or num or letter expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") [ delimeter space or ( or num or letter expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = "]" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If Rsd_6.Contains(var) Then
                        DataGridView1.Rows.Add("]", "]", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") ] delimeter space, [, " & Chr(34) & " math operator, logical operator, or relational operator expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") ] delimeter space, [, " & Chr(34) & " math operator, logical operator, or relational operator expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = "{" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rsd_slowercase.Contains(var) Then
                        DataGridView1.Rows.Add("{", "{", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") { delimeter space or  lowercase alpha expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") { delimeter space or lowercase alpha expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = "}" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If rsd_slowercase.Contains(var) Then
                        DataGridView1.Rows.Add("}", "}", linecount)
                    Else
                        LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") } delimeter space or  lowercase alpha expected" & Environment.NewLine)
                        flag = flag + 1
                        Continue Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") } delimeter space or  lowercase alpha expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
#End Region

#Region "string newline comment"

            'STRING
            'PLURAL

            If var = Chr(34) Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If Rsd_string.Contains(var) Then
                        JOLLYSTRING(Chr(34), linecount, flag)
                    Else
                        DataGridView1.Rows.Add(Chr(34) + Chr(34), "spaglit", linecount)
                        Exit Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") string delimeter double quotes expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            'NEW LINE

            If var = ControlChars.Lf Then
                ctr = ctr + 1
                linecount = linecount + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                End If
            End If

            'SPACE

            If var = " " Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                End If
            End If

            'COMMENT
            If var = "'" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    If Rsd_string.Contains(var) Then
                        JOLLYC("'", linecount, flag)
                    Else
                        'DataGridView1.Rows.Add(Chr(34) + Chr(34), "spaglit")
                        Exit Do
                    End If
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") comment delimeter single quotes expected" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

#End Region

#Region "unused symbols"
            If var = "." Then
                ctr = ctr + 1
                'If ctr < TextBox1.Text.Length Then
                '    var = TextBox1.Text(ctr)
                '    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") . delimeter number or id expected" & Environment.NewLine)
                '    flag = flag + 1
                '    Continue Do
                'Else
                '    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") . delimeter number or id expected" & Environment.NewLine)
                '    flag = flag + 1
                '    Continue Do
                'End If
            End If
            If var = ";" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol ; is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol ; is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
            If var = "`" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol ` is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol ` is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
            If var = "@" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol @ is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol @ is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = "_" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol _ is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol _ is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = "#" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol # is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol # is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
            If var = "?" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol ? is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol ? is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If
            If var = "\" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol \ is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol \ is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If

            If var = "^" Then
                ctr = ctr + 1
                If ctr < TextBox1.Text.Length Then
                    var = TextBox1.Text(ctr)
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol ^ is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                Else
                    LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") Symbol ^ is not defined by the JolliCS compiler. It may only be used inside a comment or a string" & Environment.NewLine)
                    flag = flag + 1
                    Continue Do
                End If
            End If




#End Region
        Loop

        If flag = 0 Then
            LexicalErrorBox.Text = "No Lexical Error."
            ' START OF SYNTAX ANALYZER
            Dim syntaxana As New Syntax_Analyzer.SyntaxInitializer
            Dim result As String
            Dim tokenstream As String = ""
            Dim line As Integer = 1
            Dim linejumped As Boolean = False
            For ctr As Integer = 0 To DataGridView1.Rows.Count - 1
                linejumped = False

                If (line <> DataGridView1.Rows(ctr).Cells(2).Value) Then
                    linejumped = True
                Else
                    tokenstream += " " + DataGridView1.Rows(ctr).Cells(1).Value

                End If
                If (linejumped) Then
                    tokenstream += ControlChars.Lf + DataGridView1.Rows(ctr).Cells(1).Value

                    line = DataGridView1.Rows(ctr).Cells(2).Value

                End If


            Next
            result = syntaxana.Start(tokenstream)

            SyntaxErrorBox.Text = "Syntax Result: " & vbCrLf & result
            'MessageBox.Show(result)

            If (result Is "Syntax Analyzer Succeeded...") Then
                ' START OF SEMANTICS ANALYZER
                Dim semantics As New Semantics_Analyzer.SemanticsInitializer
                Dim tokenList As New List(Of Semantics_Analyzer.SemanticsInitializer.Tokens)
                For ctr As Integer = 0 To DataGridView1.Rows.Count - 1
                    Dim t As New Semantics_Analyzer.SemanticsInitializer.Tokens
                    t = New Semantics_Analyzer.SemanticsInitializer.Tokens
                    t.setLexemes(DataGridView1.Rows(ctr).Cells(0).Value)
                    t.setTokens(DataGridView1.Rows(ctr).Cells(1).Value)
                    t.setLines(DataGridView1.Rows(ctr).Cells(2).Value)
                    tokenList.Add(t)
                Next
                Try
                    semantics = New Semantics_Analyzer.SemanticsInitializer(tokenList)
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
                Dim res As String = semantics.Start()
            End If
        End If
    End Sub

    Sub JOLLYC(ByVal JOLLYSTR As String, ByVal linecount1 As Integer, ByVal flag1 As Integer)

        Dim iden4 As String
        Dim iden5 As String
        iden5 = JOLLYSTR
        iden4 = Nothing
        linecount = linecount1
        Dim flag As Integer
        flag = flag1
        Do
            iden4 = iden4 + var
            ctr = ctr + 1
            If ctr < TextBox1.Text.Length Then
                var = TextBox1.Text(ctr)
            ElseIf var = "'" Then
                Exit Do
            Else
                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") string " & iden4 & " delimeter single quotes expected" & Environment.NewLine)
                flag = flag + 1
                Exit Sub
            End If
        Loop Until var = "'"
        iden5 = iden5 + iden4 + var
        ctr = ctr + 1

    End Sub

#Region "lexical subs"
    Sub JOLLY(ByVal JOLLYCUTE As String, ByVal linecount1 As Integer, ByVal flag1 As Integer)

        Dim x As Integer
        Dim y As Integer
        x = 0
        Dim iden1 As String
        iden1 = JOLLYCUTE
        linecount = linecount1
        Dim flag As Integer
        flag = flag1
        Do
            iden1 = iden1 + var
            ctr = ctr + 1
            If ctr < TextBox1.Text.Length Then
                var = TextBox1.Text(ctr)
                If rd_id.Contains(var) Then
                    Exit Do
                Else
                    Continue Do
                End If
            Else
                x = 1
                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") identifier " & iden1 & " delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                flag = flag + 1
                Exit Do
            End If
        Loop Until (rd_id.Contains(var))
        y = Len(iden1)
        If id.IsMatch(iden1) And y <= 15 And x = 0 Then
            DataGridView1.Rows.Add(iden1, "identifier", linecount)
        ElseIf y > 15 Then
            LexicalErrorBox.Text = "Lexical Error: identifier " + iden1 + " identifiers should not exceed more than 10 characters" + ControlChars.Lf

        End If


    End Sub

    Sub JOLLYINTEGER(ByVal JOLLYINT As String, ByVal linecount1 As Integer, ByVal flag1 As Integer)

        Dim x As Integer
        Dim y As Integer
        Dim iden2 As String
        iden2 = JOLLYINT
        Dim iden3 As String
        iden3 = vbNull
        x = 0
        linecount = linecount1
        Dim flag As Integer
        flag = flag1
        Do
            iden2 = iden2 + var
            ctr = ctr + 1
            If ctr < TextBox1.Text.Length Then
                var = TextBox1.Text(ctr)
                If rd_numlit.Contains(var) Then
                    Exit Do
                Else
                    Continue Do
                End If
            Else
                x = 1
                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num or float " & iden2 & " delimeter space or new line or , or mathematical operators or relational operators or ) or } expected" & Environment.NewLine)
                flag = flag + 1
                Exit Do
            End If
        Loop Until (rd_numlit.Contains(var))
        y = Len(iden2)
        Dim a As Boolean = dec.IsMatch(iden2)
        If int.IsMatch(iden2) And x = 0 Then
            DataGridView1.Rows.Add(iden2, "numlit", linecount)
        ElseIf dec.IsMatch(iden2) And x = 0 Then
            DataGridView1.Rows.Add(iden2, "numlit", linecount)
        ElseIf y > 14 And x = 0 Then
            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") num or float " & iden2 & " num or float should not exceed more than 10 digits" & Environment.NewLine)
            flag = flag + 1
        End If

    End Sub

    Sub JOLLYSTRING(ByVal JOLLYSTR As String, ByVal linecount1 As Integer, ByVal flag1 As Integer)

        Dim iden4 As String
        Dim iden5 As String
        iden5 = JOLLYSTR
        iden4 = Nothing
        linecount = linecount1
        Dim flag As Integer
        flag = flag1
        Do
            iden4 = iden4 + var
            ctr = ctr + 1
            If ctr < TextBox1.Text.Length Then
                var = TextBox1.Text(ctr)
            ElseIf var = Chr(34) Then
                Exit Do
            Else
                LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") string " & iden4 & " delimeter double quotes expected" & Environment.NewLine)
                flag = flag + 1
                Exit Sub
            End If
        Loop Until var = Chr(34)
        iden5 = iden5 + iden4 + var
        ctr = ctr + 1

        If Len(iden5) <= 502 Then
            DataGridView1.Rows.Add(iden5, "spaglit", linecount)
        Else
            LexicalErrorBox.AppendText("Lexical Error: (Line # " & linecount & ") string " & iden4 & " 500 is the limit of characters in a string" & Environment.NewLine)
            flag = flag + 1
        End If

    End Sub

#End Region


    Sub JOLLIBEE(ByVal Bee As String, ByVal linecount1 As Integer)
        Dim token As String
        token = Bee
        rowcount = DataGridView1.Rows.Count.ToString
        linecount2 = linecount2

        return2 = True

        rowcount = 0
        DECLARATION(token, rowcount, linecount2, return2)
        ' STRUCT(token, rowcount, linecount2, return2)
        'FUNCTION1(token, rowcount, linecount2, return2)


    End Sub

    Sub DECLARATION(ByVal Bee As String, ByVal count As Integer, ByVal linecount1 As Integer, ByVal return1 As Boolean)

        Dim token As String
        token = Bee
        rowcount = count
        linecount2 = linecount1
        return2 = return1
        return2 = True
        Dim flag1 As Integer
        flag1 = 0

        If rowcount < DataGridView1.Rows.Count Then
            If DataGridView1.Rows(rowcount).Cells(1).Value = "num" Or DataGridView1.Rows(rowcount).Cells(1).Value = "spag" Or DataGridView1.Rows(rowcount).Cells(1).Value = "pie" Then
                DTYPE(token, rowcount, linecount2, return2)
                If return2 = True Then
                    rowcount = rowcount + 1
                    If rowcount < DataGridView1.Rows.Count Then
                        If DataGridView1.Rows(rowcount).Cells(1).Value = "identifier" Then
                            VDEC(token, rowcount, linecount2, return2)
                            If return2 = True Then
                                If rowcount < DataGridView1.Rows.Count Then
                                    If DataGridView1.Rows(rowcount).Cells(1).Value = "$" Then
                                        rowcount = rowcount + 1
                                        If rowcount < DataGridView1.Rows.Count Then
                                            If DataGridView1.Rows(rowcount).Cells(1).Value = "num" Or DataGridView1.Rows(rowcount).Cells(1).Value = "spag" Or DataGridView1.Rows(rowcount).Cells(1).Value = "tea" Or DataGridView1.Rows(rowcount).Cells(1).Value = "pie" Then
                                                Vtail(token, rowcount, linecount2, return2)
                                            Else
                                                Exit Sub
                                            End If
                                        Else
                                            Exit Sub
                                        End If
                                    Else
                                        return2 = False
                                        SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount & ") terminator missing" & Environment.NewLine)
                                        flag1 = flag1 + 1
                                        Exit Sub
                                    End If
                                Else
                                    return2 = False
                                    SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount & ") terminator missing" & Environment.NewLine)
                                    flag1 = flag1 + 1
                                    Exit Sub
                                End If
                            Else
                                return2 = False
                                Exit Sub
                            End If
                        Else
                            return2 = False

                            SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount & ") id misng" & Environment.NewLine)
                            flag1 = flag1 + 1

                        End If
                    Else
                        return2 = False
                        SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount & ") id missing" & Environment.NewLine)
                        flag1 = flag1 + 1

                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            ElseIf DataGridView1.Rows(rowcount).Cells(1).Value = "tea" Then
                If return2 = True Then
                    rowcount = rowcount + 1
                    If rowcount < DataGridView1.Rows.Count Then
                        If DataGridView1.Rows(rowcount).Cells(1).Value = "num" Or DataGridView1.Rows(rowcount).Cells(1).Value = "spag" Or DataGridView1.Rows(rowcount).Cells(1).Value = "pie" Then
                            DTYPE(token, rowcount, linecount2, return2)
                            If return2 = True Then
                                rowcount = rowcount + 1
                                If rowcount < DataGridView1.Rows.Count Then
                                    If DataGridView1.Rows(rowcount).Cells(1).Value = "identifier" Then
                                        VDEC(token, rowcount, linecount2, return2)
                                        If return2 = True Then
                                            If rowcount < DataGridView1.Rows.Count Then
                                                If DataGridView1.Rows(rowcount).Cells(1).Value = "$" Then
                                                    rowcount = rowcount + 1
                                                    If rowcount < DataGridView1.Rows.Count Then
                                                        If DataGridView1.Rows(rowcount).Cells(1).Value = "num" Or DataGridView1.Rows(rowcount).Cells(1).Value = "spag" Or DataGridView1.Rows(rowcount).Cells(1).Value = "tea" Or DataGridView1.Rows(rowcount).Cells(1).Value = "pie" Then
                                                            Vtail(token, rowcount, linecount2, return2)
                                                        Else
                                                            Exit Sub
                                                        End If
                                                    Else
                                                        Exit Sub
                                                    End If
                                                Else
                                                    return2 = False
                                                    SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount & ") terminator missing" & Environment.NewLine)
                                                    flag1 = flag1 + 1
                                                    Exit Sub
                                                End If
                                            Else
                                                return2 = False
                                                SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount & ") terminator missing" & Environment.NewLine)
                                                flag1 = flag1 + 1
                                                Exit Sub
                                            End If
                                        Else
                                            return2 = False
                                            Exit Sub
                                        End If
                                    Else
                                        return2 = False
                                        SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount & ") identifier missing" & Environment.NewLine)
                                        flag1 = flag1 + 1
                                        Exit Sub
                                    End If
                                Else
                                    return2 = False
                                    SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount & ") identifier missing" & Environment.NewLine)
                                    flag1 = flag1 + 1
                                    Exit Sub
                                End If
                            Else
                                return2 = False
                                Exit Sub
                            End If
                        End If
                    Else
                        return2 = False
                        SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount & ") data type missing" & Environment.NewLine)
                        flag1 = flag1 + 1
                        Exit Sub
                    End If
                Else
                    return2 = False
                    SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount & ") data type missing" & Environment.NewLine)
                    flag1 = flag1 + 1
                    Exit Sub
                End If
                Exit Sub
            End If
        End If
        If flag1 = 0 Then
            SyntaxErrorBox.AppendText("NO SYNTAX ERROR" & Environment.NewLine)
        End If
    End Sub
    Sub VDEC(ByVal Bee As String, ByVal count As Integer, ByVal linecount1 As Integer, ByVal return1 As Boolean)

        Dim token As String
        token = Bee
        rowcount = count
        linecount2 = linecount1
        return2 = return1

        If rowcount < DataGridView1.Rows.Count Then
            If DataGridView1.Rows(rowcount).Cells(1).Value = "identifier" Then
                IDENTIFIER(token, rowcount, linecount2, return2)   '1:48 am wait lang tangina
                If return2 = True Then
                    If rowcount < DataGridView1.Rows.Count Then
                        If DataGridView1.Rows(rowcount).Cells(1).Value = "," Then
                            VDEC2(token, rowcount, linecount2, return2) '1:48 am wait lang tangina
                        Else
                            Exit Sub
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            Else
                SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") identifier missing" & Environment.NewLine)
                return2 = False

                Exit Sub
            End If
        Else
            SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") identifier missing" & Environment.NewLine)
            return2 = False

            Exit Sub
        End If

    End Sub
    Sub DTYPE(ByVal Bee As String, ByVal count As Integer, ByVal linecount1 As Integer, ByVal return1 As Boolean)

        Dim token As String
        token = Bee
        rowcount = count
        linecount2 = linecount1
        return2 = return1

        If rowcount < DataGridView1.Rows.Count Then
            If DataGridView1.Rows(rowcount).Cells(1).Value = "num" Then
                rowcount = rowcount + 1
            ElseIf DataGridView1.Rows(rowcount).Cells(1).Value = "spag" Then
                rowcount = rowcount + 1
            ElseIf DataGridView1.Rows(rowcount).Cells(1).Value = "pie" Then
                rowcount = rowcount + 1
            Else
                SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data type required" & Environment.NewLine)
                return2 = False
            End If
        Else
            SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data type required" & Environment.NewLine)
            return2 = False
        End If

    End Sub
    Sub VDEC2(ByVal Bee As String, ByVal count As Integer, ByVal linecount1 As Integer, ByVal return1 As Boolean)

        Dim token As String
        token = Bee
        rowcount = count
        linecount2 = linecount1
        return2 = return1

        If rowcount < DataGridView1.Rows.Count Then
            If DataGridView1.Rows(rowcount).Cells(1).Value = "," Then
                rowcount = rowcount + 1
                If rowcount < DataGridView1.Rows.Count Then
                    If DataGridView1.Rows(rowcount).Cells(1).Value = "identifier" Then
                        VDEC(token, rowcount, linecount2, return2)
                    Else
                        SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") identifier missing" & Environment.NewLine)
                        return2 = False
                        Exit Sub
                    End If
                Else
                    SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") identifier missing" & Environment.NewLine)
                    return2 = False
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If

    End Sub
    Sub Vtail(ByVal Bee As String, ByVal count As Integer, ByVal linecount1 As Integer, ByVal return1 As Boolean)

        Dim token As String
        token = Bee
        rowcount = count
        linecount2 = linecount1
        return2 = return1

        If return2 = True Then
            If rowcount < DataGridView1.Rows.Count Then
                If DataGridView1.Rows(rowcount).Cells(1).Value = "num" Or DataGridView1.Rows(rowcount).Cells(1).Value = "spag" Or DataGridView1.Rows(rowcount).Cells(1).Value = "tea" Or DataGridView1.Rows(rowcount).Cells(1).Value = "pie" Then
                    VDEC(token, rowcount, linecount2, return2)
                Else
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If

    End Sub
    Sub IDENTIFIER(ByVal Bee As String, ByVal count As Integer, ByVal linecount1 As Integer, ByVal return1 As Boolean)

        Dim token As String
        token = Bee
        rowcount = count
        linecount2 = linecount1
        return2 = return1

        If rowcount < DataGridView1.Rows.Count Then
            If DataGridView1.Rows(rowcount).Cells(1).Value = "identifier" Then
                rowcount = rowcount + 1
                If rowcount < DataGridView1.Rows.Count Then
                    If DataGridView1.Rows(rowcount).Cells(1).Value = "=" Or DataGridView1.Rows(rowcount).Cells(1).Value = "[" Then
                        JOLLIARRAY(token, rowcount, linecount2, return2) '= OR [
                    Else

                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            Else
                SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") identifier missing" & Environment.NewLine)
                return2 = False
                Exit Sub
            End If

        End If
    End Sub
    Sub JOLLIARRAY(ByVal Bee As String, ByVal count As Integer, ByVal linecount1 As Integer, ByVal return1 As Boolean)

        Dim token As String
        token = Bee
        rowcount = count
        linecount2 = linecount1
        return2 = return1

        If rowcount < DataGridView1.Rows.Count Then
            If DataGridView1.Rows(rowcount).Cells(1).Value = "=" Then
                rowcount = rowcount + 1
                If rowcount < DataGridView1.Rows.Count Then
                    If DataGridView1.Rows(rowcount).Cells(1).Value = "numlit" Or DataGridView1.Rows(rowcount).Cells(1).Value = "spaglit" Or DataGridView1.Rows(rowcount).Cells(1).Value = "pielit" Then
                        VALUE(token, rowcount, linecount2, return2)
                    Else
                        SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data value missing" & Environment.NewLine)
                        return2 = False
                        Exit Sub
                    End If
                Else
                    SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data value missing" & Environment.NewLine)
                    return2 = False
                    Exit Sub
                End If
            ElseIf DataGridView1.Rows(rowcount).Cells(1).Value = "[" Then
                rowcount = rowcount + 1
                If rowcount < DataGridView1.Rows.Count Then
                    If DataGridView1.Rows(rowcount).Cells(1).Value = "num" Then
                        rowcount = rowcount + 1
                        If rowcount < DataGridView1.Rows.Count Then
                            If DataGridView1.Rows(rowcount).Cells(1).Value = "]" Then
                                rowcount = rowcount + 1
                                If rowcount < DataGridView1.Rows.Count Then
                                    If DataGridView1.Rows(rowcount).Cells(1).Value = "=" Then
                                        DECARRAY(token, rowcount, linecount2, return2) 'continuation of array [][]
                                    Else
                                        Exit Sub
                                    End If
                                Else
                                    Exit Sub
                                End If
                            Else
                                SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") ] missing" & Environment.NewLine)
                                return2 = False
                                Exit Sub
                            End If
                        Else
                            SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") ] missing" & Environment.NewLine)
                            return2 = False
                            Exit Sub
                        End If
                    Else
                        SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") array size missing" & Environment.NewLine)
                        return2 = False
                        Exit Sub
                    End If
                Else
                    SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") array size missing" & Environment.NewLine)
                    return2 = False
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If

    End Sub
    Sub VALUE(ByVal Arsh As String, ByVal count As Integer, ByVal linecount1 As Integer, ByVal return1 As Boolean)

        Dim token As String
        token = Arsh
        rowcount = count
        linecount2 = linecount1
        return2 = return1

        If rowcount < DataGridView1.Rows.Count Then
            If DataGridView1.Rows(rowcount).Cells(1).Value = "numlit" Then
                rowcount = rowcount + 1
            ElseIf DataGridView1.Rows(rowcount).Cells(1).Value = "spaglit" Then
                rowcount = rowcount + 1
            ElseIf DataGridView1.Rows(rowcount).Cells(1).Value = "pielit" Then
                rowcount = rowcount + 1

            Else
                SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data value missing" & Environment.NewLine)
                return2 = False
                Exit Sub
            End If
        Else
            SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data value missing" & Environment.NewLine)
            return2 = False
            Exit Sub
        End If

    End Sub
    Sub DECARRAY(ByVal Bee As String, ByVal count As Integer, ByVal linecount1 As Integer, ByVal return1 As Boolean)

        Dim token As String
        token = Bee
        rowcount = count
        linecount2 = linecount1
        return2 = return1

        If rowcount < DataGridView1.Rows.Count Then
            If DataGridView1.Rows(rowcount).Cells(1).Value = "=" Then
                rowcount = rowcount + 1
                If rowcount < DataGridView1.Rows.Count Then
                    If DataGridView1.Rows(rowcount).Cells(1).Value = "{" Then
                        rowcount = rowcount + 1
                        If rowcount < DataGridView1.Rows.Count Then
                            If DataGridView1.Rows(rowcount).Cells(1).Value = "numlit" Or DataGridView1.Rows(rowcount).Cells(1).Value = "spaglit" Or DataGridView1.Rows(rowcount).Cells(1).Value = "pielit" Then
                                ARRVALUE(token, rowcount, linecount2, return2)
                                If return2 = True Then
                                    rowcount = rowcount + 1
                                    If rowcount < DataGridView1.Rows.Count Then
                                        If DataGridView1.Rows(rowcount).Cells(1).Value = "}" Then
                                            rowcount = rowcount + 1
                                        Else
                                            SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") } missing" & Environment.NewLine)
                                            return2 = False
                                            Exit Sub
                                        End If
                                    Else
                                        SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") ) missing" & Environment.NewLine)
                                        return2 = False
                                        Exit Sub
                                    End If
                                Else
                                    SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") ) missing" & Environment.NewLine)
                                    return2 = False
                                    Exit Sub
                                End If
                            Else
                                SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data value missing" & Environment.NewLine)
                                return2 = False
                                Exit Sub
                            End If
                        Else
                            SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data type missing" & Environment.NewLine)
                            return2 = False
                            Exit Sub
                        End If
                    Else
                        SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") ( missing" & Environment.NewLine)
                        return2 = False
                        Exit Sub
                    End If
                Else
                    SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") ( missing" & Environment.NewLine)
                    return2 = False
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If

    End Sub
    Sub ARRVALUE(ByVal Arsh As String, ByVal count As Integer, ByVal linecount1 As Integer, ByVal return1 As Boolean)

        Dim token As String
        token = Arsh
        rowcount = count
        linecount2 = linecount1
        return2 = return1

        If rowcount < DataGridView1.Rows.Count Then
            If DataGridView1.Rows(rowcount).Cells(1).Value = "numlit" Or DataGridView1.Rows(rowcount).Cells(1).Value = "spaglit" Or DataGridView1.Rows(rowcount).Cells(1).Value = "pielit" Then
                VALUE(token, rowcount, linecount2, return2)
                If return2 = True Then
                    If rowcount < DataGridView1.Rows.Count Then
                        If DataGridView1.Rows(rowcount).Cells(1).Value = "," Then
                            VALUE1(token, rowcount, linecount2, return2)
                        End If
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            Else
                SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data value missing" & Environment.NewLine)
                return2 = False
                Exit Sub
            End If
        Else
            SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data value missing" & Environment.NewLine)
            return2 = False
            Exit Sub
        End If

    End Sub
    Sub VALUE1(ByVal Arsh As String, ByVal count As Integer, ByVal linecount1 As Integer, ByVal return1 As Boolean)

        Dim token As String
        token = Arsh
        rowcount = count
        linecount2 = linecount1
        return2 = return1

        If rowcount < DataGridView1.Rows.Count Then
            If DataGridView1.Rows(rowcount).Cells(1).Value = "," Then
                rowcount = rowcount + 1
                If rowcount < DataGridView1.Rows.Count Then
                    If DataGridView1.Rows(rowcount).Cells(1).Value = "numlit" Or DataGridView1.Rows(rowcount).Cells(1).Value = "spaglit" Or DataGridView1.Rows(rowcount).Cells(1).Value = "pielit" Then
                        ARRVALUE(token, rowcount, linecount2, return2)
                    Else
                        SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data value missing" & Environment.NewLine)
                        return2 = False
                        Exit Sub
                    End If
                Else
                    SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data value missing" & Environment.NewLine)
                    return2 = False
                    Exit Sub
                End If
            Else
                SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data value missing" & Environment.NewLine)
                return2 = False
                Exit Sub
            End If
        Else
            SyntaxErrorBox.AppendText("Syntax Error: (Line # " & linecount2 & ") data value missing" & Environment.NewLine)
            return2 = False
            Exit Sub
        End If
    End Sub

    'Private Sub Token()
    '    Dim Lexeme As String
    '    Dim Token As String
    '    Dim sb As New System.Text.StringBuilder
    '    For Each r As DataGridViewRow In DataGridView1.Rows

    '    Next

    'End Sub

    'Private Sub PrintLine(printer As PosPrinter, token As String)
    '    PrintText(printer, TruncateAt(token.ToString))

    'End Sub

    'Private Sub Pri()

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Close()
    End Sub

    Private Sub TextBox1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            linecount2 = linecount2 + 1
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Clear()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub SyntaxErrorBox_TextChanged(sender As Object, e As EventArgs) Handles SyntaxErrorBox.TextChanged

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub
End Class
