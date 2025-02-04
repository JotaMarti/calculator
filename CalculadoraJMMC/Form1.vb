﻿Public Class Form1

    Dim operator1? As Decimal
    Dim operator2? As Decimal
    Dim previousBtnClicked As Button
    Dim previousOperation As Button
    Dim currentOperation As Button
    Dim cleanScreen As Boolean = False
    Dim numberEntered As Boolean = False
    Dim alreadyOperationEntered As Boolean = False
    Dim maxLenght As Integer = 16
    Dim empty As String = ""
    Dim numberZero As String = "0"
    Dim powY As Boolean = False
    Dim multConcat = False
    Dim normalMode = True

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MenuStripStandard.Checked = True
        TableLayoutPanelScientific.Visible = False
        TableLayoutPanelStandard.Visible = True
        PanelHideStandard.Visible = False
        btnEquals.Focus()

        hidePowY()
        centerForm()

    End Sub


    Private Sub btnNum_Click(sender As Object, e As EventArgs) Handles btnNum0.Click, btnNum1.Click, btnNum9.Click, btnNum8.Click, btnNum7.Click, btnNum6.Click, btnNum5.Click, btnNum4.Click, btnNum3.Click, btnNum2.Click, btnNum9Scientific.Click, btnNum8Scientific.Click, btnNum7Scientific.Click, btnNum6Scientific.Click, btnNum5Scientific.Click, btnNum4Scientific.Click, btnNum3Scientific.Click, btnNum2Scientific.Click, btnNum1Scientific.Click, btnNum0Scientific.Click

        alreadyOperationEntered = False

        If cleanScreen = True AndAlso
            previousBtnClicked.Text <> "," Then
            cleanTxtBox()
        End If

        previousBtnClicked = sender

        ' if pow of y is selected the program stays here taking numbers when a number is clicked, additionally we only
        ' take two numbers for the pow calculation
        If powY Then
            If Not LabelPow.Text.Length >= 2 Then
                LabelPow.Text = LabelPow.Text & previousBtnClicked.Text
            End If
            Exit Sub
        End If

        ' With this logic we don't add more numbers if the maxLenght is reached, in this case 16
        ' Additionally with this logic we dont put zeros at the left of any number
        If txtBoxResult.Text.Length < maxLenght Then
            If previousBtnClicked.Text = btnNum0.Text Then
                If txtBoxResult.Text = numberZero Or
                    txtBoxResult.Text = empty Then
                    txtBoxResult.Text = numberZero
                Else
                    txtBoxResult.Text = txtBoxResult.Text & previousBtnClicked.Text
                End If
            Else
                If txtBoxResult.Text = numberZero Then
                    txtBoxResult.Text = empty
                End If
                txtBoxResult.Text = txtBoxResult.Text & previousBtnClicked.Text
                numberEntered = True
            End If
        End If

    End Sub

    Private Sub btnOperation_Click(sender As Object, e As EventArgs) Handles btnSum.Click, btnMult.Click, btnRest.Click, btnDiv.Click, btnPercentage.Click, btnSumScientific.Click, btnRestScientific.Click, btnPercentageScientific.Click, btnMultScientific.Click, btnDivScientific.Click

        If alreadyOperationEntered Then
            Exit Sub
        End If

        alreadyOperationEntered = True

        If currentOperation IsNot Nothing Then
            previousOperation = currentOperation
        End If

        currentOperation = sender

        ' Check for when we it for example the plus sign couple if consecutive times, with this if the program doesn't fail
        If numberEntered = False Then
            Exit Sub
        End If

        ' Logic to handle the pows when we concatenate operations
        If powY Then
            Try
                operator1 = Math.Pow(Decimal.Parse(txtBoxResult.Text), Integer.Parse(LabelPow.Text))
                txtBoxResult.Text = operator1
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            cleanScreen = True
            hidePowY()
            Exit Sub
        End If

        If operator1 IsNot Nothing AndAlso
                sender.Text = btnMult.Text Then
            operator2 = Decimal.Parse(txtBoxResult.Text)
            multConcat = True
            cleanScreen = True
            Exit Sub
        End If

        If multConcat Then
            operator2 = Decimal.Parse(txtBoxResult.Text) * operator2
            txtBoxResult.Text = operator2
            previousOperation = currentOperation
            multConcat = False
        End If

        ' If operator1 is empty and we have entered some numbers we save the value un operator 1, if no number is entered we paint 0 again
        ' Else if operator1 is not empty we call the equals function to do an operation because that means that is a concatenate operation
        Try
            If operator1 Is Nothing AndAlso
            txtBoxResult.Text <> numberZero Then
                operator1 = Decimal.Parse(txtBoxResult.Text)
                cleanScreen = True
            ElseIf operator1 Is Nothing AndAlso
                txtBoxResult.Text = numberZero Then
                txtBoxResult.Text = numberZero
            ElseIf operator1 IsNot Nothing AndAlso
                    currentOperation.Text = btnPercentage.Text Then
                btnIgual_Click(currentOperation, e)
            Else
                btnIgual_Click(previousOperation, e)
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        previousBtnClicked = sender

    End Sub

    Private Sub btnIgual_Click(sender As Object, e As EventArgs) Handles btnEquals.Click, btnEqualsScientific.Click

        If numberEntered = False Then
            Exit Sub
        End If

        Dim result As Decimal

        If operator1 IsNot Nothing Then

            If multConcat Then
                operator2 = Decimal.Parse(txtBoxResult.Text) * operator2
                multConcat = False
                txtBoxResult.Text = operator2
                currentOperation = previousOperation
            End If

            ' If we have the pow of y selected when we hit equals button first we check that we have numbers in the y number
            ' If we have numbers we do the power and we use it as operator two, if we dont have numbers in the y we take the number of the base
            If powY Then
                If LabelPow.Text.Length > 0 Then
                    operator2 = Math.Pow(Decimal.Parse(txtBoxResult.Text), Integer.Parse(LabelPow.Text))
                Else
                    operator2 = Decimal.Parse(txtBoxResult.Text)
                End If
            Else
                operator2 = Decimal.Parse(txtBoxResult.Text)
            End If

            If sender.Text = btnEquals.Text Then
                result = makeOperation(operator1, operator2, currentOperation.Text)
                txtBoxResult.Text = Math.Round(result, 15)
                cleanScreen = True
                operator1 = Nothing
                operator2 = Nothing
                hidePowY()
            Else
                result = makeOperation(operator1, operator2, sender.Text)
                txtBoxResult.Text = Math.Round(result, 15)
                cleanScreen = True
                operator1 = result
                numberEntered = False
                hidePowY()
            End If
        End If

        previousBtnClicked = sender

        ' Here we only enter if we do the pow as first operation and we hit equals
        If powY Then
            If LabelPow.Text.Length > 0 Then
                txtBoxResult.Text = Math.Pow(Decimal.Parse(txtBoxResult.Text), Integer.Parse(LabelPow.Text))
            End If
            hidePowY()
            txtBoxResult.Text = txtBoxResult.Text.Trim()
        End If

    End Sub

    Private Function makeOperation(op1 As Decimal, op2 As Decimal, sender As String)

        Dim result As Decimal

        Select Case sender
            Case btnSum.Text
                result = op1 + op2
            Case btnRest.Text
                result = op1 - op2
            Case btnMult.Text
                result = op1 * op2
            Case btnDiv.Text
                result = op1 / op2
            Case btnPercentage.Text
                Select Case previousOperation.Text
                    Case btnRest.Text
                        result = op1 - (op1 * (op2 / 100.0))
                    Case btnSum.Text
                        result = op1 + (op1 * (op2 / 100.0))
                    Case btnMult.Text
                        result = op1 * (op2 / 100.0)
                End Select
        End Select

        Return result

    End Function

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnDelete.Click, btnDeleteScientific.Click

        ' When we are introducing numbers in the exponent of the pow of y the delete button only works for the exponent numbers
        If powY Then
            If LabelPow.Text.Length >= 1 Then
                LabelPow.Text = LabelPow.Text.Substring(0, LabelPow.Text.Length - 1)
            End If
            Exit Sub
        End If

        ' In here we check for the comma, if we encounter a comma we delete the number and the comma
        If txtBoxResult.Text.Length > 1 Then
            Dim isComma As Char

            isComma = txtBoxResult.Text.Chars(txtBoxResult.Text.Length - 2)

            If isComma = "," Then
                txtBoxResult.Text = txtBoxResult.Text.Substring(0, txtBoxResult.Text.Length - 2)
            Else
                txtBoxResult.Text = txtBoxResult.Text.Substring(0, txtBoxResult.Text.Length - 1)
            End If

        ElseIf txtBoxResult.Text.Length = 0 Then
            txtBoxResult.Text = numberZero
            cleanScreen = True
        ElseIf txtBoxResult.Text.Length = 1 Then
            txtBoxResult.Text = numberZero
            cleanScreen = True
        End If

        previousBtnClicked = sender

    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click, btnCScientific.Click

        hidePowY()

        txtBoxResult.Text = numberZero
        cleanScreen = False

        operator1 = Nothing
        operator2 = Nothing

    End Sub

    Private Sub btnCE_Click(sender As Object, e As EventArgs) Handles btnCE.Click, btnCEScientific.Click

        hidePowY()
        txtBoxResult.Text = numberZero
        cleanScreen = True

    End Sub

    Private Sub cleanTxtBox()

        If txtBoxResult.Text <> numberZero AndAlso
            multConcat = False Then
            operator1 = Decimal.Parse(txtBoxResult.Text)
        End If
        txtBoxResult.Text = ""
        cleanScreen = False
        hidePowY()

    End Sub

    Private Sub btnSigno_Click(sender As Object, e As EventArgs) Handles btnSign.Click, btnSignScientific.Click

        hidePowY()

        If txtBoxResult.Text <> numberZero AndAlso
            Not txtBoxResult.Text.Contains("-") Then

            txtBoxResult.Text = "-" + txtBoxResult.Text
        Else
            txtBoxResult.Text = txtBoxResult.Text.Replace("-", "")
        End If

    End Sub

    Private Sub btnComa_Click(sender As Object, e As EventArgs) Handles btnComa.Click, btnComaScientific.Click

        hidePowY()

        If Not txtBoxResult.Text.Contains(",") Then
            txtBoxResult.Text = txtBoxResult.Text + ","
        End If



    End Sub

    Private Sub btnInversa_Click(sender As Object, e As EventArgs) Handles btnReverse.Click, btnReverseScientific.Click

        hidePowY()

        If txtBoxResult.Text <> 0 Then
            txtBoxResult.Text = 1 / Decimal.Parse(txtBoxResult.Text)
        End If

    End Sub



    Private Sub MenuStricScientific_Click(sender As Object, e As EventArgs) Handles MenuStricScientific.Click

        MenuStripStandard.Checked = False
        MenuStricScientific.Checked = True

        TableLayoutPanelStandard.Visible = False
        TableLayoutPanelScientific.Visible = True
        PanelHideStandard.Visible = True

        normalMode = False

    End Sub

    Private Sub MenuStripStandard_Click(sender As Object, e As EventArgs) Handles MenuStripStandard.Click

        MenuStripStandard.Checked = True
        MenuStricScientific.Checked = False

        TableLayoutPanelStandard.Visible = True
        TableLayoutPanelScientific.Visible = False
        PanelHideStandard.Visible = False

        normalMode = True


    End Sub

    Private Sub btnPow2_Click(sender As Object, e As EventArgs) Handles btnPow2.Click

        hidePowY()

        txtBoxResult.Text = Math.Pow(Double.Parse(txtBoxResult.Text), 2)

    End Sub

    Private Sub btnPow3_Click(sender As Object, e As EventArgs) Handles btnPow3.Click

        hidePowY()

        txtBoxResult.Text = Math.Pow(Double.Parse(txtBoxResult.Text), 3)

    End Sub

    Private Sub btnPowY_Click(sender As Object, e As EventArgs) Handles btnPowY.Click

        If Not powY Then
            txtBoxResult.Text = txtBoxResult.Text + "  "
            powY = True
            LabelPow.Visible = True
        Else
            hidePowY()
            txtBoxResult.Text = txtBoxResult.Text.Trim()
        End If


    End Sub

    Private Sub hidePowY()

        LabelPow.Text = ""
        LabelPow.Visible = False
        powY = False

    End Sub

    Private Sub btnFactorial_Click(sender As Object, e As EventArgs) Handles btnFactorial.Click

        hidePowY()

        If txtBoxResult.Text <> numberZero Then
            Dim acumulado As Double = 1.0
            If txtBoxResult.Text < 3200 Then
                For i As Double = 1.0 To Double.Parse(txtBoxResult.Text)
                    acumulado = acumulado * i
                Next i
                txtBoxResult.Text = Math.Round(acumulado, 11)
            End If
        End If

    End Sub

    Private Sub MenuStripViewHelp_Click(sender As Object, e As EventArgs) Handles MenuStripViewHelp.Click

        FormHelp.Show()

    End Sub

    Private Sub centerForm()

        Dim r = Screen.PrimaryScreen.WorkingArea
        Dim x = r.Width - Me.Width
        Dim y = r.Height - Me.Height

        x = CInt(x / 2)
        y = CInt(y / 2)
        Me.StartPosition = FormStartPosition.Manual
        Me.Location = New Point(x, y)

    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress

        If normalMode Then
            Select Case e.KeyChar
                Case "1"
                    btnNum1.PerformClick()
                Case "2"
                    btnNum2.PerformClick()
                Case "3"
                    btnNum3.PerformClick()
                Case "4"
                    btnNum4.PerformClick()
                Case "5"
                    btnNum5.PerformClick()
                Case "6"
                    btnNum6.PerformClick()
                Case "7"
                    btnNum7.PerformClick()
                Case "8"
                    btnNum8.PerformClick()
                Case "9"
                    btnNum9.PerformClick()
                Case "0"
                    btnNum0.PerformClick()
                Case "*"
                    btnMult.PerformClick()
                Case "/"
                    btnDiv.PerformClick()
                Case "+"
                    btnSum.PerformClick()
                Case "-"
                    btnRest.PerformClick()
            End Select

            If Asc(e.KeyChar) = 8 Then
                btnDelete.PerformClick()
            End If

            btnEquals.Focus()
        Else
            Select Case e.KeyChar
                Case "1"
                    btnNum1Scientific.PerformClick()
                Case "2"
                    btnNum2Scientific.PerformClick()
                Case "3"
                    btnNum3Scientific.PerformClick()
                Case "4"
                    btnNum4Scientific.PerformClick()
                Case "5"
                    btnNum5Scientific.PerformClick()
                Case "6"
                    btnNum6Scientific.PerformClick()
                Case "7"
                    btnNum7Scientific.PerformClick()
                Case "8"
                    btnNum8Scientific.PerformClick()
                Case "9"
                    btnNum9Scientific.PerformClick()
                Case "0"
                    btnNum0Scientific.PerformClick()
                Case "*"
                    btnMultScientific.PerformClick()
                Case "/"
                    btnDivScientific.PerformClick()
                Case "+"
                    btnSumScientific.PerformClick()
                Case "-"
                    btnRestScientific.PerformClick()
            End Select


            If Asc(e.KeyChar) = 8 Then
                btnDeleteScientific.PerformClick()
            End If

            btnEqualsScientific.Focus()
        End If




    End Sub

End Class
