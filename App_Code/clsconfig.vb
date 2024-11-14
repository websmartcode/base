Imports Microsoft.VisualBasic
Imports clsSmart
Imports clssessoes
Imports System.IO

Public Class clsconfig

    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql

    Dim _logoweb As String
    Dim _logosistema As String


    Dim _corpadrao As String = "#961940"
    Dim _nrseq As Integer
    Dim _mensagemerro As String
    Dim _logo As String
    Dim _nomecliente As String
    Dim _endereco As String
    Dim _cep As String
    Dim _bairro As String
    Dim _cidade As String
    Dim _uf As String
    Dim _liberado As Boolean
    Dim _pais As String
    Dim _telefone As String
    Dim _cnpj As String
    Dim _utc As String = "Argentina Standard Time"


    Dim _emails As New List(Of clsconfig_emails)

    Public Property Nrseq As Integer
        Get
            Return _nrseq
        End Get
        Set(value As Integer)
            _nrseq = value
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

    Public Property Logo As String
        Get
            Return _logo
        End Get
        Set(value As String)
            _logo = value
        End Set
    End Property

    Public Property Nomecliente As String
        Get
            Return _nomecliente
        End Get
        Set(value As String)
            _nomecliente = tratatexto(value, True, 145)
        End Set
    End Property

    Public Property Endereco As String
        Get
            Return _endereco
        End Get
        Set(value As String)
            _endereco = tratatexto(value, True, 145)
        End Set
    End Property

    Public Property Cep As String
        Get
            Return _cep
        End Get
        Set(value As String)
            _cep = value
        End Set
    End Property

    Public Property Bairro As String
        Get
            Return _bairro
        End Get
        Set(value As String)
            _bairro = tratatexto(value, True, 45)
        End Set
    End Property

    Public Property Cidade As String
        Get
            Return _cidade
        End Get
        Set(value As String)
            _cidade = tratatexto(value, True, 145)
        End Set
    End Property

    Public Property Uf As String
        Get
            Return _uf
        End Get
        Set(value As String)
            _uf = tratatexto(value, True, 2)
        End Set
    End Property

    Public Property Liberado As Boolean
        Get
            Return _liberado
        End Get
        Set(value As Boolean)
            _liberado = value
        End Set
    End Property

    Public Property Pais As String
        Get
            Return _pais
        End Get
        Set(value As String)
            _pais = tratatexto(value, True, 45)
        End Set
    End Property

    Public Property Telefone As String
        Get
            Return _telefone
        End Get
        Set(value As String)
            _telefone = value
        End Set
    End Property

    Public Property Cnpj As String
        Get
            Return _cnpj
        End Get
        Set(value As String)
            _cnpj = tratatexto(value, True, 20)
        End Set
    End Property

    Public Property Corpadrao As String
        Get
            Return _corpadrao
        End Get
        Set(value As String)
            _corpadrao = value
        End Set
    End Property
    Public Property Logoweb As String
        Get
            Return _logoweb
        End Get
        Set(value As String)
            _logoweb = value
        End Set
    End Property

    Public Property Logosistema As String
        Get
            Return _logosistema
        End Get
        Set(value As String)
            _logosistema = value
        End Set
    End Property
    Public Property Utc As String
        Get
            Return _utc
        End Get
        Set(value As String)
            _utc = value
        End Set
    End Property
    Public Property Emails As List(Of clsconfig_emails)
        Get
            Return _emails
        End Get
        Set(value As List(Of clsconfig_emails))
            _emails = value
        End Set
    End Property
