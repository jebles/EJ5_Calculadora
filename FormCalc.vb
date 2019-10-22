Public Class FormCalc
    Dim ultimaoperacion As Char
    Dim op0 As String
    Dim op1 As String
    Dim opActivo As Boolean 'si false: operando 0 está activo, si true: operando 1 activo.
    Dim resultado As Double
    Dim signo As Boolean 'false si negativo, true si positivo

    'NUMERICOS
    Private Sub Boton_num(sender As Object, e As EventArgs) Handles Btn8.Click, Btn7.Click, Btn9.Click, Btn6.Click, Btn5.Click, Btn4.Click, Btn3.Click, Btn2.Click, Btn1.Click, Btn0.Click
        Dim boton As Button
        boton = CType(sender, Button) 'recoge en un ojeto tipo boton las propiedades de cada boton numerico presionado

        If opActivo Then 'si esta activo el operando 1
            op1 = AddNum(boton.Text, op1)
        Else
            op0 = AddNum(boton.Text, op0)
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
            TxRes.BackColor = Color.Gray
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
        ultimaoperacion = ""
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

    Private Sub Operar(oper1 As String, oper2 As String)

        Select Case ultimaoperacion
            Case "+"
                resultado = Convert.ToDouble(oper1) + Convert.ToDouble(oper2)
            Case "-"
                resultado = Convert.ToDouble(oper1) - Convert.ToDouble(oper2)
            Case "*"
                resultado = Convert.ToDouble(oper1) * Convert.ToDouble(oper2)
            Case "/"
                resultado = Convert.ToDouble(oper1) / Convert.ToDouble(oper2)
        End Select

        TxRes.Text = resultado
    End Sub

    'OPERADORES 
    Private Sub BtnSuma_Click(sender As Object, e As EventArgs) Handles BtnSuma.Click
        ultimaoperacion = "+"
        If Not opActivo Then 'Activo el primer operando
            opActivo = True
        Else 'activo el segundo operando
            Operar(op0, op1)
            op0 = Convert.ToDouble(resultado)
            op1 = 0
        End If
        contIguales = 0
    End Sub

    Private Sub BtnResta_Click(sender As Object, e As EventArgs) Handles BtnResta.Click
        ultimaoperacion = "-"
        ' Operar()
    End Sub

    Private Sub BtnMulti_Click(sender As Object, e As EventArgs) Handles BtnMulti.Click
        ultimaoperacion = "*"
        'Operar()
    End Sub

    Private Sub BtnDiv_Click(sender As Object, e As EventArgs) Handles BtnDiv.Click
        ultimaoperacion = "/"
        'Operar()
    End Sub

    Dim contIguales As Integer = 0
    Dim aux0 As String
    Dim aux1 As String
    Private Sub BtnIgual_Click(sender As Object, e As EventArgs) Handles BtnIgual.Click

        '= consecutivo y primero (ops indepes) ok, pte operacione compuestas 3+4=5+2=

        If contIguales = 0 Then 'primer igual 
            aux0 = op0
            aux1 = op1
            MsgBox(aux0 & " " & aux1)
            MsgBox("primer igual")
            Operar(op0, op1)
            opActivo = 0

            op0 = 0
            op1 = 0
            'op0 = 0
            'op1 = 0
            contIguales += 1
        Else '= consecutivos

            MsgBox("consecutivos")


            MsgBox("aux0=" & aux0 & " aux1=" & aux1 & "op0=" & op0 & "op1=" & op1)


            aux0 = resultado

            opActivo = 1
            Operar(aux0, aux1)

        End If
    End Sub
    Public Function RutaRelativaA(nom As String)
        Dim quitarDePath As String = "bin\Debug"
        Dim path As String = My.Application.Info.DirectoryPath.Replace(quitarDePath, "") & "Resources\"
        Return IO.Path.Combine(path, nom)
    End Function

    Private Sub BtnSignum_Click(sender As Object, e As EventArgs) Handles BtnSignum.Click
        'Dim res As String
        'If signo Then
        '    If Not opActivo Then
        '        res = op0.Prepend("-")
        '    Else
        '        res = op1.Prepend("-")
        '    End If
        'Else
        '    If Not opActivo Then
        '        res = op0.Remove(0)
        '    Else
        '        res = op1.Remove(0)
        '    End If
        'End If
        'TxRes.Text = res
    End Sub
End Class
