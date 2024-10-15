using AutoMapper;

namespace Store.Application.Common.Mappings.Configuration
{
    public class ProfilesConfiguration
    {
        public static IMapper MapProfiles()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AllowNullCollections = true;

                mc.AddProfile(new ProductProfile());
                mc.AddProfile(new CategoryProfile());

            });

            return mappingConfig.CreateMapper();
        }
    }
}
