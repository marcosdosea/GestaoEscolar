using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IEscolaService
    {
        void Editar(Escola escola);
        int Inserir(Escola escola);
        Escola Obter(int idEscola);
        IEnumerable<Escola> ObterPorNome(string nome);
        IEnumerable<Escola> ObterTodos();
        void Remover(int idEscola);
    }
}
