using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_GerenciamentoDeMemoria
{
    class Pagina
    {
        private int id, r, m, ativa, idBloco;
        private DateTime ultimoAcesso;
        public Pagina()
        {

        }

        public Pagina(int id, int r, int m, int ativa, int idBloco)
        {
            this.id = id;
            this.r = r;
            this.m = m;
            this.ativa = ativa;
            this.idBloco = idBloco;
        }

        public int Id { get => id; set => id = value; }
        public int R { get => r; set => r = value; }
        public int M { get => m; set => m = value; }
        public int Ativa { get => ativa; set => ativa = value; }
        public int IdBloco { get => idBloco; set => idBloco = value; }
        public DateTime UltimoAcesso { get => ultimoAcesso; set => ultimoAcesso = value; }
    }
}
