using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_NewBegining
{
    public class LevelSwitching
    {

        Map map = new Map();

        public void Level1ToLevel2(Player player, ContentManager content)
        {
            if (player.position.X >= 1370)
            {
                map.Unload();
                map.level_two(content);
                player.position = new Vector2(0, 0);
            }
        }
    }
}
