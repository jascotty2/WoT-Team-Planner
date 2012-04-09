<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.lblProg = New System.Windows.Forms.Label()
        Me.radClan = New System.Windows.Forms.RadioButton()
        Me.pnlStart = New System.Windows.Forms.Panel()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblURL = New System.Windows.Forms.Label()
        Me.lblSearch = New System.Windows.Forms.Label()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.radTournament = New System.Windows.Forms.RadioButton()
        Me.pnlResults = New System.Windows.Forms.Panel()
        Me.btnSelectPlayersNone = New System.Windows.Forms.Button()
        Me.btnSelectPlayersAll = New System.Windows.Forms.Button()
        Me.btnSelectPlayersOK = New System.Windows.Forms.Button()
        Me.btnSelectPlayersCancel = New System.Windows.Forms.Button()
        Me.btnPickPlayers = New System.Windows.Forms.Button()
        Me.chklstShowPlayers = New System.Windows.Forms.CheckedListBox()
        Me.btnCancelRem = New System.Windows.Forms.Button()
        Me.btnRem = New System.Windows.Forms.Button()
        Me.chklstRemTeam = New System.Windows.Forms.CheckedListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtTeam = New System.Windows.Forms.TextBox()
        Me.chkEffective = New System.Windows.Forms.CheckBox()
        Me.lblTanks = New System.Windows.Forms.Label()
        Me.cmbTimeSpan = New System.Windows.Forms.ComboBox()
        Me.numTime = New System.Windows.Forms.NumericUpDown()
        Me.chkHideInactive = New System.Windows.Forms.CheckBox()
        Me.lstPlayers = New System.Windows.Forms.ListBox()
        Me.lstTanks = New System.Windows.Forms.ListBox()
        Me.txtPlayerTanks = New System.Windows.Forms.TextBox()
        Me.txtMembers = New System.Windows.Forms.TextBox()
        Me.txtClan = New System.Windows.Forms.TextBox()
        Me.lblTeam = New System.Windows.Forms.Label()
        Me.lblNumMembers = New System.Windows.Forms.Label()
        Me.lblClan = New System.Windows.Forms.Label()
        Me.lblInf = New System.Windows.Forms.Label()
        Me.pnlStart.SuspendLayout()
        Me.pnlResults.SuspendLayout()
        CType(Me.numTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblProg
        '
        Me.lblProg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProg.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProg.Location = New System.Drawing.Point(388, 307)
        Me.lblProg.Margin = New System.Windows.Forms.Padding(3, 0, 1, 0)
        Me.lblProg.Name = "lblProg"
        Me.lblProg.Size = New System.Drawing.Size(139, 14)
        Me.lblProg.TabIndex = 0
        Me.lblProg.Text = "Program by Jacob Scott"
        Me.lblProg.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'radClan
        '
        Me.radClan.AutoSize = True
        Me.radClan.Checked = True
        Me.radClan.Location = New System.Drawing.Point(10, 10)
        Me.radClan.Name = "radClan"
        Me.radClan.Size = New System.Drawing.Size(46, 17)
        Me.radClan.TabIndex = 1
        Me.radClan.TabStop = True
        Me.radClan.Text = "Clan"
        Me.radClan.UseVisualStyleBackColor = True
        '
        'pnlStart
        '
        Me.pnlStart.Controls.Add(Me.btnStart)
        Me.pnlStart.Controls.Add(Me.lblURL)
        Me.pnlStart.Controls.Add(Me.lblSearch)
        Me.pnlStart.Controls.Add(Me.txtURL)
        Me.pnlStart.Controls.Add(Me.txtSearch)
        Me.pnlStart.Controls.Add(Me.radTournament)
        Me.pnlStart.Controls.Add(Me.radClan)
        Me.pnlStart.Location = New System.Drawing.Point(12, 12)
        Me.pnlStart.Name = "pnlStart"
        Me.pnlStart.Size = New System.Drawing.Size(326, 79)
        Me.pnlStart.TabIndex = 2
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(239, 21)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(80, 28)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "Start Scan"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblURL
        '
        Me.lblURL.AutoSize = True
        Me.lblURL.Location = New System.Drawing.Point(3, 59)
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(92, 13)
        Me.lblURL.TabIndex = 4
        Me.lblURL.Text = "Tournament URL:"
        Me.lblURL.Visible = False
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(3, 36)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(62, 13)
        Me.lblSearch.TabIndex = 4
        Me.lblSearch.Text = "Search For:"
        '
        'txtURL
        '
        Me.txtURL.AcceptsReturn = True
        Me.txtURL.Location = New System.Drawing.Point(101, 56)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(222, 20)
        Me.txtURL.TabIndex = 3
        Me.txtURL.Visible = False
        '
        'txtSearch
        '
        Me.txtSearch.AcceptsReturn = True
        Me.txtSearch.Location = New System.Drawing.Point(71, 33)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(162, 20)
        Me.txtSearch.TabIndex = 3
        '
        'radTournament
        '
        Me.radTournament.AutoSize = True
        Me.radTournament.Location = New System.Drawing.Point(62, 10)
        Me.radTournament.Name = "radTournament"
        Me.radTournament.Size = New System.Drawing.Size(82, 17)
        Me.radTournament.TabIndex = 1
        Me.radTournament.Text = "Tournament"
        Me.radTournament.UseVisualStyleBackColor = True
        '
        'pnlResults
        '
        Me.pnlResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlResults.Controls.Add(Me.btnSelectPlayersNone)
        Me.pnlResults.Controls.Add(Me.btnSelectPlayersAll)
        Me.pnlResults.Controls.Add(Me.btnSelectPlayersOK)
        Me.pnlResults.Controls.Add(Me.btnSelectPlayersCancel)
        Me.pnlResults.Controls.Add(Me.btnPickPlayers)
        Me.pnlResults.Controls.Add(Me.chklstShowPlayers)
        Me.pnlResults.Controls.Add(Me.btnCancelRem)
        Me.pnlResults.Controls.Add(Me.btnRem)
        Me.pnlResults.Controls.Add(Me.chklstRemTeam)
        Me.pnlResults.Controls.Add(Me.btnAdd)
        Me.pnlResults.Controls.Add(Me.txtTeam)
        Me.pnlResults.Controls.Add(Me.chkEffective)
        Me.pnlResults.Controls.Add(Me.lblTanks)
        Me.pnlResults.Controls.Add(Me.cmbTimeSpan)
        Me.pnlResults.Controls.Add(Me.numTime)
        Me.pnlResults.Controls.Add(Me.chkHideInactive)
        Me.pnlResults.Controls.Add(Me.lstPlayers)
        Me.pnlResults.Controls.Add(Me.lstTanks)
        Me.pnlResults.Controls.Add(Me.txtPlayerTanks)
        Me.pnlResults.Controls.Add(Me.txtMembers)
        Me.pnlResults.Controls.Add(Me.txtClan)
        Me.pnlResults.Controls.Add(Me.lblTeam)
        Me.pnlResults.Controls.Add(Me.lblNumMembers)
        Me.pnlResults.Controls.Add(Me.lblClan)
        Me.pnlResults.Location = New System.Drawing.Point(12, 2)
        Me.pnlResults.Name = "pnlResults"
        Me.pnlResults.Size = New System.Drawing.Size(503, 302)
        Me.pnlResults.TabIndex = 3
        Me.pnlResults.Visible = False
        '
        'btnSelectPlayersNone
        '
        Me.btnSelectPlayersNone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectPlayersNone.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSelectPlayersNone.Location = New System.Drawing.Point(6, 237)
        Me.btnSelectPlayersNone.Name = "btnSelectPlayersNone"
        Me.btnSelectPlayersNone.Size = New System.Drawing.Size(50, 16)
        Me.btnSelectPlayersNone.TabIndex = 12
        Me.btnSelectPlayersNone.Text = "None"
        Me.btnSelectPlayersNone.UseVisualStyleBackColor = True
        Me.btnSelectPlayersNone.Visible = False
        '
        'btnSelectPlayersAll
        '
        Me.btnSelectPlayersAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectPlayersAll.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSelectPlayersAll.Location = New System.Drawing.Point(6, 220)
        Me.btnSelectPlayersAll.Name = "btnSelectPlayersAll"
        Me.btnSelectPlayersAll.Size = New System.Drawing.Size(50, 16)
        Me.btnSelectPlayersAll.TabIndex = 12
        Me.btnSelectPlayersAll.Text = "All"
        Me.btnSelectPlayersAll.UseVisualStyleBackColor = True
        Me.btnSelectPlayersAll.Visible = False
        '
        'btnSelectPlayersOK
        '
        Me.btnSelectPlayersOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectPlayersOK.Location = New System.Drawing.Point(116, 231)
        Me.btnSelectPlayersOK.Name = "btnSelectPlayersOK"
        Me.btnSelectPlayersOK.Size = New System.Drawing.Size(53, 20)
        Me.btnSelectPlayersOK.TabIndex = 9
        Me.btnSelectPlayersOK.Text = "OK"
        Me.btnSelectPlayersOK.UseVisualStyleBackColor = True
        Me.btnSelectPlayersOK.Visible = False
        '
        'btnSelectPlayersCancel
        '
        Me.btnSelectPlayersCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSelectPlayersCancel.Location = New System.Drawing.Point(57, 231)
        Me.btnSelectPlayersCancel.Name = "btnSelectPlayersCancel"
        Me.btnSelectPlayersCancel.Size = New System.Drawing.Size(53, 20)
        Me.btnSelectPlayersCancel.TabIndex = 9
        Me.btnSelectPlayersCancel.Text = "Cancel"
        Me.btnSelectPlayersCancel.UseVisualStyleBackColor = True
        Me.btnSelectPlayersCancel.Visible = False
        '
        'btnPickPlayers
        '
        Me.btnPickPlayers.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnPickPlayers.Font = New System.Drawing.Font("Trebuchet MS", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPickPlayers.Location = New System.Drawing.Point(132, 22)
        Me.btnPickPlayers.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPickPlayers.Name = "btnPickPlayers"
        Me.btnPickPlayers.Size = New System.Drawing.Size(45, 22)
        Me.btnPickPlayers.TabIndex = 4
        Me.btnPickPlayers.Text = "Players"
        Me.btnPickPlayers.UseVisualStyleBackColor = True
        '
        'chklstShowPlayers
        '
        Me.chklstShowPlayers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chklstShowPlayers.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chklstShowPlayers.FormattingEnabled = True
        Me.chklstShowPlayers.Location = New System.Drawing.Point(6, 46)
        Me.chklstShowPlayers.Name = "chklstShowPlayers"
        Me.chklstShowPlayers.Size = New System.Drawing.Size(163, 173)
        Me.chklstShowPlayers.TabIndex = 11
        Me.chklstShowPlayers.Visible = False
        '
        'btnCancelRem
        '
        Me.btnCancelRem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelRem.Location = New System.Drawing.Point(379, 278)
        Me.btnCancelRem.Name = "btnCancelRem"
        Me.btnCancelRem.Size = New System.Drawing.Size(53, 20)
        Me.btnCancelRem.TabIndex = 9
        Me.btnCancelRem.Text = "Cancel"
        Me.btnCancelRem.UseVisualStyleBackColor = True
        Me.btnCancelRem.Visible = False
        '
        'btnRem
        '
        Me.btnRem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRem.Location = New System.Drawing.Point(438, 278)
        Me.btnRem.Name = "btnRem"
        Me.btnRem.Size = New System.Drawing.Size(62, 20)
        Me.btnRem.TabIndex = 9
        Me.btnRem.Text = "Remove"
        Me.btnRem.UseVisualStyleBackColor = True
        '
        'chklstRemTeam
        '
        Me.chklstRemTeam.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chklstRemTeam.FormattingEnabled = True
        Me.chklstRemTeam.Location = New System.Drawing.Point(175, 116)
        Me.chklstRemTeam.Name = "chklstRemTeam"
        Me.chklstRemTeam.Size = New System.Drawing.Size(325, 169)
        Me.chklstRemTeam.TabIndex = 10
        Me.chklstRemTeam.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(422, 93)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(78, 20)
        Me.btnAdd.TabIndex = 9
        Me.btnAdd.Text = "Add to Team"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtTeam
        '
        Me.txtTeam.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTeam.Font = New System.Drawing.Font("DejaVu Sans Mono", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeam.Location = New System.Drawing.Point(175, 116)
        Me.txtTeam.Multiline = True
        Me.txtTeam.Name = "txtTeam"
        Me.txtTeam.ReadOnly = True
        Me.txtTeam.Size = New System.Drawing.Size(325, 176)
        Me.txtTeam.TabIndex = 8
        '
        'chkEffective
        '
        Me.chkEffective.AutoSize = True
        Me.chkEffective.Checked = True
        Me.chkEffective.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEffective.Location = New System.Drawing.Point(10, 64)
        Me.chkEffective.Name = "chkEffective"
        Me.chkEffective.Size = New System.Drawing.Size(125, 17)
        Me.chkEffective.TabIndex = 7
        Me.chkEffective.Text = "Effective Tier Sorting"
        Me.chkEffective.UseVisualStyleBackColor = True
        '
        'lblTanks
        '
        Me.lblTanks.AutoSize = True
        Me.lblTanks.Location = New System.Drawing.Point(7, 45)
        Me.lblTanks.Name = "lblTanks"
        Me.lblTanks.Size = New System.Drawing.Size(40, 13)
        Me.lblTanks.TabIndex = 6
        Me.lblTanks.Text = "Tanks:"
        '
        'cmbTimeSpan
        '
        Me.cmbTimeSpan.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbTimeSpan.FormattingEnabled = True
        Me.cmbTimeSpan.Items.AddRange(New Object() {"Minutes", "Hours", "Days", "Weeks"})
        Me.cmbTimeSpan.Location = New System.Drawing.Point(81, 278)
        Me.cmbTimeSpan.Name = "cmbTimeSpan"
        Me.cmbTimeSpan.Size = New System.Drawing.Size(78, 21)
        Me.cmbTimeSpan.TabIndex = 5
        '
        'numTime
        '
        Me.numTime.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numTime.Location = New System.Drawing.Point(21, 279)
        Me.numTime.Maximum = New Decimal(New Integer() {99, 0, 0, 0})
        Me.numTime.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numTime.Name = "numTime"
        Me.numTime.Size = New System.Drawing.Size(54, 20)
        Me.numTime.TabIndex = 4
        Me.numTime.Value = New Decimal(New Integer() {24, 0, 0, 0})
        '
        'chkHideInactive
        '
        Me.chkHideInactive.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkHideInactive.AutoSize = True
        Me.chkHideInactive.Location = New System.Drawing.Point(6, 257)
        Me.chkHideInactive.Name = "chkHideInactive"
        Me.chkHideInactive.Size = New System.Drawing.Size(156, 17)
        Me.chkHideInactive.TabIndex = 3
        Me.chkHideInactive.Text = "Hide Members Inactive for: "
        Me.chkHideInactive.UseVisualStyleBackColor = True
        '
        'lstPlayers
        '
        Me.lstPlayers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstPlayers.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPlayers.FormattingEnabled = True
        Me.lstPlayers.ItemHeight = 11
        Me.lstPlayers.Location = New System.Drawing.Point(179, 44)
        Me.lstPlayers.Name = "lstPlayers"
        Me.lstPlayers.Size = New System.Drawing.Size(321, 48)
        Me.lstPlayers.TabIndex = 2
        '
        'lstTanks
        '
        Me.lstTanks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lstTanks.Font = New System.Drawing.Font("Lucida Console", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstTanks.FormattingEnabled = True
        Me.lstTanks.ItemHeight = 11
        Me.lstTanks.Location = New System.Drawing.Point(6, 84)
        Me.lstTanks.Name = "lstTanks"
        Me.lstTanks.Size = New System.Drawing.Size(163, 169)
        Me.lstTanks.TabIndex = 2
        '
        'txtPlayerTanks
        '
        Me.txtPlayerTanks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPlayerTanks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPlayerTanks.Location = New System.Drawing.Point(179, 25)
        Me.txtPlayerTanks.Name = "txtPlayerTanks"
        Me.txtPlayerTanks.ReadOnly = True
        Me.txtPlayerTanks.Size = New System.Drawing.Size(321, 13)
        Me.txtPlayerTanks.TabIndex = 1
        '
        'txtMembers
        '
        Me.txtMembers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtMembers.Location = New System.Drawing.Point(62, 26)
        Me.txtMembers.Name = "txtMembers"
        Me.txtMembers.ReadOnly = True
        Me.txtMembers.Size = New System.Drawing.Size(82, 13)
        Me.txtMembers.TabIndex = 1
        '
        'txtClan
        '
        Me.txtClan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtClan.Location = New System.Drawing.Point(47, 6)
        Me.txtClan.Name = "txtClan"
        Me.txtClan.ReadOnly = True
        Me.txtClan.Size = New System.Drawing.Size(335, 13)
        Me.txtClan.TabIndex = 1
        '
        'lblTeam
        '
        Me.lblTeam.AutoSize = True
        Me.lblTeam.Location = New System.Drawing.Point(179, 95)
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Size = New System.Drawing.Size(84, 13)
        Me.lblTeam.TabIndex = 0
        Me.lblTeam.Text = "Team Selection:"
        '
        'lblNumMembers
        '
        Me.lblNumMembers.AutoSize = True
        Me.lblNumMembers.Location = New System.Drawing.Point(7, 26)
        Me.lblNumMembers.Name = "lblNumMembers"
        Me.lblNumMembers.Size = New System.Drawing.Size(56, 13)
        Me.lblNumMembers.TabIndex = 0
        Me.lblNumMembers.Text = "Members: "
        '
        'lblClan
        '
        Me.lblClan.AutoSize = True
        Me.lblClan.Location = New System.Drawing.Point(7, 6)
        Me.lblClan.Name = "lblClan"
        Me.lblClan.Size = New System.Drawing.Size(34, 13)
        Me.lblClan.TabIndex = 0
        Me.lblClan.Text = "Clan: "
        '
        'lblInf
        '
        Me.lblInf.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblInf.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInf.Location = New System.Drawing.Point(2, 307)
        Me.lblInf.Margin = New System.Windows.Forms.Padding(3, 0, 1, 0)
        Me.lblInf.Name = "lblInf"
        Me.lblInf.Size = New System.Drawing.Size(263, 14)
        Me.lblInf.TabIndex = 0
        Me.lblInf.Text = "World of Tanks ClanStats Team Planner  for WoT 7.2"
        Me.lblInf.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 322)
        Me.Controls.Add(Me.pnlResults)
        Me.Controls.Add(Me.pnlStart)
        Me.Controls.Add(Me.lblInf)
        Me.Controls.Add(Me.lblProg)
        Me.MinimumSize = New System.Drawing.Size(425, 360)
        Me.Name = "frmMain"
        Me.Text = "WoT Team Planner"
        Me.pnlStart.ResumeLayout(False)
        Me.pnlStart.PerformLayout()
        Me.pnlResults.ResumeLayout(False)
        Me.pnlResults.PerformLayout()
        CType(Me.numTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblProg As System.Windows.Forms.Label
    Friend WithEvents radClan As System.Windows.Forms.RadioButton
    Friend WithEvents pnlStart As System.Windows.Forms.Panel
    Friend WithEvents radTournament As System.Windows.Forms.RadioButton
    Friend WithEvents lblURL As System.Windows.Forms.Label
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents pnlResults As System.Windows.Forms.Panel
    Friend WithEvents lblClan As System.Windows.Forms.Label
    Friend WithEvents txtClan As System.Windows.Forms.TextBox
    Friend WithEvents txtMembers As System.Windows.Forms.TextBox
    Friend WithEvents lblNumMembers As System.Windows.Forms.Label
    Friend WithEvents numTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents chkHideInactive As System.Windows.Forms.CheckBox
    Friend WithEvents lstTanks As System.Windows.Forms.ListBox
    Friend WithEvents cmbTimeSpan As System.Windows.Forms.ComboBox
    Friend WithEvents lblTanks As System.Windows.Forms.Label
    Friend WithEvents chkEffective As System.Windows.Forms.CheckBox
    Friend WithEvents txtPlayerTanks As System.Windows.Forms.TextBox
    Friend WithEvents lstPlayers As System.Windows.Forms.ListBox
    Friend WithEvents txtTeam As System.Windows.Forms.TextBox
    Friend WithEvents lblTeam As System.Windows.Forms.Label
    Friend WithEvents btnRem As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents chklstRemTeam As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblInf As System.Windows.Forms.Label
    Friend WithEvents btnCancelRem As System.Windows.Forms.Button
    Friend WithEvents chklstShowPlayers As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnPickPlayers As System.Windows.Forms.Button
    Friend WithEvents btnSelectPlayersCancel As System.Windows.Forms.Button
    Friend WithEvents btnSelectPlayersOK As System.Windows.Forms.Button
    Friend WithEvents btnSelectPlayersNone As System.Windows.Forms.Button
    Friend WithEvents btnSelectPlayersAll As System.Windows.Forms.Button

End Class
