using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_GerenciamentoDeMemoria
{
    class No
    {
        private Bloco valor;
        private No prox;

        internal Bloco Valor { get => valor; set => valor = value; }
        internal No Prox { get => prox; set => prox = value; }
    }
}
