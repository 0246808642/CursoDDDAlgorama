using Empresa.Churras.Domain.Model.Enums;
using Empresa.Churras.Domain.Model.ValueObjects;
using Kernel.Domain.Model.Entities;

namespace Empresa.Churras.Domain.Model.Entities;

public class Evento : EntityKeySeq, IAggregateRoot
{
    public string? Nome { get; set; }
    public long DonoDaCasaKey { get; set; }
    public Colega? DonoDaCasa { get; set; }
    public TipoEvento Tipo { get; set; }
    public DateTime Dia { get; set; }
    public Periodo? Periodo { get; set; }
    public IList<EventoColegaConfirmado>? ColegasConfirmaram { get; set; } = new List<EventoColegaConfirmado>();

    public void CancelarPresenca(Colega colega)
    {
        if (ColegasConfirmaram == null)
        {
            return;
        }

        var confirmacao = ColegasConfirmaram.FirstOrDefault(x=> x.ColegaKey == colega.Key);
        if (confirmacao != null) 
            ColegasConfirmaram.Remove(confirmacao);
                
    }

    public void ConfirmarPresenca(Colega colega)
    {
        if(ColegasConfirmaram == null)
            ColegasConfirmaram = new List<EventoColegaConfirmado>();

       
        ColegasConfirmaram.Add(new EventoColegaConfirmado {ColegaKey= colega.Key,ColegaNome = colega.Nome});
    }
}
