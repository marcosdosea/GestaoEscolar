using System;
using System.Collections.Generic;
using System.Text;
using Core.DTO;

namespace Core.Service
{
    public interface IAlunoService
    {
        void Editar(Aluno aluno);
        int Inserir(Aluno aluno);
        Aluno Obter(int idAluno);
        IEnumerable<Aluno> ObterPorNome(string nome);
        IEnumerable<Aluno> ObterTodos();
        void Remover(int idAluno);
        IEnumerable<AlunoDTO> ObterPorNomeOrdenadoDescending(string nome);
    }
}
