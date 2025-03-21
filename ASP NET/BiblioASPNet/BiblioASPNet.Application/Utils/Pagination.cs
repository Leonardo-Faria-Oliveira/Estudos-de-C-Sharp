using BiblioASPNet.Application.Models;

namespace BiblioASPNet.Application.Utils
{
    public class Pagination<T> where T : BaseModel
    {

        public int Skip { get; set; }

        public int Total { get; set; }

        public int Take { get; set; }

        public ICollection<T> Content { get; set; }

    }
}
