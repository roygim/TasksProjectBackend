using Microsoft.AspNetCore.Mvc;
using TasksProjectBackend.SimpleObjects;

namespace TasksProjectBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjectReflectionController : ControllerBase
    {
        private readonly ObjectReflectionService _objectReflectionService;

        public ObjectReflectionController(ObjectReflectionService objectReflectionService)
        {
            _objectReflectionService = objectReflectionService;
        }

        [HttpGet("GetData")]
        public string GetData()
        {
            Name n = new Name();
            n.firstName = "John";
            n.lastName = "Doe";

            Map m = new Map();
            m.x = 10.16516;
            m.y = 12.56465;

            Address a = new Address();
            a.street = "name 1";
            a.streetNum = 12;
            a.map = m;

            Person p = new Person();
            p.age = 55;
            p.name = n;
            p.address = a;

            return _objectReflectionService.GetData(p);
        }
    }
}
