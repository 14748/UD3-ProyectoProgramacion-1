<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnconfig = New System.Windows.Forms.Button()
        Me.lbldeldia = New System.Windows.Forms.Label()
        Me.lblvict = New System.Windows.Forms.Label()
        Me.btnbarras = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(-2, 100)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(803, 13)
        Me.GroupBox1.TabIndex = 166
        Me.GroupBox1.TabStop = False
        '
        'btnconfig
        '
        Me.btnconfig.Image = CType(resources.GetObject("btnconfig.Image"), System.Drawing.Image)
        Me.btnconfig.Location = New System.Drawing.Point(634, 33)
        Me.btnconfig.Name = "btnconfig"
        Me.btnconfig.Size = New System.Drawing.Size(43, 37)
        Me.btnconfig.TabIndex = 165
        Me.btnconfig.UseVisualStyleBackColor = True
        '
        'lbldeldia
        '
        Me.lbldeldia.Font = New System.Drawing.Font("Segoe UI", 15.25!)
        Me.lbldeldia.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lbldeldia.Location = New System.Drawing.Point(354, 48)
        Me.lbldeldia.Name = "lbldeldia"
        Me.lbldeldia.Size = New System.Drawing.Size(91, 39)
        Me.lbldeldia.TabIndex = 164
        Me.lbldeldia.Text = "DEL DIA"
        '
        'lblvict
        '
        Me.lblvict.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblvict.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblvict.Location = New System.Drawing.Point(322, 9)
        Me.lblvict.Name = "lblvict"
        Me.lblvict.Size = New System.Drawing.Size(167, 39)
        Me.lblvict.TabIndex = 163
        Me.lblvict.Text = "La palabra del día"
        '
        'btnbarras
        '
        Me.btnbarras.Image = CType(resources.GetObject("btnbarras.Image"), System.Drawing.Image)
        Me.btnbarras.Location = New System.Drawing.Point(121, 29)
        Me.btnbarras.Name = "btnbarras"
        Me.btnbarras.Size = New System.Drawing.Size(42, 39)
        Me.btnbarras.TabIndex = 162
        Me.btnbarras.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnconfig)
        Me.Controls.Add(Me.lbldeldia)
        Me.Controls.Add(Me.lblvict)
        Me.Controls.Add(Me.btnbarras)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnconfig As Button
    Friend WithEvents lbldeldia As Label
    Friend WithEvents lblvict As Label
    Friend WithEvents btnbarras As Button
End Class
