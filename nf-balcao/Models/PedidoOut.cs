using System;

namespace nf_balcao.Models
{
    public class PedidoOut
    {
        public int CodNotaFical { get; set; }
        public DateTime DtaVenda { get; set; }
        public int CodProduto { get; set; }        
        public int QtdItem { get; set; }    
        public double VlrUnitario { get; set; }
        public double VlrTotItem { get; set; }    
    }
}