using Empresa.Churras.Domain.Model.Entities;

namespace Empresa.Churras.Tests.Entities;

[TestClass]
public class EventoTest
{
    [TestMethod]
    public void ConfirmarPresenca_Test()
    {
        var colega = new Colega
        {
            Key = 1,
            Nome = "Caique"
        };

        var evento = new Evento { Nome = "Churras na casa do Ary" };

        evento.ConfirmarPresenca(colega);

        var  confirmacao =  evento.ColegasConfirmaram.FirstOrDefault(x=> x.ColegaNome == "Caique");

        Assert.IsNotNull(confirmacao, "Não encontrou 'Caique' no nome confirmação.");
        Assert.AreEqual(colega.Key, confirmacao.ColegaKey, $"Confirmação não é do colega com o Id {colega.Key}");

        
    }

    [TestMethod]
    public void CancelarPresenca_Test()
    {
        var colega = new Colega
        {
            Key = 1,
            Nome = "Caique"
        };

        var evento = new Evento { Nome = "Churras na casa do Ary" };

        evento.ConfirmarPresenca(colega);

        evento.CancelarPresenca(colega);

        var confirmado = evento.ColegasConfirmaram.FirstOrDefault(x=>x.ColegaNome == "Caique");

        Assert.IsNull(confirmado, "Caique continua na lista de presença");
        
    }
}
