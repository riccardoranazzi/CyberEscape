using UnityEngine;

[System.Serializable]
public class Mail

{
    public int id; // numero univoco
    public string mittente;
    public string oggetto;
    public string corpo;
    public string iniziali;
    public string link;
    public bool isPhishing;
    public bool isAmbigua;

    public int punteggioCorretto;
    public int punteggioSbagliato;

    public string azione = ""; //segnalata, inoltrata/aperta, "" default
}