End Class
Partial Public Class clsconfig
    Public Function salvar() As Boolean
        Try
            tb1 = tab1.conectar("select * from tbconfig")
            If tb1.Rows.Count = 0 Then
                tb1 = tab1.IncluirAlterarDados("insert into tbconfig (logo, nomecliente, endereco, cnpj, bairro, cidade, uf, telefone, pais, cep,  corpadrao) values ('" & _logo & "', '" & _nomecliente & "', '" & _endereco & "', '" & _cnpj & "', '" & _bairro & "', '" & _cidade & "', '" & _uf & "', '" & _telefone & "','" & _pais & "', '" & _cep & "','" & _corpadrao & "')")
            Else
                Dim xsql As String = "update tbconfig set  telefone = '" & _telefone & "'"

                If _utc <> "" Then
                    xsql &= ", utc = '" & _utc & "'"
                End If
                If _nomecliente <> "" Then
                    xsql &= ", nomecliente = '" & _nomecliente & "'"
                End If
                If _endereco <> "" Then
                    xsql &= ", endereco = '" & _endereco & "'"
                End If
                If _bairro <> "" Then
                    xsql &= ", bairro = '" & _bairro & "'"
                End If
                If _pais <> "" Then
                    xsql &= ", pais = '" & _pais & "'"
                End If
                If _cidade <> "" Then
                    xsql &= ", cidade = '" & _cidade & "'"
                End If
                If _uf <> "" Then
                    xsql &= ", uf = '" & _uf & "'"
                End If
                If _cep <> "" Then
                    xsql &= ", cep = '" & _cep & "'"
                End If
                If _cnpj <> "" Then
                    xsql &= ", cnpj = '" & _cnpj & "'"
                End If
                If _logo <> "" Then
                    xsql &= ", logo = '" & _logo & "'"
                End If
                tb1 = tab1.IncluirAlterarDados(xsql)
            End If
            loadcostumer()
            _mensagemerro = "Config saved !"
            Return True
        Catch exsalvar As Exception
            Return False
        End Try

    End Function
    Public Function carregar() As Boolean
        Try
            tb1 = tab1.conectar("select * from tbconfig")
            If tb1.Rows.Count = 0 Then
                _nomecliente = "SmartCode"
                _cnpj = "12.971.165/0001-90"
                _bairro = "Parque da Fonte"
                _cidade = "São José dos Pinhais"
                _uf = "PR"
                _cep = "83050-320"
                _telefone = "(41)3385-1270"
                _pais = "Brasil"
                _corpadrao = "#961940"
                _utc = "Argentina Standard Time"
            Else
                _nomecliente = tb1.Rows(0)("nomecliente").ToString
                _endereco = tb1.Rows(0)("endereco").ToString
                _cnpj = tb1.Rows(0)("cnpj").ToString
                _bairro = tb1.Rows(0)("bairro").ToString
                _cidade = tb1.Rows(0)("cidade").ToString
                _uf = tb1.Rows(0)("uf").ToString
                _cep = tb1.Rows(0)("cep").ToString
                _telefone = tb1.Rows(0)("telefone").ToString
                _pais = tb1.Rows(0)("pais").ToString
                _logo = tb1.Rows(0)("logo").ToString
                _corpadrao = IIf(tb1.Rows(0)("corpadrao").ToString = "", "#961940", tb1.Rows(0)("corpadrao").ToString)
                _utc = IIf(tb1.Rows(0)("utc").ToString = "", "Argentina Standard Time", tb1.Rows(0)("utc").ToString)
            End If
            loadcostumer()
            Return True
        Catch ex As Exception
            _mensagemerro = ex.Message
            Return False
        End Try
    End Function
    Public Function loadcostumer() As Boolean
        Try
            Dim tb1 As New Data.DataTable
            Dim tab1 As New clabancopsql
            tb1 = tab1.conectar("select * from tbconfig")
            If tb1.Rows.Count = 0 Then
                With HttpContext.Current
                    .Session("nomecliente") = "SmartCode"
                    .Session("enderecocliente") = "Rua Alfredo Pinto, 1955 salas 14 e 15"
                    .Session("bairrocliente") = "Afonso Pena"
                    .Session("cidadecliente") = "São José dos Pinhais"
                    .Session("ufcliente") = "PR"
                    .Session("paiscliente") = "Brasil"
                    .Session("telefonecliente") = "(41) 3385 1270"
                    .Session("logocliente") = "logo.png"
                    .Session("corpadrao") = "#961940"
                End With
            Else
                With HttpContext.Current
                    Dim xarq As String = HttpContext.Current.Server.MapPath("~") & "social\" & tb1.Rows(0)("logo").ToString
                    .Session("nomecliente") = tb1.Rows(0)("nomecliente").ToString
                    .Session("enderecocliente") = tb1.Rows(0)("endereco").ToString
                    .Session("bairrocliente") = tb1.Rows(0)("bairro").ToString
                    .Session("cidadecliente") = tb1.Rows(0)("cidade").ToString
                    .Session("ufcliente") = tb1.Rows(0)("uf").ToString
                    .Session("paiscliente") = tb1.Rows(0)("pais").ToString
                    .Session("telefonecliente") = tb1.Rows(0)("telefone").ToString
                    .Session("logocliente") = IIf(File.Exists(xarq), tb1.Rows(0)("logo").ToString, "logo.png")
                    .Session("corpadrao") = IIf(tb1.Rows(0)("corpadrao").ToString = "", "#181B34", tb1.Rows(0)("corpadrao").ToString)
                End With
            End If
            Return True
        Catch ex As Exception
            _mensagemerro = ex.Message
            Return False
        End Try
    End Function

End Class