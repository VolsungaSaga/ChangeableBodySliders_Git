using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaleWorlds.Core;
using TaleWorlds.Localization;

namespace ChangeableBodySliders
{
    static class ModDebug
    {

        public static readonly TextObject ModName = new TextObject("Changeable Body Sliders");

        public static readonly TextObject ModLoadSuccess = new TextObject($"Loaded {ModName.ToString()}!");
        public static readonly TextObject ModLoadFailed = new TextObject($"Failed to load {ModName.ToString()}!");

        public static bool ModDebugModeOn = true;

        #region DEBUG_HELPER_FUNCTIONS

        public static void DisplayDebugMessage(string message, bool modDebugModeOn)
        {
            if (modDebugModeOn)
            {
                string message_header = $"{ModName}";


                InformationManager.DisplayMessage(new InformationMessage($"{message_header}:{message}"));
            }
        }


        #endregion
    }
}
