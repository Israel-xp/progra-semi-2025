    using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceFixed
{
    public class ErrorModel : PageModel
    {
        // Identificador de la petición (nullable porque puede no existir)
        public string? RequestId { get; set; }

        // Muestra el RequestId solo si tiene valor
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // OnGet para poblar el RequestId con el identificador de la actividad o el TraceIdentifier
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}