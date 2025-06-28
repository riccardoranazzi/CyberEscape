using UnityEngine;
using TMPro;

public class MailItemUI : MonoBehaviour
{
    public TMP_Text mittenteText;
    public TMP_Text oggettoText;

    private Mail mail;
    private MailManager manager;

    public void Setup(Mail m, MailManager mm)
    {
        mail = m;
        manager = mm;

        mittenteText.text = mail.mittente;
        oggettoText.text = mail.oggetto;
    }

    public void OnClick()
    {
        manager.OpenMailDetails(mail);
    }
}
