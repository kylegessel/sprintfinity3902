using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprintfinity3902.Controllers;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using System.Collections.Generic;

namespace Sprintfinity3902.Dungeon {
    public class DefaultMap : IMap {

        private List<IEntity> cyclableBlocks;
        private List<IEntity> cyclableItems;
        private List<IEntity> cyclableCharacters;

        private int blockIndex;
        private int itemIndex;
        private int NPCIndex;

        private IEntity goriyaBoomerang;
        private SkeletonEnemy skele;

        public DefaultMap() {

            //cyclableBlocks = new List<IEntity>();
            //cyclableItems = new List<IEntity>();
            //cyclableCharacters = new List<IEntity>();
        }

        public void Setup(Game1 gameInstance) {

            goriyaBoomerang = new BoomerangItem();
            skele = new SkeletonEnemy();

            cyclableBlocks = new List<IEntity>();
            cyclableItems = new List<IEntity>();
            cyclableCharacters = new List<IEntity>();

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

            cyclableCharacters.Add(skele);
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

            blockIndex = KeyboardManager.Instance.CreateNewDeltaKeys(Keys.T, Keys.Y);
            itemIndex = KeyboardManager.Instance.CreateNewDeltaKeys(Keys.U, Keys.I);
            NPCIndex = KeyboardManager.Instance.CreateNewDeltaKeys(Keys.O, Keys.P);

        }



        public void Update(GameTime gameTime) {
            cyclableBlocks[KeyboardManager.Instance.GetCountDeltaKey(blockIndex, cyclableBlocks.Count)].Update(gameTime);
            cyclableItems[KeyboardManager.Instance.GetCountDeltaKey(itemIndex, cyclableItems.Count)].Update(gameTime);
            cyclableCharacters[KeyboardManager.Instance.GetCountDeltaKey(NPCIndex, cyclableCharacters.Count)].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {

            cyclableBlocks[KeyboardManager.Instance.GetCountDeltaKey(blockIndex, cyclableBlocks.Count)].Draw(spriteBatch);
            cyclableItems[KeyboardManager.Instance.GetCountDeltaKey(itemIndex, cyclableItems.Count)].Draw(spriteBatch);
            cyclableCharacters[KeyboardManager.Instance.GetCountDeltaKey(NPCIndex, cyclableCharacters.Count)].Draw(spriteBatch);


        }


    }
}