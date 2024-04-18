using Ferramenta_correzione.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ferramenta_correzione.Services
{
    public interface IService<T>
    {
        IEnumerable<T> PrendiliTutti();
    }
}
