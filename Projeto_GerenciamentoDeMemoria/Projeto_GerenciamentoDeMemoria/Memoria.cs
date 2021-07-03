using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto_GerenciamentoDeMemoria
{
    class Memoria
    {
        private int offset, tamanho;
        private List<Bloco> blocos = new List<Bloco>();

        public Memoria()
        {
        }

        public Memoria(int offset, int tamanho, List<Bloco> blocos)
        {
            this.offset = offset;
            this.tamanho = tamanho;
            this.blocos = blocos;
        }

        public int Offset { get => offset; set => offset = value; }
        public int Tamanho { get => tamanho; set => tamanho = value; }
        internal List<Bloco> Blocos { get => blocos; set => blocos = value; }
        public int BlocosTodosAcessados()
        {
            int estaoAcessados = 0;
            for (int i = 0; i < this.Blocos.Count; i++)
            {
                if (this.Blocos[i].Acessado == 1)
                {
                    estaoAcessados++;
                }
            }

            if (estaoAcessados == this.Blocos.Count)
                return 1;
            else
                return 0;
        }
        public void SetarMemoria(int qtdBlocos)
        {
            //SETAR BLOCOS
            for (int i = 0; i < qtdBlocos; i++)
            {
                Bloco b = new Bloco(i, 0, -1);

                for (int j = 0; j <= this.offset; j++)
                {
                    Endereco end = new Endereco(j, 0);
                    b.Enderecos.Add(end);
                }
                this.blocos.Add(b);
            }
        }
        public String ExibirMemoria()
        {
            String text = "";
            text += "BLOCOS:           " + Environment.NewLine;
            //Console.WriteLine("");
            for (int i = 0; i < this.blocos.Count; i++)
            {
                //Console.WriteLine("\nBLOCO: " + this.blocos[i].Id + "\n");
                //Console.WriteLine("ATIVO: " + this.blocos[i].Acessado + " - );
                //Console.WriteLine("--------------------------------------");
                text += Environment.NewLine + "PÁGINA: " + this.blocos[i].IdPag + " | ACESSADO: " + this.blocos[i].Acessado;
                
                text += Environment.NewLine + Environment.NewLine + this.blocos[i].Id + ": ";
                //Console.Write("");
                for (int j = 0; j < this.blocos[i].Enderecos.Count; j++)
                {
                    if (this.blocos[i].Enderecos[j].Acessado == 1)
                    {
                        text += " 0 ";
                        //Console.Write("");
                    }
                    else
                    {
                        text += " * ";
                        //Console.Write("");
                    }
                }
                text += "--------------------------------------";
                text += Environment.NewLine;
                //Console.WriteLine("");
            }
            return text;
        }
    }
}
