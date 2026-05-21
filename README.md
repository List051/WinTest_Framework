# WinItalPascal.Framework

Framework VB.NET per Windows Forms pensato per velocizzare lo sviluppo di applicazioni gestionali moderne con SQL Server, DataGridView avanzati, popup, logging e utility grafiche integrate.

---

# 📁 Struttura Libreria

```text
WinItalPascal
│
├── Core
│   ├── ConfigHelper.vb
│   ├── ThemeFonts.vb
│   ├── Colori.vb
│
├── Database
│   ├── DB.vb
│   ├── GridUtility.vb
│
├── Forms
│   ├── FormHelper.vb
│   ├── FormUtility.vb
│   ├── FadeUtility.vb
│   ├── ScreenUtility.vb
│   ├── FrmTitolo.vb
│
├── Logging
│   ├── FrameworkLogger.vb
│   ├── LogReader.vb
│   ├── LogConfig.vb
│
├── Popup
│   ├── PopupForm.vb
│   ├── PopupHelper.vb
```

---

# 🚀 Funzionalità Principali

* Gestione SQL Server semplificata
* Query parametrizzate automatiche
* DataGridView avanzati
* Ricerca automatica multi-colonna
* Titoli personalizzati per Form
* Fade-In / Fade-Out Form
* Popup informativi personalizzabili
* Logging automatico
* Utility grafiche integrate
* Gestione colori e font centralizzata

---

# ⚙️ Configurazione Database

Il framework utilizza SQL Server tramite connection string definita in `App.config`.

## App.config

```xml
<connectionStrings>
    <add name="MiaConnessione"
         connectionString="Data Source=UTENTE-PC;
         Initial Catalog=DBClienti;
         Integrated Security=True;
         TrustServerCertificate=True"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

---

# 🗄️ Classe DB.vb

## ✔ GetConnection

Apre automaticamente una connessione SQL leggendo la connection string da `App.config`.

```vb
Dim conn = DB.GetConnection()
```

---

## ✔ FillDataTable

Riempie un `DataTable` tramite query SQL.

```vb
Dim dt = DB.FillDataTable(
    "SELECT * FROM Clienti")
