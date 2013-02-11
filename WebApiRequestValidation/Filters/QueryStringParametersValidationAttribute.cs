namespace WebApiRequestValidation.Filters
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    [AttributeUsage(AttributeTargets.Method)]
    public class QueryStringParametersValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var parameters = actionContext.ActionDescriptor.GetParameters();
            var queryParameters = actionContext.Request.GetQueryNameValuePairs();

            var invalidParams = queryParameters.Select(kvp => kvp.Key).Where(
                queryParameter => !parameters.Any(p => p.ParameterName.Equals(queryParameter, StringComparison.OrdinalIgnoreCase))).ToList();
                
            if (invalidParams.Any())
            {
                var invalidParamsStr = invalidParams.Aggregate((current, next) => current + ", " + next);
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, 
                    string.Format("Some of the parameters in the query string are invalid: {0}", invalidParamsStr));
            }
        }
    }
}