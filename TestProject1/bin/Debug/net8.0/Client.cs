using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestProject1
{
    public class Client
    {
       

        [JsonProperty("pays de naissance")]
        public string? Paysdenaissance { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("nom")]
        public string? Name { get; set; }

        [JsonProperty("phone")]
        public string? Phone { get; set; }

        [JsonProperty("adresse")]
        public string? Address { get; set; }

        [JsonProperty("Message")]
        public string? Message { get; set; }

        [JsonProperty("product")]
        public string? Product { get; set; }
    }
    /*public class Address
    {
        [JsonProperty("num")]
        public string? Num { get; set; }

        [JsonProperty("rue")]
        public string? Rue { get; set; }

        [JsonProperty("code postal")]
        public string? CodePostal { get; set; }

        [JsonProperty("Ville")]
        public string? Ville { get; set; }
    }*/
}



