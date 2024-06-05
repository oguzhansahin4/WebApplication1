using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();

        public CarController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CarDto> GetList()
        {
            var Cars = _context.Cars.ToList();
            var CarsDtos = _mapper.Map<List<CarDto>>(Cars);
            return CarsDtos;
        }
        [HttpGet("{id}")]
        public CarDto Get(int id)
        {
            var Car = _context.Cars.FirstOrDefault(x => x.Id == id);
            var CarDtos = _mapper.Map<CarDto>(Car);
            return CarDtos;
        }

        [HttpPost]
        public CarDto CarDto(CarDto CarDto)
        {
            var Car = _mapper.Map<Car>(CarDto);
            _context.Cars.Add(Car);
            _context.SaveChanges();
            return CarDto;
        }
        [HttpPut]
        public CarDto CarUpdateDto(CarDto CarDto)
        {
            var Car = _mapper.Map<Car>(CarDto);
            _context.Cars.Update(Car);
            _context.SaveChanges();
            return CarDto;
        }
        [HttpDelete("{id}")]
        public ResultDto Delete(int id)
        {
            var Car = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (Car != null)
            {
                _context.Cars.Remove(Car);
                _context.SaveChanges();
            }
            return result;
        }
    }
}
