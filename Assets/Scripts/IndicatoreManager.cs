using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IndicatorManager : MonoBehaviour
{
    public static IndicatorManager instance;

    public TMP_Text punteggioText;
    public int punteggio = 100;
    public Image indicatorImage;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        AggiornaIndicator();
    }

    public void RiduciValore(int amount)
    {
        punteggio -= 25;
        if (punteggio < 0)
            punteggio = 0;


        AggiornaIndicator();
    }

    void AggiornaIndicator()
    {
        if (punteggio != null)
            punteggioText.text = punteggio + "%";

        if (indicatorImage != null)
        {
            if (punteggio > 50)
                indicatorImage.color = Color.green;
            else if (punteggio > 25)
                indicatorImage.color = Color.yellow;
            else
                indicatorImage.color = Color.red;
        }
    }

}
