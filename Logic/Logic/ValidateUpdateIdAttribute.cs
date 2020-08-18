using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Logic
{
    public class ValidateUpdateIdAttribute : ActionFilterAttribute
    {
        public string ModelName { get; set; } = "model";
        public string PropertyName { get; set; } = "Id";
        public string SessionName { get; set; } = "UPDATEID";

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var Id = context.HttpContext.Session.GetInt32(SessionName);
            if (Id != null)
            {
                if (!context.ActionArguments.ContainsKey(ModelName))
                {
                    throw new System.Exception("Cannot find model!");
                }
                var model = context.ActionArguments[ModelName];
                var property = model.GetType().GetProperty(PropertyName);
                if (property == null)
                {
                    throw new System.Exception($"Cannot find property named {PropertyName}!");
                }
                property.SetValue(context.ActionArguments[ModelName], Id);
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}