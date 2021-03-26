using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using Sprintfinity3902.Sound;

namespace Sprintfinity3902.Commands
{
    public class SetLinkAttackCommand: ICommand
    {
        Player PlayerCharacter;
        MovingSwordItem MovingSword;
        SwordHitboxItem Sword;
        private string swordThrowInstanceID;
        private string swordSlashInstanceID;

        public SetLinkAttackCommand(Player player, MovingSwordItem movingSword, SwordHitboxItem sword)
        {
            PlayerCharacter = player;
            MovingSword = movingSword;
            Sword = sword;

            swordThrowInstanceID = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.LOZ_Sword_Shoot), 0.02f, false);
            swordSlashInstanceID = SoundManager.Instance.RegisterSoundEffectInst(SoundLoader.Instance.GetSound(SoundLoader.Sounds.LOZ_Sword_Slash), 0.02f, false);
        }

        public void Execute()
        {
            //if (PlayerCharacter.currentState != PlayerCharacter.facingDownAttack)
            //{
            //    PlayerCharacter.setState(PlayerCharacter.facingDownAttack);
            //}
            //else
            if (!MovingSword.getItemUse())
            {
                PlayerCharacter.Attack();
                Sword.UseItem(PlayerCharacter);
                MovingSword.UseItem(PlayerCharacter);

                SoundManager.Instance.GetSoundEffectInstance(swordThrowInstanceID).Play();
            }
            else
            {
                PlayerCharacter.Attack();
                Sword.UseItem(PlayerCharacter);

                SoundManager.Instance.GetSoundEffectInstance(swordSlashInstanceID).Play();
            }
        }
    }
}
