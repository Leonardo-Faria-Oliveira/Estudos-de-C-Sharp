

using System.Collections;

namespace CRUDByBlazorTemplate.Response
{
    public abstract class PaginateResponse<T>
    {


        public int Skip { get; set; }

        public int Take { get; set; }

        public int Total { get; set; }

        public List<T>? Dtos { get; set; }

    }
}
