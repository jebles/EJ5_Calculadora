﻿Public Class FormCalc
    Dim ultimaoperacion As Char
    Dim op0 As String
    Dim op1 As String
    Dim opActivo As Boolean 'si false: operando 0 está activo, si true: operando 1 activo.
    Dim resultado As Double
    Dim signoOp0 As Boolean = True 'false si negativo, true si positivo para el primer operando
    Dim signoOp1 As Boolean = True

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
    Private Sub BtnSignum_Click(sender As Object, e As EventArgs) Handles BtnSignum.Click
        Dim display As Double = TxRes.Text

        If opActivo = 0 Then 'dterminar operando activo
            If signoOp0 = True Then 'poner su estado
                signoOp0 = False
                TxRes.Text = display * -1
                TextBox1.Text = TxRes.Text
            Else
                signoOp0 = True
                TxRes.Text = Math.Abs(display)
                TextBox1.Text = TxRes.Text
            End If
        Else
            If signoOp1 = True Then 'poner su estado
                signoOp1 = False
                TxRes.Text = display * -1
                TextBox3.Text = TxRes.Text
            Else
                signoOp1 = True
                TxRes.Text = Math.Abs(display)
                TextBox3.Text = TxRes.Text
            End If
        End If

        MsgBox(signoOp0 & " " & signoOp1)

    End Sub
    Private Sub Reseteo()
        resultado = 0
        op0 = 0
        signoOp0 = True
        signoOp1 = True
        op1 = 0
        ultimaoperacion = ""
        opActivo = False
        TxRes.Text = 0
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
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

        DevuelveConSigno(oper0)

        Select Case ultimaoperacion
            Case "+"
                resultado = DevuelveConSigno(oper0) + DevuelveConSigno(oper1)
            Case "-"
                resultado = DevuelveConSigno(oper0) - DevuelveConSigno(oper1)
            Case "*"
                resultado = DevuelveConSigno(oper0) * DevuelveConSigno(oper1)
            Case "/"
                resultado = DevuelveConSigno(oper0) / DevuelveConSigno(oper1)
        End Select
        TxRes.Text = resultado
    End Sub

    Private Function DevuelveConSigno(oper0 As String)
        Dim operandoConSignoCorrecto As Double = Nothing
        If signoOp0 = False Then
            operandoConSignoCorrecto = Convert.ToDouble(oper0) * -1
        Else
            operandoConSignoCorrecto = Math.Abs(Convert.ToDouble(oper0))
        End If
        Return operandoConSignoCorrecto
    End Function

    'OPERADORES 
    Private Sub BtnSuma_Click(sender As Object, e As EventArgs) Handles BtnSuma.Click
        ultimaoperacion = "+"
        comprobarOrdenOperandosYoperar()
    End Sub

    Private Sub comprobarOrdenOperandosYoperar()

        If opActivo = 0 Then 'si está activo el primer operando, activo el segundo para recibir datos
            opActivo = 1
        Else 'si está activo el segundo operando, opero
            Operar(op0, op1)
            op0 = resultado
            op1 = 0
            signoOp1 = True
        End If
        contIguales = 0
    End Sub

    Private Sub BtnResta_Click(sender As Object, e As EventArgs) Handles BtnResta.Click
        ultimaoperacion = "-"
        comprobarOrdenOperandosYoperar()
    End Sub

    Private Sub BtnMulti_Click(sender As Object, e As EventArgs) Handles BtnMulti.Click
        ultimaoperacion = "*"
        comprobarOrdenOperandosYoperar()
    End Sub

    Private Sub BtnDiv_Click(sender As Object, e As EventArgs) Handles BtnDiv.Click
        ultimaoperacion = "/"
        comprobarOrdenOperandosYoperar()
    End Sub
    'variables auxiliares para el funcionamiento de la tecla =
    Dim contIguales As Integer = 0
    Dim aux0 As String
    Dim aux1 As String

    Private Sub BtnIgual_Click(sender As Object, e As EventArgs) Handles BtnIgual.Click

        '= primero y operaciones indepes
        If contIguales = 0 Then 'primer igual 
            aux0 = op0
            aux1 = op1
            MsgBox(aux0 & " " & ultimaoperacion & " " & aux1)
            MsgBox("primer igual")
            Operar(op0, op1)
            opActivo = 0
            'si se va a seguir sumando operandos
            op0 = resultado
            'si se va a hacer otra operacion 
            op1 = 0
            signoOp1 = True
            contIguales += 1

        ElseIf contIguales = 1 Then '= operaciones consecutivas de repeticion
            MsgBox("consecutivos")
            MsgBox("aux0=" & aux0 & " " & ultimaoperacion & " aux1=" & aux1)
            aux0 = resultado
            op0 = 0
            signoOp0 = True
            op1 = 0
            signoOp1 = True
            Operar(aux0, aux1)
        End If


    End Sub
    Public Function RutaRelativaA(nom As String)
        Dim quitarDePath As String = "bin\Debug"
        Dim path As String = My.Application.Info.DirectoryPath.Replace(quitarDePath, "") & "Resources\"
        Return IO.Path.Combine(path, nom)
    End Function

    Private Sub OperandoCambia(sender As Object, e As EventArgs) Handles Btn8.Click, Btn7.Click, Btn9.Click, Btn6.Click, Btn5.Click, Btn4.Click, Btn3.Click, Btn2.Click, Btn1.Click, Btn0.Click
        Dim boton As Button
        boton = CType(sender, Button) 'recoge en un ojeto tipo boton las propiedades de cada boton  presionado
        If opActivo = 0 Then
            TextBox1.Text = op0
        Else
            TextBox3.Text = op1
        End If
    End Sub
    Private Sub operacion(sender As Object, e As EventArgs) Handles BtnResta.Click, BtnMulti.Click, BtnDiv.Click, BtnSuma.Click
        Dim boton As Button
        boton = CType(sender, Button) 'recoge en un ojeto tipo boton las propiedades de cada boton  presionado
        TextBox2.Text = boton.Text
    End Sub


End Class
