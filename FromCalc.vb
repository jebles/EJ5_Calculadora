Public Class FromCalc
    Dim MemoriaTotal() As Memoria
    'Dim Operando1 As String 'para encadenar mas operaciones de 2 cambiar para usar un el array memoria.operandos()
    Dim Operador As Char
    'Dim Operando2 As String
    Dim Resultado As Double
    'Dim modoConcat As Boolean ' si true, operando1 activo, si false

    Dim signum As Boolean

    'NUMERICOS
    Private Sub Btn7_Click(sender As Object, e As EventArgs) Handles Btn7.Click


        ' Operando1 = concat(7)



    End Sub
    Private Sub Btn8_Click(sender As Object, e As EventArgs) Handles Btn8.Click

    End Sub

    Private Sub Btn9_Click(sender As Object, e As EventArgs) Handles Btn9.Click

    End Sub

    Private Sub Btn4_Click(sender As Object, e As EventArgs) Handles Btn4.Click

    End Sub

    Private Sub Btn5_Click(sender As Object, e As EventArgs) Handles Btn5.Click

    End Sub

    Private Sub Btn6_Click(sender As Object, e As EventArgs) Handles Btn6.Click

    End Sub

    Private Sub Btn1_Click(sender As Object, e As EventArgs) Handles Btn1.Click

    End Sub

    Private Sub Btn2_Click(sender As Object, e As EventArgs) Handles Btn2.Click

    End Sub

    Private Sub Btn3_Click(sender As Object, e As EventArgs) Handles Btn3.Click

    End Sub

    Private Sub Btn0_Click(sender As Object, e As EventArgs) Handles Btn0.Click

    End Sub

    'BOTONES ESPECIALES
    Private Sub BtnDec_Click(sender As Object, e As EventArgs) Handles BtnDec.Click

    End Sub
    Private Sub BtnC_Click(sender As Object, e As EventArgs) Handles BtnC.Click
        TxRes.Text = 0
        resetMemorias()
        signum = True
    End Sub
    Private Sub BtnSignum_Click(sender As Object, e As EventArgs) Handles BtnSignum.Click
        If signum = True Then
            'Operando1.Prepend("-")
        End If

    End Sub
    Private Sub BtnOnOff_Click(sender As Object, e As EventArgs) Handles BtnOnOff.Click
        If TxRes.Enabled = True Then
            TxRes.Clear()
            TxRes.Enabled = False
            resetMemorias()
        Else
            TxRes.Enabled = True
            TxRes.Text = 0
        End If
    End Sub

    'METODOS AUXILIARES
    Private Function concat(num As Double) As Double
        TxRes.Text += num
        Return TxRes.Text
    End Function
    Private Shared Sub resetMemorias()
        For Each mem In MemoriaTotal
            mem.rdo = 0
            Erase mem.operandos
        Next
    End Sub
    Private Sub FromCalc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MemoriaTotal(0) = New Memoria
        signum = True
    End Sub
    'OPERADORES
    Private Sub BtnDiv_Click(sender As Object, e As EventArgs) Handles BtnDiv.Click

    End Sub

    Private Sub BtnMulti_Click(sender As Object, e As EventArgs) Handles BtnMulti.Click

    End Sub

    Private Sub BtnResta_Click(sender As Object, e As EventArgs) Handles BtnResta.Click

    End Sub

    Private Sub BtnSuma_Click(sender As Object, e As EventArgs) Handles BtnSuma.Click

    End Sub

    Private Sub BtnIgual_Click(sender As Object, e As EventArgs) Handles BtnIgual.Click

    End Sub


End Class
