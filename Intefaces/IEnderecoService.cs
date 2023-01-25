using IntegraBrasilApi.Dtos;

namespace IntegraBrasilApi.Intefaces
{
    public interface IEnderecoService
    {
         Task<ResponseGenerico<EnderecoResponse>> BuscarEndereco(string cep);
    }
}