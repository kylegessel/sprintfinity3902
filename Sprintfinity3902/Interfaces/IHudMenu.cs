using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Interfaces
{
    public interface IHud : IUpdateable
    {
        List<IEntity> Icons { get; set; }

        void AddIcons();
    }
}
