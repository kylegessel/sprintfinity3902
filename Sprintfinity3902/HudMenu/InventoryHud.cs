using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Link;
using System.Collections.Generic;
using Sprintfinity3902.Sprites.Fonts;
using Sprintfinity3902.Sprites;
using System;
using Sprintfinity3902.Sound;
using Sprintfinity3902.SpriteFactories;
using System.Collections;

namespace Sprintfinity3902.HudMenu
{
    public class InventoryHud : IHud
    {
        private class OrderedSet<T> : IList<T>
        {
            public T this[int index] { get => baseList[index]; set { baseList[index] = value; } }

            public int Count => baseList.Count;

            public bool IsReadOnly => false;

            private List<T> baseList;
            public OrderedSet()
            {
                baseList = new List<T>();
            }

            public void Add(T item)
            {
                if (baseList.Contains(item)) return;
                baseList.Add(item);
            }

            public void Clear() => baseList.Clear();
            public bool Contains(T item) => baseList.Contains(item);
            public void CopyTo(T[] array, int arrayIndex) => baseList.CopyTo(array, arrayIndex);
            public IEnumerator<T> GetEnumerator() => baseList.GetEnumerator();
            public int IndexOf(T item) => baseList.IndexOf(item);
            public void Insert(int index, T item) => baseList.Insert(index, item);
            public bool Remove(T item) => baseList.Remove(item);
            public void RemoveAt(int index) => baseList.RemoveAt(index);
            IEnumerator IEnumerable.GetEnumerator() => baseList.GetEnumerator();
        }



        private Game1 game;
        private Player Link;
        private Dictionary<Player.SelectableWeapons, ISprite> weaponEnumToEntity =
            new Dictionary<Player.SelectableWeapons, ISprite>() {
                {Player.SelectableWeapons.BOW , HudSpriteFactory.Instance.CreateBowIcon()},
                {Player.SelectableWeapons.BOOMERANG , HudSpriteFactory.Instance.CreateBoomerangIcon()},
                {Player.SelectableWeapons.BOMB , HudSpriteFactory.Instance.CreateBombIcon()}
                /*Add necessary mappings here for ALL possible enum to icons*/

            };

        private static float ICON_MARGIN = 1.5f;

        private static Vector2[,] iconMatrix = new Vector2[2, 4] {
            {new Vector2(530,190), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*1,190), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*2,190), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*3,190)},
            {new Vector2(530,264), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*1,264), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*2,264), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*3,264)}
        };

        //private static Player.SelectableWeapons[] values = (Player.SelectableWeapons[])Enum.GetValues(typeof(Player.SelectableWeapons));
        private static ISprite blackTile = HudSpriteFactory.Instance.CreateBlackLongIcon();

        private OrderedSet<Player.SelectableWeapons> availableItems;
        
        private IEntity itemSelectedIcon;
        public Vector2 WorldPoint { get; private set; }
        public List<IEntity> Icons { get; private set; }

        public InventoryHud(Game1 _game)
        {
            game = _game;
            Link = game.link;
            Icons = new List<IEntity>();
            WorldPoint = new Vector2(0, -176 * Global.Var.SCALE);
            itemSelectedIcon = new ItemSelectIcon(new Vector2());
            availableItems = new OrderedSet<Player.SelectableWeapons>();
            /*Add weapons to the inventory screen by doing this or calling method below,
             make sure to add these to the static dictionary above also*/
            availableItems.Add(Player.SelectableWeapons.BOMB);
            availableItems.Add(Player.SelectableWeapons.BOOMERANG);
            availableItems.Add(Player.SelectableWeapons.BOW);
            MoveSelector();
            Initialize();

        }

        public void EnableItemInInventory(Player.SelectableWeapons weapon)
        {
            availableItems.Add(weapon);
        }

        public void MoveSelectorRight()
        {
            if (availableItems.Count == 0) return;
            int currentPos = availableItems.IndexOf(game.link.SelectedWeapon);
            game.link.SelectedWeapon = currentPos == availableItems.Count - 1 ? availableItems[0] : availableItems[currentPos + 1];
            MoveSelector();
            SoundLoader.Instance.GetSound(SoundLoader.Sounds.LOZ_Get_Rupee).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
        }

        public void MoveSelectorLeft()
        {
            if (availableItems.Count == 0) return;
            int currentPos = availableItems.IndexOf(game.link.SelectedWeapon);
            game.link.SelectedWeapon = currentPos == 0 ? availableItems[availableItems.Count - 1] : availableItems[currentPos - 1];
            MoveSelector();
            SoundLoader.Instance.GetSound(SoundLoader.Sounds.LOZ_Get_Rupee).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
        }

        private void MoveSelector() {
            if (availableItems.Count == 0) return;
            int selectedIndex = availableItems.IndexOf(game.link.SelectedWeapon);

            Vector2 selectPos = iconMatrix[selectedIndex / 4, selectedIndex % 4];
            itemSelectedIcon.Position = new Vector2(selectPos.X - 20, selectPos.Y);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            pushMatrix();
            foreach (IEntity icon in Icons) {
                icon.Draw(spriteBatch, color);
            }

            for (int i = 0; i < 13; i++) {
                for (int j = 0; j < 2; j++) {
                    blackTile.Draw(spriteBatch, new Vector2(500 + i * blackTile.Animation.CurrentFrame.Width * Global.Var.SCALE, 40 + j * blackTile.Animation.CurrentFrame.Height * Global.Var.SCALE), Color.Black);
                }
            }

            for (int i = 0; i < 11; i++) {
                for (int j = 0; j < 2; j++) {
                    blackTile.Draw(spriteBatch, new Vector2(500 + i * blackTile.Animation.CurrentFrame.Width * Global.Var.SCALE, 192 + j * blackTile.Animation.CurrentFrame.Height * Global.Var.SCALE), Color.Black);
                }
            }

            for (int i = 0; i< availableItems.Count; i++) {
                weaponEnumToEntity[availableItems[i]].Draw(spriteBatch, iconMatrix[i / 4, i % 4], Color.White);
            }

            if (availableItems.Count > 0) {
                itemSelectedIcon.Draw(spriteBatch, Color.White);
            }

            weaponEnumToEntity[game.link.SelectedWeapon].Draw(spriteBatch, new Vector2(270, 194), Color.White);

            popMatrix();

        }

        private void pushMatrix() {

            foreach (IEntity icon in Icons) {
                icon.Position = new Vector2(icon.Position.X + WorldPoint.X, icon.Position.Y + WorldPoint.Y);
            }

        }

        private void popMatrix()
        {

            foreach (IEntity icon in Icons) {
                icon.Position = new Vector2(icon.Position.X - WorldPoint.X, icon.Position.Y - WorldPoint.Y);
            }

        }

        public void TranslateMatrix(Vector2 deltaVec) {
            WorldPoint = new Vector2(WorldPoint.X + deltaVec.X, WorldPoint.Y + deltaVec.Y);
        }

        public void Initialize()
        {
            Icons.Add(new InventoryHudEntity(new Vector2(0, 0)));
        }

    }
}
