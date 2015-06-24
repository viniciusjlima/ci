using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aluno.Entity;

namespace Aluno.Models
{
    public class AlunoModel
    {
        private AlunoEntities db = new AlunoEntities();

        public List<aluno> todosAlunos()
        {
            var lista = from a in db.Aluno
                        select a;
            return lista.ToList();
        }

        public string adicionarAluno(aluno a)
        {
            string erro = null;
            try
            {
                db.Aluno.AddObject(a);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }
        public aluno obterAluno(int idAluno)
        {
            var lista = from a in db.Aluno
                        where a.IdAluno == idAluno
                        select a;
            return lista.ToList().FirstOrDefault();
        }
        public List<aluno> listarAlunos(string pesquisa)
        {
            var lista = from a in db.Aluno
                        where a.Nome.Contains(pesquisa)
                        select a;
            return lista.ToList();
        }

        public string editarAluno(aluno a)
        {
            string erro = null;
            try
            {
                if (a.EntityState == System.Data.EntityState.Detached)
                {
                    db.Aluno.Attach(a);
                }
                db.ObjectStateManager.ChangeObjectState(a, System.Data.EntityState.Modified);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }

        public string excluirAluno(aluno a)
        {
            string erro = null;
            try
            {
                db.Aluno.DeleteObject(a);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            return erro;
        }
        public string validarAluno(aluno a)
        {
            if (a.Nome == null || a.Nome == "")
            {
                return "O nome não pode ser vazio!";
            }
            if (a.CPF == null || a.CPF.Length > 11)
            {
                return "CPF inválido";
            }
            if (a.Matricula == null || a.Matricula == "")
            {
                return "Matricula Invalida";
            }
            return null;
        }
    }
}