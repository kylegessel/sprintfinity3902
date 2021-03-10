using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.Entities.Items
{
    public abstract class AbstractItem : AbstractEntity,  IItem
    {
        private IItem.ITEMS id;

        public IItem.ITEMS ID {
            get { return id; }
            set { id = value; }
        }
    }
}
