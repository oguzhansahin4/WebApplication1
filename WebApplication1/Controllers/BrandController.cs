using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        ResultDto result = new ResultDto();

        public BrandController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public List<BrandDto> GetList()
        {
            var Brands = _context.Brands.ToList();
            var BrandsDtos = _mapper.Map<List<BrandDto>>(Brands);
            return BrandsDtos;
        }
        [HttpGet("{id}")]
        public BrandDto Get(int id)
        {
            var Brand = _context.Brands.FirstOrDefault(x => x.Id == id);
            var BrandDtos = _mapper.Map<BrandDto>(Brand);
            return BrandDtos;
        }


        [HttpPost]
        public BrandDto BrandDto(BrandDto BrandDto)
        {
            var Brand = _mapper.Map<Brand>(BrandDto);
            _context.Brands.Add(Brand);
            _context.SaveChanges();
            return BrandDto;
        }
        [HttpPut]
        public BrandDto BrandUpdateDto(BrandDto BrandDto)
        {
            var Brand = _mapper.Map<Brand>(BrandDto);
            _context.Brands.Update(Brand);
            _context.SaveChanges();
            return BrandDto;
        }
        [HttpDelete("{id}")]
        public ResultDto Delete(int id)
        {
            var Brand = _context.Brands.FirstOrDefault(x => x.Id == id);
            if (Brand != null)
            {
                _context.Brands.Remove(Brand);
                _context.SaveChanges();
                result.Status = true;
                result.Message = "Brand deleted successfully";
            }
            else
            {
                result.Status = false;
                result.Message = "Brand not found";
            }
            return result;
        }
    }
}
