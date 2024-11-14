Imports Microsoft.VisualBasic
Imports clsSmart
Public Class clscaixaemails_destinatarios
    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _listaclasse As New List(Of clscaixaemails_destinatarios)
    Dim _mensagemerro As String
    Dim _nrseq As Integer
    Dim _nrsequsuario As Integer
    Dim _dtlida As Date
    Dim _lida As Boolean
    Dim _dtexcluida As Date
    Dim _excluida As Boolean
    Dim _nrseqmensagem As Integer
    Dim _rascunho As Boolean
    Dim _enviada As Boolean
    Dim _email As String
    Dim _usercad As String
    Dim _ativo As Boolean

    Public Property Listaclasse As List(Of clscaixaemails_destinatarios)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clscaixaemails_destinatarios))
            _listaclasse = value
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

    Public Property Dtlida As Date
        Get
            Return _dtlida
        End Get
        Set(value As Date)
            _dtlida = value
        End Set
    End Property

    Public Property Lida As Boolean
        Get
            Return _lida
        End Get
        Set(value As Boolean)
            _lida = value
        End Set
    End Property

    Public Property Dtexcluida As Date
        Get
            Return _dtexcluida
        End Get
        Set(value As Date)
            _dtexcluida = value
        End Set
    End Property

    Public Property Excluida As Boolean
        Get
            Return _excluida
        End Get
        Set(value As Boolean)
            _excluida = value
        End Set
    End Property

    Public Property Nrseqmensagem As Integer
        Get
            Return _nrseqmensagem
        End Get
        Set(value As Integer)
            _nrseqmensagem = value
        End Set
    End Property

    Public Property Rascunho As Boolean
        Get
            Return _rascunho
        End Get
        Set(value As Boolean)
            _rascunho = value
        End Set
    End Property

    Public Property Enviada As Boolean
        Get
            Return _enviada
        End Get
        Set(value As Boolean)
            _enviada = value
        End Set
    End Property

    Public Property Email As String
        Get
            Return _email
        End Get
        Set(value As String)
            _email = value
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
End Class
Partial Public Class clscaixaemails_destinatarios

    Public Function Listarcaixaemails_destinatarios() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "select * from tbcaixaemails_destinatarios where ativo = true"
            tb1 = tab1.conectar(xsql)
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clscaixaemails_destinatarios With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Nrsequsuario = numeros(tb1.Rows(x)("nrsequsuario").ToString), .Dtlida = valordata(tb1.Rows(x)("dtlida").ToString), .Lida = logico(tb1.Rows(x)("lida").ToString), .Dtexcluida = valordata(tb1.Rows(x)("dtexcluida").ToString), .Excluida = logico(tb1.Rows(x)("excluida").ToString), .Nrseqmensagem = numeros(tb1.Rows(x)("nrseqmensagem").ToString), .Rascunho = logico(tb1.Rows(x)("rascunho").ToString), .Enviada = logico(tb1.Rows(x)("enviada").ToString), .Email = tb1.Rows(x)("email").ToString})
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
            Dim xsql As String = "select * from tbcaixaemails_destinatarios where nrseq = " & Nrseq
            tb1 = tab1.conectar(xsql)
            If tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(tb1.Rows(0)("nrseq").ToString)
            Nrsequsuario = numeros(tb1.Rows(0)("nrsequsuario").ToString)
            Dtlida = FormatDateTime(valordata(tb1.Rows(0)("dtlida").ToString), DateFormat.ShortDate)
            Lida = logico(tb1.Rows(0)("lida").ToString)
            Dtexcluida = FormatDateTime(valordata(tb1.Rows(0)("dtexcluida").ToString), DateFormat.ShortDate)
            Excluida = logico(tb1.Rows(0)("excluida").ToString)
            Nrseqmensagem = numeros(tb1.Rows(0)("nrseqmensagem").ToString)
            Rascunho = logico(tb1.Rows(0)("rascunho").ToString)
            Enviada = logico(tb1.Rows(0)("enviada").ToString)
            Email = tb1.Rows(0)("email").ToString
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function

    Public Function salvar() As Boolean
        Try
            Dim xsql As String
            xsql = " update tbcaixaemails_destinatarios Set ativo = True"
            If Nrseq <> 0 Then
                xsql &= ",nrseq = " & moeda(Nrseq)
            End If
            If Nrsequsuario <> 0 Then
                xsql &= ",nrsequsuario = " & moeda(Nrsequsuario)
            End If
            If Dtlida <> "" Then
                xsql &= ",dtlida = '" & formatadatamysql(Dtlida) & "'"
            End If
            If Lida <> True Then
                xsql &= ",lida = '" & logico(Lida) & "'"
            End If
            If Dtexcluida <> "" Then
                xsql &= ",dtexcluida = '" & formatadatamysql(Dtexcluida) & "'"
            End If
            If Excluida <> True Then
                xsql &= ",excluida = '" & logico(Excluida) & "'"
            End If
            If Nrseqmensagem <> 0 Then
                xsql &= ",nrseqmensagem = " & moeda(Nrseqmensagem)
            End If
            If Rascunho <> True Then
                xsql &= ",rascunho = '" & logico(Rascunho) & "'"
            End If
            If Enviada <> True Then
                xsql &= ",enviada = '" & logico(Enviada) & "'"
            End If
            If Email <> "" Then
                xsql &= ",email = '" & tratatexto(Email) & "'"
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
            tb1 = tab1.IncluirAlterarDados("insert into tbcaixaemails_destinatarios (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            tb1 = tab1.conectar("Select * from  tbcaixaemails_destinatarios where nrseqctrl = '" & wcnrseqctrl & "'")
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
            tb1 = tab1.IncluirAlterarDados("update tbcaixaemails_destinatarios set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
End Class

