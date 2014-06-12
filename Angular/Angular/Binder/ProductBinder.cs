using Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Angular.Binder
{
    public class ProductBinder:IModelBinder
    {

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var imageFile = request.Files["Image"];
            var imageBytes = new byte[imageFile.ContentLength];
            imageFile.InputStream.Read(imageBytes,0,imageFile.ContentLength);
            var id = string.IsNullOrWhiteSpace(request.Params["Id"]) ? -1 : int.Parse(request.Params["Id"]);

            return new Product(){
                Id = id,
                Image = imageBytes,
                Name = request.Params["Name"],
                Price = decimal.Parse(request.Params["Price"])
            };
        }
    }
}