Imports Microsoft.VisualBasic

Public Class clsmodeloscontratos_conteudo


    Dim _mensagemerro As String
    Dim _vinculo As String
    Dim _tabela As String
    Dim _campo As String
    Dim _valor As String
    Dim _listaclasse As New List(Of clsmodeloscontratos_conteudo)

    Public Property Mensagemerro As String
        Get
            Return _mensagemerro
        End Get
        Set(value As String)
            _mensagemerro = value
        End Set
    End Property

    Public Property Vinculo As String
        Get
            Return _vinculo
        End Get
        Set(value As String)
            _vinculo = value
        End Set
    End Property

    Public Property Tabela As String
        Get
            Return _tabela
        End Get
        Set(value As String)
            _tabela = value
        End Set
    End Property

    Public Property Campo As String
        Get
            Return _campo
        End Get
        Set(value As String)
            _campo = value
        End Set
    End Property

    Public Property Valor As String
        Get
            Return _valor
        End Get
        Set(value As String)
            _valor = value
        End Set
    End Property

    Public Property Listaclasse As List(Of clsmodeloscontratos_conteudo)
        Get
            Return _listaclasse
        End Get
        Set(value As List(Of clsmodeloscontratos_conteudo))
            _listaclasse = value
        End Set
    End Property

    Public Function aplicar() As Boolean
        Try
            Dim xpadroes As New List(Of clsmodeloscontratos_conteudo)
            xpadroes.Add(New clsmodeloscontratos_conteudo With {.Campo = "{dia}", .Valor = "{dia}"})
            xpadroes.Add(New clsmodeloscontratos_conteudo With {.Campo = "{mes}", .Valor = "{mes}"})
            xpadroes.Add(New clsmodeloscontratos_conteudo With {.Campo = "{ano}", .Valor = "{ano}"})
            xpadroes.Add(New clsmodeloscontratos_conteudo With {.Campo = "{hoje}", .Valor = "{hoje}"})
            xpadroes.Add(New clsmodeloscontratos_conteudo With {.Campo = "{dataextensa}", .Valor = "{dataextensa}"})
            xpadroes.Add(New clsmodeloscontratos_conteudo With {.Campo = "{emailfinanceiro}", .Valor = "{emailfinanceiro}"})
            xpadroes.Add(New clsmodeloscontratos_conteudo With {.Campo = "{usuario}", .Valor = "{usuario}"})

            Listaclasse.Clear()

            '_______________________________________________________________________________________________________________________________________

            'maoa de sala
            Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Vinculo = "Mapa de Sala", .Tabela = "vwanoletivo_alunos"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{logo}", .Valor = "{logo}"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{empresa}", .Valor = "{empresa}"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{curso}", .Valor = "descricaocurso"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{turma}", .Valor = "descricaoturma"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{turno}", .Valor = "descricaoturno"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{turno}", .Valor = "descricaoturno"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{listaalunos}", .Valor = "{listaalunos}"})

            '_______________________________________________________________________________________________________________________________________

            ' Contratos
            Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Vinculo = "Contratos", .Tabela = "vwanoletivo_alunos"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{logo}", .Valor = "{logo}"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{empresa}", .Valor = "{empresa}"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{curso}", .Valor = "descricaocurso"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{turma}", .Valor = "descricaoturma"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{datanascimento}", .Valor = "data|dtnasc"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{nomealuno}", .Valor = "nome"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{fone}", .Valor = "{fone}"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{turno}", .Valor = "descricaoturno"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{cpf}", .Valor = "{cpf}"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{cpfaluno}", .Valor = "{cpf}"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{etnia}", .Valor = "etnia"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{colegioanterior}", .Valor = "instituicaoanterior"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{rua}", .Valor = "enderecocompleto"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{bairro}", .Valor = "bairro"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{cidade}", .Valor = "cidade"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{matricula}", .Valor = "nrseqmatricula"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{cidadenascimento}", .Valor = "cidadenascimento"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{estadonascimento}", .Valor = "estadonascimento"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{emissor}", .Valor = "orgaoemissor"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{nomepai}", .Valor = "nomepai"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{nomemae}", .Valor = "nomemae"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{cep}", .Valor = "cep"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{estadocivilaluno}", .Valor = "estadocivil"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{rgaluno}", .Valor = "rg"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{emailaluno}", .Valor = "email"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{listanotasemitidas}", .Valor = "{listaalunos}"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.AddRange(xpadroes)

            '_______________________________________________________________________________________________________________________________________

            Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Vinculo = "Reset de senha", .Tabela = "vwusuarios"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{senha}", .Valor = "decrypt|senha"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{usuario}", .Valor = "{usuario}"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.AddRange(xpadroes)

            '_______________________________________________________________________________________________________________________________________

            Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Vinculo = "Novo usuario", .Tabela = "vwusuarios"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{senha}", .Valor = "decrypt|senha"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{usuario}", .Valor = "{usuario}"})
            Listaclasse(Listaclasse.Count - 1).Listaclasse.AddRange(xpadroes)

            '_______________________________________________________________________________________________________________________________________
            '' contratos
            'Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Vinculo = "Contratos", .Tabela = "vwboletins"})
            'Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{logo}", .Valor = "{logo}"})
            'Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{empresa}", .Valor = "{empresa}"})
            'Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{curso}", .Valor = "descricaocurso"})
            'Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{turma}", .Valor = "descricaoturma"})
            'Listaclasse(Listaclasse.Count - 1).Listaclasse.Add(New clsmodeloscontratos_conteudo With {.Campo = "{turno}", .Valor = "descricaoturno"})
            ' Listaclasse(Listaclasse.Count - 1).Listaclasse.AddRange(xpadroes)

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
