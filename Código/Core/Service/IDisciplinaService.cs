using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;
namespace Core.Service
{
    public interface IDisciplinaService
    {
        int Inserir(Disciplina disciplina);
        void Editar(Disciplina disciplina);
        IEnumerable<Disciplina> ObterPorNome(string nome);
        IEnumerable<Disciplina> ObterTodos();
        void Remover(int idDisciplina);
        Disciplina Obter(int idDisciplina);

    }
}
