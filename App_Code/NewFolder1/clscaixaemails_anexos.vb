Imports Microsoft.VisualBasic
Imports clsSmart
Public Class clscaixaemails_anexos
    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _listaclasse As New List(Of clscaixaemails_anexos)
    Dim _mensagemerro As String
    Dim _nrseq As Integer
    Dim _nrseqmensagem As Integer
    Dim _arquivo As String
    Dim _ativo As Boolean
    Dim _dtcad As Date
    Dim _usercad As String
    Dim _dtexclui As Date
    Dim _userrexclui As String
    Dim _caminho As String

    Public Property Listaclasse As List(Of clscaixaemails_anexos)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clscaixaemails_anexos))
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

    Public Property Nrseqmensagem As Integer
        Get
            Return _nrseqmensagem
        End Get
        Set(value As Integer)
            _nrseqmensagem = value
        End Set
    End Property

    Public Property Arquivo As String
        Get
            Return _arquivo
        End Get
        Set(value As String)
            _arquivo = value
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

    Public Property Userrexclui As String
        Get
            Return _userrexclui
        End Get
        Set(value As String)
            _userrexclui = value
        End Set
    End Property

    Public Property Caminho As String
        Get
            Return _caminho
        End Get
        Set(value As String)
            _caminho = value
        End Set
    End Property
End Class
Partial Public Class clscaixaemails_anexos

    Public Function Listarcaixaemails_anexos() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "select * from tbcaixaemails_anexos where ativo = true"
            tb1 = tab1.conectar(xsql)
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clscaixaemails_anexos With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Nrseqmensagem = numeros(tb1.Rows(x)("nrseqmensagem").ToString), .Arquivo = tb1.Rows(x)("arquivo").ToString, .Ativo = logico(tb1.Rows(x)("ativo").ToString), .Dtcad = valordata(tb1.Rows(x)("dtcad").ToString), .Usercad = tb1.Rows(x)("usercad").ToString, .Dtexclui = valordata(tb1.Rows(x)("dtexclui").ToString), .Userrexclui = tb1.Rows(x)("userrexclui").ToString, .Caminho = tb1.Rows(x)("caminho").ToString})
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
            Dim xsql As String = "select * from tbcaixaemails_anexos where nrseq = " & Nrseq
            tb1 = tab1.conectar(xsql)
            If tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(tb1.Rows(0)("nrseq").ToString)
            Nrseqmensagem = numeros(tb1.Rows(0)("nrseqmensagem").ToString)
            Arquivo = tb1.Rows(0)("arquivo").ToString
            Ativo = logico(tb1.Rows(0)("ativo").ToString)
            Dtcad = FormatDateTime(valordata(tb1.Rows(0)("dtcad").ToString), DateFormat.ShortDate)
            Usercad = tb1.Rows(0)("usercad").ToString
            Dtexclui = FormatDateTime(valordata(tb1.Rows(0)("dtexclui").ToString), DateFormat.ShortDate)
            Userrexclui = tb1.Rows(0)("userrexclui").ToString
            Caminho = tb1.Rows(0)("caminho").ToString
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function

    Public Function salvar() As Boolean
        Try
            Dim xsql As String
            xsql = " update tbcaixaemails_anexos Set ativo = True"
            If Nrseq <> 0 Then
                xsql &= ",nrseq = " & moeda(Nrseq)
            End If
            If Nrseqmensagem <> 0 Then
                xsql &= ",nrseqmensagem = " & moeda(Nrseqmensagem)
            End If
            If Arquivo <> "" Then
                xsql &= ",arquivo = '" & tratatexto(Arquivo) & "'"
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
            If Userrexclui <> "" Then
                xsql &= ",userrexclui = '" & tratatexto(Userrexclui) & "'"
            End If
            If Caminho <> "" Then
                xsql &= ",caminho = '" & tratatexto(Caminho) & "'"
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
            tb1 = tab1.IncluirAlterarDados("insert into tbcaixaemails_anexos (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            tb1 = tab1.conectar("Select * from  tbcaixaemails_anexos where nrseqctrl = '" & wcnrseqctrl & "'")
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
            tb1 = tab1.IncluirAlterarDados("update tbcaixaemails_anexos set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
End Class

