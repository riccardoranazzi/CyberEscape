using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] livelliLineari; // Tutorial, Intro, Livello3, Livello4

    public GameObject livello1Backup;
    public GameObject livello2ConBackup;
    public GameObject livello2NoBackup;


    private int step = 0;

    private bool backupEffettuato = false;

    public GameManager gameManager;

    void Start()
    {
        DisattivaTutti();
        livelliLineari[step].SetActive(true); // Tutorial
    }

    public void Prossimo()
    {
        livelliLineari[step].SetActive(false);
        step++;

        if (step < livelliLineari.Length)
        {
            livelliLineari[step].SetActive(true);
        }
        else
        {
            // Hai finito la parte lineare, passa alla biforcazione
            if (backupEffettuato)
            {
                livello1Backup.SetActive(true);
            }
            else
            {
                livello2NoBackup.SetActive(true);
            }
        }
    }

    public void RegistraBackup(bool fatto)
    {
        backupEffettuato = fatto;
    }

    public void CompletaPercorsoParallelo()
    {
        // Disattiva percorsi alternativi
        livello1Backup.SetActive(false);
        livello2NoBackup.SetActive(false);
        livello2ConBackup.SetActive(false);

        // Attiva Livello3 e prosegui con la sequenza
        livelliLineari[step].SetActive(true);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        // Mostra pannello o carica scena
    }

    private void DisattivaTutti()
    {
        foreach (var livello in livelliLineari)
            livello.SetActive(false);

        livello1Backup.SetActive(false);
        livello2NoBackup.SetActive(false);
        livello2ConBackup.SetActive(false);
    }
}
