using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChecklistManager : MonoBehaviour
{
    public Transform checklistContent; // Content della Scroll View
    public GameObject checklistItemPrefab; // Prefab singolo item

    public List<ChecklistItem> checklist = new List<ChecklistItem>();

    void Start()
    {
        // Esempio inizializzazione
        checklist.Add(new ChecklistItem("Rispondi a tutte le mail"));
        checklist.Add(new ChecklistItem("Segnala le mail di phishing"));
        checklist.Add(new ChecklistItem("Analizza log di sistema"));

        AggiornaChecklistUI();
    }

    public void CompletaTask(string descrizione)
    {
        foreach (ChecklistItem item in checklist)
        {
            if (item.descrizione == descrizione)
            {
                item.completato = true;
                Debug.Log("Task completato: " + descrizione);
                break;
            }
        }

        AggiornaChecklistUI();
        VerificaChecklistCompletata();
    }

    void AggiornaChecklistUI()
    {
        // Pulisci lista UI
        foreach (Transform child in checklistContent)
        {
            Destroy(child.gameObject);
        }

        // Ricrea lista aggiornata
        foreach (ChecklistItem item in checklist)
        {
            GameObject obj = Instantiate(checklistItemPrefab, checklistContent);
            TMP_Text txt = obj.GetComponentInChildren<TMP_Text>();
            txt.text = item.descrizione;

            // Cambia colore o aggiungi ✔️ se completato
            if (item.completato)
                txt.color = Color.green;
            else
                txt.color = Color.black;
        }
    }

    void VerificaChecklistCompletata()
    {
        bool tuttiCompletati = true;

        foreach (ChecklistItem item in checklist)
        {
            if (!item.completato)
            {
                tuttiCompletati = false;
                break;
            }
        }

        if (tuttiCompletati)
        {
            Debug.Log("✔️ Tutte le task completate!");
            // Trigger prossima fase qui se serve
        }
    }
}
