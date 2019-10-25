Public Class FormCalc
    Dim siguienteOp As Char
    Dim op0 As String
    Dim op1 As String
    Dim opActivo As Boolean 'si false: operando 0 está activo, si true: operando 1 activo.
    Dim resultado As Double = -1


    'NUMERICOS
    Private Sub Boton_num(sender As Object, e As EventArgs) Handles Btn8.Click, Btn7.Click, Btn9.Click, Btn6.Click, Btn5.Click, Btn4.Click, Btn3.Click, Btn2.Click, Btn1.Click, Btn0.Click
        Dim boton As Button
        boton = CType(sender, Button) 'recoge en un ojeto tipo boton las propiedades de cada boton numerico presionado

        If opActivo = 0 Then 'si esta activo el operando 0
            op0 = AddNum(boton.Text, op0)
        Else
            op1 = AddNum(boton.Text, op1)
        End If
    End Sub

    'BOTONES ESPECIALES
    Private Sub BtnOn_Click(sender As Object, e As EventArgs) Handles BtnOn.Click

        If TxRes.Enabled = True Then
            TxRes.Clear()
            TxRes.Enabled = False
            TxRes.BackColor = Color.Black
            BtnOn.BackgroundImage = Image.FromFile(RutaRelativaA("off.png"))
            BtnOn.BackgroundImageLayout = ImageLayout.Zoom
            Reseteo()
            TxRes.Text = ""
        Else

            TxRes.Enabled = True
            TxRes.BackColor = Color.DarkOliveGreen
            TxRes.Text = 0
            BtnOn.BackgroundImage = Image.FromFile(RutaRelativaA("on.png"))
            BtnOn.BackgroundImageLayout = ImageLayout.Zoom
        End If
    End Sub
    Private Sub BtnC_Click(sender As Object, e As EventArgs) Handles BtnC.Click
        Reseteo()
    End Sub

    Private Sub Reseteo()
        resultado = 0
        op0 = 0
        op1 = 0
        siguienteOp = ""
        opActivo = False
        TxRes.Text = 0
    End Sub

    'METODOS AUXILIARES
    Public Sub FromCalc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnC.Focus()
    End Sub
    Private Function AddNum(num As Char, OPA As String)
        Dim numContactenado As String = OPA & num
        TxRes.Text = Convert.ToDouble(numContactenado)
        AddNum = numContactenado 'ver si se pone en boton_num luego
    End Function
    Private Sub Operar(oper0 As String, oper1 As String)

        Select Case siguienteOp
            Case "+"
                resultado = Convert.ToDouble(oper0) + Convert.ToDouble(oper1)
            Case "-"
                resultado = Convert.ToDouble(oper0) - Convert.ToDouble(oper1)
            Case "*"
                resultado = Convert.ToDouble(oper0) * Convert.ToDouble(oper1)
            Case "/"
                resultado = Convert.ToDouble(oper0) / Convert.ToDouble(oper1)
        End Select
        TxRes.Text = resultado
    End Sub

    'OPERADORES 
    Private Sub BtnSuma_Click(sender As Object, e As EventArgs) Handles BtnSuma.Click
        siguienteOp = "+"
        comprobarOrdenOperandosYoperar()
    End Sub
    Private Sub comprobarOrdenOperandosYoperar()
        If opActivo = 0 Then 'si está activo el primer operando, activo el segundo para recibir datos
            opActivo = 1
        ElseIf opActivo = 1 Then 'si está activo el segundo operando, opero
            BtnIgual.PerformClick()
        End If
        contIguales = 0
    End Sub
    Private Sub BtnResta_Click(sender As Object, e As EventArgs) Handles BtnResta.Click
        siguienteOp = "-"
        comprobarOrdenOperandosYoperar()
    End Sub
    Private Sub BtnMulti_Click(sender As Object, e As EventArgs) Handles BtnMulti.Click
        siguienteOp = "*"
        'comprobarOrdenOperandosYoperar()
        Operar(op0, op1)
    End Sub
    Private Sub BtnDiv_Click(sender As Object, e As EventArgs) Handles BtnDiv.Click
        siguienteOp = "/"
        'comprobarOrdenOperandosYoperar()
        Operar(op0, op1)
    End Sub

    Dim contIguales As Integer = 0
    Dim aux0 As String
    Dim aux1 As String
    Private Sub BtnIgual_Click(sender As Object, e As EventArgs) Handles BtnIgual.Click
        '= consecutivo y primero (ops indepes)
        If contIguales = 0 Then 'primer igual 
            aux0 = op0
            aux1 = op1
            MsgBox(aux0 & " " & siguienteOp & " " & aux1)
            MsgBox("primer igual")
            Operar(op0, op1)
            opActivo = 0
            op0 = resultado
            op1 = 0
            contIguales += 1
        ElseIf contIguales = 1 Then '= operaciones consecutivas
            MsgBox("consecutivos")
            MsgBox("aux0=" & aux0 & " " & siguienteOp & " aux1=" & aux1)
            aux0 = resultado
            op0 = 0
            op1 = 0
            Operar(aux0, aux1)
        End If
    End Sub
    Public Function RutaRelativaA(nom As String)
        Dim quitarDePath As String = "bin\Debug"
        Dim path As String = My.Application.Info.DirectoryPath.Replace(quitarDePath, "") & "Resources\"
        Return IO.Path.Combine(path, nom)
    End Function

    Private Sub BtnSignum_Click(sender As Object, e As EventArgs) Handles BtnSignum.Click
        TxRes.Text = String.Concat("-", TxRes.Text)
        If opActivo = 0 Then
            op0 = String.Concat("-", op0)
        Else
            op1 = String.Concat("-", op1)
        End If
    End Sub

    Private Sub BtnDec_Click(sender As Object, e As EventArgs) Handles BtnDec.Click
        'TxRes.Text = String.Concat()
    End Sub
End Class
