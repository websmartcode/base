Imports System.Data
Imports clsSmart

Public Class clsusuariospartial

    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
End Class

Partial Public Class clsusuariospartial : Inherits clsusuarios

    Public Function procuraparoclientes(Optional apenastabela As Boolean = False) As Boolean
        Try

            Dim xsql As String = "SELECT nrseq as nrseq_usuario, usuario as nome_usuario, email, imagemperfil FROM vwusuarios"

            If Not String.IsNullOrEmpty(Usuario) Then
                If xsql.Contains("WHERE") Then
                    xsql &= " and usuario like '%" & Usuario & "%'"
                Else
                    xsql &= " WHERE usuario like '%" & Usuario & "%'"
                End If
            End If

            If Not String.IsNullOrEmpty(Email) Then
                If xsql.Contains("WHERE") Then
                    xsql &= " or email like '%" & Email & "%'"
                Else
                    xsql &= " WHERE email like '%" & Email & "%'"
                End If
            End If

            tb1 = tab1.conectar(xsql)

            'If tb1.Rows.Count = 0 Then
            '    Mensagemerro = "Selecione um item válido para procurar"
            '    Return False
            'End If

            If apenastabela Then
                Return True
            End If

            Nrseq = numeros(tb1.Rows(0)("nrseq_usuario").ToString)
            Usuario = tb1.Rows(0)("nome_usuario").ToString
            Suspenso = logico(tb1.Rows(0)("suspenso").ToString)
            Ativo = logico(tb1.Rows(0)("ativo").ToString)
            Email = tb1.Rows(0)("email").ToString
            Imagemperfil = tb1.Rows(0)("imagemperfil").ToString

            Return True

        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function
End Class
