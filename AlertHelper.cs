using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;

namespace SistemaEduWeb
{
    public static class AlertHelper
    {
        public static void MostrarAlerta(Page page, string titulo, string mensaje, string tipo)
        {
            string script = $"swal(\"{titulo}\", \"{mensaje}\", \"{tipo}\");";
            ScriptManager.RegisterStartupScript(page, page.GetType(), "SweetAlert", script, true);
        }

        public static void ShowSweetConfirm(Page page, string triggerButtonId, string confirmButtonId, string title, string message, string confirmText = "Sí", string cancelText = "Cancelar")
        {
            string script = $@"
            $('#{triggerButtonId}').on('click', function(e) {{
                e.preventDefault();
            
                swal({{
                    title: '{title}',
                    text: '{message}',
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonText: '{confirmText}',
                    cancelButtonText: '{cancelText}',
                    closeOnConfirm: false
                }}, function(isConfirm) {{
                    if (isConfirm) {{
                        __doPostBack('{confirmButtonId}', '');
                    }}
                }});
            }});";

            ScriptManager.RegisterStartupScript(page, page.GetType(), $"SweetAlertConfirm_{triggerButtonId}", script, true);
        }

    }
}