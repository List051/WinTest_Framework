Imports WinItalPascal
Imports System.Threading.Tasks
Imports System.Data.SqlClient
Imports CustomMessageBoxVB
Public Class Test_Framework

    ' Variabile per cambiare rapidamente il DataGridView di test
    Private Property DgvTest As DataGridView
    Private ModificaAbilitata As Boolean = False
    Private RigaCorrente As Integer = -1

    Private dtOriginal As DataTable
    Private dtView As DataTable


    '    ' Popup di esempio per BtnColoraRiga
    '    Dim Nimg As Image = My.Resources.ImgA ' Sostituisci con il nome della tua immagine nelle risorse
    '    PopupHelper.AttachPopup(BtnEvidenzia, vbCrLf &
    '      "ATTENZIONE" & vbCrLf & "Informazioni utili" & vbCrLf & "Evidenzia la richiesta ", Nimg, Color.Aquamarine, Color.Blue)

    '    ' attenzione a non metter ColoriTipo 
    '    'PopupHelper.AttachPopup(BtnResetGrid, "Reset Griglia", My.Resources.ImgA, Colori.ColoreTipo.Azzurro, Color.Red)


    Private Sub Test_Framework_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FormHelper.CentraMonitor(Me)

        FrmTitolo.CTitolo(
        Me,
        "Utilizzo Libreria WinItalPascal - Demo"
    )

        DgvTest = DataGridView1

        '====================================================
        ' 1. DATI COMPLETI (PER RICERCA)
        '====================================================
        dtOriginal = DB.FillDataTable("SELECT * FROM Clienti")

        '====================================================
        ' 2. DATI VISUALIZZATI (TOP 20)
        '====================================================
        dtView = DB.FillDataTable("SELECT TOP 20 * FROM Clienti")

        DgvTest.DataSource = dtView

        '====================================================
        ' GRID INIT
        '====================================================
        GridUtility.Initialize(DgvTest)

        GridUtility.ColoraColonne(
        DgvTest,
        Colori.ColoreTipo.Giallo,
        Colori.ColoreTipo.Azzurro,
        Colori.ColoreTipo.VerdeChiaro
    )

        GridUtility.ConvertiMaiuscolo(DgvTest)

        '====================================================
        ' POPUP ESEMPIO
        '====================================================
        Dim Nimg As Image = My.Resources.ImgA
        Dim NimgQuery As Image = My.Resources.feedback

        PopupHelper.AttachPopup(
        BtnEvidenzia,
        vbCrLf & "ATTENZIONE" & vbCrLf &
        "Evidenzia il testo digitato",
        Nimg,
        Color.Aquamarine,
        Color.Blue)

        PopupHelper.AttachPopup(BtnQuery, vbCrLf &
         "ATTENZIONE" & vbCrLf & "Informazioni utili" & vbCrLf & "Effettua una ricerca anche in un solo campo ", NimgQuery, Color.Aquamarine, Color.Blue)


    End Sub

