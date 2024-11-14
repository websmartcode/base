Imports clsSmart
Partial Class seguranca
    Inherits BasePage

    Dim senhaantiga As String = ""
    Dim condchrespeciais As Boolean = False
    Dim condletramaius As Boolean = False
    Dim condnumeros As Boolean = False
    Dim condletrasminus As Boolean = False
    Dim tbsalvar As New Data.DataTable
    Dim tabsalvar As New clabancopsql
    Public Sub New()

    End Sub

    Protected Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        Dim erro As Boolean = False
        Dim tblista As New Data.DataTable
        Dim tablista As New clabancopsql
        'usuario = Session("usuario")
        tblista = tablista.conectar("Select * from vwusuarios where nrseq = " & hdorigem.Value)
        If tblista.Rows.Count > 0 Then
            senhaantiga = tblista.Rows(0)("senha").ToString
        End If
        If tratatexto(AES_Encrypt(txtSenhaAntiga.Text, "CodeSmart@9898"), True) = senhaantiga Then
            imgSenhaAntiga.ImageUrl = ("~\img\btn_gravar.png")
        Else
            imgSenhaAntiga.ImageUrl = ("~\img\button_cancel.png")
            erro = True
        End If
        If txtConfirmar.Text <> txtSenhaNova.Text Then
            erro = True
            imgSenhasConferem.ImageUrl = ("~\img\button_cancel.png")
        Else
            imgSenhasConferem.ImageUrl = ("~\img\btn_gravar.png")
        End If
        condchrespeciais = False
        condletramaius = False
        condnumeros = False
        condletrasminus = False
        For X As Integer = 33 To 47
            If txtConfirmar.Text.Contains(Chr(X)) Then
                condchrespeciais = True
            End If
        Next
        For X As Integer = 58 To 64
            If txtConfirmar.Text.Contains(Chr(X)) Then
                condchrespeciais = True
            End If
        Next
        For X As Integer = 65 To 90
            If txtConfirmar.Text.Contains(Chr(X)) Then
                condletramaius = True
            End If
        Next
        For X As Integer = 48 To 57
            If txtConfirmar.Text.Contains(Chr(X)) Then
                condnumeros = True
            End If
        Next
        For X As Integer = 48 To 57
            If txtConfirmar.Text.Contains(Chr(X)) Then
                condletrasminus = True
            End If
        Next
        If condletrasminus AndAlso condnumeros Then
            imgNumerosLetras.ImageUrl = ("~\img\btn_gravar.png")
        Else
            erro = True
            imgNumerosLetras.ImageUrl = ("~\img\button_cancel.png")

        End If
        If condletramaius Then
            imgLetraMaiuscula.ImageUrl = ("~\img\btn_gravar.png")
        Else
            erro = True
            imgLetraMaiuscula.ImageUrl = ("~\img\button_cancel.png")
        End If
        If condchrespeciais Then
            imgSimbolos.ImageUrl = ("~\img\btn_gravar.png")
        Else
            erro = True
            imgSimbolos.ImageUrl = ("~\img\button_cancel.png")
        End If
        If txtConfirmar.Text.ToLower = txtSenhaAntiga.Text.ToLower Then
            sm("swal({title: 'Ops!',text: 'As senhas devem ser diferentes!',type: 'error',confirmButtonText: 'OK'})", "swal")
            Exit Sub
        End If
        If erro Then
            Exit Sub
        End If

        Dim xsenhas As New clsusuarios_senhas
        xsenhas.Filtro_nrsequsuario = Session("idusuario")
        xsenhas.Filtro_senha = tratatexto(AES_Encrypt(txtConfirmar.Text.Trim, "CodeSmart@9898"), True)
        xsenhas.Listarusuarios_senhas()

        If xsenhas.Listaclasse.Count > 0 Then
            sm("swal({title: 'Ops!',text: 'Essa senha já foi utilizada pelo usuário !',type: 'error',confirmButtonText: 'OK'})", "swal")
            Exit Sub
        End If

        xsenhas.Nrsequsuario = Session("idusuario")
        xsenhas.Senha = tratatexto(AES_Encrypt(txtConfirmar.Text.Trim, "CodeSmart@9898"), True)
        xsenhas.salvar(True)

        tbsalvar = tabsalvar.IncluirAlterarDados("update tbusuarios set senha = '" & tratatexto(AES_Encrypt(txtConfirmar.Text.Trim, "CodeSmart@9898"), True) & "', alterado = true, dtalterado = '" & formatadatamysql(data()) & "', hralterado = '" & hora() & "', dtvalidadesenha = '" & formatadatamysql(data.AddMonths(3)) & "' where nrseq = " & hdorigem.Value)
        tblista = tablista.conectar("Select * from vwusuarios where nrseq = " & hdorigem.Value)

        If tblista.Rows(0)("alterado").ToString = "" Then
            Response.Redirect("\default.aspx")
        Else
            'If tblista.Rows(0)("gravado").ToString = "0" Then
            '    Response.Redirect("\registro.aspx")
            'Else
            Response.Redirect("\default.aspx")
            'End If

        End If


    End Sub

    Private Sub seguranca_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then Exit Sub
        lblusuario.Text = Session("usuario")
        hdorigem.Value = Session("idusuario")
        Session("usuario") = Nothing


    End Sub

    Private Sub sm(funcao As String, Optional nome As String = "")
        If nome = "" Then
            nome = funcao
        End If
        ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), nome, funcao, True)
    End Sub
End Class
