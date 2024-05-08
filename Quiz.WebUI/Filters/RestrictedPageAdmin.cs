using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Quiz.Application.DTOs;

namespace Quiz.WebUI.Filters
{
    public class RestrictedPageAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string userSession = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(userSession))
            {
                context.Result = new RedirectToRouteResult( new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            } else
            {
                LoginDTO loginDTO = JsonConvert.DeserializeObject<LoginDTO>(userSession);

                if (loginDTO == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }

                if(loginDTO.Perfil != Domain.Enums.PerfilEnum.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restrict" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuted(context);
        }
    }
}
