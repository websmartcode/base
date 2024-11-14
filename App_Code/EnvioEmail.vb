Imports Microsoft.VisualBasic

Public Class EnvioEmail

    Public remetente As String
    Public credencialUsuario As String
    Public credencialSenha As String
    Public credencialDominio As String
    Public porta As Integer
    Public smtp As String

    Public Sub New()
    End Sub

    Public Sub New(souVizinho As Boolean)
        Me.remetente = "alertas@smartcodesolucoes.com.br"
        Me.credencialUsuario = "alertas@smartcodesolucoes.com.br"
        Me.credencialSenha = "Sousmart@747791"
        Me.credencialDominio = "smartcodesolucoes.com.br"
        Me.porta = 587
        Me.smtp = "smartcodesolucoes.com.br"

    End Sub

    Public Sub New(remetente As String, credencialUsuario As String, credencialSenha As String, credencialDominio As String, porta As Integer, smtp As String)
        Me.remetente = remetente
        Me.credencialUsuario = credencialUsuario
        Me.credencialSenha = credencialSenha
        Me.credencialDominio = credencialDominio
        Me.porta = porta
        Me.smtp = smtp
    End Sub



End Class
