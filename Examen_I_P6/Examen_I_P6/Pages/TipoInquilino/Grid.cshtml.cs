using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Empleado
{
    public class GridModel : PageModel
    {

        private readonly ITipoInquilinoService TipoInquilinoService;

        public GridModel(ITipoInquilinoService TipoInquilinoService)
        {
            this.TipoInquilinoService = TipoInquilinoService;
        }

        public IEnumerable<TipoInquilinoEntity> GridList { get; set; } = new List<TipoInquilinoEntity>();

        public string Mensaje { get; set; } = "";

        public async Task<IActionResult> OnGet()
        {

            try
            {

                GridList = await TipoInquilinoService.Get();

                if (TempData.ContainsKey(key: "Msg"))
                {
                    Mensaje = TempData[key: "Msg"] as String;
                }

                TempData.Clear();

                return Page();

            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }

        }


        public async Task<IActionResult> OnGetEliminar(int id)
        {

            try
            {

                var result = await TipoInquilinoService.Delete(entity: new() { Id_TipoInquilino = id });

                if (result.CodeError != 0)
                {
                    throw new Exception(result.MsgError);
                }

                TempData[key: "Msg"] = "Se eliminó correctamente";

                return Redirect(url: "Grid");

            }
            catch (Exception ex)
            {

                return Content(content: ex.Message);
            }

        }



    }
}