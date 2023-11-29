namespace ProEventos.Domain;

public class RedeSocial
{
    public int Id { get; set; }
    public String Nome { get; set; }
    public String URL { get; set; }
    public int? EventoId { get; set; }
    public Evento Evento { get; set; }
    public int? PalestranteId { get; set; }
    public Palestrante Palestrante { get; set; }
}
