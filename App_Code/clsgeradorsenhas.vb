Imports Microsoft.VisualBasic

Public Class clsgeradorsenhas

    Dim _novasenha As String = ""
    Dim _mensagemerro As String = ""
    Public Property Novasenha As String
        Get
            Return _novasenha
        End Get
        Set(value As String)
            _novasenha = value
        End Set
    End Property

    Public Property Mensagemerro As String
        Get
            Return _mensagemerro
        End Get
        Set(value As String)
            _mensagemerro = value
        End Set
    End Property

    Public Function Gerar() As Boolean
        Try


            'nos caracteres possíveis nós evitamos a letra "L"
            'minúscula, para que o usuário não confunda com o numeral
            '"1"
            Dim carac As String = "abcdefhijkmnopqrstuvxwyz123456789@#&*AEIOU"
            'converte em uma matriz de caracteres
            Dim carac2 As Char() = carac.ToCharArray()
            'vamos embaralhar 2 vezes
            Embaralhar(carac2, 2)

            'vamos sugerir a senha de 8 caracteres
            Dim senha As String = Nothing
            For i As Integer = 0 To 9 Step 1
                senha = senha & carac2(i)
            Next

            Novasenha = senha
            Return True
        Catch ex As Exception
            Mensagemerro = ex.Message
            Return False
        End Try
    End Function

    Private Sub Embaralhar(ByRef array As Array, ByVal vezes _
       As Integer)
        Dim rand As New Random(DateTime.Now.Millisecond)
        For i As Integer = 1 To vezes
            For i2 As Integer = 1 To array.Length
                swap(array(rand.Next(0, array.Length)),
           array(rand.Next(0, array.Length)))
            Next i2
        Next i
    End Sub

    Private Sub swap(ByRef arg1 As Object, ByRef arg2 As Object)
        Dim strTemp As String
        strTemp = arg1
        arg1 = arg2
        arg2 = strTemp
    End Sub

End Class
