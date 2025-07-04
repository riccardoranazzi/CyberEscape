using UnityEngine;

public class Fase1UIManager : MonoBehaviour
{
    public GameObject panelMailList;
    public GameObject panelMailDetails;

    public static Fase1UIManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        panelMailList.SetActive(false);
        panelMailDetails.SetActive(false);
    }

    public void OpenMailList()
    {
        panelMailList.SetActive(true);
        panelMailDetails.SetActive(false);
    }

    public void OpenMailDetails()
    {
        panelMailList.SetActive(false);
        panelMailDetails.SetActive(true);
    }

    public void CloseMailDetails()
    {
        panelMailDetails.SetActive(false);
        panelMailList.SetActive(true);
    }

    public void CloseMailList()
    {
        panelMailList.SetActive(false);
    }

  

}
