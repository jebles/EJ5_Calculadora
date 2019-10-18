Module DataModulo
    Public Structure Memoria
        Public rdo As Double
        Public operaciones As [Enum]
    End Structure

    Public Resultados() As Memoria
    Public Enum operaciones
        sum
        rest
        mult
        div
        igual
    End Enum
End Module
