using Microsoft.EntityFrameworkCore;

namespace Web.Helper
{
    public static class HttpContextExtensions
    {
        public static async Task InsertPaginationParameterInResponse(this HttpContext httpContext,
            int totalRecords, int recordsPerPage)
        {
            double count = totalRecords;
            double pagesQuantity = Math.Ceiling(count / recordsPerPage);
            httpContext.Response.Headers.Add("pagesQuantity", pagesQuantity.ToString());
        }
    }
}
