﻿using static Sprintfinity3902.Entities.AbstractEntity;

namespace Sprintfinity3902.Interfaces
{
    public interface IEnemy
    {
           int HitRegister(int damage, int stunLength, Direction projDirection);
    }
}