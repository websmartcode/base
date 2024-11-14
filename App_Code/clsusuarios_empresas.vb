Imports Microsoft.VisualBasic
Imports clsSmart
Public Class clsusuarios_empresas

    Public Sub New()
        Usercad = HttpContext.Current.Session("usuario")
    End Sub
    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _mensagemerro As String
    Dim _mensagemtitulo As String = "Ops !"
    Dim _mensagemicone As String = "Error"
    Dim _filtro_nrseq As Integer = 0
    Dim _Filtro_nrsequsuario As Integer = 0
    Dim _listaclasse As New List(Of clsusuarios_empresas)
    Dim _listausuarios_empresas_unidades As New List(Of clsusuarios_empresas_unidades)
    Dim _listaempresas_unidades As New List(Of clsusuarios_empresas_unidades)
    Dim _nrseq As Integer
    Dim _usercad As String
    Dim _userexclui As String
    Dim _nrseqctrl As String
    Dim _dtcad As Date
    Dim _dtexclui As Date
    Dim _ativo As Boolean
    Dim _nrseqempresa As Integer
    Dim _nrsequsuario As Integer
    Dim _usuario As String
    Dim _imagemperfil As String
    Dim _nomefantasiaempresa As String
    Dim _razaosocialempresa As String
    Dim _logoempresa As String

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

    Public Property Listaclasse As List(Of clsusuarios_empresas)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clsusuarios_empresas))
            _listaclasse = value
        End Set
    End Property

    Public Property Listausuarios_empresas_unidades As List(Of clsusuarios_empresas_unidades)
        Get
            Return _listausuarios_empresas_unidades
        End Get
        Set(value As List(Of clsusuarios_empresas_unidades))
            _listausuarios_empresas_unidades = value
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

    Public Property nrseqempresa As Integer
        Get
            Return _nrseqempresa
        End Get
        Set(value As Integer)
            _nrseqempresa = value
        End Set
    End Property

    Public Property nrsequsuario As Integer
        Get
            Return _nrsequsuario
        End Get
        Set(value As Integer)
            _nrsequsuario = value
        End Set
    End Property

    Public Property Filtro_nrsequsuario As Integer
        Get
            Return _Filtro_nrsequsuario
        End Get
        Set(value As Integer)
            _Filtro_nrsequsuario = value
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

    Public Property Imagemperfil As String
        Get
            Return _imagemperfil
        End Get
        Set(value As String)
            _imagemperfil = value
        End Set
    End Property

    Public Property Nomefantasiaempresa As String
        Get
            Return _nomefantasiaempresa
        End Get
        Set(value As String)
            _nomefantasiaempresa = value
        End Set
    End Property

    Public Property Razaosocialempresa As String
        Get
            Return _razaosocialempresa
        End Get
        Set(value As String)
            _razaosocialempresa = value
        End Set
    End Property

    Public Property Logoempresa As String
        Get
            Return _logoempresa
        End Get
        Set(value As String)
            _logoempresa = value
        End Set
    End Property

    Public Property Listaempresas_unidades As List(Of clsusuarios_empresas_unidades)
        Get
            Return _listaempresas_unidades
        End Get
        Set(value As List(Of clsusuarios_empresas_unidades))
            _listaempresas_unidades = value
        End Set
    End Property
End Class

