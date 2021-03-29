﻿using Sprintfinity3902.Link;
using Sprintfinity3902.Interfaces;

namespace Sprintfinity3902.Entities
{
    public class RupeePickup : IPickup
    {
        public RupeePickup()
        { 

        }

        public bool Pickup(Player Link)
        {
            Link.itemcount[IItem.ITEMS.RUPEE]++;

            Link.itemPickedUp = true;
            Sound.SoundLoader.Instance.GetSound(Sound.SoundLoader.Sounds.LOZ_Get_Rupee).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);

            return false;
        }

    }
}