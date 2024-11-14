Imports Microsoft.VisualBasic
Imports clsSmart
Imports Org.BouncyCastle.Ocsp

Public Class clslogins_dth
    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _listaclasse As New List(Of clslogins_dth)
    Dim _mensagemerro As String
    Dim _nrseq As Integer
    Dim _nrseqlogin As Integer
    Dim _senha As String
    Dim _dtcad As Date
    Dim _usercad As String
    Dim _dtexclui As Date
    Dim _userexclui As String
    Dim _nrseqctrl As String
    Dim _concluido As Boolean
    Dim _erro As String
    Dim _ativo As Boolean

    Public Property Mensagemerro As String
        Get
            Return _mensagemerro
        End Get
        Set(value As String)
            _mensagemerro = value
        End Set
    End Property

    Public Property Nrseq As Integer
        Get
            Return _nrseq
        End Get
        Set(value As Integer)
            _nrseq = value
        End Set
    End Property

    Public Property Nrseqlogin As Integer
        Get
            Return _nrseqlogin
        End Get
        Set(value As Integer)
            _nrseqlogin = value
        End Set
    End Property

    Public Property Senha As String
        Get
            Return _senha
        End Get
        Set(value As String)
            _senha = value
        End Set
    End Property

    Public Property Dtcad As Date
        Get
            Return _dtcad
        End Get
        Set(value As Date)
            _dtcad = value
        End Set
    End Property

    Public Property Usercad As String
        Get
            Return _usercad
        End Get
        Set(value As String)
            _usercad = value
        End Set
    End Property

    Public Property Dtexclui As Date
        Get
            Return _dtexclui
        End Get
        Set(value As Date)
            _dtexclui = value
        End Set
    End Property

    Public Property Userexclui As String
        Get
            Return _userexclui
        End Get
        Set(value As String)
            _userexclui = value
        End Set
    End Property

    Public Property Nrseqctrl As String
        Get
            Return _nrseqctrl
        End Get
        Set(value As String)
            _nrseqctrl = value
        End Set
    End Property

    Public Property Concluido As Boolean
        Get
            Return _concluido
        End Get
        Set(value As Boolean)
            _concluido = value
        End Set
    End Property

    Public Property Erro As String
        Get
            Return _erro
        End Get
        Set(value As String)
            _erro = value
        End Set
    End Property

    Public Property Listaclasse As List(Of clslogins_dth)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clslogins_dth))
            _listaclasse = value
        End Set
    End Property

    Public Property Ativo As Boolean
        Get
            Return _ativo
        End Get
        Set(value As Boolean)
            _ativo = value
        End Set
    End Property
End Class
Partial Public Class clslogins_dth

    Public Function Listarlogins_dth() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "Select * from tblogins_dth where ativo = true"
            tb1 = tab1.conectar(xsql)
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clslogins_dth With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Nrseqlogin = numeros(tb1.Rows(x)("nrseqlogin").ToString), .Senha = tb1.Rows(x)("senha").ToString, .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Usercad = tb1.Rows(x)("usercad").ToString, .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Userexclui = tb1.Rows(x)("userexclui").ToString, .Nrseqctrl = tb1.Rows(x)("nrseqctrl").ToString, .Concluido = logico(tb1.Rows(x)("concluido").ToString), .Erro = tb1.Rows(x)("erro").ToString})
            Next
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function


    Public Function procurar() As Boolean
        Try
            If Nrseq = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Dim xsql As String = "Select * from tblogins_dth where nrseq = " & Nrseq
            tb1 = tab1.conectar(xsql)
            If tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(tb1.Rows(0)("nrseq").ToString)
            Nrseqlogin = numeros(tb1.Rows(0)("nrseqlogin").ToString)
            Senha = tb1.Rows(0)("senha").ToString
            Dtcad = FormatDateTime(valordata(tb1.Rows(0)("dtcad").ToString), DateFormat.ShortDate)
            Usercad = tb1.Rows(0)("usercad").ToString
            Dtexclui = FormatDateTime(valordata(tb1.Rows(0)("dtexclui").ToString), DateFormat.ShortDate)
            Userexclui = tb1.Rows(0)("userexclui").ToString
            Nrseqctrl = tb1.Rows(0)("nrseqctrl").ToString
            Concluido = logico(tb1.Rows(0)("concluido").ToString)
            Erro = tb1.Rows(0)("erro").ToString
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function

    Public Function salvar(Optional xnovo As Boolean = False, Optional xprocurar As Boolean = False) As Boolean
        Try
            If xprocurar Then
                tb1 = tab1.conectar("Select * from tbusuarios where nrseq = " & numeros(Nrseq))
                If tb1.Rows.Count > 0 Then
                    Nrseq = numeros(Nrseq)
                Else
                    If xnovo = True Then
                        novo()
                    End If
                End If
            Else
                If xnovo = True Then
                    novo()
                End If
            End If
            Dim xsql As String
            Dim xprocura As New clslogins_dth
            Dim xjaexiste As Boolean = True
            xprocura.nrseq = Nrseq
            If Not xprocura.procurar() Then
                xjaexiste = False
            End If
            xsql = " update tblogins_dth Set ativo = true"
            If xjaexiste Then
                If Nrseqlogin <> xprocura.Nrseqlogin Then
                    xsql &= ",nrseqlogin = " & numeros(Nrseqlogin)
                End If
            Else
                If Nrseqlogin <> 0 Then
                    xsql &= ",nrseqlogin = " & numeros(Nrseqlogin)
                End If
            End If
            If xjaexiste Then
                If Senha <> xprocura.Senha Then
                    xsql &= ",senha = '" & tratatexto(Senha) & "'"
                End If
            Else
                If Senha <> "" Then
                    xsql &= ",senha = '" & tratatexto(Senha) & "'"
                End If
            End If
            If xjaexiste Then
                If logico(Concluido) <> logico(xprocura.Concluido) Then
                    xsql &= ",concluido =  (" & logico(Concluido) & ")"
                End If
            Else

                xsql &= ",concluido = " & logico(Concluido)

            End If
            If xjaexiste Then
                If Erro <> xprocura.Erro Then
                    xsql &= ",erro = '" & tratatexto(Erro) & "'"
                End If
            Else
                If Erro <> "" Then
                    xsql &= ",erro = '" & tratatexto(Erro) & "'"
                End If
            End If
            xsql &= " where nrseq = " & Nrseq
            tb1 = tab1.IncluirAlterarDados(xsql)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function

    Public Function novo() As Boolean
        Try
            Dim wcnrseqctrl As String = gerarnrseqcontrole()
            tb1 = tab1.IncluirAlterarDados("insert into tblogins_dth (nrseqctrl, dtcad, usercad, ativo, hrcad) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false,  '" & hora() & "')")
            tb1 = tab1.conectar("Select * from  tblogins_dth where nrseqctrl = '" & wcnrseqctrl & "'")
            Nrseq = tb1.Rows(0)("nrseq").ToString
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function

    Public Function excluir() As Boolean
        Try
            If Nrseq = 0 Then
                Mensagemerro = "Por favor, informe um item para excluir !"
                Return False
            End If
            If Not procurar() Then
                Return False
            End If
            tb1 = tab1.IncluirAlterarDados("update tblogins_dth set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
End Class


