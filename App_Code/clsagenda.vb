Imports Microsoft.VisualBasic
Imports clsSmart
Public Class clsagenda
    Dim tb1 As New Data.DataTable
    Dim tab1 As New clsBanco

    Dim _mensagemerro As String
    Dim _nrseq As Integer
    Dim _nrseqdoca As Integer
    Dim _data As Date
    Dim _usercad As String
    Dim _dtcad As Date
    Dim _nrseqcarga As Integer
    Dim _hora As String
    Dim _ativo As Integer
    Dim _status As String
    Dim _agendarumo As New clsagenda_resumo
    Dim _agendadia As New List(Of clsagenda)
    Dim _agendames As New List(Of clsagenda)

    Dim _eventos As New List(Of clsagenda_eventos)
    Dim _descricaodoca As String = ""
    Dim _nomefornecedor As String = ""

    Dim _filtro_nrseqfornecedor As Integer = 0
    Dim _filtro_nrseqcliente As Integer = 0
    Dim _filtro_nrseqempresa As Integer = 0
    Dim _qtdhorariosreservados As Integer = 0

    Dim _horariosvalidos As New List(Of String)


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

    Public Property Nrseqdoca As Integer
        Get
            Return _nrseqdoca
        End Get
        Set(value As Integer)
            _nrseqdoca = value
        End Set
    End Property

    Public Property Data As Date
        Get
            Return _data
        End Get
        Set(value As Date)
            _data = value
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

    Public Property Nrseqcarga As Integer
        Get
            Return _nrseqcarga
        End Get
        Set(value As Integer)
            _nrseqcarga = value
            If _nrseqcarga <> 0 Then

            End If
        End Set
    End Property

    Public Property Hora As String
        Get
            Return _hora
        End Get
        Set(value As String)
            _hora = value
        End Set
    End Property

    Public Property Ativo As Integer
        Get
            Return _ativo
        End Get
        Set(value As Integer)
            _ativo = value
        End Set
    End Property

    Public Property Status As String
        Get
            Return _status
        End Get
        Set(value As String)
            _status = value
        End Set
    End Property

    Public Property Agendadia As List(Of clsagenda)
        Get
            Return _agendadia
        End Get
        Set(value As List(Of clsagenda))
            _agendadia = value
        End Set
    End Property

    Public Property Agendames As List(Of clsagenda)
        Get
            Return _agendames
        End Get
        Set(value As List(Of clsagenda))
            _agendames = value
        End Set
    End Property

    Public Property Eventos As List(Of clsagenda_eventos)
        Get
            Return _eventos
        End Get
        Set(value As List(Of clsagenda_eventos))
            _eventos = value
        End Set
    End Property

    Public Property Descricaodoca As String
        Get
            Return _descricaodoca
        End Get
        Set(value As String)
            _descricaodoca = value
        End Set
    End Property

    Public Property Nomefornecedor As String
        Get
            Return _nomefornecedor
        End Get
        Set(value As String)
            _nomefornecedor = value
        End Set
    End Property



    Public Property Agendarumo As clsagenda_resumo
        Get
            Return _agendarumo
        End Get
        Set(value As clsagenda_resumo)
            _agendarumo = value
        End Set
    End Property

    Public Property Filtro_nrseqfornecedor As Integer
        Get
            Return _filtro_nrseqfornecedor
        End Get
        Set(value As Integer)
            _filtro_nrseqfornecedor = value
        End Set
    End Property

    Public Property Filtro_nrseqcliente As Integer
        Get
            Return _filtro_nrseqcliente
        End Get
        Set(value As Integer)
            _filtro_nrseqcliente = value
        End Set
    End Property

    Public Property Filtro_nrseqempresa As Integer
        Get
            Return _filtro_nrseqempresa
        End Get
        Set(value As Integer)
            _filtro_nrseqempresa = value
        End Set
    End Property

    Public Property Qtdhorariosreservados As Integer
        Get
            Return _qtdhorariosreservados
        End Get
        Set(value As Integer)
            _qtdhorariosreservados = value
        End Set
    End Property



    Public Property Horariosvalidos As List(Of String)
        Get
            Return _horariosvalidos
        End Get
        Set(value As List(Of String))
            _horariosvalidos = value
        End Set
    End Property


End Class

