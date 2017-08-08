using BeFree.Model;

namespace BeFreeAPI
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
                cfg.AddProfile<ModelProfile>();
            });
        }
    }
}