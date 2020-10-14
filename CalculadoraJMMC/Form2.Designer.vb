<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormHelp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormHelp))
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Basic")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Advance")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Operations", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2})
        Me.richTxtBoxGeneral = New System.Windows.Forms.RichTextBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.RichTextBoxBasics = New System.Windows.Forms.RichTextBox()
        Me.RichTextBoxAdvance = New System.Windows.Forms.RichTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'richTxtBoxGeneral
        '
        Me.richTxtBoxGeneral.BackColor = System.Drawing.Color.White
        Me.richTxtBoxGeneral.Location = New System.Drawing.Point(125, 12)
        Me.richTxtBoxGeneral.Name = "richTxtBoxGeneral"
        Me.richTxtBoxGeneral.ReadOnly = True
        Me.richTxtBoxGeneral.Size = New System.Drawing.Size(346, 433)
        Me.richTxtBoxGeneral.TabIndex = 0
        Me.richTxtBoxGeneral.Text = resources.GetString("richTxtBoxGeneral.Text")
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(7, 12)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "Basic"
        TreeNode1.Text = "Basic"
        TreeNode2.Name = "Advance"
        TreeNode2.Text = "Advance"
        TreeNode3.Name = "Operations"
        TreeNode3.Text = "Operations"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode3})
        Me.TreeView1.Size = New System.Drawing.Size(112, 62)
        Me.TreeView1.TabIndex = 1
        '
        'RichTextBoxBasics
        '
        Me.RichTextBoxBasics.BackColor = System.Drawing.Color.White
        Me.RichTextBoxBasics.Location = New System.Drawing.Point(125, 12)
        Me.RichTextBoxBasics.Name = "RichTextBoxBasics"
        Me.RichTextBoxBasics.ReadOnly = True
        Me.RichTextBoxBasics.Size = New System.Drawing.Size(346, 432)
        Me.RichTextBoxBasics.TabIndex = 2
        Me.RichTextBoxBasics.Text = resources.GetString("RichTextBoxBasics.Text")
        '
        'RichTextBoxAdvance
        '
        Me.RichTextBoxAdvance.BackColor = System.Drawing.Color.White
        Me.RichTextBoxAdvance.Location = New System.Drawing.Point(125, 12)
        Me.RichTextBoxAdvance.Name = "RichTextBoxAdvance"
        Me.RichTextBoxAdvance.ReadOnly = True
        Me.RichTextBoxAdvance.Size = New System.Drawing.Size(346, 432)
        Me.RichTextBoxAdvance.TabIndex = 3
        Me.RichTextBoxAdvance.Text = resources.GetString("RichTextBoxAdvance.Text")
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Location = New System.Drawing.Point(7, 80)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(112, 364)
        Me.Panel1.TabIndex = 4
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(112, 365)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 30)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 30, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 26)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Calculator By Jotamarti"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 212)
        Me.Label2.Margin = New System.Windows.Forms.Padding(3, 30, 3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "2020 MIT License"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 457)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.RichTextBoxAdvance)
        Me.Controls.Add(Me.RichTextBoxBasics)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.richTxtBoxGeneral)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FormHelp"
        Me.Text = "Help"
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents richTxtBoxGeneral As RichTextBox
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents RichTextBoxBasics As RichTextBox
    Friend WithEvents RichTextBoxAdvance As RichTextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
