[System.Serializable]
public class ChecklistItem
{
    public string descrizione;
    public bool completato;

    public ChecklistItem(string descrizione)
    {
        this.descrizione = descrizione;
        this.completato = false;
    }
}
