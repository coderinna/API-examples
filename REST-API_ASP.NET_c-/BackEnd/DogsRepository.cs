

namespace DogsApi.Repo
{
    /// <summary>
    /// Luokka hallinnointiin
    /// </summary>
    public class DogsRepository
    {
        private List<Dog> dogs;

        public DogsRepository()
        {
            dogs = new List<Dog>();
            dogs.Add(new Dog { Id = 1, Name = "Musti" });
            dogs.Add(new Dog { Id = 2, Name = "Murre" });
            dogs.Add(new Dog { Id = 3, Name = "Tupsu" });
        }

        // ************* näytä kaikki nimet
        public List<Dog> GetAlldogs()
        {
            return dogs;
        }


        // ************* näytä koira nimi parametrin perusteella esim. Tupsu

        public List<Dog> GetAllDogs(string name)
        {
            var dogsFound = dogs.Where(dog => dog.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return dogsFound;
        }

        // ************* näytä tietty koira by id
        public List<Dog> GetDog()
        {

            return dogs;
        }


        // ************* lisää uusi mkoira

        public void AddDog(Dog Dog)
        {
           dogs.Add(Dog);
        }

        // ************* päivitä jo olemassa oleva koira
        public void UpdateDog(Dog dog)
        {
            foreach (var p in dogs)
            {
                if (p.Id == dog.Id)
                {
                    p.Name = dog.Name;
                    break;
                }
            }
        }



        // ************* poista koira by id
        public bool DeleteDog(Dog dog)
        {
            return DeleteDog(dog.Id);
        }

        public bool DeleteDog(int id)
        {
            Dog delete = null;

            foreach (var p in dogs)
            {
                if (p.Id == id)
                {
                    delete = p;
                    break;
                }
            }
            if (delete != null)
            {
                dogs.Remove(delete);
                return true;
            }

            return false;

        }

    }
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}