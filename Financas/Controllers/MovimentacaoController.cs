﻿using Financas.DAO;
using Financas.Entidades;
using Financas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Financas.Controllers
{
    [Authorize]
    public class MovimentacaoController : Controller
    {
        private MovimentacaoDAO movimentacaoDAO;
        private UsuarioDAO usuarioDAO;

        public MovimentacaoController(MovimentacaoDAO movimentacaoDAO, UsuarioDAO usuarioDao)
        {
            this.movimentacaoDAO = movimentacaoDAO;
            this.usuarioDAO = usuarioDao;
        }



        public ActionResult Index()
        {
            return View(movimentacaoDAO.Lista());
        }



        public ActionResult Form()
        {
            ViewBag.Usuarios = usuarioDAO.Lista();
            return View();
        }


        public ActionResult Adiciona(Movimentacao movimentacao) {
            if (ModelState.IsValid)
            {
                movimentacaoDAO.Adiciona(movimentacao);
                return RedirectToAction("Index");
            }
            else {

                ViewBag.Usuarios = usuarioDAO.Lista();

                return View("Form");
            
            }
            
        }

        public ActionResult MovimentacoesPorUsuario(MovimentacoesPorUsuarioModel model) 
        {

            model.Usuarios = usuarioDAO.Lista();
            model.Movimentacoes = movimentacaoDAO.BuscaPorUsuario(model.UsuarioId);


            return View(model);

        }

        public ActionResult Busca(BuscaMovimentacoesModel model) 
        {
            model.Usuarios = usuarioDAO.Lista();
            model.Movimentacoes = movimentacaoDAO.Busca(model.ValorMinimo, model.ValorMaximo,
                                                        model.DataMinima, model.DataMaxima,
                                                        model.Tipo, model.UsuarioId);
            return View(model);
        
        }


    }
}