```

---

## ✔ ExecuteNonQuery

Esegue query `INSERT`, `UPDATE`, `DELETE`.

```vb
DB.ExecuteNonQuery(
"DELETE FROM Clienti WHERE IdClienti = @p1",
New List(Of SqlParameter) From {
    New SqlParameter("@p1", 1)
})
```

---

## ✔ ExecuteScalar

Restituisce un singolo valore (`COUNT`, `MAX`, ecc.).

```vb
Dim totale =
DB.ExecuteScalar(
"SELECT COUNT(*) FROM Clienti")
```

---

## ✔ QueryLike

Ricerca semplificata automatica con `LIKE`.

```vb
Dim dt = DB.QueryLike(
"SELECT * FROM Clienti
 WHERE Citta LIKE @p1
   AND CAP LIKE @p2
   AND Cliente LIKE @p3",
TxtCitta.Text,
TxtCAP.Text,
TxtCliente.Text)
```

---

# 🎨 GridUtility.vb

Classe dedicata alla gestione avanzata dei `DataGridView`.

---

## ✔ Initialize

Configura automaticamente il DataGridView.

```vb
GridUtility.Initialize(DataGridView1)
```

---

## ✔ ColoraColonne

Colora automaticamente le prime colonne.

```vb
GridUtility.ColoraColonne(
DataGridView1,
Colori.ColoreTipo.Giallo,
Colori.ColoreTipo.Azzurro,
Colori.ColoreTipo.VerdeChiaro)
```

---

## ✔ ConvertiMaiuscolo

Converte il testo della grid in maiuscolo.

```vb
GridUtility.ConvertiMaiuscolo(DataGridView1)
```

---

## ✔ EvidenziaTesto

Evidenzia celle contenenti testo specifico.

```vb
GridUtility.EvidenziaTesto(
DataGridView1,
"ROMA")
```

---

## ✔ FiltraTutti

Ricerca intelligente multi-colonna tipo Google Search.

```vb
GridUtility.FiltraTutti(
DataGridView1,
dtOriginal,
TxtRicerca.Text)
```

---

# 🪟 FormHelper.vb

Utility per gestione Form.

---

## ✔ CentraMonitor

Centra automaticamente il Form nel monitor corrente.

```vb
FormHelper.CentraMonitor(Me)
```

---

## ✔ TitoloPersonalizzato

Aggiunge barra titolo personalizzata.

```vb
FormHelper.TitoloPersonalizzato(
Me,
"Titolo Personalizzato")
```

---

## ✔ FadeIn

Effetto apertura graduale.

```vb
Await FormHelper.FadeIn(Me)
```

---

## ✔ FadeOut

Effetto chiusura graduale.

```vb
Await FormHelper.FadeOut(Me)
```

---

# 🖥️ FrmTitolo.vb

Sistema avanzato per creare finestre borderless con:

* Barra titolo custom
* Pulsante chiudi
* Pulsante minimizza
* Trascinamento finestra

## Utilizzo

```vb
FrmTitolo.CTitolo(
Me,
"Titolo Personalizzato")
```

---

# 🧾 Logging

## ✔ FrameworkLogger

Scrive automaticamente errori e messaggi nel file:

```text
WinItalPascal_Log.txt
```

### Scrittura manuale

```vb
FrameworkLogger.Log(
"Operazione completata")
```

### Log errori

```vb
FrameworkLogger.LogError(
ex,
"ContestoErrore")
```

---

## ✔ LogReader

Legge o apre il file di log.

### Leggere log

```vb
Dim testo =
LogReader.ReadLog()
```

### Aprire log

```vb
LogReader.OpenLog()
```

### Cancellare log

```vb
LogReader.ClearLog()
```

---

# 💬 PopupHelper

Popup grafici associabili ai controlli.

## ✔ AttachPopup

```vb
PopupHelper.AttachPopup(
BtnInfo,
"Informazioni utili",
My.Resources.Info,
Color.Aquamarine,
Color.Blue)
```

---

# 📦 Import Necessari

```vb
Imports WinItalPascal
Imports System.Data.SqlClient
Imports System.Threading.Tasks
```

---

# 🧪 Esempio Completo

## Inizializzazione Form

```vb
Private Sub Form1_Load(...) Handles MyBase.Load

    FormHelper.CentraMonitor(Me)

    FrmTitolo.CTitolo(
    Me,
    "Demo WinItalPascal")

    GridUtility.Initialize(DataGridView1)

    Dim dt =
    DB.FillDataTable(
    "SELECT TOP 20 * FROM Clienti")

    DataGridView1.DataSource = dt

End Sub
```

---

# 🔍 Ricerca Automatica Real-Time

```vb
Private Sub TxtRicerca_TextChanged(...) _
Handles TxtRicerca.TextChanged

    GridUtility.FiltraTutti(
    DataGridView1,
    dtOriginal,
    TxtRicerca.Text)

End Sub
```

---

# ✏️ Modifica Diretta Database da Grid

```vb
Private Sub DataGridView1_RowLeave(...) _
Handles DataGridView1.RowLeave
```

Aggiorna automaticamente SQL Server quando l’utente modifica una riga.

---

# 📌 Requisiti

* .NET Framework 4.8+
* SQL Server
* Windows Forms
* Visual Studio 2022 consigliato

---

# 📖 Filosofia del Framework

WinItalPascal nasce con l’obiettivo di:

* ridurre il codice ripetitivo
* semplificare SQL Server
* velocizzare sviluppo WinForms
* centralizzare grafica e utility
* creare applicazioni gestionali moderne

---

# 🛠️ Stato Progetto

Framework in continua evoluzione.

Funzionalità future:

* Explorer SQL integrato
* CRUD automatici
* Tema Dark Mode
* Export Excel/PDF
* Componenti UI avanzati
* Gestione utenti/permessi

---

# 👨‍💻 Autore

WinItalPascal.Framework
Framework VB.NET Windows Forms sviluppato per rapid application development.
