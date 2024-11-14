Imports Microsoft.VisualBasic
Imports clsSmart
Imports br.com.correios.apps

Public Class clslogins

    Public Sub New()
        ' Usercad = HttpContext.Current.Session("usuario")
    End Sub
    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _mensagemerro As String
    Dim _mensagemtitulo As String = "Ops !"
    Dim _mensagemicone As String = "Error"
    Dim _filtro_nrseq As Integer = 0
    Dim _listaclasse As New List(Of clslogins)
    Dim _listalogins_dth As New List(Of clslogins_dth)
    Dim _nrseq As Integer
    Dim _ip As String
    Dim _nrsequsuario As Integer
    Dim _forcarlogin As Boolean
    Dim _ativo As Boolean
    Dim _dtcad As Date
    Dim _usercad As String
    Dim _dtexclui As Date
    Dim _userexclui As String
    Dim _nrseqctrl As String
    Dim _hrcad As String

    Dim _travarusuario As Boolean = False

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

    Public Property Listaclasse As List(Of clslogins)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clslogins))
            _listaclasse = value
        End Set
    End Property

    Public Property Listalogins_dth As List(Of clslogins_dth)
        Get
            Return _listalogins_dth
        End Get
        Set(value As List(Of clslogins_dth))
            _listalogins_dth = value
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

    Public Property Ip As String
        Get
            Return _ip
        End Get
        Set(value As String)
            _ip = value
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

    Public Property Forcarlogin As Boolean
        Get
            Return _forcarlogin
        End Get
        Set(value As Boolean)
            _forcarlogin = value
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

    Public Property Hrcad As String
        Get
            Return _hrcad
        End Get
        Set(value As String)
            _hrcad = value
        End Set
    End Property

    Public Property Travarusuario As Boolean
        Get
            Return _travarusuario
        End Get
        Set(value As Boolean)
            _travarusuario = value
        End Set
    End Property
End Class

Partial Public Class clslogins

    Public Function Listarlogins() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "select * from tblogins where ativo = true"
            If Filtro_nrseq <> 0 Then
                xsql &= " and nrseq = " & Filtro_nrseq
            End If
            tb1 = tab1.conectar(xsql)

            Dim tblogins_dth As New Data.DataTable
            Dim tablogins_dth As New clabancopsql
            tblogins_dth = tablogins_dth.conectar("Select * from tblogins_dth where ativo = true And nrseq In (" & xsql.Replace("*", "  nrseq ") & ")")
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clslogins With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Ip = tb1.Rows(x)("ip").ToString, .Nrsequsuario = numeros(tb1.Rows(x)("nrsequsuario").ToString), .Forcarlogin = logico(tb1.Rows(x)("forcarlogin").ToString), .Ativo = logico(tb1.Rows(x)("ativo").ToString), .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Usercad = tb1.Rows(x)("usercad").ToString, .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Userexclui = tb1.Rows(x)("userexclui").ToString, .Nrseqctrl = tb1.Rows(x)("nrseqctrl").ToString})
                Dim tbproc As Data.DataRow()
                tbproc = tblogins_dth.Select("nrseqlogin = " & tb1.Rows(x)("nrseq").ToString)
                For y As Integer = 0 To tbproc.Count - 1
                    Listaclasse(Listaclasse.Count - 1).Listalogins_dth.Add(New clslogins_dth With {.Nrseq = numeros(tbproc(y)("nrseq").ToString), .Nrseqlogin = numeros(tbproc(y)("nrseqlogin").ToString), .Senha = tbproc(y)("senha").ToString, .Dtcad = valordata(tbproc(y)("dtcad").ToString), .Usercad = tbproc(y)("usercad").ToString, .Dtexclui = valordata(tbproc(y)("dtexclui").ToString), .Userexclui = tbproc(y)("userexclui").ToString, .Nrseqctrl = tbproc(y)("nrseqctrl").ToString, .Concluido = logico(tbproc(y)("concluido").ToString), .Erro = tbproc(y)("erro").ToString})
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
            Dim xsql As String = "select * from tblogins where nrseq = " & Nrseq
            tb1 = tab1.conectar(xsql)
            If tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(tb1.Rows(0)("nrseq").ToString)
            Ip = tb1.Rows(0)("ip").ToString
            Nrsequsuario = numeros(tb1.Rows(0)("nrsequsuario").ToString)
            Forcarlogin = logico(tb1.Rows(0)("forcarlogin").ToString)
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

    Public Function salvar(Optional xnovo As Boolean = False, Optional xprocurar As Boolean = False) As Boolean
        Try

            If xprocurar Then
                tb1 = tab1.conectar("select * from tblogins where ip = '" & Ip & "' and nrsequsuario = " & Nrsequsuario)
                If tb1.Rows.Count = 0 Then
                    If xnovo = True Then
                        novo()
                    End If
                Else
                    Nrseq = tb1.Rows(0)("nrseq").ToString
                    Forcarlogin = logico(tb1.Rows(0)("Forcarlogin").ToString)
                End If
            Else
                If xnovo = True Then
                    novo()
                End If
            End If


            Dim xsql As String
            Dim xprocura As New clslogins
            Dim xjaexiste As Boolean = True
            xprocura.Nrseq = Nrseq
            If Not xprocura.procurar() Then
                xjaexiste = False
            End If
            xsql = " update tblogins Set ativo = true"
            If xjaexiste Then
                If Ip <> xprocura.Ip Then
                    xsql &= ",ip = '" & tratatexto(Ip) & "'"
                End If
            Else
                If Ip <> "" Then
                    xsql &= ",ip = '" & tratatexto(Ip) & "'"
                End If
            End If
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
                If logico(Forcarlogin) <> logico(xprocura.Forcarlogin) Then
                    xsql &= ",forcarlogin = logico(" & logico(Forcarlogin) & ")"
                End If
            Else

                xsql &= ",forcarlogin = " & logico(Forcarlogin)

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
            tb1 = tab1.IncluirAlterarDados("insert into tblogins (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            tb1 = tab1.conectar("Select * from  tblogins where nrseqctrl = '" & wcnrseqctrl & "'")
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
            tb1 = tab1.IncluirAlterarDados("update tblogins set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function


    Public Function FazerLogin(xconcluido As Boolean, xerro As String, xsenha As String) As Boolean
        Try
            Travarusuario = False
            salvar(True, True)
            If Forcarlogin Then
                xconcluido = False
                xerro = "Forçar login ativo"
                Dim xip As New clsbloqueioips
                xip.Usercad = Usercad
                xip.Endereco = Ip
                xip.Nrsequsuario = Nrsequsuario
                xip.gravarip()
                Travarusuario = True
            End If
            Dim xdth As New clslogins_dth
            xdth.Nrseqlogin = Nrseq
            xdth.Concluido = xconcluido
            xdth.Erro = xerro
            xdth.Senha = xsenha
            xdth.salvar(True)

            Return True

        Catch ex As Exception
            Return False
        End Try


    End Function
End Class


