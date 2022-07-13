using Bookstore.models.Models;
using Bookstore.models.ViewModels;
using Bookstore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookstoreAPI.Controllers
{
    [ApiController]
    [Route("api/Publisher")]
    public class PublisherController : ControllerBase
    {
        PublisherRepository _publisherRepository = new PublisherRepository();

        [Route("list")]
        [HttpGet]
        public IActionResult GetPublishers(int pageIndex=1, int pageSize=10, string keyword = "")
        {
            var publishers = _publisherRepository.GetPublishers(pageIndex, pageSize, keyword);
            ListResponse<PublisherModel> listResponse = new ListResponse<PublisherModel>()
            {
                Records = publishers.Records.Select(c => new PublisherModel(c)).ToList(),
                TotalRecords = publishers.TotalRecords,
            };

            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetPublishers(int id)
        {
            var publisher = _publisherRepository.GetPubliser(id);
            PublisherModel publisherModel = new PublisherModel(publisher);

            return Ok(publisherModel);
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddPublishers(PublisherModel model)
        {
            Publisher publisher = new Publisher()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Contact = model.Contact,
            };

            var response = _publisherRepository.AddPublisher(publisher);
            PublisherModel publisherModel = new PublisherModel(response);

            return Ok(publisherModel);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult UpdatePublishers(PublisherModel model)
        {
            Publisher publisher = new Publisher()
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                Contact = model.Contact,
            };

            var response = _publisherRepository.UpdatePublisher(publisher);
            PublisherModel publisherModel = new PublisherModel(response);

            return Ok(publisherModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeletePublishers(int id)
        {
            var response = _publisherRepository.DeletePublisher(id);
            return Ok(response);
        }
    }
}
