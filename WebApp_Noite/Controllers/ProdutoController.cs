﻿using Microsoft.AspNetCore.Mvc;
using WebApp_Noite.Models;

namespace WebApp_Noite.Controllers
{
    public class ProdutoController : Controller
    {
        public static List<ProdutoModel> db_produto = new List<ProdutoModel>();

        public IActionResult Lista(string filtro, string busca)
        {
            if (string.IsNullOrEmpty(busca))
            {
                return View(db_produto);

            }
            else
            {
                switch (filtro)
                {
                    case "id":
                        return View(db_produto.Where(a => a.Id.ToString() == busca).ToList());
                        break;

                    case "nome":
                        return View(db_produto.Where(a => a.Nome.Contains (busca)).ToList());
                        break;

                    case "qtd":
                        return View(db_produto.Where(a => a.QtdEstoque.ToString() == busca).ToList());
                        break;

                    default:
                        return View(
                        db_produto.Where(a => a.Id.ToString() == busca
                        ||
                        a.Nome.Contains(busca)
                        ||
                        a.QtdEstoque.ToString() == busca)
                        );
                        break;
                }
            }
        }

        public IActionResult Cadastrar()
        {
            ProdutoModel model = new ProdutoModel();
            return View(model);
        }

        public IActionResult SalvarDados(ProdutoModel produto)
        {
            if (produto.Id == 0)
            {
                Random rand = new Random();
                produto.Id = rand.Next(1, 999);
                db_produto.Add(produto);
            }
            else
            {
                int item = db_produto.FindIndex(a => a.Id == produto.Id);
                db_produto[item] = produto;
            }
            return RedirectToAction("Lista");
        }

        public IActionResult Excluir(int id)
        {
            ProdutoModel item = db_produto.Find(a => a.Id == id);
            if (item != null)
            {
                db_produto.Remove(item);
            }
            return RedirectToAction("Lista");

        }

        public IActionResult Editar(int id)
        {
            ProdutoModel item = db_produto.Find(cliente => cliente.Id == id);
            if (item != null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction("Lista");
            }
        }
    }
}