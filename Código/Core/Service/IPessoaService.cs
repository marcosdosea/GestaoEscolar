﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Service
{
    public interface IPessoaService
    {
        List<Pessoa> BuscarPessoas();
        void InserirPessoa(Pessoa pessoa);
    }
}
