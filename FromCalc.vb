Public Class FromCalc

    Dim Operando1 As String
    Dim Operador As Char
    Dim Operando2 As String
    Dim Resultado As Double
    Dim modoConcat As Boolean
    Dim Operando1Activo As Boolean 'si es false, el activo es el Operando2

    'NUMERICOS
    Private Sub Btn7_Click(sender As Object, e As EventArgs) Handles Btn7.Click
        If modoConcat Then
            If Operando1Activo Then
                Operando1 = concat(7)
            Else
                Operando2 = concat(7)
            End If
        End If
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
    End Sub
    Private Sub BtnSignum_Click(sender As Object, e As EventArgs) Handles BtnSignum.Click

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
        For Each mem In Resultados
            mem.rdo = 0
        Next
        OperandoActivo.uno
    End Sub
    Private Sub FromCalc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Resultados(0) = New Memoria
    End Sub
    'OPERADORES
    Private Sub BtnDiv_Click(sender As Object, e As EventArgs) Handles BtnDiv.Click
        modoConcat = False
    End Sub

    Private Sub BtnMulti_Click(sender As Object, e As EventArgs) Handles BtnMulti.Click
        modoConcat = False
    End Sub

    Private Sub BtnResta_Click(sender As Object, e As EventArgs) Handles BtnResta.Click
        modoConcat = False
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        modoConcat = False
    End Sub

    Private Sub BtnIgual_Click(sender As Object, e As EventArgs) Handles BtnIgual.Click
        modoConcat = False
    End Sub


End Class
