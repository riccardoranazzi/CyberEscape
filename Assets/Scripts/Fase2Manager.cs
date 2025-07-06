using UnityEngine;
using TMPro;

public class Fase2Manager : MonoBehaviour
{
    [Header("UI Panel Segnalazione")]
    public GameObject panelSelezioneTipoIncidente; // Panel con Dropdown e Conferma
    public TMP_Dropdown dropdownTipiIncidente;

    [Header("Button Segnala")]
    public GameObject segnalaButton; // pulsante che apre panel segnalazione

    public GameObject apriSegnalazioneButton;
    public GameObject chiudiPaginaButton;

    void Start()
    {
        // Disattiva il panel selezione all'avvio
        panelSelezioneTipoIncidente.SetActive(false);

        // Attiva solo se è la fase corretta
        if (GameManager.instance.faseAttuale == GameManager.Fase.Segnalazione)
        {
            if (segnalaButton != null)
                segnalaButton.SetActive(true);
        }
        else
        {
            if (segnalaButton != null)
                segnalaButton.SetActive(false);
        }
    }

    public void ApriSegnalazione()
    {
        panelSelezioneTipoIncidente.SetActive(true);
    }

    public void ChiudiPaginaSegnalazione()
    {
        panelSelezioneTipoIncidente.SetActive(false);
    }

    public void ApriPanelSelezioneIncidente()
    {
        if (panelSelezioneTipoIncidente != null)
            panelSelezioneTipoIncidente.SetActive(true);
    }

    public void ConfermaSegnalazione()
    {
        int punteggio = 0;

        if (dropdownTipiIncidente != null)
        {
            string incidenteSelezionato = dropdownTipiIncidente.options[dropdownTipiIncidente.value].text;

            if (incidenteSelezionato.Equals("Phishing"))
            {
                punteggio = 100;
            }
            else
            {
                punteggio = 0;
            }

            Debug.Log("✔ Incidente segnalato: " + incidenteSelezionato);

            // Marca il task come completato nella checklist
            ChecklistManager.instance.CompletaTask(1);

            // Passa alla fase successiva
            GameManager.instance.CompletaFase();
        }
    }
}
