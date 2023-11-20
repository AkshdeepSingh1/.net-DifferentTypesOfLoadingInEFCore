using LogicLayer.ModelsDTO;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace DifferentTypesOfLoadingInDotNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TryDifferentTypesOfLoading : ControllerBase
    {
        private readonly TryDifferentTypesOfLoadingService tryDifferentTypesOfLoadingService;
        public TryDifferentTypesOfLoading(TryDifferentTypesOfLoadingService tryDifferentTypesOfLoadingService)
        {
            this.tryDifferentTypesOfLoadingService = tryDifferentTypesOfLoadingService;
        }


        // To Try No loading hit this
        [HttpGet]
        public async Task<ActionResult> GetCustomerWithNoLoading(long id)
        {
            await tryDifferentTypesOfLoadingService.GetCustomerWithNoLoading(id);
            return Ok();
        }

        // To Try Eager Loading hit this
        [HttpGet]
        public async Task<ActionResult> GetCustomerWithEagerLoading1(long id)
        {
            await tryDifferentTypesOfLoadingService.GetCustomerWithEagerLoading1(id);
            return Ok();
        }

        // To Try Eager Loading hit this
        [HttpGet]
        public async Task<ActionResult> GetCustomerWithEagerLoading2(long id)
        {
            await tryDifferentTypesOfLoadingService.GetCustomerWithEagerLoading2(id);
            return Ok();
        }

        // To Try Eager Loading hit this
        [HttpGet]
        public async Task<ActionResult> GetCustomerWithEagerLoading3(long id)
        {
            await tryDifferentTypesOfLoadingService.GetCustomerWithEagerLoading3(id);
            return Ok();
        }

        // Before trying lazy loading we have to enable lazy loading in our project
        // Step1: Download a package called Microsoft.EntityFrameWorkCore.Proxies
        // Step2: While configuring the db context, configure lazy loading for whole project
        // Step3: All virtual keyword in all the related entities in db model.


        // To Try Lazy Loading hit this
        [HttpGet]
        public async Task<ActionResult> GetCustomerWithLazyLoading1(long id)
        {
            await tryDifferentTypesOfLoadingService.GetCustomerWithLazyLoading1(id);
            return Ok();
        }

        // To Try Lazy Loading hit this
        [HttpGet]
        public async Task<ActionResult> GetCustomerWithLazyLoading2(long id)
        {
            await tryDifferentTypesOfLoadingService.GetCustomerWithLazyLoading2(id);
            return Ok();
        }


        // To Try Explicit Loading hit this
        [HttpGet]
        public async Task<ActionResult> GetCustomerWithExplicitLoading(long id)
        {
            await tryDifferentTypesOfLoadingService.GetCustomerWithExplicitLoading(id);
            return Ok();
        }
    }
}
