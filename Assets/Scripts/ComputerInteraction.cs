using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public Transform player;
    public GameObject interactionMessage;
    public GameObject puntatore;
    public GameObject[] panelsPCDisplay; 


    private bool isNear = false;
    private bool isUsing = false;

    private CharacterController controller;
    private PlayerMovement movementScript;
    private MouseLook cameraLookScript;

    void Start()
    {
        puntatore.SetActive(true);
        controller = player.GetComponent<CharacterController>();
        movementScript = player.GetComponent<PlayerMovement>();
        interactionMessage.SetActive(false);
        cameraLookScript = player.GetComponentInChildren<MouseLook>();
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

    void ActivateComputer()
    {
        isUsing = true;

        if (controller != null)
            controller.enabled = false;

        puntatore.SetActive(false);
        movementScript.enabled = false;

        GameManager.instance.MostraUIFaseAttuale(); // mostra UI fase

        // Attiva il Panel_PC_Display corretto in base alla fase attuale
        int faseIndex = (int)GameManager.instance.faseAttuale;
        panelsPCDisplay[faseIndex].SetActive(true);

        interactionMessage.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        cameraLookScript.enabled = false;

    }


    void DeactivateComputer()
    {
        isUsing = false;

        if (controller != null)
            controller.enabled = true;

        puntatore.SetActive(true);
        movementScript.enabled = true;

        GameManager.instance.NascondiTutteUIFasi();

        // Disattiva tutti i panel display
        foreach (GameObject panel in panelsPCDisplay)
        {
            panel.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraLookScript.enabled = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isUsing)
        {
            isNear = true;
            interactionMessage.SetActive(true);
            Debug.Log("Giocatore vicino al computer");
        }
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
}
