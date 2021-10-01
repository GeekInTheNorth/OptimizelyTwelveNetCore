namespace OptimizelyTwelveTest.Features.Search
{
    using MediatR;

    using System.Threading;
    using System.Threading.Tasks;

    public class SearchQueryHandler : IRequestHandler<SearchQuery, SearchResponse>
    {
        public Task<SearchResponse> Handle(SearchQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new SearchResponse());
        }
    }
}