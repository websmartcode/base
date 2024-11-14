Imports Microsoft.VisualBasic
Imports clsSmart
Public Class clspermissoes

    Public Sub New()
        Usercad = HttpContext.Current.Session("usuario")
    End Sub
    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _mensagemerro As String
    Dim _mensagemtitulo As String = "Ops !"
    Dim _mensagemicone As String = "Error"
    Dim _filtro_nrseq As Integer = 0
    Dim _listaclasse As New List(Of clspermissoes)
    Dim _listapermissoesdth As New List(Of clspermissoesdth)
    Dim _nrseq As Integer
    Dim _descricao As String
    Dim _usercad As String
    Dim _dtcad As Date
    Dim _ativo As Boolean
    Dim _userexclui As String
    Dim _dtexclui As Date
    Dim _nrseqctrl As String
    Dim _empresa As String
    Dim _vertodas As Boolean
    Dim _nrseqgrupo As Integer
    Dim _tipoacesso As String
    Dim _pasta As String

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

    Public Property Listaclasse As List(Of clspermissoes)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clspermissoes))
            _listaclasse = value
        End Set
    End Property

    Public Property Listapermissoesdth As List(Of clspermissoesdth)
        Get
            Return _listapermissoesdth
        End Get
        Set(value As List(Of clspermissoesdth))
            _listapermissoesdth = value
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

    Public Property Descricao As String
        Get
            Return _descricao
        End Get
        Set(value As String)
            _descricao = value
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

    Public Property Dtcad As Date
        Get
            Return _dtcad
        End Get
        Set(value As Date)
            _dtcad = value
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

    Public Property Userexclui As String
        Get
            Return _userexclui
        End Get
        Set(value As String)
            _userexclui = value
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

    Public Property Nrseqctrl As String
        Get
            Return _nrseqctrl
        End Get
        Set(value As String)
            _nrseqctrl = value
        End Set
    End Property

    Public Property Empresa As String
        Get
            Return _empresa
        End Get
        Set(value As String)
            _empresa = value
        End Set
    End Property

    Public Property Vertodas As Boolean
        Get
            Return _vertodas
        End Get
        Set(value As Boolean)
            _vertodas = value
        End Set
    End Property

    Public Property Nrseqgrupo As Integer
        Get
            Return _nrseqgrupo
        End Get
        Set(value As Integer)
            _nrseqgrupo = value
        End Set
    End Property

    Public Property Tipoacesso As String
        Get
            Return _tipoacesso
        End Get
        Set(value As String)
            _tipoacesso = value
        End Set
    End Property

    Public Property Pasta As String
        Get
            Return _pasta
        End Get
        Set(value As String)
            _pasta = value
        End Set
    End Property
End Class

