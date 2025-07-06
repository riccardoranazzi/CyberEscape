public class ChecklistItem
{
    public int fase;
    public string descrizione;
    public bool completato;



    public ChecklistItem(int fase, string descrizione)
    {
        this.fase = fase;
        this.descrizione = descrizione;
        this.completato = false;
    }
}
