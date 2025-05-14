using UnityEngine;

public class ExitTrigger : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && gameManager.IsGameCompleted())
        {
            Debug.Log("Uscita raggiunta! Gioco completato.");
            gameManager.EndGame();
        }
    }
}