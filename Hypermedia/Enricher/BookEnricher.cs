using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Hypermedia;
using RestWithASPNETUdemy.Hypermedia.Constants;
using RestWithASPNETUdemy.Model.Base;

namespace RestWithASPNETUdemy.Model
{
  public class BookEnricher : ContentResponseEnricher<BookVO>
  {

    private readonly object _lock = new object();

    protected override Task EnrichModel(BookVO content, IUrlHelper urlHelper)
    {
      var path = "api/book/v1";
      string link = getLink(content.Id, urlHelper, path);
      content.Links.Add(new HyperMediaLink()
      {
        Action = HttpActionVerb.GET,
        Href = link,
        Rel = RelationType.self,
        Type = ResponseTypeFormat.DefaultGet
      });
      content.Links.Add(new HyperMediaLink()
      {
        Action = HttpActionVerb.POST,
        Href = link,
        Rel = RelationType.self,
        Type = ResponseTypeFormat.DefaultPost
      });
      content.Links.Add(new HyperMediaLink()
      {
        Action = HttpActionVerb.PUT,
        Href = link,
        Rel = RelationType.self,
        Type = ResponseTypeFormat.DefaultPut
      });
      content.Links.Add(new HyperMediaLink()
      {
        Action = HttpActionVerb.DELETE,
        Href = link,
        Rel = RelationType.self,
        Type = "int"
      });
      content.Links.Add(new HyperMediaLink()
      {
        Action = HttpActionVerb.PATCH,
        Href = link,
        Rel = RelationType.self,
        Type = ResponseTypeFormat.DefaultPatch
      });
      return null;
    }
    private string getLink(long id, IUrlHelper urlHelper, string path)
    {
      lock (_lock)
      {
        var url = new { controller = path, id = id };
        return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
      }
    }
  }
}

