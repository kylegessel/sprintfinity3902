﻿using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Sprintfinity3902.Entities;
using Sprintfinity3902.SpriteFactories;

namespace Sprintfinity3902.States
{
    public class FacingDownState : IPlayerState
    {
        public ILink Player { get; set; }
        public ISprite Sprite { get; set; }

        public FacingDownState(ILink currentPlayer)
        {
            Player = currentPlayer;
            // Some type of if-else statement to get the damaged version?
            Sprite = PlayerSpriteFactory.Instance.CreateLinkDownSprite();
            
            Sprite.Animation.IsPlaying = false;
        }

        public void Move()
        {
            if (!Sprite.Animation.IsPlaying) {
                Sprite.Animation.Play();
            }
            Player.Y = Player.Y + 5;
        }

    }
}
