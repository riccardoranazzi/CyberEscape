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

    // UI Panels
    public GameObject panelFase1_UI;
    public GameObject panelFase2_UI;
    public GameObject panelFase3_UI;
    public GameObject panelFase4_UI;
    public GameObject panelFase5_UI;
    public GameObject panelGameOver_UI;

    public GameObject panelPCFase1_UI;
    public GameObject panelPCFase2_UI;
    public GameObject panelPCFase3_UI;
    public GameObject panelPCFase4_UI;
    public GameObject panelPCFase5_UI;


    // Fase Managers
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
                panelFase1_UI.SetActive(true);
                break;
            case Fase.Segnalazione:
                panelFase2_UI.SetActive(true);
                break;
            case Fase.AzioniCorrettive:
                panelFase3_UI.SetActive(true);
                break;
            case Fase.Ripristino:
                panelFase4_UI.SetActive(true);
                break;
            case Fase.Prevenzione:
                panelFase5_UI.SetActive(true);
                break;
            case Fase.GameOver:
                panelGameOver_UI.SetActive(true);
                break;
        }
    }

    public void NascondiTutteUIFasi()
    {
        panelFase1_UI.SetActive(false);
        panelFase2_UI.SetActive(false);
        panelFase3_UI.SetActive(false);
        panelFase4_UI.SetActive(false);
        panelFase5_UI.SetActive(false);
        panelGameOver_UI.SetActive(false);
    }


    void DisattivaTutteLeFasi()
    {
        // UI Panels
        panelFase1_UI.SetActive(false);
        panelFase2_UI.SetActive(false);
        panelFase3_UI.SetActive(false);
        panelFase4_UI.SetActive(false);
        panelFase5_UI.SetActive(false);
        panelGameOver_UI.SetActive(false);

        panelPCFase1_UI.SetActive(false);
        panelPCFase2_UI.SetActive(false);
        panelPCFase4_UI.SetActive(false);
        panelPCFase5_UI.SetActive(false);

        // Fase Managers
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

        panelFase1_UI.SetActive(true);
        fase1Manager.SetActive(true);

        Debug.Log("✔ Fase 1: Smistamento avviata.");
    }

    public void AvviaFase2()
    {
        DisattivaTutteLeFasi();
        faseAttuale = Fase.Segnalazione;

        panelFase2_UI.SetActive(true);
        fase2Manager.SetActive(true);

        Debug.Log("✔ Fase 2: Segnalazione avviata.");
    }

    public void AvviaFase3()
    {
        DisattivaTutteLeFasi();
        faseAttuale = Fase.AzioniCorrettive;

        panelFase3_UI.SetActive(true);
        fase3Manager.SetActive(true);

        Debug.Log("✔ Fase 3: Azioni correttive avviata.");
    }

    public void AvviaFase4()
    {
        DisattivaTutteLeFasi();
        faseAttuale = Fase.Ripristino;

        panelFase4_UI.SetActive(true);
        fase4Manager.SetActive(true);

        Debug.Log("✔ Fase 4: Ripristino avviato.");
    }

    public void AvviaFase5()
    {
        DisattivaTutteLeFasi();
        faseAttuale = Fase.Prevenzione;

        panelFase5_UI.SetActive(true);
        fase5Manager.SetActive(true);

        Debug.Log("✔ Fase 5: Implementazione tecnologie preventive avviata.");
    }

    public void AvviaGameOver()
    {
        DisattivaTutteLeFasi();
        faseAttuale = Fase.GameOver;

        panelGameOver_UI.SetActive(true);

        Debug.Log("✔ GAME OVER o Fine partita.");
    }

    public void CompletaFase()
    {
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
    }
}
