using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int punteggio = 0;
    public TMP_Text punteggioText;

    void Awake()
    {
        // Singleton pattern per facile accesso
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        AggiornaPunteggioUI();
    }

    public void AggiungiPunti(int punti)
    {
        punteggio += punti;
        AggiornaPunteggioUI();
        Debug.Log("Punteggio aggiornato: " + punteggio);
    }

    public void SottraiPunti(int punti)
    {
        punteggio += punti;

        AggiornaPunteggioUI();
        Debug.Log("Punteggio aggiornato: " + punteggio);
    }

    void AggiornaPunteggioUI()
    {
        punteggioText.text = "Punteggio: " + punteggio;
    }
}
