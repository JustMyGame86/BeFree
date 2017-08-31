namespace BeFree.Common
{
    public interface IFilter
    {
        string SearchTerm { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
        string OrderBy { get; set; }
        int Skip { get; set; }
        bool OrderAsc { get; set; }
    }
}
