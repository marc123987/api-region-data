using Microsoft.AspNetCore.Mvc;
using ValueAPI.DTO;
using ValueData.DAO;
using ValueData.DAO.DTO;

namespace ValueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : Controller
    {
        private readonly ILogger<RegionController> logger;

        public RegionController(ILogger<RegionController> log)
        {
            logger = log;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("region")]
        public ActionResult<List<RegionDTO>> GetAllRegion()
        {
            try
            {
                IRegionDAO regionDAO = new RegionDAO();
                return Ok(new ContenedorDTO<List<RegionDTO>>()
                {
                    Contenido = regionDAO.GetAllRegion()
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
                return Ok(new ContenedorDTO<List<RegionDTO>>()
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("region/{IdRegion}")]
        public ActionResult<RegionDTO> GetRegionById(int IdRegion)
        {
            try
            {
                if (IdRegion <= 0)
                {
                    throw new Exception("IdRegion no puede ser menor o igual a 0");
                }
                IRegionDAO regionDAO = new RegionDAO();
                return Ok(new ContenedorDTO<RegionDTO>()
                {
                    Contenido = regionDAO.GetRegionById(IdRegion)
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
                return Ok(new ContenedorDTO<RegionDTO>()
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("region/{IdRegion}/comuna")]
        public ActionResult<List<ComunaDTO>> GetComunaByRegion(int IdRegion)
        {
            try
            {
                if (IdRegion <= 0)
                {
                    throw new Exception("IdRegion no puede ser menor o igual a 0");
                }
                IRegionDAO regionDAO = new RegionDAO();
                return Ok(new ContenedorDTO<List<ComunaDTO>>()
                {
                    Contenido = regionDAO.GetComunaByRegion(IdRegion)
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
                return Ok(new ContenedorDTO<List<ComunaDTO>>()
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("region/{IdRegion}/comuna/{IdComuna}")]
        public ActionResult<ComunaDTO> GetComunaByRegionAndId(int IdRegion, int IdComuna)
        {
            try
            {
                if (IdRegion <= 0)
                {
                    throw new Exception("IdRegion no puede ser menor o igual a 0");
                }
                if (IdComuna <= 0)
                {
                    throw new Exception("IdComuna no puede ser menor o igual a 0");
                }
                IRegionDAO regionDAO = new RegionDAO();
                return Ok(new ContenedorDTO<ComunaDTO>()
                {
                    Contenido = regionDAO.GetComunaByRegionAndId(IdRegion, IdComuna)
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
                return Ok(new ContenedorDTO<ComunaDTO>()
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPost("region/{IdRegion}/comuna")]
        public ActionResult<bool> UpdateComuna(ComunaDTO dto, int IdRegion)
        {
            try
            {
                if (dto.IdRegion <= 0)
                {
                    throw new Exception("IdRegion no puede ser menor o igual a 0");
                }
                if (dto.IdComuna <= 0)
                {
                    throw new Exception("IdComuna no puede ser menor o igual a 0");
                }
                if (string.IsNullOrWhiteSpace(dto.Comuna))
                {
                    throw new Exception("Comuna no puede ser un espacio vacío");
                }
                if (dto.Comuna.Length >= 128)
                {
                    throw new Exception("Comuna no puede exceder los 128 caracteres");
                }
                IRegionDAO regionDAO = new RegionDAO();
                regionDAO.UpdateComuna(dto);
                return Ok(new ContenedorDTO<bool>()
                {
                    Contenido = true
                });
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error");
                return Ok(new ContenedorDTO<bool>()
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}
