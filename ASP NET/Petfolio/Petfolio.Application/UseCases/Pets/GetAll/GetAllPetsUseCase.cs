using Petfolio.Communication.Enums;
using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetAll
{
    public class GetAllPetsUseCase
    {

        public ResponseAllPetsJson Execute()
        {

            return new ResponseAllPetsJson
            {
                Pets = new List<ResponseShortPetJson>
                {
                    new ResponseShortPetJson {
                        Id = 1,
                        Name = "Test",
                        Type = PetType.Dog
                    }
                }
            };
        }

    }
}
