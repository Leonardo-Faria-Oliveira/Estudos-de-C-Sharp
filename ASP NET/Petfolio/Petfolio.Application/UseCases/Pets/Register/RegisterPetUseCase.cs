using Petfolio.Communication.Requests;
using Petfolio.Communication.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfolio.Application.UseCases.Pets.Register
{
    public class RegisterPetUseCase
    {

        public ResponseRegisterPetJson Execute(RequestPetJson request)
        {
            return new ResponseRegisterPetJson
            {
                Id = 1,
                Name = request.Name,
            };
        }

    }

}
