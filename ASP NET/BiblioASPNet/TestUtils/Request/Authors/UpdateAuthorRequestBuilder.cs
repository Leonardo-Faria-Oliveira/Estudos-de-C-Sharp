using BiblioASPNet.Application.Requests.Authors;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUtils.Request.Authors
{
    public class UpdateAuthorRequestBuilder
    {

        public static UpdateAuthorRequest Build()
        {
            var faker = new Faker();

            return new UpdateAuthorRequest
            (
                Name: faker.Person.FirstName,
                About: faker.Lorem.Paragraph()
            );
        }

        public static UpdateAuthorRequest Build(string emptyProp, string? testProp)
        {
            var faker = new Faker();

            if (emptyProp == "name")
            {
                return new UpdateAuthorRequest
                (
                    Name: testProp,
                    About: faker.Lorem.Paragraph()
                );
            }

            if (emptyProp == "about")
            {
                return new UpdateAuthorRequest
                (
                    Name: faker.Person.FirstName,
                    About: testProp
                );
            }

            return new UpdateAuthorRequest
            (
                Name: faker.Person.FirstName,
                About: faker.Lorem.Paragraph()
            );
        }

    }
}
