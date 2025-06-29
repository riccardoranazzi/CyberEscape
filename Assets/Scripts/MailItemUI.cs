using UnityEngine;
using TMPro;

public class MailItemUI : MonoBehaviour
{
    public TMP_Text mittenteText;
    public TMP_Text oggettoText;
    public TMP_Text inizialiText;

    private Mail mail;
    private MailManager manager;

    public void Setup(Mail m, MailManager mm)
    {
        mail = m;
        manager = mm;

        mittenteText.text = mail.mittente;
        oggettoText.text = mail.oggetto;
        inizialiText.text = mail.iniziali;

    }

    public void OnClick()
    {
        Debug.Log("Clicked mail: " + mail.oggetto);
        manager.OpenMailDetails(mail);
    }
}
