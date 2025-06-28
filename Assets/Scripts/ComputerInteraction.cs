using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public Transform player;
    public GameObject computerUI; // NewComputerUI generale
    public GameObject panelOutlook; // Panel_Outlook interno
    public GameObject interactionMessage;
    public GameObject puntatore;

    private bool isNear = false;
    private bool isUsing = false;

    private CharacterController controller;
    private PlayerMovement movementScript;
    private MouseLook cameraLookScript;

    void Start()
    {
        puntatore.SetActive(true);
        controller = player.GetComponent<CharacterController>();
        interactionMessage.SetActive(false);
        computerUI.SetActive(false);
        movementScript = player.GetComponent<PlayerMovement>();
        // cameraLookScript = playerCamera.GetComponent<MouseLook>();
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

        // Ferma il movimento
        if (controller != null)
            controller.enabled = false;

        puntatore.SetActive(false); // disattivo il puntatore HUD
        movementScript.enabled = false; // disattivo movimento player
        // cameraLookScript.enabled = false; // disattivo mouse look se usato

        computerUI.SetActive(true); // attiva l'intera NewComputerUI
        panelOutlook.SetActive(true); // mostra Panel_Outlook come prima schermata
        interactionMessage.SetActive(false); // nasconde messaggio E

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void DeactivateComputer()
    {
        isUsing = false;

        if (controller != null)
            controller.enabled = true;

        puntatore.SetActive(true); // riattivo il puntatore HUD
        movementScript.enabled = true; // riattivo movimento player
        // cameraLookScript.enabled = true; // riattivo mouse look se usato

        computerUI.SetActive(false); // disattiva l'intera NewComputerUI
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
            Debug.Log("Giocatore si è allontanato dal computer");

            if (isUsing)
                DeactivateComputer();
        }
    }
}
