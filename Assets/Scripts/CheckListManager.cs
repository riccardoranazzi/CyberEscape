using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChecklistManager : MonoBehaviour
{
    public Transform checklistContent; // Content della Scroll View
    public GameObject checklistItemPrefab; // Prefab singolo item

    public List<ChecklistItem> checklist = new List<ChecklistItem>();

    public static ChecklistManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        // Esempio task per Fase 1
        checklist.Add(new ChecklistItem(0, "Controlla e rispondi a tutte le mail"));
        checklist.Add(new ChecklistItem(1, "Segnala l'incidente informatico"));
        checklist.Add(new ChecklistItem(2, "Esegui tutte le azioni correttive"));


        AggiornaChecklistUI();
    }

    public void CompletaTask(int fase)
    {
        foreach (ChecklistItem item in checklist)
        {
            if (item.fase == fase)
            {
                item.completato = true;
                Debug.Log("✔ Task completato: " + item.descrizione);
                break;
            }
        }

        AggiornaChecklistUI();
        VerificaChecklistCompletata();
    }

    void AggiornaChecklistUI()
    {
        Debug.Log("AggiornaChecklistUI chiamato. Items: " + checklist.Count);

        foreach (Transform child in checklistContent)
            Destroy(child.gameObject);

        foreach (ChecklistItem item in checklist)
        {
            GameObject obj = Instantiate(checklistItemPrefab, checklistContent);
            TMP_Text txt = obj.GetComponentInChildren<TMP_Text>();

            if (txt == null)
            {
                Debug.LogError("❌ TMP_Text non trovato nel prefab!");
                return;
            }

            txt.text = item.descrizione;
            txt.color = item.completato ? Color.green : Color.black;
        }
    }


    void VerificaChecklistCompletata()
    {
        bool taskFaseAttualeCompletato = false;

        foreach (ChecklistItem item in checklist)
        {
            if (item.fase == (int)GameManager.instance.faseAttuale)
            {
                Debug.Log($"Verifica task fase {item.fase}: {item.descrizione} | Completato: {item.completato}");

                taskFaseAttualeCompletato = item.completato;
                break;
            }
        }

        if (taskFaseAttualeCompletato)
        {
            Debug.Log("✔ Task della fase attuale completato! Chiamo GameManager.CompletaFase()");
            GameManager.instance.CompletaFase();
        }
        else
        {
            Debug.Log("✖ Task della fase attuale NON completato.");
        }
    }

}
