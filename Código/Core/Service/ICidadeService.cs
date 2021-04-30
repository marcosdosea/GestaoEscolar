using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface ICidadeService
    {
        int Inserir(Cidade cidade);
        void Editar(Cidade cidade);
        IEnumerable<Cidade> ObterPorCodIBGE(int codigo);
        IEnumerable<Cidade> ObterPorNome(string nome);
        IEnumerable<Cidade> ObterPorEstado(string nome);
        IEnumerable<Cidade> ObterTodos();
        void Remover(int idCidade);
        Cidade Obter(int idCidade);
    }
}
