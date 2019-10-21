Public Class FromCalc
    Friend mem As New Memoria(0, 0)
    'NUMERICOS
    Private Sub Btn7_Click(sender As Object, e As EventArgs) Handles Btn7.Click
        addNum("7")
    End Sub
    Private Sub Btn8_Click(sender As Object, e As EventArgs) Handles Btn8.Click
        addNum("8")
    End Sub

    'BOTONES ESPECIALES
    Private Sub BtnOn_Click(sender As Object, e As EventArgs) Handles BtnOn.Click

        If TxRes.Enabled = True Then
            TxRes.Clear()
            TxRes.Enabled = False

            TxRes.BackColor = Color.Black

            BtnOn.BackgroundImage = Image.FromFile("C:\Users\j.gamer\Documents\Gdrive\DI\proyectos VB\EJ5_Calculadora\Resources\off.png")
            BtnOn.BackgroundImageLayout = ImageLayout.Zoom
        Else
            TxRes.Enabled = True
            TxRes.BackColor = Color.Gray
            TxRes.Text = 0
            BtnOn.BackgroundImage = Image.FromFile("C:\Users\j.gamer\Documents\Gdrive\DI\proyectos VB\EJ5_Calculadora\Resources\on.png")
            BtnOn.BackgroundImageLayout = ImageLayout.Zoom
        End If
    End Sub


    'METODOS AUXILIARES
    Private Sub addNum(n As Char)
        mem.operando(mem.opActivo) += n
        TxRes.Text = mem.operando(mem.opActivo)
    End Sub

    Private Sub clearScr()
        TxRes.Text = "0"
    End Sub
    Public Sub FromCalc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnC.Focus()
    End Sub

    'OPERADORES
    Private Sub BtnDiv_Click(sender As Object, e As EventArgs) Handles BtnDiv.Click

    End Sub

    Private Sub BtnMulti_Click(sender As Object, e As EventArgs) Handles BtnMulti.Click

    End Sub
    Private Sub BtnSuma_Click(sender As Object, e As EventArgs) Handles BtnSuma.Click
        Select Case mem.opActivo
            Case 0
                mem.rdo += mem.operando(0)
                mem.opActivo = 1
            Case 1
                mem.rdo += mem.operando(1)
                mem.opActivo = 0
        End Select

    End Sub
    Private Sub BtnResta_Click(sender As Object, e As EventArgs) Handles BtnResta.Click

    End Sub

    Private Sub BtnIgual_Click(sender As Object, e As EventArgs) Handles BtnIgual.Click

        TxRes.Text = mem.rdo
    End Sub




End Class
