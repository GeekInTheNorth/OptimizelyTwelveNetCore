namespace OptimizelyTwelveTest.Features.Search
{
    using System.Linq;
    using EPiServer.Find;
    using EPiServer.Find.Cms;

    using MediatR;

    using OptimizelyTwelveTest.Features.Common.Pages;

    using System.Threading;
    using System.Threading.Tasks;

    public class SearchQueryHandler : IRequestHandler<SearchQuery, SearchResponse>
    {
        private readonly IClient _findClient;

        public SearchQueryHandler(IClient findClient)
        {
            _findClient = findClient;
        }

        public Task<SearchResponse> Handle(SearchQuery request, CancellationToken cancellationToken)
        {
            var pageSize = request.InitialPageSize;
            var skip = 0;
            if (request.Page > 1)
            {
                pageSize = request.LoadMorePageSize;
                skip = request.InitialPageSize + (request.LoadMorePageSize * (request.Page - 1));
            }

            var searchResult = _findClient.Search<SitePageData>()
                                          .For(request.SearchText)
                                          .UsingSynonyms()
                                          .ApplyBestBets()
                                          .Skip(skip)
                                          .Take(pageSize)
                                          .GetContentResult();

            var response = new SearchResponse()
            {
                TotalRecords = searchResult.TotalMatching,
                Results = searchResult.Items.Cast<ISitePageData>().ToList()
            };

            return Task.FromResult(response);
        }
    }
}