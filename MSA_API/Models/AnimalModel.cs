using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class AnimalModel
{
    [JsonIgnore]
    public int Id { get; set; }                
    public int CityId { get; set; }             
    public int PetShopId { get; set; }         
    public string AnimalName { get; set; }            
    public string Type { get; set; }            
    public bool Available { get; set; }         
    public decimal Price { get; set; }          
    public string ContactNumber { get; set; }   
    public string Description { get; set; }     
    public int Age { get; set; }                
    public string Breed { get; set; }           
    public string Gender { get; set; }          
    public byte[]? AnimalImage { get; set; }     
}