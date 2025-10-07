using Kernel.Domain.Model.ValueObjects;

namespace Empresa.Churras.Domain.Model.ValueObjects;

public class Endereco : ValueObject
{
    public string? Cep { get; set; }
    public string? Logradouro { get; set; }
    public string? Bairro { get; set; }
    public string? Complemento { get; set; }
    public int Número { get; set; }
    public string? Estado { get; set; }
    public string? Cidade { get; set; }
    public Coordenadas? Coordenadas { get; set; }

}