Partial Public Class clsagenda
    Public Function procurar() As Boolean
        If Nrseq = 0 Then
            Mensagemerro = "Selecione um item válido para procurar"
        End If
        tb1 = tab1.conectar("select * from tabela where nrseq = " & Nrseq)
        If tb1.Rows.Count = 0 Then
            Mensagemerro = "Selecione um item válido para procurar"
            Return False
        End If
        Nrseq = tb1.Rows(0)("nrseq").ToString
        Nrseqdoca = tb1.Rows(0)("nrseqdoca").ToString
        Data = FormatDateTime(tb1.Rows(0)("data").ToString, DateFormat.ShortDate)
        Usercad = tb1.Rows(0)("usercad").ToString
        Dtcad = FormatDateTime(tb1.Rows(0)("dtcad").ToString, DateFormat.ShortDate)
        Nrseqcarga = tb1.Rows(0)("nrseqcarga").ToString
        Hora = tb1.Rows(0)("hora").ToString
        Ativo = tb1.Rows(0)("ativo").ToString
        Status = tb1.Rows(0)("status").ToString
        Return True
        Try
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function
    Public Function salvar() As Boolean
        Try
            Dim xsql As String
            xsql = " update Table Set ativo = True"
            If Nrseq <> 0 Then
                xsql &= ",nrseq = " & moeda(Nrseq)
            End If
            If Nrseqdoca <> 0 Then
                xsql &= ",nrseqdoca = " & moeda(Nrseqdoca)
            End If
            If Data <> "" Then
                xsql &= ",data = '" & formatadatamysql(Data) & "'"
            End If
            If Usercad <> "" Then
                xsql &= ",usercad = '" & tratatexto(Usercad) & "'"
            End If
            If Dtcad <> "" Then
                xsql &= ",dtcad = '" & formatadatamysql(Dtcad) & "'"
            End If
            If Nrseqcarga <> 0 Then
                xsql &= ",nrseqcarga = " & moeda(Nrseqcarga)
            End If
            If Hora <> "" Then
                xsql &= ",hora = '" & tratatexto(Hora) & "'"
            End If
            If Ativo <> 0 Then
                xsql &= ",ativo = " & moeda(Ativo)
            End If
            If Status <> "" Then
                xsql &= ",status = '" & tratatexto(Status) & "'"
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
            Dim wcnrseqctrl As String = gerarnrseqcontrole("")
            tb1 = tab1.IncluirAlterarDados("insert into Table (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            tb1 = tab1.conectar("Select * from  tbtabela where nrseqctrl = '" & wcnrseqctrl & "'")
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
            tb1 = tab1.IncluirAlterarDados("update tbagendamedica set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
    Public Function carregaragenda() As Boolean
        Try
            _agendadia.Clear()
            Dim xsql As String = "select * from vwagenda where data = '" & formatadatamysql(_data) & "' and ativo = true"
            If Filtro_nrseqcliente <> 0 Then
                xsql &= " and nrseqcliente = " & Filtro_nrseqcliente
            End If

            If _filtro_nrseqempresa <> 0 Then
                xsql &= " and nrseqempresa = " & _filtro_nrseqempresa
            End If

            If Filtro_nrseqfornecedor <> 0 Then
                xsql &= " and nrseqfornecedor = " & Filtro_nrseqfornecedor
            End If
            tb1 = tab1.conectar(xsql)
            For x As Integer = 0 To tb1.Rows.Count - 1
                _agendadia.Add(New clsagenda With {.Data = tb1.Rows(x)("data").ToString, .Hora = tb1.Rows(x)("hora").ToString, .Status = tb1.Rows(x)("status").ToString, .Nrseqcarga = tb1.Rows(x)("nrseqcarga").ToString, .Nrseqdoca = tb1.Rows(x)("nrseqdoca").ToString, .Nrseq = tb1.Rows(x)("nrseq").ToString, .Descricaodoca = tb1.Rows(x)("descricaodoca").ToString, .Nomefornecedor = tb1.Rows(x)("nomefornecedor").ToString, .Dtcad = tb1.Rows(x)("dtcad").ToString})
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function alterarstatus() As Boolean
        Try
            tb1 = tab1.IncluirAlterarDados("update tbagenda set status = '" & Status & "' where nrseqcarga = " & _nrseqcarga)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function carregaragendames() As Boolean
        Try
            _agendames.Clear()
            tb1 = tab1.conectar("select *   from vwagenda where month(data) = " & Month(_data) & " and year(data) = '" & Year(_data) & "' and ativo = true")
            For x As Integer = 0 To tb1.Rows.Count - 1
                _agendames.Add(New clsagenda With {.Data = tb1.Rows(x)("data").ToString, .Hora = tb1.Rows(x)("hora").ToString, .Status = tb1.Rows(x)("status").ToString, .Nrseqcarga = tb1.Rows(x)("nrseqcarga").ToString, .Nrseqdoca = tb1.Rows(x)("nrseqdoca").ToString, .Nrseq = tb1.Rows(x)("nrseq").ToString, .Descricaodoca = tb1.Rows(x)("descricaodoca").ToString, .Nomefornecedor = tb1.Rows(x)("nomefornecedor").ToString, .Dtcad = tb1.Rows(x)("dtcad").ToString})
            Next

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

End Class


