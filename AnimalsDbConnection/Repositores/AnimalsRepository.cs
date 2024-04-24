using System.Data.SqlClient;
using AnimalsDbConnection.Services;

namespace AnimalsDbConnection.Repositores;

public class AnimalsRepository : IAnimalsRepository
{
    private readonly IAnimalsRepository _animalsRepository;
    public IConfiguration _configuration;

    public AnimalsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        var animals = new List<Animal>();
        
        using (var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            
            connection.Open();

            using (var cmd = new SqlCommand())
            {
                cmd.Connection = connection;
                var safeOrderBy = new string[] { "Name", "Description", "Category", "Area" }.Contains(orderBy) ? orderBy : "Name";
                cmd.CommandText = $"SELECT IdAnimal, Name, Description, Category, Area FROM Animal ORDER BY {safeOrderBy}";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var animal = new Animal
                    {
                        IdAnimal = (int)reader["IdAnimal"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Category = reader["Category"].ToString(),
                        Area = reader["Area"].ToString()
                    };
                    animals.Add(animal);
                }
            }
        }

        return animals;
    }

    public int AddAnimal(Animal animal)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        
            connection.Open();

            using var cmd = new SqlCommand();
            
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO Animal( Name, Description, Category, Area) VALUES( @Name, @Description, @Category, @Area)";
                cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
                cmd.Parameters.AddWithValue("@Name", animal.Name);
                cmd.Parameters.AddWithValue("@Description", animal.Description);
                cmd.Parameters.AddWithValue("@Category", animal.Category);
                cmd.Parameters.AddWithValue("@Area", animal.Area);
                var counter = cmd.ExecuteNonQuery();
                return counter;
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