#Region "GRIDUTILITY TEST"

    Private Sub BtnColoraOK_Click_1(sender As Object, e As EventArgs) Handles BtnColoraOK.Click
        GridUtility.ColoraOK(DataGridView1)
    End Sub


    Private Sub ResetFiltri()
        TxtCercaP1.Clear()
        TxtCercaP2.Clear()
        TxtCercaP3.Clear()
        TxtCercaAutomatica.Clear()
        TxtBoxEvidenziare.Clear()
    End Sub

    Private Sub RipopolaGrid(ByRef dgv As DataGridView)
        Dim dt = DB.FillDataTable("SELECT TOP 20 * FROM clienti")
        dgv.DataSource = dt
        GridUtility.ColoraColonne(
DgvTest,
Colori.ColoreTipo.Giallo,
Colori.ColoreTipo.Azzurro,
Colori.ColoreTipo.VerdeChiaro)
        RJMessageBox.Show("Griglia ripopolata con tutti i dati", "Ripopola Griglia", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub BtnResetGrid_Click(sender As Object, e As EventArgs) Handles BtnResetGrid.Click
        ' svuotà la TxtEvidenzia e resetta i colori della griglia
        TxtBoxEvidenziare.Text = ""
        GridUtility.ResetColori(DataGridView1)

        GridUtility.ColoraColonne(DgvTest, Colori.ColoreTipo.Giallo, Colori.ColoreTipo.Azzurro, Colori.ColoreTipo.VerdeChiaro)

        ' aggiungo msb per conferma reset anche delle TxtCercaP1 e TxtCercaP2
        If RJMessageBox.Show(" Vuoi resettare anche i campi di ricerca?", " Stranezza del reset  
    ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ResetFiltri()  ' resetta i filtri di ricerca
            ' rigenera elenco completo in dgvtest
            ' ripopola la griglia con tutti i dati, altrimenti rimangono i dati filtrati
            RipopolaGrid(DgvTest)

        End If

    End Sub

    Private Sub BtnEvidenzia_Click(sender As Object, e As EventArgs) Handles BtnEvidenzia.Click
        Dim testoevidenziare As String = TxtBoxEvidenziare.Text.Trim.ToUpper()
        If String.IsNullOrEmpty(testoevidenziare) Then Exit Sub
        GridUtility.EvidenziaTesto(DgvTest, testoevidenziare)
    End Sub

#End Region

#Region "FORMHELPER TEST"

    Private Async Sub BtnApreForm_Click(sender As Object, e As EventArgs) Handles BtnApreForm.Click

        ' CREA IL FORM REALE
        Dim frm As New FrmAprire()

        ' titolo personalizzato
        FormHelper.TitoloPersonalizzato(frm, "Titolo Personalizzato Demo")

        ' centra il form
        FormHelper.Centra(frm)

        ' fade-in + show
        Await FormHelper.FadeIn(frm)

        ' prima con WinIaoraLib usavo questo, ma ora ho spostato tutto in FormHelper per avere un unico punto di accesso
        ' non funziona con il pannello, ma è più semplice da usare se non serve il pannello
        ' Comunquèera un parenformt, quindi non so se è un problema di WinIaoraLib o del mio codice, comunque ora uso FormHelper che ha tutto integrato
        ' ModUtility.ApriFormFade(New FrmAprire()) ' Apri il form con effetto fade-in

    End Sub


#End Region

#Region "CONFIGHELPER TEST"

    Private Sub BtnMostraCS_Click_1(sender As Object, e As EventArgs) Handles BtnMostraCS.Click
        Dim cs = ConfigHelper.GetConnectionString()
        RJMessageBox.Show(cs, "Connection String")
    End Sub

#End Region

    ' controlla se ci sono form aperti (escluso TestFramework) e li chiude, in particolare FrmAprire che è il form di test per FormHelper
    ' Questo è utile per evitare di avere più istanze di FrmAprire aperte durante i test, e per assicurarsi che ogni test parta con un ambiente pulito.
    ' Nota: Se vuoi chiudere tutti i form aperti, incluso TestFramework, puoi rimuovere la condizione che esclude TestFramework.
    Private Sub CloseOpenForm()
        ' Crea una lista dei form aperti (senza modificare Application.OpenForms durante il ciclo)
        Dim openFormsList As New List(Of Form)

        ' Aggiungi i form aperti alla lista
        For Each f As Form In Application.OpenForms
            ' Escludi Frm principale dalla chiusura
            If f.Name <> "TestFramework" Then
                openFormsList.Add(f)
            End If
        Next

        ' Chiudi ogni form nella lista, tranne TestFramework
        For Each f As Form In openFormsList
            If f.Name = "FrmAprire" AndAlso f.Visible Then   ' Foglio test
                f.Close()

            End If
        Next
    End Sub


#Region "QUERY TEST"

    Private Sub BtnQuery_Click(sender As Object, e As EventArgs) Handles BtnQuery.Click

        ' Esempio di query con parametri LIKE, usando i valori delle TextBox come parametri di ricerca.
        'Dim citta As String = TxtCercaP1.Text.Trim()
        'Dim cap As String = TxtCercaP2.Text.Trim()
        'Dim param1 As String = If(String.IsNullOrEmpty(citta), "%", $"%{citta}%")
        'Dim param2 As String = If(String.IsNullOrEmpty(cap), "%", $"%{cap}%")

        Dim dt = DB.QueryLike(
"SELECT * FROM Clienti
 WHERE Citta LIKE @p1
   AND CAP LIKE @p2
   AND Cliente LIKE @p3
 ORDER BY Cliente",
TxtCercaP1.Text,
TxtCercaP2.Text,
TxtCercaP3.Text)

        DgvTest.DataSource = dt

    End Sub
    Private Sub TxtCercaAutomatica_TextChanged(
    sender As Object,
    e As EventArgs
) Handles TxtCercaAutomatica.TextChanged

        GridUtility.FiltraTutti(
        DataGridView1,
        dtOriginal,
        TxtCercaAutomatica.Text
    )

    End Sub

    Private Sub BtnModifica_Click(sender As Object, e As EventArgs) Handles BtnModifica.Click

        ModificaAbilitata = Not ModificaAbilitata

        DgvTest.ReadOnly = Not ModificaAbilitata

        If ModificaAbilitata Then

            BtnModifica.Text = "Modifica ATTIVA"

        Else

            ' reset colori righe salvate

            GridUtility.ResetColori(DataGridView1)

            BtnModifica.Text = "Abilita Modifica"

        End If

    End Sub

    Private Sub DataGridView1_RowLeave(
    sender As Object,
    e As DataGridViewCellEventArgs) _
    Handles DataGridView1.RowLeave

        Try

        If Not ModificaAbilitata Then Exit Sub

        If e.RowIndex < 0 Then Exit Sub

        If e.RowIndex >= DataGridView1.Rows.Count Then Exit Sub

        Dim row As DataGridViewRow =
            DataGridView1.Rows(e.RowIndex)

        ' evita riga nuova
        If row.IsNewRow Then Exit Sub

        '====================================================
        ' LETTURA VALORI
        '====================================================

        Dim id As Integer =
            Convert.ToInt32(row.Cells("IdClienti").Value)

        Dim cliente As String =
            If(row.Cells("Cliente").Value, "").ToString()

        Dim indirizzo As String =
            If(row.Cells("Indirizzo").Value, "").ToString()

        Dim citta As String =
            If(row.Cells("Citta").Value, "").ToString()

        Dim prov As String =
            If(row.Cells("Prov").Value, "").ToString()

        Dim cap As String =
            If(row.Cells("CAP").Value, "").ToString()

        Dim tel As String =
            If(row.Cells("Tel").Value, "").ToString()

        Dim piva As String =
            If(row.Cells("P_IVA").Value, "").ToString()

            '====================================================
            ' UPDATE DATABASE
            '====================================================

            DB.ExecuteNonQuery(
        "UPDATE Clienti
         SET Cliente = @p1,
             Indirizzo = @p2,
             Citta = @p3,
             Prov = @p4,
             CAP = @p5,
             Tel = @p6,
             P_IVA = @p7
         WHERE IdClienti = @p8",
         New List(Of SqlParameter) From {
             New SqlParameter("@p1", cliente),
             New SqlParameter("@p2", indirizzo),
             New SqlParameter("@p3", citta),
             New SqlParameter("@p4", prov),
             New SqlParameter("@p5", cap),
             New SqlParameter("@p6", tel),
             New SqlParameter("@p7", piva),
             New SqlParameter("@p8", id)
         })

            '====================================================
            ' FEEDBACK VISIVO
            '====================================================

            row.DefaultCellStyle.BackColor =
            Color.LightGreen

        FrameworkLogger.Log(
            "Riga cliente salvata ID=" & id
        )

    Catch ex As Exception

        FrameworkLogger.LogError(
            ex,
            "DataGridView1_RowLeave"
        )

        MessageBox.Show(
            ex.Message,
            "Errore",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
        )

    End Try

    End Sub

#End Region
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click

        RJMessageBox.Show(LogReader.ReadLog(), "FILE LOG") ' Legge il file di log e lo mostra in un MessageBox

    End Sub


End Class