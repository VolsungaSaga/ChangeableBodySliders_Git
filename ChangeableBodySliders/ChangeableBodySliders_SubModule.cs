using System;
using System.Windows.Forms;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace ChangeableBodySliders
{
    public class ChangeableBodySliders_SubModule : MBSubModuleBase
    {


        public readonly TextObject ModLoadSuccess = new TextObject("{=BodySliderEnabler_LoadSuccess} Loaded BodySliderEnabler!");
        public readonly TextObject ModLoadFailed = new TextObject("{=BodySliderEnabler_LoadFailed} Failed to load BodySliderEnabler! Dammit!");


        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            try
            {
                TaleWorlds.Core.FaceGen.ShowDebugValues = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ModLoadFailed.ToString()}\n{ex.Message} \n\n{ex.InnerException?.Message}");
            }

            

        }

        public override void OnGameLoaded(Game game, object initializerObject)
        {
            base.OnGameLoaded(game, initializerObject);

            CampaignGameStarter gameInitializer = (CampaignGameStarter)initializerObject;

            TaleWorlds.Core.FaceGen.ShowDebugValues = true;

        }

    }
}
