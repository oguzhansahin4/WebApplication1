using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentacarController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();

        public RentacarController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<RentacarDto> GetList()
        {
            var Rentacars = _context.Rentacars.ToList();
            var RentacarsDtos = _mapper.Map<List<RentacarDto>>(Rentacars);
            return RentacarsDtos;
        }
        [HttpGet("{id}")]
        public RentacarDto Get(int id)
        {
            var Rentacar = _context.Rentacars.FirstOrDefault(x => x.Id == id);
            var RentacarDtos = _mapper.Map<RentacarDto>(Rentacar);
            return RentacarDtos;
        }

        [HttpPost]
        public RentacarDto RentacarDto(RentacarDto RentacarDto)
        {
            var Rentacar = _mapper.Map<Rentacar>(RentacarDto);
            _context.Rentacars.Add(Rentacar);
            _context.SaveChanges();
            return RentacarDto;
        }
        [HttpPut]
        public RentacarDto RentacarUpdateDto(RentacarDto RentacarDto)
        {
            var Rentacar = _mapper.Map<Rentacar>(RentacarDto);
            _context.Rentacars.Update(Rentacar);
            _context.SaveChanges();
            return RentacarDto;
        }
        [HttpDelete("{id}")]
        public ResultDto Delete(int id)
        {
            var Rentacar = _context.Rentacars.FirstOrDefault(x => x.Id == id);
            if (Rentacar != null)
            {
                _context.Rentacars.Remove(Rentacar);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Rentacar deleted";
            }
            else
            {
                result.Status = false;
                result.Message = "Rentacar not found";
            }
            return result;
        }
    }
}
