using System.ComponentModel;

namespace Empresa.Churras.Domain.Model.Enums;

public enum TipoEvento
{
    [Description("Não tem na lista")]
    Outros = 0,

    Churras = 1,

    Pizza = 2,

    Lanche = 3
}
