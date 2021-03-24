using System;
namespace nf_balcao.Data.Collections

{
    public class Pedido
    {
        public int CodNotaFical { get; set; }
        public DateTime DtaVenda { get; set; }
        public int CodProduto { get; set; }        
        public int QtdItem { get; set; }    
        public double VlrUnitario { get; set; }
        public double VlrTotItem { get; set; }

        public Pedido(int notaFiscal, DateTime dtaVenda, int codProduto, int qtdItem, double vlrUnitario, 
        double vlrTotItem)
        {
            this.CodNotaFical = notaFiscal;
            this.DtaVenda     = dtaVenda;
            this.CodProduto   = codProduto;
            this.QtdItem      = qtdItem;
            this.VlrUnitario  = vlrUnitario;
            this.VlrTotItem   = vlrTotItem;
        }
    }
}