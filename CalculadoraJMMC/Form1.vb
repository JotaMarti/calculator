Public Class Form1

    Dim operador1? As Decimal
    Dim operador2? As Decimal
    Dim btnClicked As Button
    Dim previousOperation As Button
    Dim currentOperation As Button
    Dim limpiaPantalla As Boolean = False
    Dim numberEntered As Boolean = False
    Dim maxLenght As Integer = 16
    Dim empty As String = ""
    Dim numeroCero As String = "0"
    Dim powY As Boolean = False

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        MenuStripStandard.Checked = True
        TableLayoutPanelScientific.Visible = False
        TableLayoutPanelStandard.Visible = True
        PanelHideStandard.Visible = False

        hidePowY()

    End Sub


    Private Sub btnNum_Click(sender As Object, e As EventArgs) Handles btnNum0.Click, btnNum1.Click, btnNum9.Click, btnNum8.Click, btnNum7.Click, btnNum6.Click, btnNum5.Click, btnNum4.Click, btnNum3.Click, btnNum2.Click, btnNum9Scientific.Click, btnNum8Scientific.Click, btnNum7Scientific.Click, btnNum6Scientific.Click, btnNum5Scientific.Click, btnNum4Scientific.Click, btnNum3Scientific.Click, btnNum2Scientific.Click, btnNum1Scientific.Click, btnNum0Scientific.Click

        If limpiaPantalla = True AndAlso
            btnClicked.Text <> "," Then
            cleanTxtBox()
        End If

        btnClicked = TryCast(sender, Button)

        ' Si he seleccionado la potencia de y me quedo aqui capturando los numeros y el programa no sigue
        If powY Then
            If Not LabelPow.Text.Length >= 2 Then
                LabelPow.Text = LabelPow.Text & btnClicked.Text
            End If
            Exit Sub
        End If


        ' Con esto no añado más numeros si ha superado el largo máximo, en este caso he puesto 16
        ' También realizo varias comprobaciones para no poner ceros a la izquierda
        If txtBoxResultado.Text.Length < maxLenght Then
            If btnClicked.Text = btnNum0.Text Then
                If txtBoxResultado.Text = numeroCero Or
                    txtBoxResultado.Text = empty Then
                    txtBoxResultado.Text = numeroCero
                Else
                    txtBoxResultado.Text = txtBoxResultado.Text & btnClicked.Text
                End If
            Else
                If txtBoxResultado.Text = numeroCero Then
                    txtBoxResultado.Text = empty
                End If
                txtBoxResultado.Text = txtBoxResultado.Text & btnClicked.Text
                numberEntered = True
            End If
        End If

    End Sub

    Private Sub btnOperation_Click(sender As Object, e As EventArgs) Handles btnMas.Click, btnMult.Click, btnRest.Click, btnDiv.Click, btnPorcentaje.Click, btnSumScientific.Click, btnRestScientific.Click, btnPorcentajeScientific.Click, btnMultScientific.Click, btnDivScientific.Click

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
            txtBoxResultado.Text <> numeroCero Then
            operador1 = Decimal.Parse(txtBoxResultado.Text)
            limpiaPantalla = True
        ElseIf operador1 Is Nothing AndAlso
            txtBoxResultado.Text = numeroCero Then
            txtBoxResultado.Text = numeroCero
        ElseIf operador1 IsNot Nothing AndAlso
                currentOperation.Text = btnPorcentaje.Text Then
            btnIgual_Click(currentOperation, e)
        Else
            btnIgual_Click(previousOperation, e)
        End If


        btnClicked = TryCast(sender, Button)



    End Sub

    Private Sub btnIgual_Click(sender As Object, e As EventArgs) Handles btnIgual.Click, btnIgualScientific.Click

        Dim buttonOrigin As Button

        buttonOrigin = TryCast(sender, Button)

        Dim resultado As Decimal

        ' Si tenemos operador1 guardamos operador2 y depende de si le hemos pulsado en igual o en los operador realizo dos cosas distintas
        If operador1 IsNot Nothing Then

            ' Si he seleccionado la potencia de Y cuando le doy a igual primero chequeo que tengo numeros en la potencia
            ' Si tengo numeros hago la potencia y la uso como operador dos, si no tengo uso el numero principal como operador 2
            If powY Then
                If LabelPow.Text.Length > 0 Then
                    operador2 = Math.Pow(Decimal.Parse(txtBoxResultado.Text), Integer.Parse(LabelPow.Text))
                Else
                    operador2 = Decimal.Parse(txtBoxResultado.Text)
                End If
            Else
                operador2 = Decimal.Parse(txtBoxResultado.Text)
            End If

            If buttonOrigin.Text = btnIgual.Text Then
                resultado = makeOperation(operador1, operador2, currentOperation.Text)
                txtBoxResultado.Text = Math.Round(resultado, 15)
                limpiaPantalla = True
                operador1 = Nothing
                operador2 = Nothing
                hidePowY()
            Else
                resultado = makeOperation(operador1, operador2, buttonOrigin.Text)
                txtBoxResultado.Text = Math.Round(resultado, 15)
                limpiaPantalla = True
                operador1 = resultado
                numberEntered = False
                hidePowY()
            End If
        End If

        btnClicked = TryCast(sender, Button)


        ' Aqui solo entro si hago la potencia como primera operacion y le doy a igual
        If powY Then
            If LabelPow.Text.Length > 0 Then
                txtBoxResultado.Text = Math.Pow(Decimal.Parse(txtBoxResultado.Text), Integer.Parse(LabelPow.Text))
            End If
            hidePowY()
            txtBoxResultado.Text = txtBoxResultado.Text.Trim()
        End If

    End Sub

    Private Function makeOperation(op1 As Decimal, op2 As Decimal, sender As String)

        Dim Resultado As Decimal

        Select Case sender
            Case btnMas.Text
                Resultado = op1 + op2
            Case btnRest.Text
                Resultado = op1 - op2
            Case btnMult.Text
                Resultado = op1 * op2
            Case btnDiv.Text
                Resultado = op1 / op2
            Case btnPorcentaje.Text
                Select Case previousOperation.Text
                    Case btnRest.Text
                        Resultado = op1 - (op1 * (op2 / 100.0))
                    Case btnMas.Text
                        Resultado = op1 + (op1 * (op2 / 100.0))
                    Case btnMult.Text
                        Resultado = op1 * (op2 / 100.0)
                End Select
        End Select

        Return Resultado

    End Function

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click, btnBorrarScientific.Click

        If powY Then
            If LabelPow.Text.Length >= 1 Then
                LabelPow.Text = LabelPow.Text.Substring(0, LabelPow.Text.Length - 1)
            End If
            Exit Sub
        End If

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
            txtBoxResultado.Text = numeroCero
            limpiaPantalla = True
        ElseIf txtBoxResultado.Text.Length = 1 Then
            txtBoxResultado.Text = numeroCero
            limpiaPantalla = True
        End If

        btnClicked = TryCast(sender, Button)

    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click, btnCScientific.Click

        hidePowY()

        txtBoxResultado.Text = numeroCero
        limpiaPantalla = False

        operador1 = Nothing
        operador2 = Nothing

    End Sub

    Private Sub btnCE_Click(sender As Object, e As EventArgs) Handles btnCE.Click, btnCEScientific.Click

        hidePowY()

        txtBoxResultado.Text = numeroCero
        limpiaPantalla = True

        btnClicked = TryCast(sender, Button)


    End Sub

    Private Sub cleanTxtBox()

        If txtBoxResultado.Text <> numeroCero Then
            operador1 = Decimal.Parse(txtBoxResultado.Text)
        End If
        txtBoxResultado.Text = ""
        limpiaPantalla = False
        hidePowY()

    End Sub

    Private Sub btnSigno_Click(sender As Object, e As EventArgs) Handles btnSigno.Click, btnSignoScientific.Click

        hidePowY()

        ' Si el textBox no tiene solo un numero 0 y si ademas no tiene un signo negativa le pongo el signo negativo al principio del string
        ' Si el textBox ya tiene un signo negativo lo quito al pulsar el boton
        If txtBoxResultado.Text <> numeroCero AndAlso
            Not txtBoxResultado.Text.Contains("-") Then

            txtBoxResultado.Text = "-" + txtBoxResultado.Text
        Else
            txtBoxResultado.Text = txtBoxResultado.Text.Replace("-", "")
        End If

    End Sub

    Private Sub btnComa_Click(sender As Object, e As EventArgs) Handles btnComa.Click, btnComaScientific.Click

        hidePowY()

        btnClicked = TryCast(sender, Button)

        If Not txtBoxResultado.Text.Contains(",") Then
            txtBoxResultado.Text = txtBoxResultado.Text + ","
        End If



    End Sub

    Private Sub btnInversa_Click(sender As Object, e As EventArgs) Handles btnInversa.Click, btnReverseScientific.Click

        hidePowY()

        If txtBoxResultado.Text <> 0 Then
            txtBoxResultado.Text = 1 / Decimal.Parse(txtBoxResultado.Text)
        End If

    End Sub



    Private Sub MenuStricScientific_Click(sender As Object, e As EventArgs) Handles MenuStricScientific.Click

        MenuStripStandard.Checked = False
        MenuStricScientific.Checked = True

        TableLayoutPanelStandard.Visible = False
        TableLayoutPanelScientific.Visible = True
        PanelHideStandard.Visible = True


    End Sub

    Private Sub MenuStripStandard_Click(sender As Object, e As EventArgs) Handles MenuStripStandard.Click

        MenuStripStandard.Checked = True
        MenuStricScientific.Checked = False

        TableLayoutPanelStandard.Visible = True
        TableLayoutPanelScientific.Visible = False
        PanelHideStandard.Visible = False


    End Sub

    Private Sub btnPow2_Click(sender As Object, e As EventArgs) Handles btnPow2.Click
        hidePowY()

        txtBoxResultado.Text = Math.Pow(Decimal.Parse(txtBoxResultado.Text), 2)

    End Sub

    Private Sub btnPow3_Click(sender As Object, e As EventArgs) Handles btnPow3.Click
        hidePowY()

        txtBoxResultado.Text = Math.Pow(Decimal.Parse(txtBoxResultado.Text), 3)

    End Sub

    Private Sub btnPowY_Click(sender As Object, e As EventArgs) Handles btnPowY.Click


        txtBoxResultado.Text = txtBoxResultado.Text + "  "
        powY = True
        LabelPow.Visible = True

    End Sub

    Private Sub hidePowY()
        LabelPow.Text = ""
        LabelPow.Visible = False
        powY = False
    End Sub

    Private Sub btnFactorial_Click(sender As Object, e As EventArgs) Handles btnFactorial.Click

        If txtBoxResultado.Text <> numeroCero Then
            hidePowY()

            Dim acumulado As Double = 1

            For i As Double = 2 To Double.Parse(txtBoxResultado.Text)

                acumulado = acumulado * i

            Next i

            txtBoxResultado.Text = Math.Round(acumulado, 11)
        End If



    End Sub
End Class
