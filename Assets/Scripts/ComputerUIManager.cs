using UnityEngine;

public class ComputerUIManager : MonoBehaviour
{
    public GameObject computerMainUI; // schermata principale con icone
    public GameObject panelOutlook;   // lista mail
    public GameObject panelMailDetails; // dettagli mail

    void Start()
    {
        // All’avvio attiva solo la schermata principale
        computerMainUI.SetActive(true);
        panelOutlook.SetActive(false);
        panelMailDetails.SetActive(false);
    }

    public void OpenMailList()
    {
        computerMainUI.SetActive(false);
        panelOutlook.SetActive(true);
        panelMailDetails.SetActive(false);
    }

    public void OpenMailDetails()
    {
        computerMainUI.SetActive(false);
        panelOutlook.SetActive(false);
        panelMailDetails.SetActive(true);
    }

    public void CloseMailDetails()
    {
        panelMailDetails.SetActive(false);
        panelOutlook.SetActive(true);
    }

    public void CloseMailList()
    {
        panelOutlook.SetActive(false);
        computerMainUI.SetActive(true);
    }
}
