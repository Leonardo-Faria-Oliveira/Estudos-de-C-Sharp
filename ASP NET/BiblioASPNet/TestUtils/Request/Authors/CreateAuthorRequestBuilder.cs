using BiblioASPNet.Application.Requests.Authors;
using Bogus;

namespace TestUtils.Request.Authors
{
    public class CreateAuthorRequestBuilder
    {

        public static CreateAuthorRequest Build()
        {
            var faker = new Faker();

            return new CreateAuthorRequest
            (
                Name: faker.Person.FirstName,
                About: faker.Lorem.Paragraph()
            );
        }

        public static CreateAuthorRequest Build(string emptyProp, string? testProp)
        {
            var faker = new Faker();

            if(emptyProp == "name")
            {
                return new CreateAuthorRequest
                (
                    Name: testProp,
                    About: faker.Lorem.Paragraph()
                );
            }

            if (emptyProp == "about")
            {
                return new CreateAuthorRequest
                (
                    Name: faker.Person.FirstName,
                    About: testProp
                );
            }

            return new CreateAuthorRequest
            (
                Name: faker.Person.FirstName,
                About: faker.Lorem.Paragraph()
            );
        }

    }
}
