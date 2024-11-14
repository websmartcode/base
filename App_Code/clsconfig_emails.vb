Imports Microsoft.VisualBasic
Imports clsSmart

Public Class clsconfig_emails

    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _mensagemerro As String
    Dim _mensagemtitulo As String = "Ops !"
    Dim _mensagemicone As String = "error"
    Dim _listaclasse As New List(Of clsconfig_emails)
    Dim _nrseq As Integer
    Dim _servidor As String
    Dim _usuario As String
    Dim _senha As String
    Dim _porta As Integer
    Dim _ativo As Boolean
    Dim _dtcad As Date
    Dim _usercad As String
    Dim _dtexclui As Date
    Dim _userexclui As String
    Dim _nrseqctrl As String

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

    Public Property Listaclasse As List(Of clsconfig_emails)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clsconfig_emails))
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

    Public Property Servidor As String
        Get
            Return _servidor
        End Get
        Set(value As String)
            _servidor = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _usuario
        End Get
        Set(value As String)
            _usuario = value
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

    Public Property Porta As Integer
        Get
            Return _porta
        End Get
        Set(value As Integer)
            _porta = value
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
End Class

Partial Public Class clsconfig_emails

    Public Function Listarconfig_emails() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "select * from tbconfig_emails where ativo = true"
            tb1 = tab1.conectar(xsql)
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clsconfig_emails With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Servidor = tb1.Rows(x)("servidor").ToString, .Usuario = tb1.Rows(x)("usuario").ToString, .Senha = tb1.Rows(x)("senha").ToString, .Porta = numeros(tb1.Rows(x)("porta").ToString), .Ativo = logico(tb1.Rows(x)("ativo").ToString), .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Usercad = tb1.Rows(x)("usercad").ToString, .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Userexclui = tb1.Rows(x)("userexclui").ToString, .Nrseqctrl = tb1.Rows(x)("nrseqctrl").ToString})
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
            Dim xsql As String = "select * from tbconfig_emails where nrseq = " & Nrseq
            tb1 = tab1.conectar(xsql)
            If tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(tb1.Rows(0)("nrseq").ToString)
            Servidor = tb1.Rows(0)("servidor").ToString
            Usuario = tb1.Rows(0)("usuario").ToString
            Senha = tb1.Rows(0)("senha").ToString
            Porta = numeros(tb1.Rows(0)("porta").ToString)
            Ativo = logico(tb1.Rows(0)("ativo").ToString)
            Dtcad = FormatDateTime(valordata(tb1.Rows(0)("dtcad").ToString), DateFormat.ShortDate)
            Usercad = tb1.Rows(0)("usercad").ToString
            Dtexclui = FormatDateTime(valordata(tb1.Rows(0)("dtexclui").ToString), DateFormat.ShortDate)
            Userexclui = tb1.Rows(0)("userexclui").ToString
            Nrseqctrl = tb1.Rows(0)("nrseqctrl").ToString
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function

    Public Function salvar() As Boolean
        Try
            Dim xsql As String
            xsql = " update tbconfig_emails Set ativo = True"
            If Nrseq <> 0 Then
                xsql &= ",nrseq = " & moeda(Nrseq)
            End If
            If Servidor <> "" Then
                xsql &= ",servidor = '" & tratatexto(Servidor) & "'"
            End If
            If Usuario <> "" Then
                xsql &= ",usuario = '" & tratatexto(Usuario) & "'"
            End If
            If Senha <> "" Then
                xsql &= ",senha = '" & tratatexto(Senha) & "'"
            End If
            If Porta <> 0 Then
                xsql &= ",porta = " & moeda(Porta)
            End If
            If Ativo <> True Then
                xsql &= ",ativo = '" & logico(Ativo) & "'"
            End If
            If Dtcad <> "" Then
                xsql &= ",dtcad = '" & formatadatamysql(Dtcad) & "'"
            End If
            If Usercad <> "" Then
                xsql &= ",usercad = '" & tratatexto(Usercad) & "'"
            End If
            If Dtexclui <> "" Then
                xsql &= ",dtexclui = '" & formatadatamysql(Dtexclui) & "'"
            End If
            If Userexclui <> "" Then
                xsql &= ",userexclui = '" & tratatexto(Userexclui) & "'"
            End If
            If Nrseqctrl <> "" Then
                xsql &= ",nrseqctrl = '" & tratatexto(Nrseqctrl) & "'"
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
            tb1 = tab1.IncluirAlterarDados("insert into tbconfig_emails (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            tb1 = tab1.conectar("Select * from  tbconfig_emails where nrseqctrl = '" & wcnrseqctrl & "'")
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
            tb1 = tab1.IncluirAlterarDados("update tbconfig_emails set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
End Class


