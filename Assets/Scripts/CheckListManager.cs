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
        // Esempio task progressiva Fase 1
        checklist.Add(new ChecklistItem(0, "Controlla e rispondi a tutte le mail", MailManager.instance.GetNumeroMailTotali()));

        AggiornaChecklistUI();
    }


    public void CompletaTask(int fase)
    {
        foreach (ChecklistItem item in checklist)
        {
            if (item.fase == fase)
            {
                item.completato = true;
                Debug.Log("Task completato: " + item.fase + ": " + item.descrizione);
                break;
            }
        }

        AggiornaChecklistUI();
        VerificaChecklistCompletata();
    }

    void AggiornaChecklistUI()
    {
        foreach (Transform child in checklistContent)
        {
            Destroy(child.gameObject);
        }

        foreach (ChecklistItem item in checklist)
        {
            GameObject obj = Instantiate(checklistItemPrefab, checklistContent);
            TMP_Text txt = obj.GetComponentInChildren<TMP_Text>();

            if (item.progressiTotali > 0)
                txt.text = $"{item.descrizione}: {item.progressiAttuali}/{item.progressiTotali}";
            else
                txt.text = item.descrizione;

            txt.color = item.completato ? Color.green : Color.black;
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
            Debug.Log("Tutte le task completate!");
            GameManager.instance.CompletaFase();
            // Trigger prossima fase qui se serve
        }
    }

    public void IncrementaProgressi(int fase)
    {
        foreach (ChecklistItem item in checklist)
        {
            if (item.fase == fase)
            {
                item.progressiAttuali++;

                if (item.progressiAttuali >= item.progressiTotali)
                    item.completato = true;

                break;
            }
        }

        AggiornaChecklistUI();
        VerificaChecklistCompletata();
    }

}
