using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprintfinity3902.Interfaces;
using Sprintfinity3902.Sprites;
using System;
using System.Collections.Generic;

namespace Sprintfinity3902.SpriteFactories
{
    public class FontSpriteFactory
    {
        public static Texture2D Texture {
            get; private set;
        }

        private static FontSpriteFactory instance;
        
        private static string FONT_FILE_NAME = "NES - The Legend of Zelda - Fonts";
        private static Dictionary<char, Rectangle> sourceRectangles;
        public static int ITEMS_PER_ROW = 16;
        public static int ITEM_WIDTH = 16;
        public static int ITEM_HEIGHT = 16;
        private static string ALPHABET = "0123456789abcdefghijklmnopqrstuvwxyz,!'&.\"?- ";

        public static FontSpriteFactory Instance
        {
            get {
                if (instance == null) {
                    instance = new FontSpriteFactory();
                }
                return instance;
            }
        }

        private FontSpriteFactory() {
            sourceRectangles = new Dictionary<char, Rectangle>();
        }

        public void LoadAllTextures(ContentManager content)
        {
            Texture = content.Load<Texture2D>(FONT_FILE_NAME);

            char[] alpha = ALPHABET.ToCharArray();

            for (int j = 0; j < ITEMS_PER_ROW; j++) {
                for (int i = 0; i < ITEMS_PER_ROW; i++) {
                    int flattenedArrayIndex = j * ITEMS_PER_ROW + i;
                    try {
                        sourceRectangles.Add(alpha[flattenedArrayIndex], new Rectangle(330 + i*ITEM_WIDTH, 20 + j*ITEM_HEIGHT, ITEM_WIDTH, ITEM_HEIGHT));
                    } catch (Exception e) {
                        break;
                    }
                    
                }
            }
        }

        public List<Rectangle> GenerateSourceRectangles(string str) {
            List<Rectangle> ret = new List<Rectangle>();

            foreach (char c in str.ToLower()) {
                ret.Add(sourceRectangles[c]);
            }

            return ret;
        }

    }
}
