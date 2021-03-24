using System.Collections.Generic;

namespace Sprintfinity3902.Interfaces
{
    public interface IHud : IUpdateable
    {
        List<IEntity> Icons { get; set; }

        void Initialize();
    }
}
