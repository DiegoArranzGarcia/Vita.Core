using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Vita.Core.Pagination.Http.Headers
{
    public static class PaginationExtension
	{
		public const string DefaultPaginationCookieName = "X-Pagination";

		public static void AddPaginationMetadata<T>(this HttpResponse response, PagedList<T> page, string paginationCookieName = DefaultPaginationCookieName)
		{
			var metadata = new PaginationMetadata()
			{
				TotalCount = page.TotalCount,
				PageSize = page.PageSize,
				CurrentPage = page.CurrentPage,
				TotalPages = page.TotalPages,
				HasNext = page.HasNext,
				HasPrevious = page.HasPrevious
			};

			response.Headers.Add(paginationCookieName, JsonConvert.SerializeObject(metadata));
		}
	}
}
