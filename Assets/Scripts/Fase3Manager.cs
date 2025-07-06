using UnityEngine;

public class Fase3Manager : MonoBehaviour
{
    public static Fase3Manager instance;

    public int numeroAzioniTotali = 3; 
    private int numeroAzioniCompletate = 0;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        Debug.Log("✔ Fase3Manager Awake - numeroAzioniTotali = " + numeroAzioniTotali);
    }


    void Start()
    {
        Debug.Log("✔ Fase3Manager avviato. Azioni totali richieste: " + numeroAzioniTotali);
    }

    public void AzioneCorrettaCompletata()
    {
        numeroAzioniCompletate++;
        Debug.Log("✔ Azioni correttive completate: " + numeroAzioniCompletate + "/" + numeroAzioniTotali + " chiamato da: " + UnityEngine.StackTraceUtility.ExtractStackTrace());

        if (numeroAzioniCompletate >= numeroAzioniTotali)
        {
            Debug.Log("✔ Tutte le azioni correttive completate. Completo task fase 3.");
            ChecklistManager.instance.CompletaTask(2);
            GameManager.instance.CompletaFase();
        }
    }

}
