using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public Transform player;
    public Transform computerViewPoint;
    public GameObject computerUI;
    public GameObject interactionMessage;
    public GameObject playerCamera;


    private bool isNear = false;
    private bool isUsing = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    private CharacterController controller;
    private PlayerMovement movementScript;
    private MouseLook cameraLookScript;


    void Start()
    {
        controller = player.GetComponent<CharacterController>();
        interactionMessage.SetActive(false);
        movementScript = player.GetComponent<PlayerMovement>();
        cameraLookScript = playerCamera.GetComponent<MouseLook>();
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
        originalPosition = player.position;
        originalRotation = player.rotation;

        // Ferma il movimento
        if (controller != null)
            controller.enabled = false;

        movementScript.enabled = false; //disattivo movimento
        cameraLookScript.enabled = false; //disattivo movimento visuale
        player.position = computerViewPoint.position;
        player.rotation = computerViewPoint.rotation;


        //computerUI.SetActive(true);
        interactionMessage.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void DeactivateComputer()
    {
        isUsing = false;
        player.position = originalPosition;
        player.rotation = originalRotation;

        if (controller != null)
            controller.enabled = true;

        //computerUI.SetActive(false);
        cameraLookScript.enabled = true; //riattivo il movimento visuale
        movementScript.enabled = true; //riattivo movimento
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
            Debug.Log("Giocatore allontanato dal computer");

            if (isUsing)
                DeactivateComputer();
        }
    }
}
