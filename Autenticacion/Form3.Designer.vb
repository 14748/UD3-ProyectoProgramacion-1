<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.pnlRegister = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblRegisterRePassword = New System.Windows.Forms.Label()
        Me.lblRegisterPassword = New System.Windows.Forms.Label()
        Me.lblRegisterUsername = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.txtRegisterRePassword = New System.Windows.Forms.TextBox()
        Me.panel6 = New System.Windows.Forms.Panel()
        Me.pictureBox7 = New System.Windows.Forms.PictureBox()
        Me.linkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.label5 = New System.Windows.Forms.Label()
        Me.txtRegisterPassword = New System.Windows.Forms.TextBox()
        Me.label6 = New System.Windows.Forms.Label()
        Me.Register = New System.Windows.Forms.Button()
        Me.panel4 = New System.Windows.Forms.Panel()
        Me.panel5 = New System.Windows.Forms.Panel()
        Me.pictureBox4 = New System.Windows.Forms.PictureBox()
        Me.pictureBox5 = New System.Windows.Forms.PictureBox()
        Me.pictureBox6 = New System.Windows.Forms.PictureBox()
        Me.txtRegisterUsername = New System.Windows.Forms.TextBox()
        Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.label4 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.pictureBox3 = New System.Windows.Forms.PictureBox()
        Me.pictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.lblLoginPassword = New System.Windows.Forms.Label()
        Me.lblLoginUsername = New System.Windows.Forms.Label()
        Me.pnlRegister.SuspendLayout()
        CType(Me.pictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlRegister
        '
        Me.pnlRegister.BackColor = System.Drawing.Color.Black
        Me.pnlRegister.Controls.Add(Me.Button1)
        Me.pnlRegister.Controls.Add(Me.lblRegisterRePassword)
        Me.pnlRegister.Controls.Add(Me.lblRegisterPassword)
        Me.pnlRegister.Controls.Add(Me.lblRegisterUsername)
        Me.pnlRegister.Controls.Add(Me.label1)
        Me.pnlRegister.Controls.Add(Me.txtRegisterRePassword)
        Me.pnlRegister.Controls.Add(Me.panel6)
        Me.pnlRegister.Controls.Add(Me.pictureBox7)
        Me.pnlRegister.Controls.Add(Me.linkLabel2)
        Me.pnlRegister.Controls.Add(Me.label5)
        Me.pnlRegister.Controls.Add(Me.txtRegisterPassword)
        Me.pnlRegister.Controls.Add(Me.label6)
        Me.pnlRegister.Controls.Add(Me.Register)
        Me.pnlRegister.Controls.Add(Me.panel4)
        Me.pnlRegister.Controls.Add(Me.panel5)
        Me.pnlRegister.Controls.Add(Me.pictureBox4)
        Me.pnlRegister.Controls.Add(Me.pictureBox5)
        Me.pnlRegister.Controls.Add(Me.pictureBox6)
        Me.pnlRegister.Controls.Add(Me.txtRegisterUsername)
        Me.pnlRegister.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlRegister.Location = New System.Drawing.Point(0, 0)
        Me.pnlRegister.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlRegister.Name = "pnlRegister"
        Me.pnlRegister.Size = New System.Drawing.Size(397, 533)
        Me.pnlRegister.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(36, 28)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(323, 107)
        Me.Button1.TabIndex = 29
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblRegisterRePassword
        '
        Me.lblRegisterRePassword.AutoSize = True
        Me.lblRegisterRePassword.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.lblRegisterRePassword.ForeColor = System.Drawing.Color.Red
        Me.lblRegisterRePassword.Location = New System.Drawing.Point(23, 374)
        Me.lblRegisterRePassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRegisterRePassword.Name = "lblRegisterRePassword"
        Me.lblRegisterRePassword.Size = New System.Drawing.Size(352, 17)
        Me.lblRegisterRePassword.TabIndex = 27
        Me.lblRegisterRePassword.Text = "Invitation code is incorrect or has expired"
        Me.lblRegisterRePassword.Visible = False
        '
        'lblRegisterPassword
        '
        Me.lblRegisterPassword.AutoSize = True
        Me.lblRegisterPassword.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.lblRegisterPassword.ForeColor = System.Drawing.Color.Red
        Me.lblRegisterPassword.Location = New System.Drawing.Point(23, 302)
        Me.lblRegisterPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRegisterPassword.Name = "lblRegisterPassword"
        Me.lblRegisterPassword.Size = New System.Drawing.Size(288, 17)
        Me.lblRegisterPassword.TabIndex = 26
        Me.lblRegisterPassword.Text = "Password Has Less Than 6 Characters"
        Me.lblRegisterPassword.Visible = False
        '
        'lblRegisterUsername
        '
        Me.lblRegisterUsername.AutoSize = True
        Me.lblRegisterUsername.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.lblRegisterUsername.ForeColor = System.Drawing.Color.Red
        Me.lblRegisterUsername.Location = New System.Drawing.Point(23, 230)
        Me.lblRegisterUsername.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRegisterUsername.Name = "lblRegisterUsername"
        Me.lblRegisterUsername.Size = New System.Drawing.Size(288, 17)
        Me.lblRegisterUsername.TabIndex = 25
        Me.lblRegisterUsername.Text = "Username Has Less Than 4 Characters"
        Me.lblRegisterUsername.Visible = False
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.label1.ForeColor = System.Drawing.Color.Red
        Me.label1.Location = New System.Drawing.Point(23, 230)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(184, 17)
        Me.label1.TabIndex = 24
        Me.label1.Text = "Username Already Taken"
        Me.label1.Visible = False
        '
        'txtRegisterRePassword
        '
        Me.txtRegisterRePassword.BackColor = System.Drawing.Color.Black
        Me.txtRegisterRePassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRegisterRePassword.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRegisterRePassword.ForeColor = System.Drawing.Color.White
        Me.txtRegisterRePassword.Location = New System.Drawing.Point(68, 345)
        Me.txtRegisterRePassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRegisterRePassword.Name = "txtRegisterRePassword"
        Me.txtRegisterRePassword.Size = New System.Drawing.Size(292, 17)
        Me.txtRegisterRePassword.TabIndex = 3
        '
        'panel6
        '
        Me.panel6.BackColor = System.Drawing.Color.White
        Me.panel6.Location = New System.Drawing.Point(27, 369)
        Me.panel6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panel6.Name = "panel6"
        Me.panel6.Size = New System.Drawing.Size(333, 1)
        Me.panel6.TabIndex = 23
        '
        'pictureBox7
        '
        Me.pictureBox7.Image = Global.Autenticacion.My.Resources.Resources.Authentication_Lock
        Me.pictureBox7.Location = New System.Drawing.Point(27, 336)
        Me.pictureBox7.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictureBox7.Name = "pictureBox7"
        Me.pictureBox7.Size = New System.Drawing.Size(33, 31)
        Me.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBox7.TabIndex = 22
        Me.pictureBox7.TabStop = False
        '
        'linkLabel2
        '
        Me.linkLabel2.AutoSize = True
        Me.linkLabel2.LinkColor = System.Drawing.Color.White
        Me.linkLabel2.Location = New System.Drawing.Point(255, 468)
        Me.linkLabel2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.linkLabel2.Name = "linkLabel2"
        Me.linkLabel2.Size = New System.Drawing.Size(40, 16)
        Me.linkLabel2.TabIndex = 6
        Me.linkLabel2.TabStop = True
        Me.linkLabel2.Text = "Login"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.ForeColor = System.Drawing.Color.White
        Me.label5.Location = New System.Drawing.Point(84, 468)
        Me.label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(162, 16)
        Me.label5.TabIndex = 20
        Me.label5.Text = "Already have an account?"
        '
        'txtRegisterPassword
        '
        Me.txtRegisterPassword.BackColor = System.Drawing.Color.Black
        Me.txtRegisterPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRegisterPassword.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.txtRegisterPassword.ForeColor = System.Drawing.Color.White
        Me.txtRegisterPassword.Location = New System.Drawing.Point(68, 272)
        Me.txtRegisterPassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRegisterPassword.Name = "txtRegisterPassword"
        Me.txtRegisterPassword.Size = New System.Drawing.Size(292, 17)
        Me.txtRegisterPassword.TabIndex = 2
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label6.ForeColor = System.Drawing.Color.White
        Me.label6.Location = New System.Drawing.Point(167, 503)
        Me.label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(41, 20)
        Me.label6.TabIndex = 7
        Me.label6.Text = "Exit"
        '
        'Register
        '
        Me.Register.BackColor = System.Drawing.Color.White
        Me.Register.FlatAppearance.BorderSize = 0
        Me.Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Register.Font = New System.Drawing.Font("Bahnschrift", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Register.ForeColor = System.Drawing.Color.Black
        Me.Register.Location = New System.Drawing.Point(28, 406)
        Me.Register.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Register.Name = "Register"
        Me.Register.Size = New System.Drawing.Size(315, 41)
        Me.Register.TabIndex = 5
        Me.Register.Text = "REGISTER"
        Me.Register.UseVisualStyleBackColor = False
        '
        'panel4
        '
        Me.panel4.BackColor = System.Drawing.Color.White
        Me.panel4.Location = New System.Drawing.Point(27, 297)
        Me.panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panel4.Name = "panel4"
        Me.panel4.Size = New System.Drawing.Size(333, 1)
        Me.panel4.TabIndex = 13
        '
        'panel5
        '
        Me.panel5.BackColor = System.Drawing.Color.White
        Me.panel5.Location = New System.Drawing.Point(27, 225)
        Me.panel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panel5.Name = "panel5"
        Me.panel5.Size = New System.Drawing.Size(333, 1)
        Me.panel5.TabIndex = 14
        '
        'pictureBox4
        '
        Me.pictureBox4.Image = Global.Autenticacion.My.Resources.Resources.Authentication_Lock
        Me.pictureBox4.Location = New System.Drawing.Point(27, 263)
        Me.pictureBox4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictureBox4.Name = "pictureBox4"
        Me.pictureBox4.Size = New System.Drawing.Size(33, 31)
        Me.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBox4.TabIndex = 11
        Me.pictureBox4.TabStop = False
        '
        'pictureBox5
        '
        Me.pictureBox5.Image = Global.Autenticacion.My.Resources.Resources.Authentication_User
        Me.pictureBox5.Location = New System.Drawing.Point(27, 192)
        Me.pictureBox5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictureBox5.Name = "pictureBox5"
        Me.pictureBox5.Size = New System.Drawing.Size(33, 31)
        Me.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBox5.TabIndex = 12
        Me.pictureBox5.TabStop = False
        '
        'pictureBox6
        '
        Me.pictureBox6.BackColor = System.Drawing.Color.Black
        Me.pictureBox6.Location = New System.Drawing.Point(27, 15)
        Me.pictureBox6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictureBox6.Name = "pictureBox6"
        Me.pictureBox6.Size = New System.Drawing.Size(347, 138)
        Me.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBox6.TabIndex = 9
        Me.pictureBox6.TabStop = False
        '
        'txtRegisterUsername
        '
        Me.txtRegisterUsername.BackColor = System.Drawing.Color.Black
        Me.txtRegisterUsername.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtRegisterUsername.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.txtRegisterUsername.ForeColor = System.Drawing.Color.White
        Me.txtRegisterUsername.Location = New System.Drawing.Point(51, 73)
        Me.txtRegisterUsername.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRegisterUsername.Name = "txtRegisterUsername"
        Me.txtRegisterUsername.Size = New System.Drawing.Size(292, 17)
        Me.txtRegisterUsername.TabIndex = 1
        '
        'linkLabel1
        '
        Me.linkLabel1.AutoSize = True
        Me.linkLabel1.LinkColor = System.Drawing.Color.White
        Me.linkLabel1.Location = New System.Drawing.Point(219, 466)
        Me.linkLabel1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.linkLabel1.Name = "linkLabel1"
        Me.linkLabel1.Size = New System.Drawing.Size(58, 16)
        Me.linkLabel1.TabIndex = 37
        Me.linkLabel1.TabStop = True
        Me.linkLabel1.Text = "Register"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.ForeColor = System.Drawing.Color.White
        Me.label4.Location = New System.Drawing.Point(97, 466)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(116, 16)
        Me.label4.TabIndex = 39
        Me.label4.Text = "Need an account?"
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.Black
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.txtPassword.ForeColor = System.Drawing.Color.White
        Me.txtPassword.Location = New System.Drawing.Point(67, 270)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(292, 17)
        Me.txtPassword.TabIndex = 31
        Me.txtPassword.Text = "Password"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label3.ForeColor = System.Drawing.Color.White
        Me.label3.Location = New System.Drawing.Point(165, 501)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(41, 20)
        Me.label3.TabIndex = 38
        Me.label3.Text = "Exit"
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.White
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Bahnschrift", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.ForeColor = System.Drawing.Color.Black
        Me.btnLogin.Location = New System.Drawing.Point(27, 404)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(315, 41)
        Me.btnLogin.TabIndex = 36
        Me.btnLogin.Text = "LOG IN"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.White
        Me.panel2.Location = New System.Drawing.Point(25, 295)
        Me.panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(333, 1)
        Me.panel2.TabIndex = 34
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.White
        Me.panel1.Location = New System.Drawing.Point(25, 223)
        Me.panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(333, 1)
        Me.panel1.TabIndex = 35
        '
        'pictureBox3
        '
        Me.pictureBox3.Image = Global.Autenticacion.My.Resources.Resources.Authentication_Lock
        Me.pictureBox3.Location = New System.Drawing.Point(25, 261)
        Me.pictureBox3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictureBox3.Name = "pictureBox3"
        Me.pictureBox3.Size = New System.Drawing.Size(33, 31)
        Me.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBox3.TabIndex = 32
        Me.pictureBox3.TabStop = False
        '
        'pictureBox2
        '
        Me.pictureBox2.Image = Global.Autenticacion.My.Resources.Resources.Authentication_User
        Me.pictureBox2.Location = New System.Drawing.Point(25, 190)
        Me.pictureBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictureBox2.Name = "pictureBox2"
        Me.pictureBox2.Size = New System.Drawing.Size(33, 31)
        Me.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBox2.TabIndex = 33
        Me.pictureBox2.TabStop = False
        '
        'pictureBox1
        '
        Me.pictureBox1.Location = New System.Drawing.Point(25, 14)
        Me.pictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(347, 138)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureBox1.TabIndex = 29
        Me.pictureBox1.TabStop = False
        '
        'txtUserName
        '
        Me.txtUserName.BackColor = System.Drawing.Color.Black
        Me.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUserName.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.txtUserName.ForeColor = System.Drawing.Color.White
        Me.txtUserName.Location = New System.Drawing.Point(67, 199)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(292, 17)
        Me.txtUserName.TabIndex = 30
        Me.txtUserName.Text = "Username"
        '
        'lblLoginPassword
        '
        Me.lblLoginPassword.AutoSize = True
        Me.lblLoginPassword.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.lblLoginPassword.ForeColor = System.Drawing.Color.Red
        Me.lblLoginPassword.Location = New System.Drawing.Point(21, 300)
        Me.lblLoginPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLoginPassword.Name = "lblLoginPassword"
        Me.lblLoginPassword.Size = New System.Drawing.Size(88, 17)
        Me.lblLoginPassword.TabIndex = 41
        Me.lblLoginPassword.Text = "Wrong HWID"
        Me.lblLoginPassword.Visible = False
        '
        'lblLoginUsername
        '
        Me.lblLoginUsername.AutoSize = True
        Me.lblLoginUsername.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.lblLoginUsername.ForeColor = System.Drawing.Color.Red
        Me.lblLoginUsername.Location = New System.Drawing.Point(23, 228)
        Me.lblLoginUsername.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLoginUsername.Name = "lblLoginUsername"
        Me.lblLoginUsername.Size = New System.Drawing.Size(280, 17)
        Me.lblLoginUsername.TabIndex = 42
        Me.lblLoginUsername.Text = "Please Input Username And Password"
        Me.lblLoginUsername.Visible = False
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(397, 533)
        Me.Controls.Add(Me.pnlRegister)
        Me.Controls.Add(Me.linkLabel1)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.pictureBox3)
        Me.Controls.Add(Me.pictureBox2)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.txtUserName)
        Me.Controls.Add(Me.lblLoginPassword)
        Me.Controls.Add(Me.lblLoginUsername)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "Form3"
        Me.Text = "Form1"
        Me.pnlRegister.ResumeLayout(False)
        Me.pnlRegister.PerformLayout()
        CType(Me.pictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents pnlRegister As Panel
    Private WithEvents lblRegisterRePassword As Label
    Private WithEvents lblRegisterPassword As Label
    Private WithEvents lblRegisterUsername As Label
    Private WithEvents label1 As Label
    Private WithEvents txtRegisterRePassword As TextBox
    Private WithEvents panel6 As Panel
    Private WithEvents pictureBox7 As PictureBox
    Private WithEvents linkLabel2 As LinkLabel
    Private WithEvents label5 As Label
    Private WithEvents txtRegisterPassword As TextBox
    Private WithEvents label6 As Label
    Private WithEvents Register As Button
    Private WithEvents panel4 As Panel
    Private WithEvents panel5 As Panel
    Private WithEvents pictureBox4 As PictureBox
    Private WithEvents pictureBox5 As PictureBox
    Public WithEvents txtRegisterUsername As TextBox
    Private WithEvents linkLabel1 As LinkLabel
    Private WithEvents label4 As Label
    Private WithEvents txtPassword As TextBox
    Private WithEvents label3 As Label
    Private WithEvents btnLogin As Button
    Private WithEvents panel2 As Panel
    Private WithEvents panel1 As Panel
    Private WithEvents pictureBox3 As PictureBox
    Private WithEvents pictureBox2 As PictureBox
    Private WithEvents pictureBox1 As PictureBox
    Private WithEvents txtUserName As TextBox
    Private WithEvents lblLoginPassword As Label
    Private WithEvents lblLoginUsername As Label
    Friend WithEvents Button1 As Button
    Private WithEvents pictureBox6 As PictureBox
End Class
