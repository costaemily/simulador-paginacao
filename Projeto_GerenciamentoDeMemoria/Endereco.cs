using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_GerenciamentoDeMemoria
{
    class Endereco
    {
        private int id, acessado;

        public Endereco()
        {
        }

        public Endereco(int id, int acessado)
        {
            this.id = id;
            this.acessado = acessado;
        }

        public int Id { get => id; set => id = value; }
        public int Acessado { get => acessado; set => acessado = value; }
    }
}
