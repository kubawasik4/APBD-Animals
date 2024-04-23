using System.ComponentModel.DataAnnotations;

public class Animal
{
    public int IdAnimal { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    [MaxLength(20)]
    public string Area { get; set; }
   
}