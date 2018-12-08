using Lojinha.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lojinha.Controllers
{
    [Authorize]
    public class CarrinhoController: Controller
    {

        private readonly IProdutoServices _produtoServices;
        private readonly ICarrinhoServices _carrinhoService;
        public CarrinhoController(IProdutoServices produtoServices, ICarrinhoServices carrinhoService)
        {
            _produtoServices = produtoServices;
            _carrinhoService = carrinhoService;
        }

        public async Task<IActionResult> Add(string id)
        {
            var usuario = HttpContext.User.Identity.Name;
            var carrinho = _carrinhoService.Obter(usuario);
            carrinho.Add(await _produtoServices.ObterProduto(id));

            _carrinhoService.Salvar(usuario, carrinho);

            return PartialView("Index", carrinho);
        }

        public IActionResult Finalizar(string id)
        {
            var usuario = HttpContext.User.Identity.Name;
            var carrinho = _carrinhoService.Obter(usuario);

            //TODO: Inserir Queue

             _carrinhoService.Limpar(usuario);

            return View(carrinho);
        }
    }
}
