using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using AutoMapper;

namespace Delphinus_Yachts.Automapper
{
    public class AutomapperWebConfig
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