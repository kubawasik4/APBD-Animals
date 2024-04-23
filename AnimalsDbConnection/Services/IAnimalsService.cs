
public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int AddAnimal(Animal animal);
    int UpdateAnimal(int id, Animal animal);
    int DeleteAnimal(int idAnimal);
}