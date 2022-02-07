
namespace Financas
{
    partial class frm_Fonte
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvFontes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFontes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFontes
            // 
            this.dgvFontes.AllowUserToAddRows = false;
            this.dgvFontes.AllowUserToDeleteRows = false;
            this.dgvFontes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFontes.Location = new System.Drawing.Point(12, 12);
            this.dgvFontes.Name = "dgvFontes";
            this.dgvFontes.ReadOnly = true;
            this.dgvFontes.Size = new System.Drawing.Size(776, 170);
            this.dgvFontes.TabIndex = 0;
            // 
            // frm_Fonte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvFontes);
            this.Name = "frm_Fonte";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFontes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFontes;
    }
}

