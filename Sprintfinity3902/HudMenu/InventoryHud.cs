using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Entities;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sound;
using System;
using System.Collections;
using System.Collections.Generic;
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


        public static IEntity createObjectByClassType(Type clazz, Vector2 pos)
        {
            // .. do construction work here
            Object theObject = Activator.CreateInstance(clazz, pos);
            return (IEntity)theObject;
        }

        private static Dictionary<IPlayer.SelectableWeapons, Type> weaponEnumToEntity;

        private static float ICON_MARGIN = 1.5f;

        private static Vector2[,] iconMatrix = new Vector2[2, 4] {
            {new Vector2(530,190), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*1,190), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*2,190), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*3,190)},
            {new Vector2(530,264), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*1,264), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*2,264), new Vector2(530 + Global.Var.TILE_SIZE*Global.Var.SCALE*ICON_MARGIN*3,264)}
        };

        //private static Player.SelectableWeapons[] values = (Player.SelectableWeapons[])Enum.GetValues(typeof(Player.SelectableWeapons));
        private static int blackTileSquareWidth = 8;

        private Game1 Game;
        private IPlayer Link;
        private OrderedSet<IPlayer.SelectableWeapons> availableItems;
        private IEntity itemSelectedIcon;

        private DungeonHud parent;

        public InventoryHud(DungeonHud _parent)
        {
            parent = _parent;
            Icons = new List<IEntity>();
            WorldPoint = new Vector2(0, -176 * Global.Var.SCALE);
            itemSelectedIcon = new ItemSelectIcon(new Vector2(0, 0));
            availableItems = new OrderedSet<IPlayer.SelectableWeapons>();
            weaponEnumToEntity = new Dictionary<IPlayer.SelectableWeapons, Type>() {
                {IPlayer.SelectableWeapons.BOW , typeof(BowIcon)},
                {IPlayer.SelectableWeapons.BOOMERANG , typeof(BoomerangIcon)},
                {IPlayer.SelectableWeapons.BOMB , typeof(BombIcon)},
                {IPlayer.SelectableWeapons.NONE , typeof(BlackLongIcon) }
                /*Add necessary mappings here for ALL possible enum to icons*/

            };
            
            Game = parent.Game;
            Link = parent.Game.playerCharacter;
        }

        public void EnableItemInInventory(IPlayer.SelectableWeapons weapon)
        {
            if (!availableItems.Contains(weapon))
                availableItems.Add(weapon);
        }

        public void RemoveItemInInventory(IPlayer.SelectableWeapons weapon)
        {
            if (availableItems.Contains(weapon))
                availableItems.Remove(weapon);
        }

        public void MoveSelectorRight()
        {
            if (availableItems.Count == 0) return;
            if (!availableItems.Contains(Link.SelectedWeapon)) return;
            int currentPos = availableItems.IndexOf(Link.SelectedWeapon);
            Link.SelectedWeapon = currentPos == availableItems.Count - 1 ? availableItems[0] : availableItems[currentPos + 1];
            MoveSelector(Link);
            SoundLoader.Instance.GetSound(SoundLoader.Sounds.LOZ_Get_Rupee).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            ((InGameHud)parent.InGame).UpdateSelectedItems(Link.SelectedWeapon);

        }

        public void MoveSelectorLeft()
        {
            if (availableItems.Count == 0) return;
            if (!availableItems.Contains(Link.SelectedWeapon)) return;
            int currentPos = availableItems.IndexOf(Link.SelectedWeapon);
            Link.SelectedWeapon = currentPos == 0 ? availableItems[availableItems.Count - 1] : availableItems[currentPos - 1];
            MoveSelector(Link);
            SoundLoader.Instance.GetSound(SoundLoader.Sounds.LOZ_Get_Rupee).Play(Global.Var.VOLUME, Global.Var.PITCH, Global.Var.PAN);
            ((InGameHud)parent.InGame).UpdateSelectedItems(Link.SelectedWeapon);

        }

        private void MoveSelector(IPlayer Link) {
            if (availableItems.Count == 0) return;
            Debug.WriteLine(availableItems.ToString());
            if (!availableItems.Contains(Link.SelectedWeapon)) return;
            int selectedIndex = availableItems.IndexOf(Link.SelectedWeapon);

            Vector2 selectPos = iconMatrix[selectedIndex / 4, selectedIndex % 4];
            itemSelectedIcon.Position = new Vector2(selectPos.X - 20, selectPos.Y);
        }

        public override void Update(GameTime gameTime)
        {
            itemSelectedIcon.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Color color)
        {
            pushMatrix(Icons.ToArray());

            foreach (IEntity icon in Icons) {
                icon.Draw(spriteBatch, Color.White);
            }
            
            for (int i = 0; i< availableItems.Count; i++) {
                IEntity usableItems = createObjectByClassType(weaponEnumToEntity[availableItems[i]], new Vector2(270,195));
                usableItems.Position = iconMatrix[i / 4, i % 4];
                pushMatrix(usableItems);
                usableItems.Draw(spriteBatch, Color.White);
                popMatrix(usableItems);
            }

            if (availableItems.Count > 0 && itemSelectedIcon.X != 0) {
                pushMatrix(itemSelectedIcon);
                itemSelectedIcon.Draw(spriteBatch, Color.White);
                popMatrix(itemSelectedIcon);
            }

            if (Link.SelectedWeapon != IPlayer.SelectableWeapons.NONE)
            {
                IEntity reference = createObjectByClassType(weaponEnumToEntity[Link.SelectedWeapon], new Vector2(270, 195));
                pushMatrix(reference);
                reference.Draw(spriteBatch, Color.White);
                popMatrix(reference);
            }

            popMatrix(Icons.ToArray());

        }

        public override void Initialize()
        {
            Icons.Add(new InventoryHudEntity(new Vector2(0, 0)));
            for (int i = 0; i < 12; i++) {
                for (int j = 0; j < 4; j++) {
                    Icons.Add(new BlackSquareIcon(new Vector2(500 + i * blackTileSquareWidth * Global.Var.SCALE, 40 + j * blackTileSquareWidth * Global.Var.SCALE)));
                }
            }

            for (int i = 0; i < 11; i++) {
                for (int j = 0; j < 4; j++) {
                    Icons.Add(new BlackSquareIcon(new Vector2(500 + i * blackTileSquareWidth * Global.Var.SCALE, 192 + j * blackTileSquareWidth * Global.Var.SCALE)));
                }
            }
        }
    }
}
