﻿
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tapioca.HATEOAS;

namespace AuthJWT.Domain.Model.Entities
{
    //public class UsuariosEnricher : ObjectContentResponseEnricher<Usuarios>
    //{
    //    protected override Task EnrichModel(Usuarios content, IUrlHelper urlHelper)
    //    {
    //        var path = "api/user";
    //        var url = new { controller = path, id = content.Id };

    //        content.Links.Add(new HyperMediaLink()
    //        {
    //            Action = HttpActionVerb.GET,
    //            Href = urlHelper.Link("Default API", url),
    //            Rel = RelationType.self,
    //            Type = ResponseTypeFormat.DefaultGet
    //        });

    //        content.Links.Add(new HyperMediaLink()
    //        {
    //            Action = HttpActionVerb.PUT,
    //            Href = urlHelper.Link("Default API", url),
    //            Rel = RelationType.self,
    //            Type = ResponseTypeFormat.DefaultPost
    //        });

    //        content.Links.Add(new HyperMediaLink()
    //        {
    //            Action = HttpActionVerb.POST,
    //            Href = urlHelper.Link("Default API", url),
    //            Rel = RelationType.self,
    //            Type = ResponseTypeFormat.DefaultPost
    //        });

    //        content.Links.Add(new HyperMediaLink()
    //        {
    //            Action = HttpActionVerb.DELETE,
    //            Href = urlHelper.Link("Default API", url),
    //            Rel = RelationType.self,
    //            Type = "int"
    //        });

    //        return null;
    //    }
    //}
}
