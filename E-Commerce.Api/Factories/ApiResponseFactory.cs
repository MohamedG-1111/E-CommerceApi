using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Factories
{
    public static class ApiResponseFactory
    {
        public static IActionResult GenerateApiVaildationsErrors(ActionContext context)
        {
            var errors = context.ModelState.Where(x => x.Value.Errors.Count() > 0)
                .ToDictionary(X => X.Key, X => X.Value.Errors.Select(X => X.ErrorMessage).ToArray());
            var Problem = new ProblemDetails()
            {
                Title = "Vaildation Errors",
                Status=StatusCodes.Status400BadRequest,
                Detail= "One or more validation errors occurred.",
                Extensions = { { "Errors",errors} }
               
            };
            return new BadRequestObjectResult(Problem);
                   
        }
    }
}
