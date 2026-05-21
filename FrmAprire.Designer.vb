<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAprire
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnFadeOut = New System.Windows.Forms.Button()
        Me.PanelTest = New System.Windows.Forms.Panel()
        Me.DTGAprire = New System.Windows.Forms.DataGridView()
        Me.CboTabella = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PanelTest.SuspendLayout()
        CType(Me.DTGAprire, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(63, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(495, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Apre la tabella di Default impostata su  Clienti"
        '
        'BtnFadeOut
        '
        Me.BtnFadeOut.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.BtnFadeOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFadeOut.Location = New System.Drawing.Point(1122, 158)
        Me.BtnFadeOut.Name = "BtnFadeOut"
        Me.BtnFadeOut.Size = New System.Drawing.Size(184, 39)
        Me.BtnFadeOut.TabIndex = 6
        Me.BtnFadeOut.Text = "Chiudi"
        Me.BtnFadeOut.UseVisualStyleBackColor = False
        '
        'PanelTest
        '
        Me.PanelTest.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PanelTest.Controls.Add(Me.DTGAprire)
        Me.PanelTest.Location = New System.Drawing.Point(59, 214)
        Me.PanelTest.Name = "PanelTest"
        Me.PanelTest.Size = New System.Drawing.Size(1280, 414)
        Me.PanelTest.TabIndex = 7
        '
        'DTGAprire
        '
        Me.DTGAprire.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DTGAprire.Location = New System.Drawing.Point(61, 71)
        Me.DTGAprire.Name = "DTGAprire"
        Me.DTGAprire.Size = New System.Drawing.Size(1166, 293)
        Me.DTGAprire.TabIndex = 0
        '
        'CboTabella
        '
        Me.CboTabella.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboTabella.FormattingEnabled = True
        Me.CboTabella.Location = New System.Drawing.Point(771, 161)
        Me.CboTabella.Name = "CboTabella"
        Me.CboTabella.Size = New System.Drawing.Size(216, 32)
        Me.CboTabella.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(572, 169)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(177, 24)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Seleziona Tabella"
        '
        'FrmAprire
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1377, 673)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CboTabella)
        Me.Controls.Add(Me.PanelTest)
        Me.Controls.Add(Me.BtnFadeOut)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmAprire"
        Me.Text = "FrmAprire"
        Me.PanelTest.ResumeLayout(False)
        CType(Me.DTGAprire, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents BtnFadeOut As Button
    Friend WithEvents PanelTest As Panel
    Friend WithEvents DTGAprire As DataGridView
    Friend WithEvents CboTabella As ComboBox
    Friend WithEvents Label2 As Label
End Class
