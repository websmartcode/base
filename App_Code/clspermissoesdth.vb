﻿Imports clsSmart
Imports Org.BouncyCastle.Ocsp

Public Class clspermissoesdth
    Dim tb1 As New Data.DataTable
    Dim tab1 As New clabancopsql
    Dim _listaclasse As New List(Of clspermissoesdth)
    Dim _mensagemerro As String
    Dim _nrseq As Integer
    Dim _nrseqpermissao As Integer
    Dim _pagina As String
    Dim _ativo As Boolean
    Dim _dtcad As Date
    Dim _usercad As String
    Dim _dtexclui As Date
    Dim _userexclui As String
    Dim _nrseqctrl As String

    Public Property Listaclasse As List(Of clspermissoesdth)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clspermissoesdth))
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

    Public Property Nrseqpermissao As Integer
        Get
            Return _nrseqpermissao
        End Get
        Set(value As Integer)
            _nrseqpermissao = value
        End Set
    End Property

    Public Property Pagina As String
        Get
            Return _pagina
        End Get
        Set(value As String)
            _pagina = value
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
End Class
Partial Public Class clspermissoesdth

    Public Function Listarpermissoesdth() As Boolean
        Try
            Listaclasse.Clear()
            Dim xsql As String = "Select * from tbpermissoesdth where ativo = true"
            tb1 = tab1.conectar(xsql)
            For x As Integer = 0 To tb1.Rows.Count - 1
                Listaclasse.Add(New clspermissoesdth With {.Nrseq = numeros(tb1.Rows(x)("nrseq").ToString), .Nrseqpermissao = numeros(tb1.Rows(x)("nrseqpermissao").ToString), .Pagina = tb1.Rows(x)("pagina").ToString, .Ativo = logico(tb1.Rows(x)("ativo").ToString)})
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
            Dim xsql As String = "Select * from tbpermissoesdth where nrseq = " & Nrseq
            tb1 = tab1.conectar(xsql)
            If tb1.Rows.Count = 0 Then
                Mensagemerro = "Selecione um item válido para procurar"
                Return False
            End If
            Nrseq = numeros(tb1.Rows(0)("nrseq").ToString)
            Nrseqpermissao = numeros(tb1.Rows(0)("nrseqpermissao").ToString)
            Pagina = tb1.Rows(0)("pagina").ToString
            Ativo = logico(tb1.Rows(0)("ativo").ToString)
            Return True
        Catch excons As Exception
            Mensagemerro = excons.Message
            Return False
        End Try
    End Function

    Public Function salvar(Optional xnovo As Boolean = False, Optional xprocurar As Boolean = False) As Boolean
        Try
            If xprocurar Then
                tb1 = tab1.conectar("Select * from tbusuarios where nrseq = " & numeros(Nrseq))
                If tb1.Rows.Count > 0 Then
                    Nrseq = numeros(Nrseq)
                Else
                    If xnovo = True Then
                        novo()
                    End If
                End If
            Else
                If xnovo = True Then
                    novo()
                End If
            End If
            Dim xsql As String
            Dim xprocura As New clspermissoes
            Dim xjaexiste As Boolean = True
            xprocura.Nrseq = Nrseq
            If Not xprocura.procurar() Then
                xjaexiste = False
            End If
            xsql = " update tbpermissoesdth Set ativo = true"
            If xjaexiste Then
                If Nrseqpermissao <> numeros(" & xprocura.nrseqpermissao & ") Then
                    xsql &= ",nrseqpermissao = " & numeros(Nrseqpermissao)
                End If
            Else
                If Nrseqpermissao <> 0 Then
                    xsql &= ",nrseqpermissao = " & numeros(Nrseqpermissao)
                End If
            End If
            If xjaexiste Then
                If Pagina <> " & xprocura.pagina & " Then
                    xsql &= ",pagina = '" & tratatexto(Pagina) & "'"
                End If
            Else
                If Pagina <> "" Then
                    xsql &= ",pagina = '" & tratatexto(Pagina) & "'"
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
            tb1 = tab1.IncluirAlterarDados("insert into tbpermissoesdth (nrseqctrl, dtcad, usercad, ativo) values ('" & wcnrseqctrl & "','" & hoje() & "','" & Usercad & "', false)")
            tb1 = tab1.conectar("Select * from  tbpermissoesdth where nrseqctrl = '" & wcnrseqctrl & "'")
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
            tb1 = tab1.IncluirAlterarDados("update tbpermissoesdth set ativo = " & IIf(Ativo, "false, dtexclui = '" & hoje() & "', userexclui = '" & Usercad & "'", "true") & " where nrseq = " & Nrseq)
            Return True
        Catch exsalvar As Exception
            Mensagemerro = exsalvar.Message
            Return False
        End Try
    End Function
End Class

