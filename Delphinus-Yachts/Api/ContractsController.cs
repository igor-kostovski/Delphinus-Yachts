using System.Web.Http;
using AutoMapper;
using Delphinus_Yachts.Domain.Models;
using Delphinus_Yachts.Domain.Services;
using Delphinus_Yachts.DTOs;

namespace Delphinus_Yachts.Api
{
    public class ContractsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ContractService _contractService;

        public ContractsController(IMapper mapper, ContractService contractService)
        {
            _mapper = mapper;
            _contractService = contractService;
        }

        [HttpGet]
        public IHttpActionResult Get([FromUri]TableFilter filter)
        {
            var dataAndCount = _contractService.GetAll(filter);

            return Ok(dataAndCount);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var model = _contractService.Get(id);

            return Ok(_mapper.Map<ContractDTO>(model));
        }

        [HttpPost]
        public IHttpActionResult Create(ContractDTO dto)
        {
            var model = _mapper.Map<ContractModel>(dto);
            model = _contractService.Create(model);

            return Ok(model.Id);
        }

        [HttpPut]
        public IHttpActionResult Update(ContractDTO dto)
        {
            var model = _mapper.Map<ContractModel>(dto);
            model = _contractService.Update(model);

            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _contractService.Delete(id);

            return Ok();
        }
    }
}