Public Class Form1

    Dim operador1? As Decimal
    Dim operador2? As Decimal
    Dim btnClicked As Button
    Dim previousOperation As Button
    Dim currentOperation As Button
    Dim limpiaPantalla As Boolean = False
    Dim numberEntered As Boolean = False
    Dim maxLenght As Integer = 16


    Private Sub btnNum_Click(sender As Object, e As EventArgs) Handles btnNum0.Click, btnNum1.Click, btnNum9.Click, btnNum8.Click, btnNum7.Click, btnNum6.Click, btnNum5.Click, btnNum4.Click, btnNum3.Click, btnNum2.Click

        If limpiaPantalla = True AndAlso
            btnClicked.Text <> "," Then
            cleanTxtBox()
        End If

        btnClicked = TryCast(sender, Button)

        ' Con esto no añado más numero si ha superado el largo máximo, en este caso he puesto 16
        ' También realizo varias comprobaciones para no poner ceros a la izquierda
        If txtBoxResultado.Text.Length < maxLenght Then
            If btnClicked.Text = btnNum0.Text Then
                If txtBoxResultado.Text = "0" Or
                    txtBoxResultado.Text = "" Then
                    txtBoxResultado.Text = "0"
                Else
                    txtBoxResultado.Text = txtBoxResultado.Text & btnClicked.Text
                End If
            Else
                If txtBoxResultado.Text = "0" Then
                    txtBoxResultado.Text = ""
                End If
                txtBoxResultado.Text = txtBoxResultado.Text & btnClicked.Text
                numberEntered = True
            End If
        End If

    End Sub

    Private Sub btnOperation_Click(sender As Object, e As EventArgs) Handles btnMas.Click, btnMult.Click, btnRest.Click, btnDiv.Click

        ' Si la operacion actual no es nula me guardo la operacion anterior
        If currentOperation IsNot Nothing Then
            previousOperation = currentOperation
        End If

        ' Me guardo la operacion actual
        currentOperation = TryCast(sender, Button)

        ' Esto es un check para cuando se concatenan operaciones, si damos varias veces al boton más por ejemplo no haga nada
        If numberEntered = False Then
            Exit Sub
        End If

        ' Si el operador1 esta vacio y hemos escrito algo me guardo el valor, si no se ha escrito nada vuelvo a pintar el 0
        ' Y si todo es correcto llamo al sub del boton igual para realizar la operacion con el valor de la operacion anterior.
        If operador1 Is Nothing AndAlso
            txtBoxResultado.Text <> "0" Then
            operador1 = Decimal.Parse(txtBoxResultado.Text)
            limpiaPantalla = True
        ElseIf operador1 Is Nothing AndAlso
            txtBoxResultado.Text = "0" Then
            txtBoxResultado.Text = "0"
        Else
            btnIgual_Click(previousOperation, e)
        End If


        btnClicked = TryCast(sender, Button)



    End Sub

    Private Sub btnIgual_Click(sender As Object, e As EventArgs) Handles btnIgual.Click

        Dim buttonOrigin As Button

        buttonOrigin = TryCast(sender, Button)

        Dim resultado As Decimal

        ' Si tenemos operador1 guardamos operador2 y depende de si le hemos pulsado en igual o en los operador realizo dos cosas distintas
        If operador1 IsNot Nothing Then

            operador2 = Decimal.Parse(txtBoxResultado.Text)

            If buttonOrigin.Text = "=" Then
                resultado = makeOperation(operador1, operador2, currentOperation.Text)
                txtBoxResultado.Text = Math.Round(resultado, 15)
                limpiaPantalla = True
                operador1 = Nothing
                operador2 = Nothing
            Else
                resultado = makeOperation(operador1, operador2, previousOperation.Text)
                txtBoxResultado.Text = Math.Round(resultado, 15)
                limpiaPantalla = True
                operador1 = resultado
                numberEntered = False
            End If
        End If

        btnClicked = TryCast(sender, Button)

    End Sub

    Private Function makeOperation(op1 As Decimal, op2 As Decimal, sender As String)

        Dim Resultado As Decimal

        'If sender = "+" Then
        '    Resultado = op1 + op2
        'ElseIf sender = "-" Then
        '    Resultado = op1 - op2
        'ElseIf sender = "×" Then
        '    Resultado = op1 * op2
        'ElseIf sender = "/" Then
        '    Resultado = op1 / op2
        'End If

        Select Case sender
            Case "+"
                Resultado = op1 + op2
            Case "-"
                Resultado = op1 - op2
            Case "×"
                Resultado = op1 * op2
            Case "/"
                Resultado = op1 / op2
            Case "%"
                Select Case previousOperation.Text
                    Case "-"
                        Resultado = op1 - (op1 * (op2 / 100.0))
                    Case "+"
                        Resultado = op1 + (op1 * (op2 / 100.0))
                    Case "×"
                        Resultado = op1 * (op2 / 100.0)
                End Select
        End Select



        Return Resultado

    End Function

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

        ' En el primer if realizo una comprobación, por que cuando el numero tenia coma se quedaba por ej 3, y generaba problemas,
        ' lo que hago es comprobar si lo siguiente a borrar es un coma y en ese caso borro el numero y la coma
        If txtBoxResultado.Text.Length > 1 Then
            Dim esComa As Char

            esComa = txtBoxResultado.Text.Chars(txtBoxResultado.Text.Length - 2)

            If esComa = "," Then
                txtBoxResultado.Text = txtBoxResultado.Text.Substring(0, txtBoxResultado.Text.Length - 2)
            Else
                txtBoxResultado.Text = txtBoxResultado.Text.Substring(0, txtBoxResultado.Text.Length - 1)
            End If

        ElseIf txtBoxResultado.Text.Length = 0 Then
            txtBoxResultado.Text = "0"
            limpiaPantalla = True
        ElseIf txtBoxResultado.Text.Length = 1 Then
            txtBoxResultado.Text = "0"
            limpiaPantalla = True
        End If

        btnClicked = TryCast(sender, Button)

    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click

        txtBoxResultado.Text = "0"
        limpiaPantalla = False

        operador1 = Nothing
        operador2 = Nothing

    End Sub

    Private Sub btnCE_Click(sender As Object, e As EventArgs) Handles btnCE.Click

        txtBoxResultado.Text = "0"
        limpiaPantalla = True

        btnClicked = TryCast(sender, Button)


    End Sub

    Private Sub cleanTxtBox()

        If txtBoxResultado.Text <> "0" Then
            operador1 = Decimal.Parse(txtBoxResultado.Text)
        End If
        txtBoxResultado.Text = ""
        limpiaPantalla = False

    End Sub

    Private Sub btnSigno_Click(sender As Object, e As EventArgs) Handles btnSigno.Click

        If txtBoxResultado.Text <> "0" AndAlso
            Not txtBoxResultado.Text.Contains("-") Then

            txtBoxResultado.Text = "-" + txtBoxResultado.Text
        Else
            txtBoxResultado.Text = txtBoxResultado.Text.Replace("-", "")
        End If

    End Sub

    Private Sub btnComa_Click(sender As Object, e As EventArgs) Handles btnComa.Click

        btnClicked = TryCast(sender, Button)

        If Not txtBoxResultado.Text.Contains(",") Then
            txtBoxResultado.Text = txtBoxResultado.Text + ","
        End If



    End Sub

    Private Sub btnInversa_Click(sender As Object, e As EventArgs) Handles btnInversa.Click

        If txtBoxResultado.Text <> 0 Then
            txtBoxResultado.Text = 1 / Decimal.Parse(txtBoxResultado.Text)
        End If

    End Sub

    Private Sub btnPorcentaje_Click(sender As Object, e As EventArgs) Handles btnPorcentaje.Click

        previousOperation = currentOperation

        currentOperation = sender

    End Sub
End Class
