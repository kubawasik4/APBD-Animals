using System.ComponentModel.DataAnnotations;
using AnimalsDbConnection.Validators;

public class Animal
{
    public int IdAnimal { get; set; }
    [Required]
    [MaxLength(50)]
    [StringValidator(ErrorMessage = "pole Name nie moze miec nazwy 'string'")]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    [StringValidator(ErrorMessage = "pole Description nie moze miec nazwy 'string'")]
    public string Description { get; set; }
    [Required]
    [MaxLength(20)]
    [StringValidator(ErrorMessage = "pole Category nie moze miec nazwy 'string'")]
    public string Category { get; set; }
    [Required]
    [MaxLength(20)]
    [StringValidator(ErrorMessage = "pole Area nie moze miec nazwy 'string'")]
    public string Area { get; set; }
   
}