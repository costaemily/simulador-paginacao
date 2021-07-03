using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_GerenciamentoDeMemoria
{
    public partial class Principal : Form
    {
        Queue<Bloco> fila = new Queue<Bloco>();
        List<Bloco> lista = new List<Bloco>();
        Memoria prin = new Memoria();
        ListaCircular l = new ListaCircular();
        TabelaDePaginas tabelap = new TabelaDePaginas();
        Memoria sec = new Memoria();
        int qtdBlocos;
        public Principal()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAlocar_Click(object sender, EventArgs e)
        {
            if((nudPagN.Value == 0) || (nudOffset.Value == 0) || (nudBlocos.Value == 0))
            {
                MessageBox.Show("POR FAVOR DIGITE AS INFORMAÇÕES DOS SEGUINTES CAMPOS: 'ENDEREÇAMENTO DE MEMÓRIA', 'OFFSET' E 'BLOCOS.'");
            }
            else
            {
                prin.Tamanho = Tamanho((int)nudPagN.Value);
                prin.Offset = Tamanho((int)nudOffset.Value);
                qtdBlocos = (int)nudBlocos.Value;

                prin.SetarMemoria(qtdBlocos);
                txtPrincipal.Text += prin.ExibirMemoria();

                sec.Tamanho = prin.Tamanho;
                sec.Offset = prin.Offset;
                sec.SetarMemoria(2 * qtdBlocos);
                txtSecundaria.Text += sec.ExibirMemoria();

                tabelap.SetarTabelaPaginas(prin);

                for (int i = 0; i < tabelap.TabelaPagina.Count; i++)
                {
                    ListViewItem item = new ListViewItem(tabelap.TabelaPagina[i].Id.ToString());
                    item.SubItems.Add(tabelap.TabelaPagina[i].Ativa.ToString());
                    item.SubItems.Add(tabelap.TabelaPagina[i].R.ToString());
                    item.SubItems.Add(tabelap.TabelaPagina[i].M.ToString());
                    item.SubItems.Add(tabelap.TabelaPagina[i].IdBloco.ToString());
                    item.SubItems.Add(tabelap.TabelaPagina[i].UltimoAcesso.ToString("HH:mm:ss"));

                    lsvTabelaPaginas.Items.Add(item);
                }
            } 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        static int Tamanho(int num)
        {
            double soma = 0;
            for (int i = 0; i < num; i++)
            {
                soma += Math.Pow(2, i);
            }
            return (int)soma;
        }
        static void Relogio(Memoria prin, Memoria sec, int indexPag, int indexDeslo, ListaCircular l, TabelaDePaginas tabelap)
        {
            bool comSO = false;
            if (sec.Blocos.Count != 0)
            {
                for (int i = 0; i < sec.Blocos.Count; i++)
                {
                    if (sec.Blocos[i].IdPag == indexPag)
                    {
                        //ESCOLHENDO O BLOCO QUE VAI SER SUBSTITUIDO
                        No aux = l.Ult.Prox;
                        while (tabelap.TabelaPagina[aux.Valor.IdPag].R != 0)
                        {
                            tabelap.TabelaPagina[aux.Valor.IdPag].R = 0;
                            l.Ult = aux;
                            aux = aux.Prox;
                        }
                        No aux1 = aux;
                        Bloco b = new Bloco();
                        b.criarBloco(sec.Offset);
                        b = aux.Valor;

                        //ENCONTRANDO O BLOCO NA SEC PARA PRIN
                        Bloco r = new Bloco();
                        r.criarBloco(sec.Offset);

                        sec.Blocos[i].Enderecos[indexDeslo].Acessado = 1;
                        r = sec.Blocos[i];
                        sec.Blocos[i] = b;
                        sec.Blocos[i].Id = i;

                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].R = 0;
                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].Ativa = 0;
                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].IdBloco = -1;
                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].UltimoAcesso = DateTime.MinValue;

                        for (int j = 0; j < prin.Blocos.Count; j++)
                        {
                            if (prin.Blocos[j] == b)
                            {
                                prin.Blocos[j] = r;
                                prin.Blocos[j].Id = j;

                                tabelap.TabelaPagina[indexPag].Ativa = 1;
                                tabelap.TabelaPagina[indexPag].IdBloco = j;
                                tabelap.TabelaPagina[indexPag].R = 1;
                                tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;
                                aux1.Valor = prin.Blocos[j];
                                l.Ult = l.Ult.Prox;
                                break;
                            }
                        }
                        sec.ExibirMemoria();
                        comSO = true;
                        break;
                    }
                }
            }

            if (comSO != true)
            {
                //Principal
                if (tabelap.TabelaPagina[indexPag].Ativa == 1)
                {
                    //ACESSAR PÁGINA JÁ ALOCADA
                    for (int i = 0; i < prin.Blocos.Count; i++)
                    {
                        if (prin.Blocos[i].IdPag == indexPag)
                        {
                            prin.Blocos[i].Enderecos[indexDeslo].Acessado = 1;
                        }
                    }

                    int todos1 = 0;
                    No aux = l.Ult.Prox;
                    while (aux != l.Ult)
                    {
                        if (tabelap.TabelaPagina[aux.Valor.IdPag].R == 1)
                        {
                            todos1++;
                        }
                        aux = aux.Prox;
                    }
                    if (tabelap.TabelaPagina[aux.Valor.IdPag].R == 1)
                    {
                        todos1++;
                    }
                    if (todos1 == (l.QTD(l)))
                    {
                        aux = l.Ult.Prox;
                        while (aux != l.Ult)
                        {
                            tabelap.TabelaPagina[aux.Valor.IdPag].R = 0;
                            aux = aux.Prox;
                        }
                        tabelap.TabelaPagina[aux.Valor.IdPag].R = 0;
                    }
                    tabelap.TabelaPagina[indexPag].R = 1;
                    tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;

                }
                else if (prin.BlocosTodosAcessados() == 0)
                {
                    for (int i = 0; i < prin.Blocos.Count; i++)
                    {
                        if (prin.Blocos[i].Acessado == 0)
                        {
                            //ALOCAR PÁGINA PELA PRIMEIRA VEZ
                            prin.Blocos[i].Acessado = 1;
                            prin.Blocos[i].IdPag = indexPag;
                            prin.Blocos[i].Enderecos[indexDeslo].Acessado = 1;

                            tabelap.TabelaPagina[indexPag].Ativa = 1;
                            tabelap.TabelaPagina[indexPag].IdBloco = i;
                            tabelap.TabelaPagina[indexPag].R = 1;
                            tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;

                            l.InserirLista(l, prin.Blocos[i], prin);

                            break;
                        }
                    }
                }
                else
                {
                    No aux = l.Ult.Prox;
                    while (tabelap.TabelaPagina[aux.Valor.IdPag].R != 0)
                    {
                        tabelap.TabelaPagina[aux.Valor.IdPag].R = 0;
                        l.Ult = aux;
                        aux = aux.Prox;
                    }
                    No aux1 = aux;
                    //aux = aux.Prox;
                    Bloco b = new Bloco();
                    b.criarBloco(sec.Offset);
                    b = aux.Valor;
                    //ENCONTRANDO O BLOCO NA SEC PARA PRIN

                    for (int i = 0; i < sec.Blocos.Count; i++)
                    {
                        if (sec.Blocos[i].Acessado == 0)
                        {
                            sec.Blocos[i] = b;
                            sec.Blocos[i].Id = i;

                            tabelap.TabelaPagina[b.IdPag].Ativa = 0;
                            tabelap.TabelaPagina[b.IdPag].IdBloco = -1;
                            tabelap.TabelaPagina[b.IdPag].R = 0;
                            tabelap.TabelaPagina[b.IdPag].UltimoAcesso = DateTime.MinValue;
                            break;
                        }
                    }
                    Bloco novo = new Bloco();
                    novo.criarBloco(prin.Offset);

                    novo.Enderecos[indexDeslo].Acessado = 1;

                    for (int i = 0; i < prin.Blocos.Count; i++)
                    {
                        if (prin.Blocos[i] == b)
                        {
                            prin.Blocos[i] = novo;
                            prin.Blocos[i].Acessado = 1;
                            prin.Blocos[i].Id = i;
                            prin.Blocos[i].IdPag = indexPag;

                            aux1.Valor = prin.Blocos[i];
                            l.Ult = l.Ult.Prox;

                            tabelap.TabelaPagina[indexPag].Ativa = 1;
                            tabelap.TabelaPagina[indexPag].IdBloco = i;
                            tabelap.TabelaPagina[indexPag].R = 1;
                            tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;

                            break;
                        }
                    }
                    sec.ExibirMemoria();
                }
            }
        }
        static void SegundaChance(Memoria prin, Memoria sec, int indexPag, int indexDeslo, Queue<Bloco> fila, TabelaDePaginas tabelap)
        {
            bool comSO = false;
            if (sec.Blocos.Count != 0)
            {
                for (int i = 0; i < sec.Blocos.Count; i++)
                {
                    if (sec.Blocos[i].IdPag == indexPag)
                    {
                        //ESCOLHENDO O BLOCO QUE VAI SER SUBSTITUIDO
                        Bloco b = new Bloco();
                        b.criarBloco(sec.Offset);

                        b = fila.Dequeue();
                        while (tabelap.TabelaPagina[b.IdPag].R == 1)
                        {
                            tabelap.TabelaPagina[b.IdPag].R = 0;
                            fila.Enqueue(b);
                            b = fila.Dequeue();
                        }
                        //ENCONTRANDO O BLOCO NA SEC PARA PRIN
                        Bloco r = new Bloco();
                        r.criarBloco(sec.Offset);

                        sec.Blocos[i].Enderecos[indexDeslo].Acessado = 1;
                        r = sec.Blocos[i];
                        sec.Blocos[i] = b;
                        sec.Blocos[i].Id = i;

                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].Ativa = 0;
                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].IdBloco = -1;
                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].R = 0;
                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].UltimoAcesso = DateTime.MinValue;

                        for (int j = 0; j < prin.Blocos.Count; j++)
                        {
                            if (prin.Blocos[j] == b)
                            {
                                prin.Blocos[j] = r;
                                prin.Blocos[j].Id = j;

                                tabelap.TabelaPagina[indexPag].Ativa = 1;
                                tabelap.TabelaPagina[indexPag].IdBloco = j;
                                tabelap.TabelaPagina[indexPag].R = 1;
                                tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;
                                fila.Enqueue(prin.Blocos[j]);
                                break;
                            }
                        }
                        sec.ExibirMemoria();
                        comSO = true;
                        break;
                    }
                }
            }

            if (comSO != true)
            {
                //Principal
                if (tabelap.TabelaPagina[indexPag].Ativa == 1)
                {
                    //ACESSAR PÁGINA JÁ ALOCADA
                    for (int i = 0; i < prin.Blocos.Count; i++)
                    {
                        if (prin.Blocos[i].IdPag == indexPag)
                        {
                            prin.Blocos[i].Enderecos[indexDeslo].Acessado = 1;
                        }
                    }

                    Bloco b = new Bloco();
                    Bloco c = new Bloco();
                    c.criarBloco(prin.Offset);
                    b.criarBloco(prin.Offset);
                    int j = 0, saoTodos1 = 0;

                    while (j != fila.Count)
                    {
                        b = fila.Dequeue();
                        if (j == 0)
                        {
                            c = b;
                        }
                        if (tabelap.TabelaPagina[b.IdPag].R != 0)
                        {
                            saoTodos1++;
                        }
                        fila.Enqueue(b);
                        j++;
                    }
                    if(saoTodos1 == fila.Count)
                    {
                        j = 0;
                        while (j != fila.Count)
                        {
                            b = fila.Dequeue();
                            tabelap.TabelaPagina[b.IdPag].R = 0;
                            fila.Enqueue(b);
                            j++;
                        }
                    }
                    tabelap.TabelaPagina[indexPag].R = 1;
                    tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;
                }
                else if (prin.BlocosTodosAcessados() == 0)
                {
                    for (int i = 0; i < prin.Blocos.Count; i++)
                    {
                        if (prin.Blocos[i].Acessado == 0)
                        {
                            //ALOCAR PÁGINA PELA PRIMEIRA VEZ
                            prin.Blocos[i].Acessado = 1;
                            prin.Blocos[i].IdPag = indexPag;
                            prin.Blocos[i].Enderecos[indexDeslo].Acessado = 1;

                            tabelap.TabelaPagina[indexPag].Ativa = 1;
                            tabelap.TabelaPagina[indexPag].IdBloco = i;
                            tabelap.TabelaPagina[indexPag].R = 1;
                            tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;

                            fila.Enqueue(prin.Blocos[i]);

                            break;
                        }
                    }
                }
                else
                {
                    Bloco b = new Bloco();
                    b.criarBloco(sec.Offset);

                    b = fila.Dequeue();
                    while (tabelap.TabelaPagina[b.IdPag].R == 1)
                    {
                        tabelap.TabelaPagina[b.IdPag].R = 0;
                        fila.Enqueue(b);
                        b = fila.Dequeue();
                    }
                    //ENCONTRANDO O BLOCO NA SEC PARA PRIN

                    for (int i = 0; i < sec.Blocos.Count; i++)
                    {
                        if (sec.Blocos[i].Acessado == 0)
                        {
                            sec.Blocos[i] = b;
                            sec.Blocos[i].Id = i;

                            tabelap.TabelaPagina[b.IdPag].Ativa = 0;
                            tabelap.TabelaPagina[b.IdPag].IdBloco = -1;
                            tabelap.TabelaPagina[b.IdPag].R = 0;
                            tabelap.TabelaPagina[b.IdPag].UltimoAcesso = DateTime.MinValue;
                            break;
                        }
                    }
                    Bloco novo = new Bloco();
                    novo.criarBloco(prin.Offset);

                    novo.Enderecos[indexDeslo].Acessado = 1;

                    for (int i = 0; i < prin.Blocos.Count; i++)
                    {
                        if (prin.Blocos[i] == b)
                        {
                            prin.Blocos[i] = novo;
                            prin.Blocos[i].Acessado = 1;
                            prin.Blocos[i].Id = i;
                            prin.Blocos[i].IdPag = indexPag;

                            fila.Enqueue(prin.Blocos[i]);

                            tabelap.TabelaPagina[indexPag].Ativa = 1;
                            tabelap.TabelaPagina[indexPag].IdBloco = i;
                            tabelap.TabelaPagina[indexPag].R = 1;
                            tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;
                            break;
                        }
                    }
                    sec.ExibirMemoria();
                }
            }
        }
        static void FIFO(Memoria prin, Memoria sec, int indexPag, int indexDeslo, Queue<Bloco> fila, TabelaDePaginas tabelap)
        {
            bool comSO = false;
            if (sec.Blocos.Count != 0)
            {
                for (int i = 0; i < sec.Blocos.Count; i++)
                {
                    if (sec.Blocos[i].IdPag == indexPag)
                    {
                        Bloco ultFila = new Bloco();
                        Bloco blocoPPrin = new Bloco();

                        ultFila.criarBloco(prin.Offset);
                        ultFila = fila.Dequeue();

                        blocoPPrin.criarBloco(sec.Offset);

                        sec.Blocos[i].Enderecos[indexDeslo].Acessado = 1;
                        blocoPPrin = sec.Blocos[i];
                        sec.Blocos[i] = ultFila;

                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].Ativa = 0;
                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].IdBloco = -1;
                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].UltimoAcesso = DateTime.MinValue;

                        for (int j = 0; j < prin.Blocos.Count; j++)
                        {
                            if (prin.Blocos[j] == ultFila)
                            {
                                prin.Blocos[j] = blocoPPrin;

                                tabelap.TabelaPagina[indexPag].Ativa = 1;
                                tabelap.TabelaPagina[indexPag].IdBloco = j;
                                tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;
                                fila.Enqueue(prin.Blocos[j]);
                                break;
                            }
                        }
                        sec.ExibirMemoria();

                        comSO = true;
                        break;
                    }
                }
            }

            if (comSO != true)
            {
                //Principal
                if (tabelap.TabelaPagina[indexPag].Ativa == 1)
                {
                    prin.Blocos[tabelap.TabelaPagina[indexPag].IdBloco].Enderecos[indexDeslo].Acessado = 1;
                    tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;
                }
                else if (prin.BlocosTodosAcessados() == 0)
                {
                    for (int i = 0; i < prin.Blocos.Count; i++)
                    {
                        if (prin.Blocos[i].Acessado == 0)
                        {
                            prin.Blocos[i].Enderecos[indexDeslo].Acessado = 1;
                            prin.Blocos[i].Acessado = 1;
                            prin.Blocos[i].IdPag = indexPag;

                            tabelap.TabelaPagina[indexPag].Ativa = 1;
                            tabelap.TabelaPagina[indexPag].IdBloco = i;
                            tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;

                            fila.Enqueue(prin.Blocos[i]);
                            break;
                        }
                    }
                }
                else
                {
                    Bloco blo = fila.Dequeue();


                    for (int i = 0; i < sec.Blocos.Count; i++)
                    {
                        if (sec.Blocos[i].Acessado == 0)
                        {
                            sec.Blocos[i] = blo;
                            break;
                        }
                    }

                    tabelap.TabelaPagina[blo.IdPag].Ativa = 0;
                    tabelap.TabelaPagina[blo.IdPag].IdBloco = -1;
                    tabelap.TabelaPagina[blo.IdPag].UltimoAcesso = DateTime.MinValue;

                    Bloco novo = new Bloco();
                    novo.criarBloco(prin.Offset);

                    novo.Enderecos[indexDeslo].Acessado = 1;

                    //Substituir o Bloco da Memoria Principal
                    for (int i = 0; i < prin.Blocos.Count; i++)
                    {
                        if (prin.Blocos[i] == blo)
                        {
                            prin.Blocos[i] = novo;
                            prin.Blocos[i].Acessado = 1;
                            prin.Blocos[i].Id = blo.Id;
                            prin.Blocos[i].IdPag = indexPag;
                            fila.Enqueue(prin.Blocos[i]);

                            tabelap.TabelaPagina[indexPag].Ativa = 1;
                            tabelap.TabelaPagina[indexPag].IdBloco = i;
                            tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;
                            break;
                        }
                    }
                    sec.ExibirMemoria();
                }
            }
        }
        static void LRU(Memoria prin, Memoria sec, int indexPag, int indexDeslo, List<Bloco> lista, TabelaDePaginas tabelap)
        {
            bool comSO = false;
            if (sec.Blocos.Count != 0)
            {
                for (int i = 0; i < sec.Blocos.Count; i++)
                {
                    if (sec.Blocos[i].IdPag == indexPag)
                    {
                        Bloco b = new Bloco();
                        b.criarBloco(prin.Offset);
                        DateTime d = tabelap.TabelaPagina[0].UltimoAcesso;
                        b = lista[0];
                        int indexRet = 0;
                        for (int j = 0; j < lista.Count; j++)
                        {
                            if (tabelap.TabelaPagina[lista[j].IdPag].UltimoAcesso < d)
                            {
                                d = tabelap.TabelaPagina[lista[j].IdPag].UltimoAcesso;
                                b = lista[j];
                                indexRet = j;
                            }
                        }

                        lista.RemoveAt(indexRet);

                        Bloco blocoPPrin = new Bloco();
                        blocoPPrin.criarBloco(sec.Offset);

                        sec.Blocos[i].Enderecos[indexDeslo].Acessado = 1;
                        blocoPPrin = sec.Blocos[i];
                        sec.Blocos[i] = b;

                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].Ativa = 0;
                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].IdBloco = -1;
                        tabelap.TabelaPagina[sec.Blocos[i].IdPag].UltimoAcesso = DateTime.MinValue;

                        for (int j = 0; j < prin.Blocos.Count; j++)
                        {
                            if (prin.Blocos[j] == b)
                            {
                                prin.Blocos[j] = blocoPPrin;

                                tabelap.TabelaPagina[indexPag].Ativa = 1;
                                tabelap.TabelaPagina[indexPag].IdBloco = j;
                                tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;

                                lista.Add(prin.Blocos[j]);
                                break;
                            }
                        }
                        sec.ExibirMemoria();

                        comSO = true;
                        break;
                    }
                }
            }

            if (comSO != true)
            {
                //Principal
                if (tabelap.TabelaPagina[indexPag].Ativa == 1)
                {
                    prin.Blocos[tabelap.TabelaPagina[indexPag].IdBloco].Enderecos[indexDeslo].Acessado = 1;
                    tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;
                }
                else if (prin.BlocosTodosAcessados() == 0)
                {
                    for (int i = 0; i < prin.Blocos.Count; i++)
                    {
                        if (prin.Blocos[i].Acessado == 0)
                        {
                            prin.Blocos[i].Enderecos[indexDeslo].Acessado = 1;
                            prin.Blocos[i].Acessado = 1;
                            prin.Blocos[i].IdPag = indexPag;

                            tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;
                            tabelap.TabelaPagina[indexPag].Ativa = 1;
                            tabelap.TabelaPagina[indexPag].IdBloco = i;

                            lista.Add(prin.Blocos[i]);
                            break;
                        }
                    }
                }
                else
                {
                    Bloco b = new Bloco();
                    b.criarBloco(prin.Offset);
                    DateTime d = tabelap.TabelaPagina[lista[0].IdPag].UltimoAcesso;
                    b = lista[0];
                    int indexRet = 0;
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if(DateTime.Compare(tabelap.TabelaPagina[lista[i].IdPag].UltimoAcesso, d) < 0)
                        {
                            d = tabelap.TabelaPagina[lista[i].IdPag].UltimoAcesso;
                            b = lista[i];
                            indexRet = i;
                        }
                        
                    }

                    for (int i = 0; i < sec.Blocos.Count; i++)
                    {
                        if (sec.Blocos[i].Acessado == 0)
                        {
                            sec.Blocos[i] = b;
                            break;
                        }
                    }

                    lista.RemoveAt(indexRet);

                    tabelap.TabelaPagina[b.IdPag].Ativa = 0;
                    tabelap.TabelaPagina[b.IdPag].IdBloco = -1;
                    tabelap.TabelaPagina[b.IdPag].UltimoAcesso = DateTime.MinValue;

                    Bloco novo = new Bloco();
                    novo.criarBloco(prin.Offset);

                    novo.Enderecos[indexDeslo].Acessado = 1;

                    //Substituir o Bloco da Memoria Principal
                    for (int i = 0; i < prin.Blocos.Count; i++)
                    {
                        if (prin.Blocos[i] == b)
                        {
                            prin.Blocos[i] = novo;
                            prin.Blocos[i].Acessado = 1;
                            prin.Blocos[i].Id = b.Id;
                            prin.Blocos[i].IdPag = indexPag;
                            lista.Add(prin.Blocos[i]);

                            tabelap.TabelaPagina[indexPag].Ativa = 1;
                            tabelap.TabelaPagina[indexPag].IdBloco = i;
                            tabelap.TabelaPagina[indexPag].UltimoAcesso = DateTime.Now;
                            break;
                        }
                    }
                    sec.ExibirMemoria();
                }
            }
        }

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            if(cmbAlgoritmo.Text == "")
            {
                MessageBox.Show("POR FAVOR ESCOLHA UM ALGORITMO PARA A SIMULAÇÃO.");
            }
            else
            {
                if (cmbAlgoritmo.Text == "FIFO")
                {
                    int indexPag = (int)nudPag.Value;
                    int indexDeslo = (int)nudDeslo.Value;
                    FIFO(prin, sec, indexPag, indexDeslo, fila, tabelap);

                    lsvTabelaPaginas.Items.Clear();
                    for (int i = 0; i < tabelap.TabelaPagina.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(tabelap.TabelaPagina[i].Id.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].Ativa.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].R.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].M.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].IdBloco.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].UltimoAcesso.ToString("HH:mm:ss"));
                        lsvTabelaPaginas.Items.Add(item);
                    }

                    txtPrincipal.Text = "";
                    txtPrincipal.Text += prin.ExibirMemoria();

                    txtSecundaria.Text = "";
                    txtSecundaria.Text += sec.ExibirMemoria();

                }
                else if (cmbAlgoritmo.Text == "SEGUNDA CHANCE")
                {
                    int indexPag = (int)nudPag.Value;
                    int indexDeslo = (int)nudDeslo.Value;
                    SegundaChance(prin, sec, indexPag, indexDeslo, fila, tabelap);

                    lsvTabelaPaginas.Items.Clear();
                    for (int i = 0; i < tabelap.TabelaPagina.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(tabelap.TabelaPagina[i].Id.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].Ativa.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].R.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].M.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].IdBloco.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].UltimoAcesso.ToString("HH:mm:ss"));
                        lsvTabelaPaginas.Items.Add(item);
                    }

                    txtPrincipal.Text = "";
                    txtPrincipal.Text += prin.ExibirMemoria();

                    txtSecundaria.Text = "";
                    txtSecundaria.Text += sec.ExibirMemoria();
                }
                else if (cmbAlgoritmo.Text == "RELÓGIO")
                {
                    int indexPag = (int)nudPag.Value;
                    int indexDeslo = (int)nudDeslo.Value;
                    Relogio(prin, sec, indexPag, indexDeslo, l, tabelap);

                    lsvTabelaPaginas.Items.Clear();
                    for (int i = 0; i < tabelap.TabelaPagina.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(tabelap.TabelaPagina[i].Id.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].Ativa.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].R.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].M.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].IdBloco.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].UltimoAcesso.ToString("HH:mm:ss"));
                        lsvTabelaPaginas.Items.Add(item);
                    }

                    txtPrincipal.Text = "";
                    txtPrincipal.Text += prin.ExibirMemoria();

                    txtSecundaria.Text = "";
                    txtSecundaria.Text += sec.ExibirMemoria();
                }
                else if (cmbAlgoritmo.Text == "LRU")
                {
                    int indexPag = (int)nudPag.Value;
                    int indexDeslo = (int)nudDeslo.Value;
                    LRU(prin, sec, indexPag, indexDeslo, lista, tabelap);

                    lsvTabelaPaginas.Items.Clear();
                    for (int i = 0; i < tabelap.TabelaPagina.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(tabelap.TabelaPagina[i].Id.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].Ativa.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].R.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].M.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].IdBloco.ToString());
                        item.SubItems.Add(tabelap.TabelaPagina[i].UltimoAcesso.ToString("HH:mm:ss"));
                        lsvTabelaPaginas.Items.Add(item);
                    }

                    txtPrincipal.Text = "";
                    txtPrincipal.Text += prin.ExibirMemoria();

                    txtSecundaria.Text = "";
                    txtSecundaria.Text += sec.ExibirMemoria();
                }
            }
        }

        private void btnLimparTudo_Click(object sender, EventArgs e)
        {
            txtPrincipal.Text = "";
            txtSecundaria.Text = "";
            lsvTabelaPaginas.Items.Clear();
            nudBlocos.Value = 0;
            nudDeslo.Value = 0;
            nudOffset.Value = 0;
            nudPag.Value = 0;
            nudPagN.Value = 0;

            prin.Blocos.Clear();
            prin.Offset = 0;
            prin.Tamanho = 0;
            sec.Blocos.Clear();
            sec.Offset = 0;
            sec.Tamanho = 0;

            tabelap.TabelaPagina.Clear();

            cmbAlgoritmo.Text = "";
            lista.Clear();
            fila.Clear();
            l.Ult = null;
        }
    }
}

