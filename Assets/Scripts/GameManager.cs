using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum Fase
    {
        Smistamento,
        Segnalazione,
        AzioniCorrettive,
        Ripristino,
        Prevenzione,
        GameOver
    }

    public Fase faseAttuale;

    // UI Panels fasi
    public GameObject panelPCFase1_Display;
    public GameObject panelPCFase2_Display;
    public GameObject panelPCFase3_Display;
    public GameObject panelPCFase4_Display;
    public GameObject panelPCFase5_Display;
    public GameObject panelGameOver_Display;

    // Managers fasi
    public GameObject fase1Manager;
    public GameObject fase2Manager;
    public GameObject fase3Manager;
    public GameObject fase4Manager;
    public GameObject fase5Manager;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        AvviaFase1();
    }

    public void MostraUIFaseAttuale()
    {
        NascondiTutteUIFasi();

        switch (faseAttuale)
        {
            case Fase.Smistamento:
                panelPCFase1_Display.SetActive(true);
                break;
            case Fase.Segnalazione:
                panelPCFase2_Display.SetActive(true);
                break;
            case Fase.AzioniCorrettive:
                panelPCFase3_Display.SetActive(true);
                break;
            case Fase.Ripristino:
                panelPCFase4_Display.SetActive(true);
                break;
            case Fase.Prevenzione:
                panelPCFase5_Display.SetActive(true);
                break;
            case Fase.GameOver:
                panelGameOver_Display.SetActive(true);
                break;
        }
    }

    public void NascondiTutteUIFasi()
    {
        panelPCFase1_Display.SetActive(false);
        panelPCFase2_Display.SetActive(false);
        panelPCFase3_Display.SetActive(false);
        panelPCFase4_Display.SetActive(false);
        panelPCFase5_Display.SetActive(false);
        panelGameOver_Display.SetActive(false);
    }

    void DisattivaTutteLeFasi()
    {
        // Disattiva UI Panels fasi
        NascondiTutteUIFasi();

        // Disattiva Managers fasi
        fase1Manager.SetActive(false);
        fase2Manager.SetActive(false);
        fase3Manager.SetActive(false);
        fase4Manager.SetActive(false);
        fase5Manager.SetActive(false);
    }

    public void AvviaFase1()
    {
        DisattivaTutteLeFasi();
        faseAttuale = Fase.Smistamento;
        panelPCFase1_Display.SetActive(true);

        fase1Manager.SetActive(true);
        Debug.Log("✔ Fase 1: Smistamento avviata.");
    }

    public void AvviaFase2()
    {


        Debug.Log("✔ AvviaFase2 chiamato");
        Debug.Log("panelPCFase2_Display: " + (panelPCFase2_Display != null));
        Debug.Log("fase2Manager: " + (fase2Manager != null));

        DisattivaTutteLeFasi();
        faseAttuale = Fase.Segnalazione;

        panelPCFase2_Display.SetActive(true);
        fase2Manager.SetActive(true);
        Debug.Log("✔ Fase 2: Segnalazione avviata.");
    }

    public void AvviaFase3()
    {
        DisattivaTutteLeFasi();
        faseAttuale = Fase.AzioniCorrettive;

        if (panelPCFase3_Display != null)
        {
            panelPCFase3_Display.SetActive(true);
            Debug.Log("✔ PanelPCFase3_Display attivato");
        }
        else
        {
            Debug.LogError("❌ panelPCFase3_Display non assegnato!");
        }

        if (fase3Manager != null)
        {
            fase3Manager.SetActive(true);
            Debug.Log("✔ Fase3Manager attivato");
        }
        else
        {
            Debug.LogError("❌ fase3Manager non assegnato!");
        }

        Debug.Log("✔ Fase 3: Azioni correttive avviata.");
    }

    public void AvviaFase4()
    {
        DisattivaTutteLeFasi();
        faseAttuale = Fase.Ripristino;
        panelPCFase4_Display.SetActive(true);
        fase4Manager.SetActive(true);
        Debug.Log("✔ Fase 4: Ripristino avviato.");
    }

    public void AvviaFase5()
    {
        DisattivaTutteLeFasi();
        faseAttuale = Fase.Prevenzione;
        panelPCFase5_Display.SetActive(true);
        fase5Manager.SetActive(true);
        Debug.Log("✔ Fase 5: Implementazione tecnologie preventive avviata.");
    }

    public void AvviaGameOver()
    {
        DisattivaTutteLeFasi();
        faseAttuale = Fase.GameOver;
     
        panelGameOver_Display.SetActive(true);
        Debug.Log("✔ GAME OVER o Fine partita.");
    }

    public void CompletaFase()
    {

        Debug.Log("✔ CompletaFase chiamato: fase attuale = " + faseAttuale);

        switch (faseAttuale)
        {
            case Fase.Smistamento:
                AvviaFase2();
                break;
            case Fase.Segnalazione:
                AvviaFase3();
                break;
            case Fase.AzioniCorrettive:
                AvviaFase4();
                break;
            case Fase.Ripristino:
                AvviaFase5();
                break;
            case Fase.Prevenzione:
                AvviaGameOver();
                break;
            case Fase.GameOver:
                Debug.Log("✔ Partita conclusa.");
                break;
        }

        ComputerInteraction computer = FindObjectOfType<ComputerInteraction>();
        if (computer != null && computer.isUsing) // Se il giocatore sta usando il PC
        {
            computer.AggiornaUIFaseAttuale();
        }
    }
}
