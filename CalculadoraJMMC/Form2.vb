﻿Public Class FormHelp

    Private Sub FormHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        richTxtBoxGeneral.Visible = True
        RichTextBoxAdvance.Visible = False
        RichTextBoxBasics.Visible = False

        centerForm(Form1.Location.X, Form1.Location.Y)

        TreeView1.ExpandAll()


    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick

        Select Case e.Node.Text
            Case "Operations"
                richTxtBoxGeneral.Visible = True
                RichTextBoxAdvance.Visible = False
                RichTextBoxBasics.Visible = False
            Case "Basic"
                richTxtBoxGeneral.Visible = False
                RichTextBoxAdvance.Visible = False
                RichTextBoxBasics.Visible = True
            Case "Advance"
                richTxtBoxGeneral.Visible = False
                RichTextBoxAdvance.Visible = True
                RichTextBoxBasics.Visible = False
        End Select



    End Sub


    Public Sub centerForm(x As Integer, y As Integer)

        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(x + Form1.Width, y)

    End Sub
End Class