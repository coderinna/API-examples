using Microsoft.AspNetCore.Mvc;
using DogsApi.Repo;

namespace Dogs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DogsController : ControllerBase
    {

        private static DogsRepository dogsRepository = new DogsRepository();



        /*********************** GET-pyynt�
        [HttpGet]
        [Route("api/dogs")]
        public List<Dog> Dogs([FromQuery] string? query)
        {

            var dogs = dogsRepository.GetAllDogs();

            if (string.IsNullOrEmpty(query))
            {
                return dogs;
            }
            else
            {
                var selectedDogs = new List<Dog>();

                foreach (var dog in dogs)
                {
                    if (dog.Name.Contains(query, StringComparison.InvariantCultureIgnoreCase))
                    {
                        selectedDogs.Add(dog);
                    }
                }

                return selectedDogs;

            }
        }
        */
        //*********************** GET-pyynt� yksi by Id 
        [HttpGet]
        [Route("api/dogs/{id}")]
        public ActionResult<Dog> dog(int id)
        {

            var dogs = dogsRepository.GetDog();

            foreach (var dog in dogs)
            {
                if (dog.Id == id)
                {
                    return Ok(dog);
                }
            }

            return NotFound();

        }

        //*********************** POST-pyynt� lis�� uusi koira

        [HttpPost]
        [Route("api/dogs")]
        public ActionResult AddDog(Dog dog)
        {

            dogsRepository.AddDog(dog);

            return Ok(dog);

        }

        //*********************** PUT-pyynt� p�ivit� koira
        [HttpPut]
        [Route("api/dogs/{id}")]
        public ActionResult UpdateDog(Dog dog)
        {
            dogsRepository.UpdateDog(dog);

            return Ok();
        }

        //*********************** DELETE-pyynt� poista koira

        [HttpDelete]
        [Route("api/dogs/{id}")]
        public ActionResult DeleteDog(Dog dog)
        {
            var result = dogsRepository.DeleteDog(dog);

            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        //*********************** GET-pyynt� perus tervehdys query parametrille nimi
        [HttpGet]
        [Route("MoiKoira")]
        public string Terve([FromQuery] string? x)
        {
            return "Moi koira:" + x;
        }


    }
}