Partial Public Class clsusuarios_empresas

    Public Function Listarusuarios_empresas() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "select * from vwusuarios_empresas where ativo = true and empresaativa"
            If Filtro_nrseq <> 0 Then
                xsql &= " and nrseq = " & Filtro_nrseq
            End If
            If Filtro_nrsequsuario <> 0 Then
                xsql &= " and nrsequsuario = " & Filtro_nrsequsuario
            End If
            xsql &= " order by nrseq"
            tb1 = tab1.conectar(xsql)

            Dim tbusuarios_empresas_unidades As New Data.DataTable
            Dim tabusuarios_empresas_unidades As New clabancopsql

            Dim tbempresas_unidades As New Data.DataTable
            Dim taempresas_unidades As New clabancopsql

            tbempresas_unidades = taempresas_unidades.conectar("select * from tbempresas_unidades where ativo = true and nrseqempresa in (" & xsql.Replace("*", "  nrseqempresa ") & ")")

            tbusuarios_empresas_unidades = tabusuarios_empresas_unidades.conectar("Select * from vwusuarios_empresas_unidades where ativo = true And nrsequsuariosempresas In (" & xsql.Replace("*", "  nrseq ") & ")")

            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clsusuarios_empresas With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Usercad = tb1.Rows(x)("usercad").ToString, .Userexclui = tb1.Rows(x)("userexclui").ToString, .Nrseqctrl = tb1.Rows(x)("nrseqctrl").ToString, .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Ativo = logico(tb1.Rows(x)("ativo").ToString), .nrseqempresa = numeros(tb1.Rows(x)("nrseqempresa").ToString), .nrsequsuario = numeros(tb1.Rows(x)("nrsequsuario").ToString), .Logoempresa = tb1.Rows(x)("Logoempresa").ToString, .Nomefantasiaempresa = tb1.Rows(x)("Nomefantasiaempresa").ToString, .Razaosocialempresa = tb1.Rows(x)("Razaosocialempresa").ToString, .Usuario = tb1.Rows(x)("Usuario").ToString, .Imagemperfil = tb1.Rows(x)("Imagemperfil").ToString})
                Dim tbproc As Data.DataRow()
                tbproc = tbusuarios_empresas_unidades.Select("nrsequsuariosempresas = " & numeros(tb1.Rows(x)("nrseq").ToString))
                For y As Integer = 0 To tbproc.Count - 1
                    Listaclasse(Listaclasse.Count - 1).Listausuarios_empresas_unidades.Add(New clsusuarios_empresas_unidades With {.Nrseq = numeros(tbproc(y)("nrseq").ToString), .Usercad = tbproc(y)("usercad").ToString, .Userexclui = tbproc(y)("userexclui").ToString, .Nrseqctrl = tbproc(y)("nrseqctrl").ToString, .Dtcad = valordata(tbproc(y)("dtcad").ToString), .Dtexclui = valordata(tbproc(y)("dtexclui").ToString), .Ativo = logico(tbproc(y)("ativo").ToString), .Nrsequsuariosempresas = numeros(tbproc(y)("nrsequsuariosempresas").ToString), .Nrsequnidade = numeros(tbproc(y)("nrsequnidade").ToString), .Nomeunidade = tbproc(y)("Nomeunidade").ToString, .Razaoempresa = numeros(tbproc(y)("Razaosocialempresa").ToString)})
                Next
                tbproc = tbempresas_unidades.Select("nrseqempresa = " & numeros(tb1.Rows(x)("nrseqempresa").ToString))
                For z As Integer = 0 To tbproc.Count - 1
                    Listaclasse(Listaclasse.Count - 1).Listaempresas_unidades.Add(New clsusuarios_empresas_unidades With {.Nrseq = numeros(tbproc(z)("nrseq").ToString), .Usercad = tbproc(z)("usercad").ToString, .Userexclui = tbproc(z)("userexclui").ToString, .Nrseqctrl = tbproc(z)("nrseqctrl").ToString, .Dtcad = valordata(tbproc(z)("dtcad").ToString), .Dtexclui = valordata(tbproc(z)("dtexclui").ToString), .Ativo = logico(tbproc(z)("ativo").ToString), .Nrsequsuariosempresas = numeros(tbproc(z)("nrsequsuariosempresas").ToString), .Nrsequnidade = numeros(tbproc(z)("nrsequnidade").ToString), .Nomeunidade = tbproc(z)("nomeunidade").ToString})
                Next
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
            Dim xsql As String = "select * from tbusuarios_empresas where nrseq = " & Nrseq
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
            nrseqempresa = numeros(tb1.Rows(0)("nrseqempresa").ToString)
            nrsequsuario = numeros(tb1.Rows(0)("nrsequsuario").ToString)
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function

    Public Function salvar(Optional xnovo As Boolean = False, Optional xprocurar As Boolean = False) As Boolean
        Try
            If xprocurar Then
                tb1 = tab1.conectar("select * from tbusuarios_empresas where nrsequsuario = " & nrsequsuario & " and nrseqempresa = " & nrseqempresa)
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
            Dim xprocura As New clsusuarios_empresas
            Dim xjaexiste As Boolean = True
            xprocura.Nrseq = Nrseq
            If Not xprocura.procurar() Then
                xjaexiste = False
            End If
            xsql = "update tbusuarios_empresas Set ativo = true"
            If xjaexiste Then
                If nrseqempresa <> numeros(xprocura.nrseqempresa) Then
                    xsql &= ",nrseqempresa = " & numeros(nrseqempresa)
                End If
            Else
                If nrseqempresa <> 0 Then
                    xsql &= ",nrseqempresa = " & numeros(nrseqempresa)
                End If
            End If
            If xjaexiste Then
                If nrsequsuario <> numeros(xprocura.nrsequsuario) Then
                    xsql &= ",nrsequsuario = " & numeros(nrsequsuario)
                End If
            Else
                If nrsequsuario <> 0 Then
                    xsql &= ",nrsequsuario = " & numeros(nrsequsuario)
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
            tb1 = tab1.IncluirAlterarDados("insert into tbusuarios_empresas (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            tb1 = tab1.conectar("Select * from  tbusuarios_empresas where nrseqctrl = '" & wcnrseqctrl & "'")
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
            tb1 = tab1.IncluirAlterarDados("update tbusuarios_empresas set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
End Class


