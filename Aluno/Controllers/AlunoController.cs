using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aluno.Entity;
using Aluno.Models;
using Aluno.ViewModels;

namespace Aluno.Controllers
{
    public class AlunoController : Controller
    {
        private AlunoModel alunoModel = new AlunoModel();

        public ActionResult Index()
        {
            AlunoViewModel vm = new AlunoViewModel();
            vm.alunos = alunoModel.todosAlunos();
            return View(vm);
		//testeJenkins
        }
        public PartialViewResult List(string a)
        {
            var alunos = alunoModel.listarAlunos(a);
            return PartialView(alunos);
        }
        public PartialViewResult Edit(int id)
        {
            aluno a = new aluno();
            if (id != 0)
            {
                a = alunoModel.obterAluno(id);
            }
            return PartialView(a);
        }
        [HttpPost]
        public ActionResult Edit(aluno a)
        {
            string erro = null;
            if (a.IdAluno == 0)
                erro = alunoModel.adicionarAluno(a);
            else
                erro = alunoModel.editarAluno(a);
            if (erro == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Erro = erro;
                return View(a);
            }
        }
        public ActionResult Delete(int id)
        {
            aluno a = alunoModel.obterAluno(id);
            alunoModel.excluirAluno(a);
            return RedirectToAction("Index");
        }

    }
}
