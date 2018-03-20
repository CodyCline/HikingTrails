using HikingTrails.Models;
using System.Collections.Generic;
namespace HikingTrails.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}