namespace ProEventos.Domain;

public class Evento
{
    public int Id { get; set; }
    public String Local { get; set; }
    public DateTime? DataEvento{ get; set; }
    public String Tema{ get; set; }
    public int QtdPessoas { get; set; }
    public String ImageUrl { get; set; }
    public String Telefone { get; set; }
    public String Email { get; set; }
    public IEnumerable<Lote> Lotes { get; set; }
    public IEnumerable<RedeSocial> RedesSociais { get; set; }
    public IEnumerable<PalestranteEvento> PalestranteEventos { get; set; }
}
