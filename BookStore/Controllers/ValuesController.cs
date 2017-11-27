using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using BookStore.Models.Pagination;
using Swashbuckle.Swagger;
using Swashbuckle.Swagger.Annotations;

namespace BookStore.Controllers
{
    /// <summary>
    /// Values Controller
    /// </summary>
    public class ValuesController : ApiController
    {
        List<Phone> phones;

        public ValuesController()
        {
            phones = new List<Phone>
            {
                new Phone {Id = 1, Model = "Samsung Galaxy III", Producer = "Samsung"},
                new Phone {Id = 2, Model = "Samsung Ace II", Producer = "Samsung"},
                new Phone {Id = 3, Model = "HTC Hero", Producer = "HTC"},
                new Phone {Id = 4, Model = "HTC One S", Producer = "HTC"},
                new Phone {Id = 5, Model = "HTC One X", Producer = "HTC"},
                new Phone {Id = 6, Model = "LG Optimus 3D", Producer = "LG"},
                new Phone {Id = 7, Model = "Nokia N9", Producer = "Nokia"},
                new Phone {Id = 8, Model = "Samsung Galaxy Nexus", Producer = "Samsung"},
                new Phone {Id = 9, Model = "Sony Xperia X10", Producer = "SONY"},
                new Phone {Id = 10, Model = "Samsung Galaxy II", Producer = "Samsung"}
            };
        }

        /// <summary>
        /// Test request
        /// </summary>
        /// <param name="page"></param>
        /// <returns>test results</returns>
        [SwaggerResponseContentType(responseType:"text/plain", Exclusive=true)]
        [SwaggerResponse(HttpStatusCode.InternalServerError,"Bad Data")]
        public IndexViewModel Get(int page = 1)
        {
            int pageSize = 3; // количество объектов на страницу
            IEnumerable<Phone> phonesPerPages = phones.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phones.Count };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = phonesPerPages };
            return ivm;
        }
    }

    /// <summary>
    /// SwaggerResponseContentTypeAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class SwaggerResponseContentTypeAttribute : Attribute
    {
        /// <summary>
        /// SwaggerResponseContentTypeAttribute
        /// </summary>
        /// <param name="responseType"></param>
        public SwaggerResponseContentTypeAttribute(string responseType)
        {
            ResponseType = responseType;
        }
        /// <summary>
        /// Response Content Type
        /// </summary>
        public string ResponseType { get; private set; }

        /// <summary>
        /// Remove all other Response Content Types
        /// </summary>
        public bool Exclusive { get; set; }
    }

    public class ResponseContentTypeOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            var requestAttributes = apiDescription.GetControllerAndActionAttributes<SwaggerResponseContentTypeAttribute>().FirstOrDefault();

            if (requestAttributes != null)
            {
                if (requestAttributes.Exclusive)
                    operation.produces.Clear();

                operation.produces.Add(requestAttributes.ResponseType);
            }
        }
    }
}