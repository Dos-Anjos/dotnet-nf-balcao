using nf_balcao.Data.Collections;
using nf_balcao.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace nf_balcao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Pedido> _pedidosCollection;

        public PedidoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _pedidosCollection = _mongoDB.DB.GetCollection<Pedido>(typeof(Pedido).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarPedido([FromBody] PedidoOut ou)
        {
            var pedido = new Pedido(ou.CodNotaFical, ou.DtaVenda, ou.CodProduto, ou.QtdItem, ou.VlrUnitario,
            ou.VlrTotItem);

            _pedidosCollection.InsertOne(pedido);
            
            return StatusCode(201, "MSG001-I Pedido incluído com sucesso!");
        }

        [HttpGet]
        public ActionResult ObterPedido()
        {
            var pedido = _pedidosCollection.Find(Builders<Pedido>.Filter.Empty).ToList();
            
            return Ok(pedido);
        }
    }
}