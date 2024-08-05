using Newtonsoft.Json;
using ShoppingMiddleware.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static ShoppingMiddleware.Models.DTOModel.DBShopingDTOModel;
using System.Web.Http.Description;
using static ShoppingMiddleware.Models.Flutter.FlutterServiceDTOModel;

namespace ShoppingMiddleware.Controllers
{
    public class ProductServiceController : ApiController
    {
        private BackendFlutter2024Entities db = new BackendFlutter2024Entities();

    }
}
