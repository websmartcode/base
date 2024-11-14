Imports clsSmart

Public Class clsusuarios_empresas_unidades
    Public Sub New()
        Usercad = HttpContext.Current.Session("usuario")
    End Sub
    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _mensagemerro As String
    Dim _mensagemtitulo As String = "Ops !"
    Dim _mensagemicone As String = "Error"
    Dim _filtro_nrseq As Integer = 0
    Dim _listaclasse As New List(Of clsusuarios_empresas_unidades)
    Dim _nrseq As Integer
    Dim _usercad As String
    Dim _userexclui As String
    Dim _nrseqctrl As String
    Dim _dtcad As Date
    Dim _dtexclui As Date
    Dim _ativo As Boolean
    Dim _nrsequsuariosempresas As Integer
    Dim _nrsequnidade As Integer
    Dim _nomeunidade As String

    Dim _razaoempresa As String

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

    Public Property Listaclasse As List(Of clsusuarios_empresas_unidades)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clsusuarios_empresas_unidades))
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

    Public Property Usercad As String
        Get
            Return _usercad
        End Get
        Set(value As String)
            _usercad = value
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

    Public Property Dtcad As Date
        Get
            Return _dtcad
        End Get
        Set(value As Date)
            _dtcad = value
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

    Public Property Ativo As Boolean
        Get
            Return _ativo
        End Get
        Set(value As Boolean)
            _ativo = value
        End Set
    End Property

    Public Property Nrsequsuariosempresas As Integer
        Get
            Return _nrsequsuariosempresas
        End Get
        Set(value As Integer)
            _nrsequsuariosempresas = value
        End Set
    End Property

    Public Property Nrsequnidade As Integer
        Get
            Return _nrsequnidade
        End Get
        Set(value As Integer)
            _nrsequnidade = value
        End Set
    End Property

    Public Property Nomeunidade As String
        Get
            Return _nomeunidade
        End Get
        Set(value As String)
            _nomeunidade = value
        End Set
    End Property

    Public Property Razaoempresa As String
        Get
            Return _razaoempresa
        End Get
        Set(value As String)
            _razaoempresa = value
        End Set
    End Property
End Class

Partial Public Class clsusuarios_empresas_unidades

    Public Function Listarusuarios_empresas_unidades() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "select * from vwusuarios_empresas_unidades where ativo = true"
            If Filtro_nrseq <> 0 Then
                xsql &= " and nrseq = " & Filtro_nrseq
            End If
            tb1 = tab1.conectar(xsql)
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clsusuarios_empresas_unidades With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Usercad = tb1.Rows(x)("usercad").ToString, .Userexclui = tb1.Rows(x)("userexclui").ToString, .Nrseqctrl = tb1.Rows(x)("nrseqctrl").ToString, .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Ativo = logico(tb1.Rows(x)("ativo").ToString), .Nrsequsuariosempresas = numeros(tb1.Rows(x)("nrsequsuariosempresas").ToString), .Nrsequnidade = numeros(tb1.Rows(x)("nrsequnidade").ToString), .Nomeunidade = tb1.Rows(x)("nomeunidade").ToString})
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
            Dim xsql As String = "select * from tbusuarios_empresas_unidades where nrseq = " & Nrseq
            tb1 = tab1.conectar(xsql)
            If tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(tb1.Rows(0)("nrseq").ToString)
            Usercad = tb1.Rows(0)("usercad").ToString
            Userexclui = tb1.Rows(0)("userexclui").ToString
            Nrseqctrl = tb1.Rows(0)("nrseqctrl").ToString
            Dtcad = FormatDateTime(valordata(tb1.Rows(0)("dtcad").ToString), DateFormat.ShortDate)
            Dtexclui = FormatDateTime(valordata(tb1.Rows(0)("dtexclui").ToString), DateFormat.ShortDate)
            Ativo = logico(tb1.Rows(0)("ativo").ToString)
            Nrsequsuariosempresas = numeros(tb1.Rows(0)("nrsequsuariosempresas").ToString)
            Nrsequnidade = numeros(tb1.Rows(0)("nrsequnidade").ToString)
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function

    Public Function salvar(Optional xnovo As Boolean = False, Optional xprocurar As Boolean = False) As Boolean
        Try
            If xprocurar Then
                tb1 = tab1.conectar("select * from tbusuarios_empresas_unidades where nrsequnidade = " & numeros(Nrsequnidade) & " and nrsequsuariosempresas = " & numeros(Nrsequsuariosempresas))
                If tb1.Rows.Count = 0 Then
                    If xnovo = True Then
                        novo()
                    End If
                Else
                    Nrseq = tb1.Rows(0)("nrseq").ToString
                End If
            Else
                If xnovo = True Then
                    novo()
                End If
            End If

            Dim xsql As String
            Dim xprocura As New clsusuarios_empresas_unidades
            Dim xjaexiste As Boolean = True
            xprocura.Nrseq = Nrseq
            If Not xprocura.procurar() Then
                xjaexiste = False
            End If
            xsql = "update tbusuarios_empresas_unidades Set ativo = true"
            If xjaexiste Then
                If Nrsequsuariosempresas <> numeros(xprocura.Nrsequsuariosempresas) Then
                    xsql &= ",nrsequsuariosempresas = " & numeros(Nrsequsuariosempresas)
                End If
            Else
                If Nrsequsuariosempresas <> 0 Then
                    xsql &= ",nrsequsuariosempresas = " & numeros(Nrsequsuariosempresas)
                End If
            End If
            If xjaexiste Then
                If Nrsequnidade <> numeros(xprocura.Nrsequnidade) Then
                    xsql &= ",nrsequnidade = " & numeros(Nrsequnidade)
                End If
            Else
                If Nrsequnidade <> 0 Then
                    xsql &= ",nrsequnidade = " & numeros(Nrsequnidade)
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
            tb1 = tab1.IncluirAlterarDados("insert into tbusuarios_empresas_unidades (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            tb1 = tab1.conectar("Select * from  tbusuarios_empresas_unidades where nrseqctrl = '" & wcnrseqctrl & "'")
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
            tb1 = tab1.IncluirAlterarDados("update tbusuarios_empresas_unidades set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
End Class

