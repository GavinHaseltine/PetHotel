using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType {Shepherd, Poodle, Beagle, Bulldog, Terrier, Boxer, Labrador, Retriever}
    public enum PetColorType {White, Black, Golden, Tricolor, Spotted}
    public class Pet {
        public string name {get;set;}
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PetColorType color {get;set;}
        public DateTime checkedInAt {get;set;}  
        public int petOwnerid {get;set;}
        public int id {get;set;}
        public PetBreedType breed {get;set;}
        [ForeignKey("petOwner")]
        public int petOwnerId {get;set;}
        public PetOwner petOwner {get;set;}
    }
}

{
  "name" : "Fido",
  "color" : "White",
  "checkedInAt" : "2020-07-21T03:17:58.917069",
  "petOwnerid" : 1,
  "id" : 1,
  "breed" : "Beagle",
  "petOwner" : {
      "id" : 1,
      "petCount" : 1,
      "emailAddress" : "asdf@asdf.com",
      "name" : "blaine"
  }
}