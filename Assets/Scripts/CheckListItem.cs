public class ChecklistItem
{
    public int fase;
    public string descrizione;
    public bool completato;

    public int progressiAttuali;
    public int progressiTotali;

    public ChecklistItem(int fase, string descrizione, int progressiTotali = 0)
    {
        this.fase = fase;
        this.descrizione = descrizione;
        this.completato = false;

        this.progressiAttuali = 0;
        this.progressiTotali = progressiTotali;
    }
}
