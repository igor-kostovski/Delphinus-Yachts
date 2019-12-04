using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Delphinus_Yachts.Domain.Automapper
{
    public class AutomapperDomainConfig
    {
        public static IEnumerable<Profile> GetProfiles()
        {
            var assembly = Assembly.GetExecutingAssembly();

            return assembly
                .GetTypes()
                .Where(x => x.Name.EndsWith("Profile"))
                .Where(x => typeof(Profile).IsAssignableFrom(x) && x.IsPublic && !x.IsAbstract)
                .Distinct()
                .Select(x => (Profile)Activator.CreateInstance(x));
        }
    }
}
