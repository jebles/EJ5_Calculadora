Module DataModulo
    Public Class Memoria
        Public rdo As Double
        Public operando() As String
        Public opActivo As Integer

        Public Sub New(rdo As Double, opActivo As Integer)
            ReDim operando(1)
            Me.rdo = 0
            operando(0) = ""
            Me.opActivo = 0 'solo 0 y 1
        End Sub
    End Class

    Sub New()

    End Sub
End Module
