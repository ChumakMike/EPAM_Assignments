using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using AutoMapper.Configuration;
using AutoMapper.Mappers;
using EpamSqlTask5EntityFramework;

namespace WebApp.Controllers {
    public class ProductsController : ApiController {
        private UnitOfWork u;
        private IMapper mapper;

        public ProductsController(UnitOfWork unt) {
            this.u = unt;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductDTO, Product>();
            });
            mapper = config.CreateMapper();
        }

        [HttpGet]
        public IHttpActionResult GetAllProducts() {
            var res = u.ProductRep.GetAll();
            if (res == null) return NotFound();
            var list = new List<ProductDTO>();
            foreach(var pr in res) {
                var dest = mapper.Map<Product, ProductDTO>(pr);
                list.Add(dest);
            }
            return Ok(list);
        }

        [HttpPost]
        public void CreateProduct([FromBody] ProductDTO product) {
            var prod = mapper.Map<ProductDTO, Product>(product);
            u.ProductRep.Insert(prod);
            u.ProductRep.Save();
        }

    }
}
