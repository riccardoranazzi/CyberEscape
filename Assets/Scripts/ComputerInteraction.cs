using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public Transform player;
    public GameObject interactionMessage;
    public GameObject puntatore;
    public GameObject uiPCMain; // UI principale PC
    public GameObject[] panelsPCDisplay; // array panel per fasi

    private bool isNear = false;
    public bool isUsing = false;

    private CharacterController controller;
    private PlayerMovement movementScript;
    private MouseLook cameraLookScript;

    void Start()
    {
        puntatore.SetActive(true);
        controller = player.GetComponent<CharacterController>();
        movementScript = player.GetComponent<PlayerMovement>();
        cameraLookScript = player.GetComponentInChildren<MouseLook>();

        interactionMessage.SetActive(false);
        uiPCMain.SetActive(false); // UI PC spenta all'avvio

        // Disattiva tutti i panel fasi all'avvio
        foreach (GameObject panel in panelsPCDisplay)
            panel.SetActive(false);
    }

    void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.E))
        {
            if (!isUsing)
                ActivateComputer();
            else
                DeactivateComputer();
        }
    }

    public void AggiornaUIFaseAttuale()
    {
        // Disattiva tutti i panels
        foreach (GameObject panel in panelsPCDisplay)
            panel.SetActive(false);

        // Attiva panel della fase attuale
        int faseIndex = (int)GameManager.instance.faseAttuale;
        panelsPCDisplay[faseIndex].SetActive(true);

        Debug.Log("✔ UI PC aggiornata alla nuova fase: " + GameManager.instance.faseAttuale);
    }

    void ActivateComputer()
    {
        isUsing = true;

        if (controller != null)
            controller.enabled = false;

        puntatore.SetActive(false);
        movementScript.enabled = false;
        cameraLookScript.enabled = false;

        uiPCMain.SetActive(true); // attiva UI PC principale
        GameManager.instance.MostraUIFaseAttuale(); // mostra UI fase attuale

        // Attiva il Panel_PC_Display corretto in base alla fase attuale
        int faseIndex = (int)GameManager.instance.faseAttuale;
        panelsPCDisplay[faseIndex].SetActive(true);

        interactionMessage.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Debug.Log("✔ Computer attivato");
    }


    void DeactivateComputer()
    {
        isUsing = false;

        if (controller != null)
            controller.enabled = true;

        puntatore.SetActive(true);
        movementScript.enabled = true;
        cameraLookScript.enabled = true;

        foreach (GameObject panel in panelsPCDisplay)
            panel.SetActive(false);

        uiPCMain.SetActive(false); // disattiva UI_PC_Main

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Debug.Log("✔ Computer disattivato");
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            interactionMessage.SetActive(false);

            if (isUsing)
                DeactivateComputer();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isUsing)
        {
            isNear = true;
            interactionMessage.SetActive(true);
            Debug.Log("✔ Giocatore vicino al computer");
        }
    }

}
