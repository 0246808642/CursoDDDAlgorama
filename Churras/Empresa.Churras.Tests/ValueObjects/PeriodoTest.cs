using Empresa.Churras.Domain.Model.ValueObjects;

namespace Empresa.Churras.Tests.ValueObjects;

[TestClass]
public class PeriodoTest
{
    [TestMethod]
    public void QuantoDuraEmHoras_Test()
    {
        var periodo = new Periodo
        {
            Inicio = new DateTime(2021, 08, 21, 12, 0, 0),
            Fim = new DateTime(2021, 08, 21, 18, 0, 0)
        };

        var horas = periodo.QuantoDuraEmHoras();

        Assert.AreEqual(6, horas);
    }

    [TestMethod]
    public void FaltaQuantoTempoParaComecarDays_Test()
    {
        var dtInicio = DateTime.Now.AddDays(3).AddHours(5);
        var dtFim = dtInicio.AddHours(6);

        var periodo = new Periodo
        {
            Inicio = dtInicio,
            Fim = dtFim,
        };

        var quantoFalta = periodo.QuandoFaltaParaComecar();

        Assert.AreEqual("Começa em 3 dias e 4 horas", quantoFalta);
    }

    [TestMethod]
    public void FaltaQuantoTempoParaComecarHours_Test()
    {
        var dtInicio = DateTime.Now.AddHours(5);
        var dtFim = dtInicio.AddHours(6);

        var periodo = new Periodo
        {
            Inicio = dtInicio,
            Fim = dtFim,
        };

        var quantoFalta = periodo.QuandoFaltaParaComecar();

        Assert.AreEqual("Começa em 4 horas", quantoFalta);
    }

    [TestMethod]
    public void FaltaQuantoTempoParaComecarHours_TestJaComecou()
    {
        var dtInicio = DateTime.Now.AddHours(-1);
        var dtFim = dtInicio.AddHours(6);

        var periodo = new Periodo
        {
            Inicio = dtInicio,
            Fim = dtFim,
        };

        var quantoFalta = periodo.QuandoFaltaParaComecar();

        Assert.AreEqual("Já começou!", quantoFalta);
    }
}
