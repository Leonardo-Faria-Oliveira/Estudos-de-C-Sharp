using AutoMapper;
using BiblioASPNet.Application.Utils;

namespace TestUtils.Mapper
{
    public class AutoMapperBuilder
    {

        public static IMapper Build()
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new AutoMapperConfig());
            });

            return mapper.CreateMapper();
        }

    }
}
