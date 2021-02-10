using Sprintfinity3902.Sprites;
using Sprintfinity3902.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprintfinity3902.States
{
    public class FacingDownAttackState : IPlayerState
    {
        public ISprite Sprite { get; set; }
        Player PlayerCharacter;

        public FacingDownAttackState(Player playerCharacter)
        {
            PlayerCharacter = playerCharacter;
            Sprite = new LinkDownAttackSprite(PlayerCharacter.Texture);
            
            if(Sprite.Animation.IsPlaying == false)
            {
                PlayerCharacter.setState(PlayerCharacter.facingDown);
            }
        }


        public void Move()
        {

            //Sprite.CurrentPositionY = Sprite.CurrentPositionY + 5;
            //PlayerCharacter.setCurrentPositionY(Sprite.CurrentPositionY);
        }

    }
}
