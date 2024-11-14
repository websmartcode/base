Imports Microsoft.VisualBasic
Imports clsSmart
Public Class clsusuarios_senhas

    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _mensagemerro As String
    Dim _mensagemtitulo As String = "Ops !"
    Dim _mensagemicone As String = "Error"
    Dim _filtro_nrseq As Integer = 0
    Dim _filtro_nrsequsuario As Integer = 0
    Dim _filtro_senha As String = ""
    Dim _listaclasse As New List(Of clsusuarios_senhas)
    Dim _nrseq As Integer
    Dim _nrsequsuario As Integer
    Dim _senha As String
    Dim _dtcad As Date
    Dim _usercad As String
    Dim _dtexclui As Date
    Dim _userexclui As String
    Dim _ativo As Boolean
    Dim _nrseqctrl As String

    Public Sub New()
        Usercad = HttpContext.Current.Session("usuario")
    End Sub

    Public Property Mensagemerro As String
        Get
            Return _mensagemerro
        End Get
        Set(value As String)
            _mensagemerro = value
        End Set
    End Property

    Public Property Mensagemtitulo As String
        Get
            Return _mensagemtitulo
        End Get
        Set(value As String)
            _mensagemtitulo = value
        End Set
    End Property

    Public Property Mensagemicone As String
        Get
            Return _mensagemicone
        End Get
        Set(value As String)
            _mensagemicone = value
        End Set
    End Property

    Public Property Filtro_nrseq As Integer
        Get
            Return _filtro_nrseq
        End Get
        Set(value As Integer)
            _filtro_nrseq = value
        End Set
    End Property

    Public Property Listaclasse As List(Of clsusuarios_senhas)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clsusuarios_senhas))
            _listaclasse = value
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

    Public Property Nrsequsuario As Integer
        Get
            Return _nrsequsuario
        End Get
        Set(value As Integer)
            _nrsequsuario = value
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

    Public Property Ativo As Boolean
        Get
            Return _ativo
        End Get
        Set(value As Boolean)
            _ativo = value
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

    Public Property Filtro_nrsequsuario As Integer
        Get
            Return _filtro_nrsequsuario
        End Get
        Set(value As Integer)
            _filtro_nrsequsuario = value
        End Set
    End Property

    Public Property Filtro_senha As String
        Get
            Return _filtro_senha
        End Get
        Set(value As String)
            _filtro_senha = value
        End Set
    End Property
End Class

Partial Public Class clsusuarios_senhas

    Public Function Listarusuarios_senhas() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "select * from tbusuarios_senhas where ativo = true"
            If Filtro_nrseq <> 0 Then
                xsql &= " and nrseq = " & Filtro_nrseq
            End If
            If Filtro_nrseq <> 0 Then
                xsql &= " and nrsequsuario = " & Filtro_nrsequsuario
            End If
            If Filtro_senha <> "" Then
                xsql &= " and senha = '" & Filtro_senha & "'"
            End If
            tb1 = tab1.conectar(xsql)
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clsusuarios_senhas With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Nrsequsuario = numeros(tb1.Rows(x)("nrsequsuario").ToString), .Senha = tb1.Rows(x)("senha").ToString, .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Usercad = tb1.Rows(x)("usercad").ToString, .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Userexclui = tb1.Rows(x)("userexclui").ToString, .Ativo = logico(tb1.Rows(x)("ativo").ToString), .Nrseqctrl = tb1.Rows(x)("nrseqctrl").ToString})
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
            Dim xsql As String = "select * from tbusuarios_senhas where nrseq = " & Nrseq
            tb1 = tab1.conectar(xsql)
            If tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(tb1.Rows(0)("nrseq").ToString)
            Nrsequsuario = numeros(tb1.Rows(0)("nrsequsuario").ToString)
            Senha = tb1.Rows(0)("senha").ToString
            Dtcad = FormatDateTime(valordata(tb1.Rows(0)("dtcad").ToString), DateFormat.ShortDate)
            Usercad = tb1.Rows(0)("usercad").ToString
            Dtexclui = FormatDateTime(valordata(tb1.Rows(0)("dtexclui").ToString), DateFormat.ShortDate)
            Userexclui = tb1.Rows(0)("userexclui").ToString
            Ativo = logico(tb1.Rows(0)("ativo").ToString)
            Nrseqctrl = tb1.Rows(0)("nrseqctrl").ToString
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function

    Public Function salvar(Optional xnovo As Boolean = False) As Boolean
        Try
            If xnovo = True Then
                novo()
            End If
            Dim xsql As String
            Dim xprocura As New clsusuarios_senhas
            Dim xjaexiste As Boolean = True
            xprocura.Nrseq = Nrseq
            If Not xprocura.procurar() Then
                xjaexiste = False
            End If
            xsql = " update tbusuarios_senhas Set ativo = true"
            If xjaexiste Then
                If Nrsequsuario <> numeros(xprocura.Nrsequsuario) Then
                    xsql &= ",nrsequsuario = " & numeros(Nrsequsuario)
                End If
            Else
                If Nrsequsuario <> 0 Then
                    xsql &= ",nrsequsuario = " & numeros(Nrsequsuario)
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
            tb1 = tab1.IncluirAlterarDados("insert into tbusuarios_senhas (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            tb1 = tab1.conectar("Select * from  tbusuarios_senhas where nrseqctrl = '" & wcnrseqctrl & "'")
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
            tb1 = tab1.IncluirAlterarDados("update tbusuarios_senhas set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
End Class


