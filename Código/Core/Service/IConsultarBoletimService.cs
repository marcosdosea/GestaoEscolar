using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IConsultarBoletimService
    {
        IEnumerable<Avaliacao> ObterBoletim(int idAluno);

        IEnumerable<Avaliacao> ObterBoletim(int idAluno, int idTurma);



    }
}
