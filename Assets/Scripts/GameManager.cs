using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject exitMessageUI;
    public GameObject exitTrigger;

    private bool gameCompleted = false;
    public void ShowExitMessage()

    {
        gameCompleted = true;
        exitMessageUI.SetActive(true);
        exitTrigger.SetActive(true);
    }

    public bool IsGameCompleted()
    {
        return gameCompleted;
    }

    public void EndGame()

    {
        Debug.Log("Fine del gioco!");
    }
}
