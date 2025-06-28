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

    private List<Mail> mails = new List<Mail>();
    private Mail mailSelezionata;

    void Start()
    {
        // Carica lista mail di test
        LoadMails();
        PopulateMailList();
    }

    void LoadMails()
    {
        mails.Add(new Mail
        {
            mittente = "IT Support",
            oggetto = "Aggiornamento password richiesto",
            corpo = "Gentile utente, clicchi qui per aggiornare la password aziendale entro oggi.",
            isPhishing = true,
            isAmbigua = false
        });

        mails.Add(new Mail
        {
            mittente = "HR Department",
            oggetto = "Busta paga di maggio",
            corpo = "In allegato trova la sua busta paga di maggio. Grazie.",
            isPhishing = false,
            isAmbigua = false
        });
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
        Debug.Log("Mail inoltrata/aperta: " + mailSelezionata.oggetto);

        // Feedback base
        corpoText.text += "\n\n[Azione: inoltrata o aperta]";
    }

    public void SegnalaMail()
    {
        Debug.Log("Mail segnalata: " + mailSelezionata.oggetto + " | Phishing: " + mailSelezionata.isPhishing);

        if (mailSelezionata.isPhishing)
        {
            corpoText.text += "\n\n[✔ Segnalazione corretta]";
        }
        else
        {
            corpoText.text += "\n\n[✖ Falso positivo]";
        }
    }
}
