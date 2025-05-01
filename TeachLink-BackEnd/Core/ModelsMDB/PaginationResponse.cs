namespace TeachLink_BackEnd.Core.ModelsMDB
{
    public class PaginationResponse<T>
    {
        public IEnumerable<T> Items { get; set; }  
        public bool HasNextPage { get; set; }      
        public int TotalCount { get; set; }         
    }
}
