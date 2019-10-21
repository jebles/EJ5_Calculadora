Module DataModulo
    Public Class Memoria
        Public rdo As Double
        Public operando() As Double
        Public opActivo As Integer

        Public Sub New(rdo As Double, opActivo As Integer)
            ReDim operando(1)
            Me.rdo = 0
            operando(0) = 0
            Me.opActivo = 0 'solo 0 y 1
        End Sub
    End Class

End Module
