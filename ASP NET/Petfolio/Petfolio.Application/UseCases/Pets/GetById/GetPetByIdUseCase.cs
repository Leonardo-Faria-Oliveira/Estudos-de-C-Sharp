using Microsoft.VisualBasic;
using Petfolio.Communication.Enums;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetById
{
    public class GetPetByIdUseCase
    {

        public ResponsePetJson Execute(int id)
        {
            return new ResponsePetJson
            {
                Id = id,
                Name = "Test",
                Birthday = new DateTime(year: 2024, month: 02, day: 03),
                Type = PetType.Dog
            };
        }
    }
}
