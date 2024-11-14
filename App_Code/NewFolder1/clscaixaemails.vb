Imports Microsoft.VisualBasic
Imports clsSmart
Public Class clscaixaemails

    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _mensagemerro As String
    Dim _mensagemtitulo As String = "Ops !"
    Dim _mensagemicone As String = "error"
    Dim _listaclasse As New List(Of clscaixaemails)
    Dim _listacaixaemails_anexos As New List(Of clscaixaemails_anexos)
    Dim _listacaixaemails_destinatarios As New List(Of clscaixaemails_destinatarios)
    Dim _nrseq As Integer
    Dim _assunto As String
    Dim _nrseqremetente As Integer
    Dim _dtcad As Date
    Dim _usercad As String
    Dim _ativo As Boolean
    Dim _dtexclui As Date
    Dim _userexclui As String
    Dim _corpo As String
    Dim _anexo As Boolean
    Dim _urgente As Boolean
    Dim _nrseqctrl As String
    Dim _hrcad As String


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

    Public Property Listaclasse As List(Of clscaixaemails)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clscaixaemails))
            _listaclasse = value
        End Set
    End Property

    Public Property Listacaixaemails_anexos As List(Of clscaixaemails_anexos)
        Get
            Return _listacaixaemails_anexos
        End Get
        Set(value As List(Of clscaixaemails_anexos))
            _listacaixaemails_anexos = value
        End Set
    End Property

    Public Property Listacaixaemails_destinatarios As List(Of clscaixaemails_destinatarios)
        Get
            Return _listacaixaemails_destinatarios
        End Get
        Set(value As List(Of clscaixaemails_destinatarios))
            _listacaixaemails_destinatarios = value
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

    Public Property Assunto As String
        Get
            Return _assunto
        End Get
        Set(value As String)
            _assunto = value
        End Set
    End Property

    Public Property Nrseqremetente As Integer
        Get
            Return _nrseqremetente
        End Get
        Set(value As Integer)
            _nrseqremetente = value
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

    Public Property Ativo As Boolean
        Get
            Return _ativo
        End Get
        Set(value As Boolean)
            _ativo = value
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

    Public Property Corpo As String
        Get
            Return _corpo
        End Get
        Set(value As String)
            _corpo = value
        End Set
    End Property

    Public Property Anexo As Boolean
        Get
            Return _anexo
        End Get
        Set(value As Boolean)
            _anexo = value
        End Set
    End Property

    Public Property Urgente As Boolean
        Get
            Return _urgente
        End Get
        Set(value As Boolean)
            _urgente = value
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
End Class

