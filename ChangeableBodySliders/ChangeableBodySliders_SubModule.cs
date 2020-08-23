using System;
using System.Windows.Forms;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.CampaignBehaviors;
using TaleWorlds.Core;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace ChangeableBodySliders
{
    public class ChangeableBodySliders_SubModule : MBSubModuleBase
    {

        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            try
            {
                TaleWorlds.Core.FaceGen.ShowDebugValues = true;
                //Want this to show up all the time, to let people know that the mod loaded successfully.
                ModDebug.DisplayDebugMessage($"Loaded submodule {ModDebug.ModName}", true);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ModDebug.ModLoadFailed.ToString()}\n{ex.Message} \n\n{ex.InnerException?.Message}");
            }

            

        }

        public override void OnGameLoaded(Game game, object initializerObject)
        {
            base.OnGameLoaded(game, initializerObject);

            CampaignGameStarter campaignInitializer = (CampaignGameStarter)initializerObject;

            //Enable the age, weight, and build sliders. I don't think I need to do this per se,
            // since I already flip this flag in OnSubModuleLoad, but it doesn't do any harm and I don't
            // know if the base.OnGameLoaded does anything with ShowDebugValues.
            TaleWorlds.Core.FaceGen.ShowDebugValues = true;

            ModDebug.DisplayDebugMessage("OnGameLoaded", ModDebug.ModDebugModeOn);

            

        }

        public override void OnGameInitializationFinished(Game game)
        {
            base.OnGameInitializationFinished(game);

            //Here's where I get rid of the old, broken DynamicBodyCampaignBehavior. 
            // I check if this current call of RemoveBehavior did it right, but this won't be able to tell
            // if a mod that loads after my mod does something with an assumedly extant DynamicBodyCampaignBehavior.
            Campaign.Current.CampaignBehaviorManager.RemoveBehavior<DynamicBodyCampaignBehavior>();

            var oldDynamicBodyBehavior = Campaign.Current.CampaignBehaviorManager.GetBehavior<DynamicBodyCampaignBehavior>();
            if (oldDynamicBodyBehavior != null)
            {
                ModDebug.DisplayDebugMessage($"Could not remove existing Dynamic Body Campaign Behavior. {ModDebug.ModName} might not work right as a consequence.", true);

            }



            //Add my custom behavior.
            Campaign.Current.CampaignBehaviorManager.AddBehavior(new HeroBodyPropertiesCampaignBehavior());

            //Self-check; query for existence of newly added behavior in the behavior list.
            HeroBodyPropertiesCampaignBehavior myBehavior = Campaign.Current.CampaignBehaviorManager.GetBehavior<HeroBodyPropertiesCampaignBehavior>();
            if (myBehavior == null)
            {
                ModDebug.DisplayDebugMessage("Failed to add HeroBodyProperties behavior -- you won't see skill/attribute based body changes, but you can still play.", true);
            }
            else
            {
                ModDebug.DisplayDebugMessage("Added HeroBodyProperties behavior successfully.", ModDebug.ModDebugModeOn);
            }
        }





    }
}
