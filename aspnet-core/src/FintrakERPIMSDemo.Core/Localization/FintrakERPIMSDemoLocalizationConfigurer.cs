using System.Reflection;
using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace FintrakERPIMSDemo.Localization
{
    public static class FintrakERPIMSDemoLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(
                    FintrakERPIMSDemoConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(FintrakERPIMSDemoLocalizationConfigurer).GetAssembly(),
                        "FintrakERPIMSDemo.Localization.FintrakERPIMSDemo"
                    )
                )
            );
        }
    }
}