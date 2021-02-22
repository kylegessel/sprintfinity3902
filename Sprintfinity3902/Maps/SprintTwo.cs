using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Commands;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System.Collections.Generic;

namespace Sprintfinity3902.Maps
{
    public class SprintTwo : Map
    {

        private List<IEntity> cyclableBlocks;
        private List<IEntity> cyclableItems;
        private List<IEntity> cyclableCharacters;

        private int blockIndex;
        private int itemIndex;
        private int NPCIndex;

        public ILink playerCharacter;
        private IEntity boomerangItem;
        private IEntity bombItem;
        private IEntity movingSword;
        private IEntity goriyaBoomerang;

        public SprintTwo()
        {

            cyclableBlocks = new List<IEntity>();
            cyclableItems = new List<IEntity>();
            cyclableCharacters = new List<IEntity>();
        }

        public void Setup()
        {
            KeyboardManager.Instance.Reset();

            goriyaBoomerang = new BoomerangItem();


            cyclableItems.Add(new RupeeItem(new Vector2(500, 300)));
            cyclableItems.Add(new HeartItem(new Vector2(500, 300)));
            cyclableItems.Add(new CompassItem(new Vector2(500, 300)));
            cyclableItems.Add(new MapItem(new Vector2(500, 300)));
            cyclableItems.Add(new KeyItem(new Vector2(500, 300)));
            cyclableItems.Add(new HeartContainerItem(new Vector2(500, 300)));
            cyclableItems.Add(new ClockItem(new Vector2(500, 300)));
            cyclableItems.Add(new BowItem(new Vector2(500, 300)));
            cyclableItems.Add(new TriforceItem(new Vector2(500, 300)));
            cyclableItems.Add(new FairyItem(new Vector2(500, 300)));

            cyclableCharacters.Add(new SkeletonEnemy());
            cyclableCharacters.Add(new GelEnemy());
            cyclableCharacters.Add(new HandEnemy());
            cyclableCharacters.Add(new BlueBatEnemy());
            cyclableCharacters.Add(new SpikeEnemy());
            cyclableCharacters.Add(new GoriyaEnemy((BoomerangItem)goriyaBoomerang));
            cyclableCharacters.Add(new FinalBossEnemy());
            cyclableCharacters.Add(new OldManNPC());
            cyclableCharacters.Add(new Fire());

            cyclableBlocks.Add(new RegularBlock());
            cyclableBlocks.Add(new Face1Block());
            cyclableBlocks.Add(new Face2Block());
            cyclableBlocks.Add(new StairsBlock());
            cyclableBlocks.Add(new BrickBlock());
            cyclableBlocks.Add(new StripeBlock());
            cyclableBlocks.Add(new BlackBlock());
            cyclableBlocks.Add(new SpottedBlock());
            cyclableBlocks.Add(new DarkBlueBlock());
            playerCharacter = new Player();

            boomerangItem = new BoomerangItem();
            bombItem = new BombItem(new Vector2(-1000, -1000));
            movingSword = new MovingSwordItem(new Vector2(-1000, -1000));

            KeyboardManager.Instance.Initialize((Player)playerCharacter);

            KeyboardManager.Instance.RegisterKeyUpCallback(() => { ((Player)playerCharacter).CurrentState.Sprite.Animation.Stop(); }, Keys.W, Keys.A, Keys.S, Keys.D, Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.E);

            blockIndex = KeyboardManager.Instance.CreateNewDeltaKeys(Keys.T, Keys.Y);
            itemIndex = KeyboardManager.Instance.CreateNewDeltaKeys(Keys.U, Keys.I);
            NPCIndex = KeyboardManager.Instance.CreateNewDeltaKeys(Keys.O, Keys.P);

            // KeyboardManager.Instance.RegisterCommand(new SetDamageLinkCommand(this), Keys.E);
            KeyboardManager.Instance.RegisterCommand(new UseBombCommand((Player)playerCharacter, (BombItem)bombItem), Keys.D1);
            KeyboardManager.Instance.RegisterCommand(new UseBoomerangCommand((Player)playerCharacter, (BoomerangItem)boomerangItem), Keys.D2);
            KeyboardManager.Instance.RegisterCommand(new SetLinkAttackCommand((Player)playerCharacter, (MovingSwordItem)movingSword), Keys.Z, Keys.N);
        }



        public void Update(GameTime gameTime)
        {
            cyclableBlocks[KeyboardManager.Instance.GetCountDeltaKey(blockIndex, cyclableBlocks.Count)].Update(gameTime);
            cyclableItems[KeyboardManager.Instance.GetCountDeltaKey(itemIndex, cyclableItems.Count)].Update(gameTime);
            cyclableCharacters[KeyboardManager.Instance.GetCountDeltaKey(NPCIndex, cyclableCharacters.Count)].Update(gameTime);

            playerCharacter.Update(gameTime);
            boomerangItem.Update(gameTime);
            bombItem.Update(gameTime);
            movingSword.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            cyclableBlocks[KeyboardManager.Instance.GetCountDeltaKey(blockIndex, cyclableBlocks.Count)].Draw(spriteBatch);
            cyclableItems[KeyboardManager.Instance.GetCountDeltaKey(itemIndex, cyclableItems.Count)].Draw(spriteBatch);
            cyclableCharacters[KeyboardManager.Instance.GetCountDeltaKey(NPCIndex, cyclableCharacters.Count)].Draw(spriteBatch);

            playerCharacter.Draw(spriteBatch, Color.White);

            boomerangItem.Draw(spriteBatch);
            bombItem.Draw(spriteBatch);
            movingSword.Draw(spriteBatch);

        }


    }
}
