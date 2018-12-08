using Lojinha.Core.Models;
using Lojinha.Infrastructure.Redis;
using Lojinha.Infrastructure.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Core.Services
{
    public class CarrinhoServices : ICarrinhoServices
    {

        private const string _key = "rm331835";
        private readonly IRedisCache _redis;
        
        

        public CarrinhoServices(IRedisCache cache, IAzureStorage storage)
        {
            _redis = cache;
        }

        public void Limpar(string usuario)
        {
            _redis.Set($"{_key}:carrinho:{usuario}", null);
        }

        public void Salvar(string usuario, Carrinho carrinho)
        {
            _redis.Set($"{_key}:carrinho:{usuario}", JsonConvert.SerializeObject(carrinho));
        }

        public Carrinho Obter(string usuario)
        {
            var value = _redis.Get($"{_key}:carrinho:{usuario}");
            if(string.IsNullOrWhiteSpace(value))
            {
                var carrinho = new Carrinho();
                Salvar(usuario, carrinho);

                return carrinho;
            }
            return JsonConvert.DeserializeObject<Carrinho>(value);
        }


      
    }
}
