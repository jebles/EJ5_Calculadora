Public Class FormCalc
    Dim ultimaoperacion As Char
    Friend mem As New Memoria(0, 0)

    'NUMERICOS
    Private Sub Btn7_Click(sender As Object, e As EventArgs) Handles Btn7.Click
        addNum(7)
    End Sub
    Private Sub Btn8_Click(sender As Object, e As EventArgs) Handles Btn8.Click
        addNum(8)
    End Sub
    Private Sub Btn9_Click(sender As Object, e As EventArgs) Handles Btn9.Click
        addNum(9)
    End Sub
    Private Sub Btn4_Click(sender As Object, e As EventArgs) Handles Btn4.Click
        addNum(4)
    End Sub
    Private Sub Btn5_Click(sender As Object, e As EventArgs) Handles Btn5.Click
        addNum(5)
    End Sub
    Private Sub Btn6_Click(sender As Object, e As EventArgs) Handles Btn6.Click
        addNum(6)
    End Sub
    Private Sub Btn1_Click(sender As Object, e As EventArgs) Handles Btn1.Click
        addNum(1)
    End Sub
    Private Sub Btn2_Click(sender As Object, e As EventArgs) Handles Btn2.Click
        addNum(2)
    End Sub
    Private Sub Btn3_Click(sender As Object, e As EventArgs) Handles Btn3.Click
        addNum(3)
    End Sub
    Private Sub Btn0_Click(sender As Object, e As EventArgs) Handles Btn0.Click
        addNum(0)
    End Sub

    'BOTONES ESPECIALES
    Private Sub BtnOn_Click(sender As Object, e As EventArgs) Handles BtnOn.Click

        If TxRes.Enabled = True Then
            TxRes.Clear()
            TxRes.Enabled = False

            TxRes.BackColor = Color.Black

            BtnOn.BackgroundImage = Image.FromFile(RutaRelativaA("off.png"))
            BtnOn.BackgroundImageLayout = ImageLayout.Zoom
            reseteo()
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
        reseteo()
    End Sub

    Private Sub reseteo()
        mem.rdo = 0
        mem.operando(0) = 0
        mem.operando(1) = 0
        TxRes.Text = 0
    End Sub

    'METODOS AUXILIARES
    Private Sub addNum(n As Int16)
        Dim op As String = mem.operando(mem.opActivo).ToString
        Dim str As String = op + n.ToString
        mem.operando(mem.opActivo) = str
        TxRes.Text = mem.operando(mem.opActivo)
        'lastBtnPresIsNum = True
    End Sub

    Public Sub FromCalc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnC.Focus()
    End Sub

    'OPERADORES    
    Dim contIgual As Integer = 0

    Private Sub Operar(ope As Char, Optional eq As Char = "")

        Select Case ope
            Case "+"
                mem.rdo += mem.operando(mem.opActivo)
                CambioOPA()
                mem.operando(mem.opActivo) = 0

            Case "-"

            Case "*"

                If eq = "=" AndAlso contIgual > 0 Then  'multimplicaciones 
                    Dim aux As Integer = mem.rdo
                    'MsgBox("repite multi " & mem.rdo & " x " & mem.operando(0))
                    mem.rdo = aux * mem.operando(1)
                    CambioOPA()
                ElseIf eq = "=" Then    'segunda y sucesivas que se da al =
                    mem.rdo = mem.operando(0) * mem.operando(1)
                    CambioOPA()
                    contIgual += 1
                    ' MsgBox("cont==" & contIgual & " y eq -> " & eq)
                Else    '
                    mem.rdo = mem.operando(mem.opActivo)
                    CambioOPA()
                    contIgual = 0
                End If

            Case "/"
                'mem.rdo /= mem.operando(mem.opActivo)
        End Select



    End Sub

    Private Sub BtnDiv_Click(sender As Object, e As EventArgs) Handles BtnDiv.Click
        Operar("/",)
        ultimaoperacion = "/"
    End Sub

    Private Sub BtnMulti_Click(sender As Object, e As EventArgs) Handles BtnMulti.Click
        Operar("*",)
        ultimaoperacion = "*"
    End Sub
    Private Sub BtnSuma_Click(sender As Object, e As EventArgs) Handles BtnSuma.Click
        Operar("+",)
        ultimaoperacion = "+"
    End Sub



    Private Sub BtnResta_Click(sender As Object, e As EventArgs) Handles BtnResta.Click
        Operar("-",)
    End Sub
    Private Sub CambioOPA()

        If mem.opActivo = 0 Then
                mem.opActivo = 1
            ElseIf mem.opActivo = 1 Then
                mem.opActivo = 0
            End If

    End Sub
    Dim contMulti As Integer = 0
    Private Sub BtnIgual_Click(sender As Object, e As EventArgs) Handles BtnIgual.Click

        Operar(ultimaoperacion, "=")
        TxRes.Text = mem.rdo


    End Sub
    Public Function RutaRelativaA(nom As String)
        Dim quitarDePath As String = "bin\Debug"
        Dim path As String = My.Application.Info.DirectoryPath.Replace(quitarDePath, "") & "Resources\"
        Return IO.Path.Combine(path, nom)
    End Function
End Class
