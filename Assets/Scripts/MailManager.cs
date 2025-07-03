using UnityEngine;

using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class MailManager : MonoBehaviour
{
    public GameObject panelOutlook;
    public GameObject panelMailDetails;
    public GameObject mailItemPrefab;
    public Transform mailListContent;
    public ComputerUIManager uiManager;

    public TMP_Text mittenteText;
    public TMP_Text oggettoText;
    public TMP_Text corpoText;
    public TMP_Text linkText;
    public TMP_Text inizialiText;

    private List<Mail> mails = new List<Mail>();
    private Mail mailSelezionata;
    private int mailIdCounter = 0;

    void Start()
    {
        // Carica lista mail di test
        LoadMails();
        PopulateMailList();
    }

    void LoadMails()
    {
        // WHALING - PHISHING (transfer funds)
        mails.Add(new Mail
        {
            id = mailIdCounter++,
            mittente = "Dott. G. Martelli <g.martelli@nom3azienda.com>",
            oggetto = "Richiesta riservata per trasferimento fondi",
            corpo = @"Ciao,
sto lavorando a una trattativa riservata e ho bisogno che tu effettui un bonifico da €17.000 entro oggi.
I dettagli sono confidenziali, ti allego il file criptato (password: CEO2024).
Ti aggiorno nel pomeriggio.

Dott. G. Martelli – CEO azi3nda.com",
            link = "Dettagli_Transfer_CEO2024.zip",
            iniziali = "GM",
            isPhishing = true,
            isAmbigua = false,
            punteggioCorretto = 5,
            punteggioSbagliato = -10
        });

        // PHISHING AMBIGUA
        mails.Add(new Mail
        {
            id = mailIdCounter++,
            mittente = "Amministrazione HR <hr@azienda.com>",
            oggetto = "Aggiornamento modulo benefit annuale – Azione richiesta",
            corpo = @"Gentile dipendente,

ti inviamo in allegato il modulo aggiornato per i benefit aziendali 2025.
Ti chiediamo di verificarlo e confermare eventuali modifiche entro domani alle 12:00 per garantire la corretta registrazione nel sistema paghe.

Per motivi di sicurezza, il documento è protetto da password.
Password: Benefit2025

Grazie per la collaborazione,
Ufficio Risorse Umane",
            link = "Modulo_Benefit_2025.zip",
            iniziali = "HR",
            isPhishing = true,
            isAmbigua = true,
            punteggioCorretto = 10, 
            punteggioSbagliato = -5 
        });


        // AMBIGUA MA AFFIDABILE (spese straordinarie)
        mails.Add(new Mail
        {
            id = mailIdCounter++,
            mittente = "Giulia Ferri <giulia.ferri@azienda.com>",
            oggetto = "Approvazione spese straordinarie Q2",
            corpo = @"Ciao,
allego la richiesta di spesa fuori budget per il trimestre corrente, già approvata verbalmente con il CFO.
Fammi sapere appena riesci a firmare digitalmente il modulo per inviarlo al reparto contabilità.
Buon lavoro,
Giulia Ferri – Dip. Operazioni",
            link = "Modulo_Approvazione_Spese_Q2.pdf",
            iniziali = "GF",
            isPhishing = false,
            isAmbigua = true,
            punteggioCorretto = 10, 
            punteggioSbagliato = -5 
        });

        // AFFIDABILE (ordine pagamento)
        mails.Add(new Mail
        {
            id = mailIdCounter++,
            mittente = "Ufficio Acquisti <acquisti@azienda.com>",
            oggetto = "Autorizzazione pagamento fornitore – Ordine n. 4539",
            corpo = @"Ciao,
ti inoltro la distinta per l’ordine 4539, già validata in piattaforma SAP.

Trovi il file al link in allegato.
Grazie,
Ufficio Acquisti",
            link = "https://intranet.azienda.local/modulo",
            iniziali = "UA",
            isPhishing = false,
            isAmbigua = false,
            punteggioCorretto = 5, // es. phishing facile +5
            punteggioSbagliato = -10 // phishing facile -10
        });

        // OPEN PHISHING LINK 1
        mails.Add(new Mail
        {
            id = mailIdCounter++,
            mittente = "IT Support <it-support@outlook-security.com>",
            oggetto = "[Notifica IT] Accesso bloccato - Verifica richiesta",
            corpo = @"Abbiamo rilevato un tentativo di accesso sospetto.
Conferma la tua identità.
Clicca sul link qui sotto o il tuo account sarà sospeso tra 30 minuti.",
            iniziali = "IT",
            link = "http://outl0ok-verifica-security.info",
            isPhishing = true,
            isAmbigua = false,
            punteggioCorretto = 5, // es. phishing facile +5
            punteggioSbagliato = -10 // phishing facile -10
        });

        /*
        // OPEN PHISHING LINK 2
        mails.Add(new Mail
        {
            id = mailIdCounter++,
            mittente = "Pagamento Web <no-reply@pagamentoweb.biz>",
            oggetto = "Ricevuta pagamento disponibile",
            corpo = @"La ricevuta del tuo pagamento è pronta:
Clicca qui per contestare la transazione se non riconosci l’addebito.",
            link = "http://pagamentoweb.biz/documento",
            iniziali = "PW",
            isPhishing = true,
            isAmbigua = false,
            punteggioCorretto = 5,
            punteggioSbagliato = -10 
        });
        */

        // OPEN AMBIGUA MA AFFIDABILE
        mails.Add(new Mail
        {
            id = mailIdCounter++,
            mittente = "Security Team <security@azienda.com>",
            oggetto = "Accesso insolito al tuo account aziendale",
            corpo = @"Abbiamo rilevato un accesso da una nuova postazione (IP: 185.64.22.11).
Se si tratta di te, ignora.
In caso contrario, clicca il link qui sotto:",
            link = "https://intranet.azienda.local/security/accesso-anomalo",
            iniziali = "ST",
            isPhishing = false,
            isAmbigua = true,
            punteggioCorretto = 10, 
            punteggioSbagliato = -5 
        });

        /*

        // OPEN AFFIDABILE
        mails.Add(new Mail
        {
            id = mailIdCounter++,
            mittente = "Portal Security <security@azienda.com>",
            oggetto = "Conferma accesso dispositivo non riconosciuto",
            corpo = @"Gentile utente,
login rilevato da un nuovo dispositivo.
IP: 192.168.35.12
Dispositivo: Chrome / Milano

Se non sei stato tu, cambia la password:
https://portal.azienda.it/security/profilo",
            link = "https://portal.azienda.it/security/profilo",
            iniziali = "PS",
            isPhishing = false,
            isAmbigua = false,
            punteggioCorretto = 5, // es. phishing facile +5
            punteggioSbagliato = -10 // phishing facile -10
        });
        

        // EMAIL CON FILE INFETTO - PHISHING 1
        mails.Add(new Mail
        {
            id = mailIdCounter++,
            mittente = "Contabilità Fornitori <contabilita@nom3azienda.com>",
            oggetto = "[Fattura Proforma] URGENTE - Ordine #9033",
            corpo = @"In allegato trovi la fattura da validare.
Password: 2206",
            link = "fattura_9033.zip",
            iniziali = "CF",
            isPhishing = true,
            isAmbigua = false,
            punteggioCorretto = 5, 
            punteggioSbagliato = -10 
        });
        

        // EMAIL CON FILE INFETTO - PHISHING 2
        mails.Add(new Mail
        {
            id = mailIdCounter++,
            mittente = "Cybersecurity Eventi <eventi-cyber@azienda.com>",
            oggetto = "Conferma registrazione evento cybersecurity",
            corpo = @"Per completare la registrazione, apri il file allegato.",
            link = "modulo_iscrizione_evento.docm",
            iniziali = "CE",
            isPhishing = true,
            isAmbigua = false,
            punteggioCorretto = 5,
            punteggioSbagliato = -10 
        });
        */
        // EMAIL AMBIGUA CON FILE:EXE
        mails.Add(new Mail
        {
            id = mailIdCounter++,
            mittente = "Legal Department <legal@azienda.com>",
            oggetto = "Contratto aggiornato da firmare",
            corpo = @"Allego il documento aggiornato con le modifiche richieste.
Apreire il file e inviarlo controfirmato per avviare la pratica.",
            link = "contratto_v3.2.pdf.exe",
            iniziali = "LD",
            isPhishing = true,
            isAmbigua = true,
            punteggioCorretto = 10, 
            punteggioSbagliato = -5 
        });

        // EMAIL AFFIDABILE - FILE + LINK
        mails.Add(new Mail
        {
            id = mailIdCounter++,
            mittente = "Legal Department <legal@azienda.com>",
            oggetto = "Invio contratto aggiornato per firma",
            corpo = @"Allego il contratto aggiornato, in formato PDF firmabile.",
            link = @"contratto_firma_vfinal.pdf",
            iniziali = "LD",
            isPhishing = false,
            isAmbigua = false,
            punteggioCorretto = 5,
            punteggioSbagliato = -10 
        });
    }



    public void RefreshMailList()
    {
        // Pulisci lista attuale
        foreach (Transform child in mailListContent)
        {
            Destroy(child.gameObject);
        }

        // Rigenera lista con mail senza azione registrata
        foreach (Mail mail in mails)
        {
            if (string.IsNullOrEmpty(mail.azione))
            {
                GameObject item = Instantiate(mailItemPrefab, mailListContent);
                item.GetComponent<MailItemUI>().Setup(mail, this);
            }
        }
    }


    void PopulateMailList()
    {
        foreach (Mail mail in mails)
        {
            GameObject item = Instantiate(mailItemPrefab, mailListContent);
            item.GetComponent<MailItemUI>().Setup(mail, this);
        }
    }

    public void OpenMailDetails(Mail mail)
    {
        mailSelezionata = mail;

        // aggiorna i testi dettagli mail come già implementato
        mittenteText.text = mail.mittente;
        oggettoText.text = mail.oggetto;
        corpoText.text = mail.corpo;
        linkText.text = mail.link;
        inizialiText.text = mail.iniziali;
        

        // chiama UI Manager
        uiManager.OpenMailDetails();
    }

    public void CloseMailDetails()
    {
        panelMailDetails.SetActive(false);
        panelOutlook.SetActive(true);
    }

    public void InoltraApriMail()
    {
        Debug.Log("Mail aprta: " + mailSelezionata.oggetto + " | Phishing: " + mailSelezionata.isPhishing + "Mail id: " + mailSelezionata.id);

        mailSelezionata.azione = "aperta";

        RefreshMailList();
        CloseMailDetails();
        ControllaMailGestite();

        GestisciAzioneMail(mailSelezionata, "aperta");

        // Feedback base
        corpoText.text += "\n\n[Azione: inoltrata o aperta]";
    }

    public void SegnalaMail()
    {
        Debug.Log("Mail segnalata: " + mailSelezionata.oggetto + " | Phishing: " + mailSelezionata.isPhishing + "Mail id: " + mailSelezionata.id);

        mailSelezionata.azione = "segnalata";

        if (mailSelezionata.isPhishing)
        {
            corpoText.text += "\n\n[✔ Segnalazione corretta]";
        }
        else
        {
            corpoText.text += "\n\n[✖ Falso positivo]";
        }

        GestisciAzioneMail(mailSelezionata, "segnalata");

        RefreshMailList();
        CloseMailDetails();
        ControllaMailGestite();
    }

    //funzione per trogliere le check mail dalla checklist
    public void ControllaMailGestite()
    {
        bool tutteGestite = true;

        foreach (Mail mail in mails)
        {
            if (string.IsNullOrEmpty(mail.azione))
            {
                tutteGestite = false;
                break;
            }
        }

        if (tutteGestite)
        {
            FindObjectOfType<ChecklistManager>().CompletaTask("Rispondi a tutte le mail");
        }
    }

    public void GestisciAzioneMail(Mail mail, string azione)
    {
        mail.azione = azione;

        if (azione == "segnalata")
        {
            if (mail.isPhishing)
            {
                ScoreManager.instance.AggiungiPunti(mail.punteggioCorretto);
                // Azione corretta: non riduce indicator
            }
            else
            {
                ScoreManager.instance.SottraiPunti(mail.punteggioSbagliato);
                IndicatorManager.instance.RiduciValore(25);
            }
        }
        else if (azione == "aperta")
        {
            if (!mail.isPhishing)
            {
                ScoreManager.instance.AggiungiPunti(mail.punteggioCorretto);
                // Azione corretta: non riduce indicator
            }
            else
            {
                ScoreManager.instance.SottraiPunti(mail.punteggioSbagliato);
                IndicatorManager.instance.RiduciValore(25);
            }
        }

        // Aggiorna checklist, refresh lista, ecc.
    }

}
