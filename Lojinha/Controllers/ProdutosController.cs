using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lojinha.Core.Models;
using Lojinha.Core.Services;
using Lojinha.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lojinha.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IProdutoServices _produtoServices;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoServices produtoServices, IMapper mapper)
        {
            _produtoServices = produtoServices;
            _mapper = mapper;
        }

        public IActionResult Create()
        {            
            var produto = new Produto
            {
                Id = 3332,
                Nome = "Iphone XS MAX II",
                Categoria = new Categoria
                {
                    Id = 1,
                    Nome = "Celulares"
                },
                Descricao = "Iphone XS MAX II 128GB",
                Fabricante = new Fabricante
                {
                    Id = 1,
                    Nome = "Apple"
                },
                Preco = 5500m,
                Tags = new[] {"iphone", "celular", "apple"},
                ImagemPrincipalUrl = "https://icdn2.digitaltrends.com/image/iphone-xs-max-review-1-1500x994.jpg"
            };
            //_azureStorage.AddProduto(produto);
            _produtoServices.Add(produto);

            return Content("OK");
        }

        public async Task<IActionResult> List()
        {
            var produtos = await _produtoServices.ObterProdutos();
            var vm = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return View(vm);
        }

        public async Task<IActionResult> Details(string id)
        {
            var produto = await _produtoServices.ObterProduto(id);
            var vm = _mapper.Map<ProdutoViewModel>(produto);
            return View(vm);
        }
    }
}
