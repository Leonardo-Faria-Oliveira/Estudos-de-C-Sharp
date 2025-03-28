using BiblioASPNet.Application.Models;

namespace BiblioASPNet.Application.Utils
{
    public class Pagination<L>
    {

        public int Skip { get; set; }

        public int Total { get; set; }

        public int Take { get; set; }

        public ICollection<L> Content { get; set; }

    }
}
