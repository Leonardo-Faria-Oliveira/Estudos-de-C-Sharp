using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfolio.Communication.Responses
{
    public class ResponseErrorsJson
    {

        public ICollection<string> Errors { get; set; } = [];

    }
}
