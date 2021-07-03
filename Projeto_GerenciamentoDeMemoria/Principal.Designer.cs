
namespace Projeto_GerenciamentoDeMemoria
{
    partial class Principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbAlgoritmo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nudBlocos = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudOffset = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudPagN = new System.Windows.Forms.NumericUpDown();
            this.btnAlocar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsvTabelaPaginas = new System.Windows.Forms.ListView();
            this.colunaId = new System.Windows.Forms.ColumnHeader();
            this.colunaAtivo = new System.Windows.Forms.ColumnHeader();
            this.colunaR = new System.Windows.Forms.ColumnHeader();
            this.colunaM = new System.Windows.Forms.ColumnHeader();
            this.colunaBloco = new System.Windows.Forms.ColumnHeader();
            this.colunaUltimoAcesso = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPrincipal = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nudDeslo = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudPag = new System.Windows.Forms.NumericUpDown();
            this.btnAcessar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtSecundaria = new System.Windows.Forms.TextBox();
            this.btnLimparTudo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlocos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPagN)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeslo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPag)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cmbAlgoritmo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudBlocos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nudOffset);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nudPagN);
            this.groupBox1.Controls.Add(this.btnAlocar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 206);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setar Memória";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(14, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 13;
            this.label9.Text = "Algoritmo:";
            // 
            // cmbAlgoritmo
            // 
            this.cmbAlgoritmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlgoritmo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAlgoritmo.FormattingEnabled = true;
            this.cmbAlgoritmo.Items.AddRange(new object[] {
            "FIFO",
            "SEGUNDA CHANCE",
            "RELÓGIO",
            "LRU"});
            this.cmbAlgoritmo.Location = new System.Drawing.Point(112, 164);
            this.cmbAlgoritmo.Name = "cmbAlgoritmo";
            this.cmbAlgoritmo.Size = new System.Drawing.Size(121, 23);
            this.cmbAlgoritmo.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(195, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 30);
            this.label4.TabIndex = 11;
            this.label4.Text = "OBS: \r\nEm bits.";
            // 
            // nudBlocos
            // 
            this.nudBlocos.Location = new System.Drawing.Point(111, 116);
            this.nudBlocos.Name = "nudBlocos";
            this.nudBlocos.Size = new System.Drawing.Size(54, 23);
            this.nudBlocos.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Blocos:";
            // 
            // nudOffset
            // 
            this.nudOffset.Location = new System.Drawing.Point(111, 78);
            this.nudOffset.Name = "nudOffset";
            this.nudOffset.Size = new System.Drawing.Size(54, 23);
            this.nudOffset.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Offset:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // nudPagN
            // 
            this.nudPagN.Location = new System.Drawing.Point(111, 39);
            this.nudPagN.Name = "nudPagN";
            this.nudPagN.Size = new System.Drawing.Size(54, 23);
            this.nudPagN.TabIndex = 6;
            // 
            // btnAlocar
            // 
            this.btnAlocar.Location = new System.Drawing.Point(190, 120);
            this.btnAlocar.Name = "btnAlocar";
            this.btnAlocar.Size = new System.Drawing.Size(64, 23);
            this.btnAlocar.TabIndex = 4;
            this.btnAlocar.Text = "Alocar";
            this.btnAlocar.UseVisualStyleBackColor = true;
            this.btnAlocar.Click += new System.EventHandler(this.btnAlocar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(14, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Endereçamento\r\nVirtual:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsvTabelaPaginas);
            this.groupBox2.Location = new System.Drawing.Point(292, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 418);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tabela de Páginas";
            // 
            // lsvTabelaPaginas
            // 
            this.lsvTabelaPaginas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colunaId,
            this.colunaAtivo,
            this.colunaR,
            this.colunaM,
            this.colunaBloco,
            this.colunaUltimoAcesso});
            this.lsvTabelaPaginas.FullRowSelect = true;
            this.lsvTabelaPaginas.GridLines = true;
            this.lsvTabelaPaginas.HideSelection = false;
            this.lsvTabelaPaginas.Location = new System.Drawing.Point(6, 39);
            this.lsvTabelaPaginas.MultiSelect = false;
            this.lsvTabelaPaginas.Name = "lsvTabelaPaginas";
            this.lsvTabelaPaginas.Size = new System.Drawing.Size(261, 360);
            this.lsvTabelaPaginas.TabIndex = 0;
            this.lsvTabelaPaginas.UseCompatibleStateImageBehavior = false;
            this.lsvTabelaPaginas.View = System.Windows.Forms.View.Details;
            // 
            // colunaId
            // 
            this.colunaId.Text = "ID";
            this.colunaId.Width = 30;
            // 
            // colunaAtivo
            // 
            this.colunaAtivo.Text = "Ativo";
            this.colunaAtivo.Width = 45;
            // 
            // colunaR
            // 
            this.colunaR.Text = "R";
            this.colunaR.Width = 35;
            // 
            // colunaM
            // 
            this.colunaM.Text = "M";
            this.colunaM.Width = 35;
            // 
            // colunaBloco
            // 
            this.colunaBloco.Text = "Bloco";
            this.colunaBloco.Width = 45;
            // 
            // colunaUltimoAcesso
            // 
            this.colunaUltimoAcesso.Text = "Ultimo A.";
            this.colunaUltimoAcesso.Width = 80;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPrincipal);
            this.groupBox3.Location = new System.Drawing.Point(571, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(273, 206);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Memória Principal";
            // 
            // txtPrincipal
            // 
            this.txtPrincipal.BackColor = System.Drawing.Color.White;
            this.txtPrincipal.Location = new System.Drawing.Point(6, 32);
            this.txtPrincipal.Multiline = true;
            this.txtPrincipal.Name = "txtPrincipal";
            this.txtPrincipal.ReadOnly = true;
            this.txtPrincipal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPrincipal.Size = new System.Drawing.Size(260, 155);
            this.txtPrincipal.TabIndex = 20;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.nudDeslo);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.nudPag);
            this.groupBox5.Controls.Add(this.btnAcessar);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(13, 262);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(273, 164);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Acessar Memória";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(180, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 30);
            this.label5.TabIndex = 11;
            this.label5.Text = "OBS: \r\nEm decimal.";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // nudDeslo
            // 
            this.nudDeslo.Location = new System.Drawing.Point(111, 78);
            this.nudDeslo.Name = "nudDeslo";
            this.nudDeslo.Size = new System.Drawing.Size(54, 23);
            this.nudDeslo.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(14, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Endereço:";
            // 
            // nudPag
            // 
            this.nudPag.Location = new System.Drawing.Point(111, 39);
            this.nudPag.Name = "nudPag";
            this.nudPag.Size = new System.Drawing.Size(54, 23);
            this.nudPag.TabIndex = 6;
            // 
            // btnAcessar
            // 
            this.btnAcessar.Location = new System.Drawing.Point(14, 131);
            this.btnAcessar.Name = "btnAcessar";
            this.btnAcessar.Size = new System.Drawing.Size(64, 23);
            this.btnAcessar.TabIndex = 4;
            this.btnAcessar.Text = "Acessar";
            this.btnAcessar.UseVisualStyleBackColor = true;
            this.btnAcessar.Click += new System.EventHandler(this.btnAcessar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(14, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Página:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtSecundaria);
            this.groupBox6.Location = new System.Drawing.Point(571, 262);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(273, 206);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Memória Secundária";
            // 
            // txtSecundaria
            // 
            this.txtSecundaria.BackColor = System.Drawing.Color.White;
            this.txtSecundaria.Location = new System.Drawing.Point(6, 32);
            this.txtSecundaria.Multiline = true;
            this.txtSecundaria.Name = "txtSecundaria";
            this.txtSecundaria.ReadOnly = true;
            this.txtSecundaria.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSecundaria.Size = new System.Drawing.Size(260, 155);
            this.txtSecundaria.TabIndex = 20;
            // 
            // btnLimparTudo
            // 
            this.btnLimparTudo.Location = new System.Drawing.Point(12, 447);
            this.btnLimparTudo.Name = "btnLimparTudo";
            this.btnLimparTudo.Size = new System.Drawing.Size(107, 23);
            this.btnLimparTudo.TabIndex = 12;
            this.btnLimparTudo.Text = "Limpar Tudo";
            this.btnLimparTudo.UseVisualStyleBackColor = true;
            this.btnLimparTudo.Click += new System.EventHandler(this.btnLimparTudo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(13, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(334, 24);
            this.label6.TabIndex = 14;
            this.label6.Text = "SIMULADOR DE ALGORITMOS DE PAGINAÇÃO";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 482);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnLimparTudo);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulação";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBlocos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPagN)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeslo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPag)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAlocar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lsvTabelaPaginas;
        private System.Windows.Forms.TextBox txtPrincipal;
        private System.Windows.Forms.ColumnHeader colunaId;
        private System.Windows.Forms.NumericUpDown nudPagN;
        private System.Windows.Forms.NumericUpDown nudOffset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colunaAtivo;
        private System.Windows.Forms.ColumnHeader colunaR;
        private System.Windows.Forms.ColumnHeader colunaM;
        private System.Windows.Forms.ColumnHeader colunaBloco;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbAlgoritmo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudBlocos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudDeslo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudPag;
        private System.Windows.Forms.Button btnAcessar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtSecundaria;
        private System.Windows.Forms.Button btnLimparTudo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader colunaUltimoAcesso;
    }
}