Partial Public Class clspermissoes

    Public Function Listarpermissoes() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "select * from tbpermissoes where ativo = true"
            If Filtro_nrseq <> 0 Then
                xsql &= " and nrseq = " & Filtro_nrseq
            End If
            tb1 = tab1.conectar(xsql)

            Dim tbpermissoesdth As New Data.DataTable
            Dim tabpermissoesdth As New clabancopsql
            tbpermissoesdth = tabpermissoesdth.conectar("Select * from tbpermissoesdth where ativo = true And nrseq In (" & xsql.Replace("*", "  nrseq ") & ")")
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clspermissoes With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Descricao = tb1.Rows(x)("descricao").ToString, .Usercad = tb1.Rows(x)("usercad").ToString, .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Ativo = logico(tb1.Rows(x)("ativo").ToString), .Userexclui = tb1.Rows(x)("userexclui").ToString, .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Nrseqctrl = tb1.Rows(x)("nrseqctrl").ToString, .Empresa = tb1.Rows(x)("empresa").ToString, .Vertodas = logico(tb1.Rows(x)("vertodas").ToString), .Nrseqgrupo = numeros(tb1.Rows(x)("nrseqgrupo").ToString), .Tipoacesso = tb1.Rows(x)("tipoacesso").ToString, .Pasta = tb1.Rows(x)("pasta").ToString})
                Dim tbproc As Data.DataRow()
                tbproc = tbpermissoesdth.Select("nrseqpermissoe = " & tb1.Rows(x)("nrseq").ToString)
                For y As Integer = 0 To tbproc.Count - 1
                    Listaclasse(Listaclasse.Count - 1).Listapermissoesdth.Add(New clspermissoesdth With {.Nrseq = numeros(tbproc(y)("nrseq").ToString), .Nrseqpermissao = numeros(tbproc(y)("nrseqpermissao").ToString), .Pagina = tbproc(y)("pagina").ToString, .Ativo = logico(tbproc(y)("ativo").ToString)})
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
            Dim xsql As String = "select * from tbpermissoes where nrseq = " & Nrseq
            tb1 = tab1.conectar(xsql)
            If tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(tb1.Rows(0)("nrseq").ToString)
            Descricao = tb1.Rows(0)("descricao").ToString
            Usercad = tb1.Rows(0)("usercad").ToString
            Dtcad = FormatDateTime(valordata(tb1.Rows(0)("dtcad").ToString), DateFormat.ShortDate)
            Ativo = logico(tb1.Rows(0)("ativo").ToString)
            Userexclui = tb1.Rows(0)("userexclui").ToString
            Dtexclui = FormatDateTime(valordata(tb1.Rows(0)("dtexclui").ToString), DateFormat.ShortDate)
            Nrseqctrl = tb1.Rows(0)("nrseqctrl").ToString
            Empresa = tb1.Rows(0)("empresa").ToString
            Vertodas = logico(tb1.Rows(0)("vertodas").ToString)
            Nrseqgrupo = numeros(tb1.Rows(0)("nrseqgrupo").ToString)
            Tipoacesso = tb1.Rows(0)("tipoacesso").ToString
            Pasta = tb1.Rows(0)("pasta").ToString
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
            Dim xprocura As New clspermissoes
            Dim xjaexiste As Boolean = True
            xprocura.Nrseq = Nrseq
            If Not xprocura.procurar() Then
                xjaexiste = False
            End If
            xsql = " update tbpermissoes Set ativo = true"
            If xjaexiste Then
                If Descricao <> xprocura.Descricao Then
                    xsql &= ",descricao = '" & tratatexto(Descricao) & "'"
                End If
            Else
                If Descricao <> "" Then
                    xsql &= ",descricao = '" & tratatexto(Descricao) & "'"
                End If
            End If
            If xjaexiste Then
                If Empresa <> xprocura.Empresa Then
                    xsql &= ",empresa = '" & tratatexto(Empresa) & "'"
                End If
            Else
                If Empresa <> "" Then
                    xsql &= ",empresa = '" & tratatexto(Empresa) & "'"
                End If
            End If
            If xjaexiste Then
                If logico(Vertodas) <> logico(xprocura.Vertodas) Then
                    xsql &= ",vertodas = logico(" & logico(Vertodas) & ")"
                End If
            Else
                If Vertodas <> True Then
                    xsql &= ",vertodas = " & logico(Vertodas)
                End If
            End If
            If xjaexiste Then
                If Nrseqgrupo <> numeros(xprocura.Nrseqgrupo) Then
                    xsql &= ",nrseqgrupo = " & numeros(Nrseqgrupo)
                End If
            Else
                If Nrseqgrupo <> 0 Then
                    xsql &= ",nrseqgrupo = " & numeros(Nrseqgrupo)
                End If
            End If
            If xjaexiste Then
                If Tipoacesso <> xprocura.Tipoacesso Then
                    xsql &= ",tipoacesso = '" & tratatexto(Tipoacesso) & "'"
                End If
            Else
                If Tipoacesso <> "" Then
                    xsql &= ",tipoacesso = '" & tratatexto(Tipoacesso) & "'"
                End If
            End If
            If xjaexiste Then
                If Pasta <> xprocura.Pasta Then
                    xsql &= ",pasta = '" & tratatexto(Pasta) & "'"
                End If
            Else
                If Pasta <> "" Then
                    xsql &= ",pasta = '" & tratatexto(Pasta) & "'"
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
            tb1 = tab1.IncluirAlterarDados("insert into tbpermissoes (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            tb1 = tab1.conectar("Select * from  tbpermissoes where nrseqctrl = '" & wcnrseqctrl & "'")
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
            tb1 = tab1.IncluirAlterarDados("update tbpermissoes set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
End Class


