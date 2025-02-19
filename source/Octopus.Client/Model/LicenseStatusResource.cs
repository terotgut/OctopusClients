using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Octopus.Client.Serialization;

namespace Octopus.Client.Model
{
    public static class LicenseKinds
    {
        public static readonly string Unlicensed = "Unlicensed";
        public static readonly string Trial = "Trial";
        public static readonly string CommunityEdition = "CommunityEdition";
        public static readonly string CommercialLicense = "CommercialLicense";
    }
    
    public static class LicenseMessageDispositions
    {
        public static readonly string Information = "Information";
        public static readonly string Warning = "Warning";
        public static readonly string Error = "Error";
    }

    public class LicenseStatusResource : Resource
    {
        /// <summary>
        /// One of the values from LicenseKinds
        /// </summary>
        public string LicenseKind { get; set; }
        public bool IsCompliant { get; set; }
        public string HostingEnvironment { get; set; }
        public string ComplianceSummary { get; set; }
        
        [JsonConverter(typeof(DateConverter))]
        public DateTime EffectiveExpiryDate { get; set; }
        public int DaysToEffectiveExpiryDate { get; set; }
        public LicenseMessageResource[] Messages { get; set; }
        public LicenseLimitStatusResource[] Limits { get; set; }
    }
    
    public class LicenseMessageResource
    {
        public string Message { get; set; }
        
        /// <summary>
        /// One of the values from LicenseMessageDispositions
        /// </summary>
        public string Disposition { get; set; }
    }
    
    public class LicenseLimitStatusResource
    {
        public string Name { get; set; }
        public int EffectiveLimit { get; set; }
        public string EffectiveLimitDescription { get; set; }
        public bool IsUnlimited { get; set; }
        public int CurrentUsage { get; set; }
        public string Message { get; set; }
        
        /// <summary>
        /// One of the values from LicenseMessageDispositions
        /// </summary>
        public string Disposition { get; set; }
    }
}