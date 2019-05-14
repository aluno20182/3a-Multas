using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Multas.Models;

namespace Multas.Controllers
{
    public class AgentesController : Controller
    {
        private MultasDB db = new MultasDB();

        // GET: Agentes
        public ActionResult Index()
        {
            return View(db.Agentes.ToList());
        }

        // GET: Agentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

        // GET: Agentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nome,Esquadra,Fotografia")] Agentes agentes, HttpPostedFileBase fotografia)
        {
            if (ModelState.IsValid)
            {
                db.Agentes.Add(agentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agentes);
        }

        // GET: Agentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agentes agentes = db.Agentes.Find(id);
            if (agentes == null)
            {
                return HttpNotFound();
            }
            return View(agentes);
        }

 

        // GET: Agentes/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int? id)
        {

            //o ID do agente não foi fornecido
            //não é possivel procurar o Agente
            // o que devo fazer?
            if (id == null)
            {
                ///opção por defeito do 'template'
                ///return new HttpSatusCodeResult(HttpStatusCode.BadRequest);

                /// e ão há ID do Agente, uma de duas coisas aconteceu:
                ///     -há um erro nos links da app
                ///     -há um 'chico esperto' a fazer asneiras no URL


                //redereciono o utilizador para o ecrã inicial
                return RedirectToAction("Index");
            }

            //procurar os dados do Agente, cujo ID é fornecido
            Agentes agente = db.Agentes.Find(id);

            ///se o agente não for encontrado
            if (agente == null)
            {
                //ou há erro,
                //ou há um 'chico esperto'...

                //redereciono o utilizador para o ecrã inicial
                return RedirectToAction("Index");

            }

            //para o caso do utilizador alterar, de forma fraudulenta, os dados
            //do Agente, vamos guardá-los internamente
            //Para isso, vou guardar o valor do ID do Agente
            //  -guardar o ID do Agente num cookie cifrado
            //  -guardar o ID nume var. de sessão (quem estiver a usar o Asp .Net Core já não tem esta ferramenta...)
            //  - outras opções

            Session["IdAgente"] = agente.ID;
            Session["Metodo"] = "Agentes/Delete";

            //Envia para a View os dados do Agente em encontrado
            return View(agente);
        }

        // POST: Agentes/Delete/5
        /// <summary>
        /// concretizar a operação de remoção de um agente
        /// </summary>
        /// <param name="id">identificador do agente</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {

            if (id == null)
            {
                ///se entrei aqui, é pq há um erro
                ///não se sabe o ID do agente a remover
                return RedirectToAction("Index");
            }

            ///avaliar se o ID do agente que é fornecido
            ///é o mesmo ID do agente que foi apresentado no ecrã
            if(id!=(int)Session["IdAgente"])
            {
                //há um ataque!!
                //redirecionar para a pagina de Index
                return RedirectToAction("Index");
            }

            ///avaliar se o metodo é o que é esperado
            string operacao = "Agentes/Delete";
            if (operacao != (string)Session["Metodo"])
            {
                //há um ataque!!
                //redirecionar para a pagina de Index
                return RedirectToAction("Index");
            }

            //procurar dados do Agente na BD
            Agentes agente = db.Agentes.Find(id);

            if (agente == null)
            {
                //não foi possivel entcontrar o Agente
                return RedirectToAction("Index");
            }

            try
            {
                db.Agentes.Remove(agente);
                db.SaveChanges();
            }
            catch (Exception)
            {
                // captura a excessão e processa o código para resolver o problema
                // pode haver mais do que um 'catch' associado a um 'try'

                // enviar mensagem de erro para o utilizador
                ModelState.AddModelError("", "Ocorreu um erro com a eliminação do Agente "
                                            + agente.Nome +
                                            ". Provavelmente relacionado com o facto do " +
                                            "agente ter emitido multas...");
                // devolver os dados do Agente à View
                return View(agente);
            }

            // redireciona o interface para a view INDEX associada ao controller Agentes
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}