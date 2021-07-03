using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_GerenciamentoDeMemoria
{
    class Bloco
    {
        private List<Endereco> enderecos = new List<Endereco>();
        private int id, acessado;
        private int idPag;

        public Bloco()
        {
        }

        public Bloco(int id, int acessado, int idPag)
        {
            this.id = id;
            this.acessado = acessado;
            this.idPag = idPag;
        }

        public int Id { get => id; set => id = value; }
        public int Acessado { get => acessado; set => acessado = value; }
        public int IdPag { get => idPag; set => idPag = value; }
        internal List<Endereco> Enderecos { get => enderecos; set => enderecos = value; }

        public void criarBloco(int offset)
        {
            for (int i = 0; i <= offset; i++)
            {
                Endereco endereco = new Endereco();
                endereco.Acessado = 0;
                endereco.Id = i;
                Enderecos.Add(endereco);

            }
            Id = -1;
            IdPag = -1;
            Acessado = 0;
        }
    }
}
