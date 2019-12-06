using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EpamSqlTask5EntityFramework;
using AutoMapper;

namespace WebApp.Controllers {
    public class OrdersController : ApiController {
        private UnitOfWork u;
        private IMapper mapper;

        public OrdersController(UnitOfWork unt) {
            this.u = unt;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Order, OrderDTO>();
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
            });
            mapper = config.CreateMapper();
        }

        [HttpPost]
        public void CreateOrder([FromBody] OrderDTO order) {
            var ord = mapper.Map<OrderDTO, Order>(order);
            u.OrderRep.Insert(ord);
            u.OrderRep.Save();
        }

        [HttpGet]
        public IHttpActionResult GetAllOrders() {
            var res = u.OrderRep.GetAll();
            if (res == null) return NotFound();
            var list = new List<OrderDTO>();
            foreach (var or in res) {
                var dest = mapper.Map<Order, OrderDTO>(or);
                list.Add(dest);
            }
            return Ok(list);
        }

        [HttpGet]
        public IHttpActionResult GetOrder(int id) {
            var res = u.OrderRep.GetById(id);
            if (res == null) return NotFound();
            return Ok(res);
        }

        [Route("api/orders/{id}/products")]
        [HttpGet]
        public IHttpActionResult GetAllProductsOfOrder(int id) {
            var list = new List<ProductDTO>();
            var prods = u.ProductRep.GetAll().Where(x => x.Order_id == id);
            foreach(var r in prods) {
                var prod = mapper.Map<Product, ProductDTO>(r);
                list.Add(prod);
            }
            return Ok(list);
        }

        [Route("api/orders/{id}/products")]
        [HttpPut]
        public void AddProductToOrder(int id, [FromBody] ProductDTO productDTO) {
            var prod = mapper.Map<ProductDTO, Product>(productDTO);
            prod.Order_id = id;
            u.ProductRep.Insert(prod);
            u.ProductRep.Save();
        }

    }
}
