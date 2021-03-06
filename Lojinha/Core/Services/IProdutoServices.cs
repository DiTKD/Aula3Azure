﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Lojinha.Core.Models;

namespace Lojinha.Core.Services
{
    public interface IProdutoServices
    {
        Task<List<Produto>> ObterProdutos();
        void Add(Produto produto);
        Task<Produto> ObterProduto(string id);
    }
}