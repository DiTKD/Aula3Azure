using System.Collections.Generic;
using System.Threading.Tasks;
using Lojinha.Core.Models;

namespace Lojinha.Core.Services
{
    public interface ICarrinhoServices
    {
        void Limpar(string usuario);
        void Salvar(string usuario, Carrinho carrinho);
        Carrinho Obter(string usuario);


    }
}