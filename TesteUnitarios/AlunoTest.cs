using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aluno;
using Aluno.Entity;
using Aluno.Models;
using Aluno.Controllers;


namespace TesteUnitarios
{
    [TestClass]
    public class AlunoTest
    {
        public aluno aluno1, aluno2;

        [TestInitialize]
        public void InicializarTest()
        {
           aluno1 = new aluno()
            {
                IdAluno = 1,
                Nome = "AlunoTeste1",
                CPF = "11111111111",
                Matricula = "11111111"
            };
        }

        //teste2repositoriossss
        [TestMethod]
        public void Garantir_Que_2_Alunos_Sao_Iguais_Quando_Tem_Mesmo_Id()
        {
            aluno2 = new aluno()
            {
                IdAluno = 1,
                Nome = "AlunoTeste2",
                CPF = "22222222222",
                Matricula = "22222222"
            };
            Assert.AreEqual(aluno1.IdAluno, aluno2.IdAluno);
        }

        [TestMethod]
        public void Garantir_Que_2_Alunos_Sao_Iguais_Quando_Tem_Mesmo_Login()
        {
            aluno2 = new aluno()
            {
                IdAluno = 2,
                Nome = "AlunoTeste1",
                CPF = "22222222222",
                Matricula = "22222222"
            };
            Assert.AreEqual(aluno1.Nome, aluno2.Nome);
        }

        [TestMethod]
        public void Garantir_Que_2_Alunos_Sao_Iguais_Quando_Tem_Mesmo_CPF()
        {
            aluno2 = new aluno()
            {
                IdAluno = 2,
                Nome = "AlunoTeste2",
                CPF = "11111111111",
                Matricula = "22222222"
            };

            Assert.AreEqual(aluno1.CPF, aluno2.CPF);
        }
       
    }
}
