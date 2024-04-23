using AnimalsDbConnection.Repositores;

namespace AnimalsDbConnection.Services;

public class AnimalsService : IAnimalsService
{
    private readonly IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return _animalsRepository.GetAnimals(orderBy);
    }

    public int AddAnimal(Animal animal)
    {
        return _animalsRepository.AddAnimal(animal);
    }

    public int UpdateAnimal(int id,Animal animal)
    {
        return _animalsRepository.UpdateAnimal(id, animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        return _animalsRepository.DeleteAnimal(idAnimal);
    }
    
}