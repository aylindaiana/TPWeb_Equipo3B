Public Class GraciasPorParticipar
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub


    Protected Sub BotonParticipar_Click(sender As Object, e As EventArgs)
        Response.Redirect("~/Default.aspx")
    End Sub

End Class