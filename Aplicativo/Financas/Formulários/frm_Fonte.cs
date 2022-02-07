using financas_core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Financas
{
    public partial class frm_Fonte : Form
    {
        public frm_Fonte()
        {
            InitializeComponent();
            carregaDgvFontes();
        }

        private void carregaDgvFontes()
        {
            dgvFontes.ColumnCount = 6;
            dgvFontes.Rows.Clear();
            dgvFontes.AllowUserToAddRows = false;
            dgvFontes.ReadOnly = true;
            dgvFontes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvFontes.Columns[0].Name = "codigo";
            dgvFontes.Columns[1].Name = "descricao";
            dgvFontes.Columns[2].Name = "tipo";
            dgvFontes.Columns[3].Name = "bandeira";
            dgvFontes.Columns[4].Name = "fatura";
            dgvFontes.Columns[5].Name = "fechamento";

            dgvFontes.Columns[0].HeaderText = "Código";
            dgvFontes.Columns[1].HeaderText = "Descrição";
            dgvFontes.Columns[2].HeaderText = "Tipo";
            dgvFontes.Columns[3].HeaderText = "Bandeira";
            dgvFontes.Columns[4].HeaderText = "Fatura";
            dgvFontes.Columns[5].HeaderText = "Fechamento";

            foreach (Fonte fonte in Fonte.listaFontesSemFiltro())
                dgvFontes.Rows.Add
                (
                    fonte.codigo,
                    fonte.descricao,
                    fonte.tipo.Trim(),
                    fonte.dadosCartao.bandeira.Trim(),
                    fonte.dadosCartao.pagamentoFatura,
                    fonte.dadosCartao.fechamentoFatura
                );

            dgvFontes.Refresh();
        }
    }
}
