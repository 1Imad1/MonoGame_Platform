using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_NewBegining
{
    class Map : MapEngine
    {
        public bool lvl1 = false;
        public bool lvl2 = false;
        public bool lvl3 = false;

        public virtual void level_one(ContentManager content)
        {
            Tiles.Content = content;

            Generate(new int[,]{
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,},
                {2,1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,1,1,2,2,},
                {2,2,1,1,1,0,0,0,0,1,1,1,2,2,2,1,0,0,0,0,2,2,},
                {2,2,0,0,0,0,0,0,1,2,2,2,2,2,2,2,1,0,0,0,2,2,},
                {2,0,0,0,0,0,1,1,2,2,2,2,2,2,2,2,2,1,1,1,2,2,},
                {2,0,0,0,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
                {2,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,}
            }, 64);
        }

        public void level_two(ContentManager content)
        {
            Tiles.Content = content;

            Generate(new int[,]{
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,},
                {2,0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,2,},
                {2,0,0,0,0,0,0,1,1,1,0,0,0,1,1,1,0,0,0,0,0,2,},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,},
                {2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,},
                {2,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,}
            }, 64);
        }

        public void FromOneLevelToAnother(Player player, ContentManager content)
        {
            lvl1 = true;
            //from level 1 to level 2
            if (player.position.X >= 1370 && lvl1 == true)
            {
                Unload();

                level_two(content);
                player.position = new Vector2(0, 0);

                lvl2 = true;
            }

            //from
            if (player.position.X >= 1290 && lvl2 == true)
            {
                Unload();
                lvl2 = false;
                level_one(content);
                player.position = new Vector2(0, 0);
            }
        }

        public void Level2ToLevel3(Player player, ContentManager content)
        {
            if (player.position.X >= 1370 && lvl2 == true)
            {
                Unload();

                level_one(content);
                player.position = new Vector2(0, 0);
            }
        }
    }
}
