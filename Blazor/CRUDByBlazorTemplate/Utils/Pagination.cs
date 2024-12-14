namespace CRUDByBlazorTemplate.Utils
{
    public class Pagination<T> where T : class
    {

        public int Skip { get; set; }

        public int Take { get; set; }

        public int Total { get; set; }

        public List<T> Content { get; set; }

    }
}
