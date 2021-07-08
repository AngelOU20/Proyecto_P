using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proyecto_P.Data;
using Proyecto_P.Models;

namespace Proyecto_P.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var listProducto=_context.DataProducto.OrderBy(x => x.NombreProducto).ToList();
            return View(listProducto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AgregarProducto(){
            return View();
        }

        [HttpPost]
        public IActionResult AgregarProducto(Producto p){
            if(ModelState.IsValid){
                p.PrecioTotal= p.CantidadCajas * p.PrecioPorCajas;
                p.CantidadProductosTotal= p.CantidadCajas * p.CantidadProductosPorCajas;
                p.PrecioPorProducto= p.PrecioPorCajas / p.CantidadProductosPorCajas;
                _context.Add(p);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public IActionResult EditarProducto(int Id){
            var producto = _context.DataProducto.Find(Id);
            return View(producto);
        }


        [HttpPost]
        public IActionResult EditarProducto(Producto p){
            if(ModelState.IsValid){
                var producto = _context.DataProducto.Find(p.Id);
                producto.NombreProducto = p.NombreProducto;
                producto.Proveedor = p.Proveedor;
                producto.CantidadCajas = p.CantidadCajas;
                producto.PrecioPorCajas = p.PrecioPorCajas;
                producto.PrecioTotal= p.CantidadCajas * p.PrecioPorCajas;
                producto.CantidadProductosPorCajas = p.CantidadProductosPorCajas;
                producto.CantidadProductosTotal= p.CantidadCajas * p.CantidadProductosPorCajas;
                producto.PrecioPorProducto= p.PrecioPorCajas / p.CantidadProductosPorCajas;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }


        public IActionResult DetalleProducto(int Id){
            var listproducto = _context.DataProducto.Find(Id);
            return View(listproducto);
        }
   
        public IActionResult EliminarProducto(int Id) 
        {
            var Producto= _context.DataProducto.Find(Id);
            _context.Remove(Producto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Index(string ordenar, string filtro)
        {
            var listProd= _context.DataProducto.OrderBy(s => s.Id).ToList();
            
            if(ordenar == "MayorPrecio"){
                listProd=_context.DataProducto.Where(c => c.NombreProducto.ToUpper().Contains(filtro.ToUpper())).OrderByDescending(s=>s.PrecioPorProducto) .ToList();
            }else if(ordenar == "MenorPrecio"){
                Console.WriteLine("MenorPrecio"+ ordenar);
                listProd=_context.DataProducto.Where(c => c.NombreProducto.ToUpper().Contains(filtro.ToUpper())).OrderBy(s=>s.PrecioPorProducto) .ToList();
            }else{
                listProd=_context.DataProducto.Where(c => c.NombreProducto.ToUpper().Contains(filtro.ToUpper())).OrderBy(s=>s.Id) .ToList();
            }
            return View(listProd);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
