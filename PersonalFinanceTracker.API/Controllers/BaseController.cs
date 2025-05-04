using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.API.Interfaces;

namespace PersonalFinanceTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<TEntity, TController> : ControllerBase where TEntity : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly ILogger<TController> _logger;
        protected readonly IMapper _mapper;

        public BaseController(IRepository<TEntity> repository, IMapper mapper, ILogger<TController> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
    }
}