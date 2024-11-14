Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports clsSmart
Imports System.IO
Partial Class socialnetwork_loadimage
    Inherits System.Web.UI.Page
    Dim m_sImageNameUserUpload As String
    Dim m_sImageNameGenerated As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sImageName As String = ""
        Dim sImagePathImages As String = Server.MapPath("~\social")
        Session("ImageName") = ""
        If (FileUpload1.HasFile) Then

            sImageName = Guid.NewGuid().ToString().Substring(0, 8)
            Dim sFileExt As String = Path.GetExtension(FileUpload1.FileName)
            m_sImageNameUserUpload = sImageName + sFileExt
            m_sImageNameGenerated = Path.Combine(sImagePathImages, m_sImageNameUserUpload)
            FileUpload1.PostedFile.SaveAs(m_sImageNameGenerated)
            Session("ImageName") = m_sImageNameUserUpload
        End If
        imgcrop.ImageUrl = "/social/" + Session("ImageName")
    End Sub

    Private Sub btnsalvar_Click(sender As Object, e As EventArgs) Handles btnsalvar.Click
        If Session("ImageName") = "" Then Exit Sub
        'Dim tbsalvar As New Data.DataTable
        Dim tabsalvar As New clabancopsql
        Dim tbsalvar As New Data.DataTable
        Dim m_sImageNameUserUpload As String = Session("ImageName")
        Dim sImagePathImages As String = Server.MapPath("~\social\")
        If (hdnW.Value <> "") Then
            Dim iHeight As Integer = Convert.ToInt32(hdnH.Value)
            Dim iWidth As Integer = Convert.ToInt32(hdnW.Value)
            Dim Int As Integer = Convert.ToInt32(hdnH.Value)
            Dim iXCoord As Integer = Convert.ToInt32(hdnX.Value)
            Dim iYCoord As Integer = Convert.ToInt32(hdnY.Value)
            '//Call CropImage method defined below
            Dim byt_CropImage = CropImage(sImagePathImages + m_sImageNameUserUpload, iWidth, iHeight, iXCoord, iYCoord)
            Dim oMemoryStream As MemoryStream = New MemoryStream(byt_CropImage, 0, byt_CropImage.Length)
            oMemoryStream.Write(byt_CropImage, 0, byt_CropImage.Length)

            Dim oCroppedImage As System.Drawing.Image = System.Drawing.Image.FromStream(oMemoryStream, True)
            Dim sSaveTo As String = sImagePathImages + "T" & m_sImageNameUserUpload
            oCroppedImage.Save(sSaveTo, oCroppedImage.RawFormat)

            imgCropped.ImageUrl = "social/" + m_sImageNameUserUpload
            Session("imgret") = Request.Url.OriginalString.Replace(Request.Path, "/social/" & "T" & m_sImageNameUserUpload)  ' Server.MapPath("~\social\").Replace("\", "\\") & "T" & m_sImageNameUserUpload
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "fecharmodaldocsparent1('" & Session("imgret") & "')", "fecharmodaldocsparent1('" & Session("imgret") & "')", True)



            Select Case hdorigem.Value.ToLower
                Case Is = "usuarios"

                    Dim xuser As New clsusuarios
                    xuser.Nrseq = hdchave.Value
                    xuser.Imagemperfil = "T" & m_sImageNameUserUpload
                    xuser.alterarusuario()

                    'tbsalvar = tabsalvar.IncluirAlterarDados("update tbusuarios set imagemperfil = '" & "T" & m_sImageNameUserUpload & "' where usuario = '" & hdchave.Value & "'")

                    tbsalvar = tabsalvar.IncluirAlterarDados("insert into  tbusuarios_perfil (arquivo, dtcad, ativo, nrsequsuario) values ('" & "T" & m_sImageNameUserUpload & "', '" & hoje() & "', true, " & hdchave.Value & ")")



                Case Is = "clientes"
                    tbsalvar = tabsalvar.IncluirAlterarDados("update tbclientes set logo = '" & "T" & m_sImageNameUserUpload & "' where nrseq = " & hdchave.Value)
                Case Is = "empresa"
                    Dim xconfig As New clsconfig
                    xconfig.Logo = "T" & m_sImageNameUserUpload
                    xconfig.salvar()
            End Select
            Response.Redirect("/default.aspx")
        Else
            Select Case hdorigem.Value.ToLower
                Case Is = "usuarios"

                    Dim xuser As New clsusuarios
                    xuser.Nrseq = hdchave.Value
                    xuser.Imagemperfil = m_sImageNameUserUpload
                    xuser.alterarusuario()

                    'tbsalvar = tabsalvar.IncluirAlterarDados("update tbusuarios set imagemperfil = '" & "T" & m_sImageNameUserUpload & "' where usuario = '" & hdchave.Value & "'")

                    tbsalvar = tabsalvar.IncluirAlterarDados("insert into  tbusuarios_perfil (arquivo, dtcad, ativo, nrsequsuario) values ('" & m_sImageNameUserUpload & "', '" & hoje() & "', true, " & hdchave.Value & ")")



                Case Is = "clientes"
                    tbsalvar = tabsalvar.IncluirAlterarDados("update tbclientes set logo = '" & m_sImageNameUserUpload & "' where nrseq = " & hdchave.Value)
                Case Is = "empresa"
                    Dim xconfig As New clsconfig
                    xconfig.Logo = m_sImageNameUserUpload
                    xconfig.salvar()
            End Select

            Response.Redirect("/default.aspx")

        End If
    End Sub

    Private Sub socialnetwork_loadimage_Load(sender As Object, e As EventArgs) Handles Me.Load
        hdchave.Value = Session("chave")
        hdorigem.Value = Session("origem")
    End Sub
    Private Function CropImage(sImagePath As String, iWidth As Integer, iHeight As Integer, iX As Integer, iY As Integer)
        Try
            Dim oOriginalImage As System.Drawing.Image = System.Drawing.Image.FromFile(sImagePath)
            Dim oBitmap As System.Drawing.Image = New System.Drawing.Bitmap(iWidth, iHeight)
            ' oBitmap.SetResolution(oOriginalImage.HorizontalResolution, oOriginalImage.VerticalResolution)
            Dim Graphic As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(oBitmap)
            Graphic.SmoothingMode = SmoothingMode.AntiAlias
            Graphic.InterpolationMode = InterpolationMode.HighQualityBicubic
            Graphic.PixelOffsetMode = PixelOffsetMode.HighQuality
            Graphic.DrawImage(oOriginalImage, New System.Drawing.Rectangle(0, 0, iWidth, iHeight), iX, iY, iWidth, iHeight, System.Drawing.GraphicsUnit.Pixel)
            Dim oMemoryStream As MemoryStream = New MemoryStream()
            oBitmap.Save(oMemoryStream, oOriginalImage.RawFormat)
            Return oMemoryStream.GetBuffer()

        Catch ex As Exception
            Dim teste As String = ex.Message
            teste &= "1"
            Return False
        End Try

    End Function
End Class
