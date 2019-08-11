using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_NewBegining
{
    /// <summary>
    /// Makes it possible to switch between Levels
    /// </summary>
    interface ILevels
    {
        bool Level1IsCurrentLevel { get; set; }
        bool Level2IsCurrentLevel { get; set; }
        bool Level3IsCurrentLevel { get; set; }
    }
}
