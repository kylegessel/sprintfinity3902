﻿using Microsoft.Xna.Framework;
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
using System.Diagnostics;

namespace Sprintfinity3902.HudMenu
{
    public class InventoryHud : AbstractHud
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



        
        private Dictionary<Player.SelectableWeapons, IEntity> weaponEnumToEntity =
            new Dictionary<Player.SelectableWeapons, IEntity>() {
                {Player.SelectableWeapons.BOW , new BowIcon(new Vector2())},
                {Player.SelectableWeapons.BOOMERANG , new BoomerangIcon(new Vector2())},
                {Player.SelectableWeapons.BOMB , new BoomerangIcon(new Vector2())}
                /*Add necessary mappings here for ALL possible enum to icons*/

            };

        private static float ICON_MARGIN = 1.5f;

        private static Vector2[,] iconMatrix = new Vector2[2, 4] {
            {new Vector2(530,190), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*1,190), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*2,190), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*3,190)},
            {new Vector2(530,264), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*1,264), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*2,264), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*3,264)}
        };

        //private static Player.SelectableWeapons[] values = (Player.SelectableWeapons[])Enum.GetValues(typeof(Player.SelectableWeapons));
        private static int blackTileSquareWidth = 8;

        private OrderedSet<Player.SelectableWeapons> availableItems;
        private ISprite hudInventoryBaseSprite;
        private IEntity itemSelectedIcon;
        private Game1 game;
        private Player Link;

        public InventoryHud(Game1 _game)
        {
            game = _game;
            Link = game.link;
            Icons = new List<IEntity>();
            WorldPoint = new Vector2(0, -176 * Global.Var.SCALE);
            itemSelectedIcon = new ItemSelectIcon(new Vector2());
            hudInventoryBaseSprite = HudSpriteFactory.Instance.CreateInventoryHud();
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

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            pushMatrix(Icons.ToArray());

            foreach (IEntity icon in Icons) {
                icon.Draw(spriteBatch, Color.White);
            }

            for (int i = 0; i< availableItems.Count; i++) {
                IEntity usableItems = weaponEnumToEntity[availableItems[i]];
                usableItems.Position = iconMatrix[i / 4, i % 4];
                pushMatrix(usableItems);
                usableItems.Draw(spriteBatch, Color.White);
                popMatrix(usableItems);
            }

            if (availableItems.Count > 0) {
                pushMatrix(itemSelectedIcon);
                itemSelectedIcon.Draw(spriteBatch, Color.White);
                popMatrix(itemSelectedIcon);
            }

            IEntity reference = weaponEnumToEntity[game.link.SelectedWeapon];
            pushMatrix(reference);
            reference.Draw(spriteBatch, Color.White);
            popMatrix(reference);

            popMatrix(Icons.ToArray());

        }

        public override void Initialize()
        {
            Icons.Add(new InventoryHudEntity(new Vector2(0, 0)));
            for (int i = 0; i < 13; i++) {
                for (int j = 0; j < 2; j++) {
                    Icons.Add(new BlackSquareIcon(new Vector2(500 + i * blackTileSquareWidth * Global.Var.SCALE, 40 + j * blackTileSquareWidth * Global.Var.SCALE)));
                }
            }

            for (int i = 0; i < 11; i++) {
                for (int j = 0; j < 2; j++) {
                    Icons.Add(new BlackSquareIcon(new Vector2(500 + i * blackTileSquareWidth * Global.Var.SCALE, 192 + j * blackTileSquareWidth * Global.Var.SCALE)));
                }
            }
        }

    }
}
