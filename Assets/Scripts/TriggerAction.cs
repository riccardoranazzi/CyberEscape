using UnityEngine;

public class TriggerAction : MonoBehaviour
{
    public string azioneDescrizione = "Azione correttiva";
    public GameObject uiInterazione;

    private bool isPlayerNear = false;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            EseguiAzione();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            if (uiInterazione != null)
                uiInterazione.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            if (uiInterazione != null)
                uiInterazione.SetActive(false);
        }
    }

    void EseguiAzione()
    {
        Debug.Log("✔ Azione correttiva eseguita: " + azioneDescrizione);

        if (uiInterazione != null)
            uiInterazione.SetActive(false);

        // Chiama il manager di Fase 3 per registrare l'azione completata
        Fase3Manager.instance.AzioneCorrettaCompletata();

        // Distruggi trigger per evitare ripetizione
        Destroy(gameObject);
    }
}
