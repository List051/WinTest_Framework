Imports WinItalPascal
'Imports WinIaoraLib
Public Class FrmAprire

    Private ReadOnly MiaQuery As String =
        "SELECT TOP 10 * FROM clienti"


    Private Sub FrmAprire_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '====================================================
        ' FORM
        '====================================================
        FormHelper.CentraMonitor(Me)

        FrmTitolo.CTitolo(
            Me,
            "Demo di FormHelper.ApriFormFade")

        '====================================================
        ' GRID
        '====================================================
        GridUtility.Initialize(DTGAprire)

        '====================================================
        ' DATI
        '====================================================
        Dim dt As DataTable =
            DB.FillDataTable(MiaQuery)

        DTGAprire.DataSource = dt
        CaricaTabella("clienti")
        '====================================================
        ' COLORI COLONNE

        ' CARICA COMBO TABELLE

        Dim dtTables As DataTable = DB.GetTables()

        CboTabella.DataSource = dtTables
        CboTabella.DisplayMember = "TABLE_NAME"
        CboTabella.ValueMember = "TABLE_NAME"

        If CboTabella.Items.Count > 0 Then
            CboTabella.SelectedIndex = 0
        End If
        '====================================================



        '====================================================
        GridUtility.ColoraColonne(
            DTGAprire,
            Colori.ColoreTipo.Giallo,
            Colori.ColoreTipo.Azzurro,
            Colori.ColoreTipo.VerdeChiaro)

    End Sub

    Private Sub CboTabella_SelectionChangeCommitted(
    sender As Object,
    e As EventArgs
) Handles CboTabella.SelectionChangeCommitted

        Dim tabella As String =
        CboTabella.SelectedValue.ToString()

        CaricaTabella(tabella)

    End Sub

    Private Sub CaricaTabella(nomeTabella As String)

        Try

            Dim sql As String =
            "SELECT TOP 50 * FROM " & nomeTabella

            Dim dt As DataTable =
            DB.FillDataTable(sql)

            DTGAprire.DataSource = dt

            GridUtility.ColoraColonne(
            DTGAprire,
            Colori.ColoreTipo.Giallo,
            Colori.ColoreTipo.Azzurro,
            Colori.ColoreTipo.VerdeChiaro
        )

        Catch ex As Exception

            FrameworkLogger.LogError(ex, "CaricaTabella")

        End Try

    End Sub
    Private Sub CboTabella_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboTabella.SelectedIndexChanged

        If CboTabella.SelectedItem Is Nothing Then Exit Sub

        Dim tabella As String =
            CboTabella.SelectedItem.ToString()

        CaricaTabella(tabella)
    End Sub


    Private Sub BtnFadeOut_Click(sender As Object, e As EventArgs) Handles BtnFadeOut.Click
        Close()
    End Sub


    Private Sub DTGAprire_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DTGAprire.CellContentClick
        GridUtility.ColoraColonne(
DTGAprire,
Colori.ColoreTipo.Giallo,
Colori.ColoreTipo.Azzurro,
Colori.ColoreTipo.VerdeChiaro)
    End Sub


End Class