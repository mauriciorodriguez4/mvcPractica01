using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvcPractica01.Models;

namespace mvcPractica01.Controllers
{
    public class equiposController : Controller
    {
        private readonly equiposDbContext _equiposDbContext;
        public equiposController(equiposDbContext equiposDbContext)
        {
            _equiposDbContext = equiposDbContext;
        }

        public IActionResult Index()
        {
            var listaDeMarcas = (from m in _equiposDbContext.marcas select m).ToList();
            ViewData["listaDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas","nombre_marca") ;

            var listaDeTipoEquipo = (from m in _equiposDbContext.tipo_equipo select m).ToList();
            ViewData["listaDeTipoEquipo"] = new SelectList(listaDeTipoEquipo, "id_tipo_equipo", "descripcion");

            var listaEstadoEquipo = (from m in _equiposDbContext.estados_equipo select m).ToList();
            ViewData["listaEstadoEquipo"] = new SelectList(listaEstadoEquipo, "id_estados_equipo", "estado");


            var listadoDeEquipos = (from e in _equiposDbContext.equiposs
                                    join m in _equiposDbContext.marcas on e.marca_id equals m.id_marcas
                                    select new
                                    {
                                        nombre = e.nombre,
                                        descripcion = e.descripcion,
                                        marca_id = e.marca_id,
                                        marca_nombre = m.nombre_marca
                                    }).ToList();
            ViewData["listadoDeEquipos"] = listadoDeEquipos;
            return View();
        }

        public IActionResult crearEquipos(equiposs nuevoEquipo)
        {
            _equiposDbContext.Add(nuevoEquipo);
            _equiposDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
