Imports Microsoft.VisualBasic
Public Class clsacessos

    Dim _mensagemerro As String
    Dim _mensagemtitulo As String = "Ops !"
    Dim _mensagemicone As String = "Error"
    Dim _filtro_nrseq As Integer = 0
    Dim _listaclasse As New List(Of clsacessos)
    Dim _nrseq As Integer
    Dim _nomecliente As String
    Dim _cliente As String
    Dim _dataacesso As String
    Dim _maquina As String
    Dim _sistema As String
    Dim _versao As String
    Dim _sistemaoperacional As String
    Dim _usuario As String
    Dim _dominio As String
    Dim _serial As String
    Dim _horaacesso As String
    Dim _usuariosistema As String
    Dim _data As Date
    Dim _dtacesso As Date
    Dim _pais As String
    Dim _nrseqcliente As Integer

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

    Public Property Listaclasse As List(Of clsacessos)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clsacessos))
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

    Public Property Nomecliente As String
        Get
            Return _nomecliente
        End Get
        Set(value As String)
            _nomecliente = value
        End Set
    End Property

    Public Property Dataacesso As String
        Get
            Return _dataacesso
        End Get
        Set(value As String)
            _dataacesso = value
        End Set
    End Property

    Public Property Maquina As String
        Get
            Return _maquina
        End Get
        Set(value As String)
            _maquina = value
        End Set
    End Property

    Public Property Sistema As String
        Get
            Return _sistema
        End Get
        Set(value As String)
            _sistema = value
        End Set
    End Property

    Public Property Versao As String
        Get
            Return _versao
        End Get
        Set(value As String)
            _versao = value
        End Set
    End Property

    Public Property Sistemaoperacional As String
        Get
            Return _sistemaoperacional
        End Get
        Set(value As String)
            _sistemaoperacional = value
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

    Public Property Dominio As String
        Get
            Return _dominio
        End Get
        Set(value As String)
            _dominio = value
        End Set
    End Property

    Public Property Serial As String
        Get
            Return _serial
        End Get
        Set(value As String)
            _serial = value
        End Set
    End Property

    Public Property Horaacesso As String
        Get
            Return _horaacesso
        End Get
        Set(value As String)
            _horaacesso = value
        End Set
    End Property

    Public Property Usuariosistema As String
        Get
            Return _usuariosistema
        End Get
        Set(value As String)
            _usuariosistema = value
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

    Public Property Dtacesso As Date
        Get
            Return _dtacesso
        End Get
        Set(value As Date)
            _dtacesso = value
        End Set
    End Property

    Public Property Pais As String
        Get
            Return _pais
        End Get
        Set(value As String)
            _pais = value
        End Set
    End Property

    Public Property Nrseqcliente As Integer
        Get
            Return _nrseqcliente
        End Get
        Set(value As Integer)
            _nrseqcliente = value
        End Set
    End Property

    Public Property Cliente As String
        Get
            Return _cliente
        End Get
        Set(value As String)
            _cliente = value
        End Set
    End Property
End Class

