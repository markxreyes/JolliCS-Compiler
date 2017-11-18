<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox1 = New System.Windows.Forms.RichTextBox()
        Me.LexicalErrorBox = New System.Windows.Forms.RichTextBox()
        Me.SyntaxAnalyzerButton = New System.Windows.Forms.Button()
        Me.SyntaxErrorBox = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.LexicalAnalyzerButton = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Lexeme = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Token = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LineNumbers_For_RichTextBox1 = New LexicalAnalyzer.LineNumbers_For_RichTextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Lexeme, Me.Token, Me.Line})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(765, 15)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(532, 307)
        Me.DataGridView1.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.AutoWordSelection = True
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(84, 139)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(649, 405)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "mamsir$" & Global.Microsoft.VisualBasic.ChrW(10) & "tray()" & Global.Microsoft.VisualBasic.ChrW(10) & "{" & Global.Microsoft.VisualBasic.ChrW(10) & "takeout // ""Welcome to JolliCS""$" & Global.Microsoft.VisualBasic.ChrW(10) & "}" & Global.Microsoft.VisualBasic.ChrW(10) & "thanks$ "
        Me.TextBox1.WordWrap = False
        '
        'LexicalErrorBox
        '
        Me.LexicalErrorBox.BackColor = System.Drawing.Color.White
        Me.LexicalErrorBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LexicalErrorBox.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LexicalErrorBox.Location = New System.Drawing.Point(765, 357)
        Me.LexicalErrorBox.Margin = New System.Windows.Forms.Padding(4)
        Me.LexicalErrorBox.Name = "LexicalErrorBox"
        Me.LexicalErrorBox.ReadOnly = True
        Me.LexicalErrorBox.Size = New System.Drawing.Size(532, 187)
        Me.LexicalErrorBox.TabIndex = 5
        Me.LexicalErrorBox.Text = ""
        '
        'SyntaxAnalyzerButton
        '
        Me.SyntaxAnalyzerButton.Location = New System.Drawing.Point(16, 389)
        Me.SyntaxAnalyzerButton.Margin = New System.Windows.Forms.Padding(4)
        Me.SyntaxAnalyzerButton.Name = "SyntaxAnalyzerButton"
        Me.SyntaxAnalyzerButton.Size = New System.Drawing.Size(483, 28)
        Me.SyntaxAnalyzerButton.TabIndex = 6
        Me.SyntaxAnalyzerButton.Text = "Syntax Analyzer"
        Me.SyntaxAnalyzerButton.UseVisualStyleBackColor = True
        '
        'SyntaxErrorBox
        '
        Me.SyntaxErrorBox.BackColor = System.Drawing.Color.Black
        Me.SyntaxErrorBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SyntaxErrorBox.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SyntaxErrorBox.ForeColor = System.Drawing.Color.White
        Me.SyntaxErrorBox.Location = New System.Drawing.Point(38, 571)
        Me.SyntaxErrorBox.Margin = New System.Windows.Forms.Padding(4)
        Me.SyntaxErrorBox.Name = "SyntaxErrorBox"
        Me.SyntaxErrorBox.ReadOnly = True
        Me.SyntaxErrorBox.Size = New System.Drawing.Size(695, 150)
        Me.SyntaxErrorBox.TabIndex = 7
        Me.SyntaxErrorBox.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(38, 552)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 19)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "SYNTAX ERROR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(765, 338)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 19)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "LEXICAL ERROR"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Image = Global.LexicalAnalyzer.My.Resources.Resources.clear
        Me.Button1.Location = New System.Drawing.Point(647, 74)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 38)
        Me.Button1.TabIndex = 11
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.ForeColor = System.Drawing.Color.Transparent
        Me.Button4.Image = Global.LexicalAnalyzer.My.Resources.Resources.ccc_copy
        Me.Button4.Location = New System.Drawing.Point(16, 13)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(95, 38)
        Me.Button4.TabIndex = 9
        Me.Button4.UseVisualStyleBackColor = False
        '
        'LexicalAnalyzerButton
        '
        Me.LexicalAnalyzerButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LexicalAnalyzerButton.BackgroundImage = Global.LexicalAnalyzer.My.Resources.Resources.order
        Me.LexicalAnalyzerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.LexicalAnalyzerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LexicalAnalyzerButton.ForeColor = System.Drawing.Color.Transparent
        Me.LexicalAnalyzerButton.Image = Global.LexicalAnalyzer.My.Resources.Resources.order
        Me.LexicalAnalyzerButton.Location = New System.Drawing.Point(647, 28)
        Me.LexicalAnalyzerButton.Margin = New System.Windows.Forms.Padding(4)
        Me.LexicalAnalyzerButton.Name = "LexicalAnalyzerButton"
        Me.LexicalAnalyzerButton.Size = New System.Drawing.Size(95, 38)
        Me.LexicalAnalyzerButton.TabIndex = 2
        Me.LexicalAnalyzerButton.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Red
        Me.PictureBox1.BackgroundImage = Global.LexicalAnalyzer.My.Resources.Resources.QW
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(-39, -2)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1372, 761)
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Lexeme
        '
        Me.Lexeme.HeaderText = "Lexeme"
        Me.Lexeme.Name = "Lexeme"
        Me.Lexeme.ReadOnly = True
        '
        'Token
        '
        Me.Token.HeaderText = "Token"
        Me.Token.Name = "Token"
        Me.Token.ReadOnly = True
        '
        'Line
        '
        Me.Line.HeaderText = "Line"
        Me.Line.Name = "Line"
        Me.Line.ReadOnly = True
        Me.Line.Visible = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.Black
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Font = New System.Drawing.Font("Century Gothic", 8.25!)
        Me.RichTextBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RichTextBox1.Location = New System.Drawing.Point(765, 570)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(532, 151)
        Me.RichTextBox1.TabIndex = 14
        Me.RichTextBox1.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(765, 551)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 19)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "SEMANTICS ERROR"
        '
        'LineNumbers_For_RichTextBox1
        '
        Me.LineNumbers_For_RichTextBox1._SeeThroughMode_ = False
        Me.LineNumbers_For_RichTextBox1.AutoSizing = False
        Me.LineNumbers_For_RichTextBox1.BackColor = System.Drawing.SystemColors.Window
        Me.LineNumbers_For_RichTextBox1.BackgroundGradient_AlphaColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LineNumbers_For_RichTextBox1.BackgroundGradient_BetaColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.LineNumbers_For_RichTextBox1.BackgroundGradient_Direction = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal
        Me.LineNumbers_For_RichTextBox1.BorderLines_Color = System.Drawing.Color.SlateGray
        Me.LineNumbers_For_RichTextBox1.BorderLines_Style = System.Drawing.Drawing2D.DashStyle.Dot
        Me.LineNumbers_For_RichTextBox1.BorderLines_Thickness = 1.0!
        Me.LineNumbers_For_RichTextBox1.DockSide = LexicalAnalyzer.LineNumbers_For_RichTextBox.LineNumberDockSide.Left
        Me.LineNumbers_For_RichTextBox1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LineNumbers_For_RichTextBox1.GridLines_Color = System.Drawing.Color.SlateGray
        Me.LineNumbers_For_RichTextBox1.GridLines_Style = System.Drawing.Drawing2D.DashStyle.Dot
        Me.LineNumbers_For_RichTextBox1.GridLines_Thickness = 1.0!
        Me.LineNumbers_For_RichTextBox1.LineNrs_Alignment = System.Drawing.ContentAlignment.TopRight
        Me.LineNumbers_For_RichTextBox1.LineNrs_AntiAlias = True
        Me.LineNumbers_For_RichTextBox1.LineNrs_AsHexadecimal = False
        Me.LineNumbers_For_RichTextBox1.LineNrs_ClippedByItemRectangle = True
        Me.LineNumbers_For_RichTextBox1.LineNrs_LeadingZeroes = True
        Me.LineNumbers_For_RichTextBox1.LineNrs_Offset = New System.Drawing.Size(0, 0)
        Me.LineNumbers_For_RichTextBox1.Location = New System.Drawing.Point(38, 139)
        Me.LineNumbers_For_RichTextBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.LineNumbers_For_RichTextBox1.MarginLines_Color = System.Drawing.Color.SlateGray
        Me.LineNumbers_For_RichTextBox1.MarginLines_Side = LexicalAnalyzer.LineNumbers_For_RichTextBox.LineNumberDockSide.Right
        Me.LineNumbers_For_RichTextBox1.MarginLines_Style = System.Drawing.Drawing2D.DashStyle.Solid
        Me.LineNumbers_For_RichTextBox1.MarginLines_Thickness = 1.0!
        Me.LineNumbers_For_RichTextBox1.Name = "LineNumbers_For_RichTextBox1"
        Me.LineNumbers_For_RichTextBox1.Padding = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.LineNumbers_For_RichTextBox1.ParentRichTextBox = Me.TextBox1
        Me.LineNumbers_For_RichTextBox1.Show_BackgroundGradient = True
        Me.LineNumbers_For_RichTextBox1.Show_BorderLines = True
        Me.LineNumbers_For_RichTextBox1.Show_GridLines = True
        Me.LineNumbers_For_RichTextBox1.Show_LineNrs = True
        Me.LineNumbers_For_RichTextBox1.Show_MarginLines = True
        Me.LineNumbers_For_RichTextBox1.Size = New System.Drawing.Size(45, 405)
        Me.LineNumbers_For_RichTextBox1.TabIndex = 8
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Ivory
        Me.ClientSize = New System.Drawing.Size(1332, 758)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SyntaxErrorBox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.LineNumbers_For_RichTextBox1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.LexicalErrorBox)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.LexicalAnalyzerButton)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.SyntaxAnalyzerButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LexicalAnalyzerButton As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents LexicalErrorBox As System.Windows.Forms.RichTextBox
    Friend WithEvents SyntaxAnalyzerButton As System.Windows.Forms.Button
    Friend WithEvents SyntaxErrorBox As System.Windows.Forms.RichTextBox
    Friend WithEvents LineNumbers_For_RichTextBox1 As LexicalAnalyzer.LineNumbers_For_RichTextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Lexeme As DataGridViewTextBoxColumn
    Friend WithEvents Token As DataGridViewTextBoxColumn
    Friend WithEvents Line As DataGridViewTextBoxColumn
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label3 As Label
End Class