Partial Public Class clscaixaemails

    Public Function Listarcaixaemails() As Boolean
        Try
            Dim tbx As New Data.DataTable
            Dim tabx As New clabancopsql
            Dim tbx2 As New Data.DataTable
            Dim tabx2 As New clabancopsql

            Listaclasse.Clear()
            Dim xsql As String = "select * from tbcaixaemails where ativo = true"
            xsql &= " order by nrseq desc"

            tbx = tabx.conectar("select * from tbcaixaemails_anexos where nrseqmensagem in (" & xsql.Replace("*", " nrseq ") & ")")
            tbx2 = tabx2.conectar("select * from tbcaixaemails_mensagens where nrseqmensagem in (" & xsql.Replace("*", " nrseq ") & ")")

            tb1 = tab1.conectar(xsql)
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clscaixaemails With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Assunto = tb1.Rows(x)("assunto").ToString, .Nrseqremetente = numeros(tb1.Rows(x)("nrseqremetente").ToString), .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Usercad = tb1.Rows(x)("usercad").ToString, .Ativo = logico(tb1.Rows(x)("ativo").ToString), .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Userexclui = tb1.Rows(x)("userexclui").ToString, .Corpo = tb1.Rows(x)("corpo").ToString, .Anexo = logico(tb1.Rows(x)("anexo").ToString), .Urgente = logico(tb1.Rows(x)("urgente").ToString), .Nrseqctrl = tb1.Rows(x)("nrseqctrl").ToString, .Hrcad = tb1.Rows(x)("hrcad").ToString})
                Dim tbproc As Data.DataRow()
                tbproc = tbx.Select("nrseqmensagem = " & tb1.Rows(x)("nrseq").ToString)
                For y As Integer = 0 To tbproc.Count - 1
                    Listaclasse(Listaclasse.Count - 1).Listacaixaemails_anexos.Add(New clscaixaemails_anexos With {.Nrseq = numeros(tbproc(y)("nrseq").ToString), .Nrseqmensagem = numeros(tbproc(y)("nrseqmensagem").ToString), .Arquivo = tbproc(y)("arquivo").ToString, .Ativo = logico(tbproc(y)("ativo").ToString), .Dtcad = valordata(tbproc(y)("dtcad").ToString), .Usercad = tbproc(y)("usercad").ToString, .Dtexclui = valordata(tbproc(y)("dtexclui").ToString), .Userrexclui = tbproc(y)("userrexclui").ToString, .Caminho = tbproc(y)("caminho").ToString})
                Next
                tbproc = tbx2.Select("nrseqmensagem = " & tb1.Rows(x)("nrseq").ToString)
                For y As Integer = 0 To tbproc.Count - 1
                    Listaclasse(Listaclasse.Count - 1).Listacaixaemails_destinatarios.Add(New clscaixaemails_destinatarios With {.Nrseq = numeros(tbproc(y)("nrseq").ToString), .Nrsequsuario = numeros(tbproc(y)("nrsequsuario").ToString), .Dtlida = valordata(tbproc(y)("dtlida").ToString), .Lida = logico(tbproc(y)("lida").ToString), .Dtexcluida = valordata(tbproc(y)("dtexcluida").ToString), .Excluida = logico(tbproc(y)("excluida").ToString), .Nrseqmensagem = numeros(tbproc(y)("nrseqmensagem").ToString), .Rascunho = logico(tbproc(y)("rascunho").ToString), .Enviada = logico(tbproc(y)("enviada").ToString), .Email = tbproc(y)("email").ToString})
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
            Dim xsql As String = "select * from tbcaixaemails where nrseq = " & Nrseq
            tb1 = tab1.conectar(xsql)
            If tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(tb1.Rows(0)("nrseq").ToString)
            Assunto = tb1.Rows(0)("assunto").ToString
            Nrseqremetente = numeros(tb1.Rows(0)("nrseqremetente").ToString)
            Dtcad = FormatDateTime(valordata(tb1.Rows(0)("dtcad").ToString), DateFormat.ShortDate)
            Usercad = tb1.Rows(0)("usercad").ToString
            Ativo = logico(tb1.Rows(0)("ativo").ToString)
            Dtexclui = FormatDateTime(valordata(tb1.Rows(0)("dtexclui").ToString), DateFormat.ShortDate)
            Userexclui = tb1.Rows(0)("userexclui").ToString
            Corpo = tb1.Rows(0)("corpo").ToString
            Anexo = logico(tb1.Rows(0)("anexo").ToString)
            Urgente = logico(tb1.Rows(0)("urgente").ToString)
            Nrseqctrl = tb1.Rows(0)("nrseqctrl").ToString
            Hrcad = tb1.Rows(0)("hrcad").ToString
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function

    Public Function salvar() As Boolean
        Try
            Dim xsql As String
            xsql = " update tbcaixaemails Set ativo = True"
            If Nrseq <> 0 Then
                xsql &= ",nrseq = " & moeda(Nrseq)
            End If
            If Assunto <> "" Then
                xsql &= ",assunto = '" & tratatexto(Assunto) & "'"
            End If
            If Nrseqremetente <> 0 Then
                xsql &= ",nrseqremetente = " & moeda(Nrseqremetente)
            End If
            If Dtcad <> "" Then
                xsql &= ",dtcad = '" & formatadatamysql(Dtcad) & "'"
            End If
            If Usercad <> "" Then
                xsql &= ",usercad = '" & tratatexto(Usercad) & "'"
            End If
            If Ativo <> True Then
                xsql &= ",ativo = '" & logico(Ativo) & "'"
            End If
            If Dtexclui <> "" Then
                xsql &= ",dtexclui = '" & formatadatamysql(Dtexclui) & "'"
            End If
            If Userexclui <> "" Then
                xsql &= ",userexclui = '" & tratatexto(Userexclui) & "'"
            End If
            If Corpo <> "" Then
                xsql &= ",corpo = '" & tratatexto(Corpo) & "'"
            End If
            If Anexo <> True Then
                xsql &= ",anexo = '" & logico(Anexo) & "'"
            End If
            If Urgente <> True Then
                xsql &= ",urgente = '" & logico(Urgente) & "'"
            End If
            If Nrseqctrl <> "" Then
                xsql &= ",nrseqctrl = '" & tratatexto(Nrseqctrl) & "'"
            End If
            If Hrcad <> "" Then
                xsql &= ",hrcad = '" & tratatexto(Hrcad) & "'"
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
            tb1 = tab1.IncluirAlterarDados("insert into tbcaixaemails (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            tb1 = tab1.conectar("Select * from  tbcaixaemails where nrseqctrl = '" & wcnrseqctrl & "'")
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
            tb1 = tab1.IncluirAlterarDados("update tbcaixaemails set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
End Class


