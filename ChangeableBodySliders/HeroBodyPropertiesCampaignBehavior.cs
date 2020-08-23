using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace ChangeableBodySliders
{
    class HeroBodyPropertiesCampaignBehavior : CampaignBehaviorBase
    {
        //This is where we tell the engine , "Hey, whenever some event happens, do this little function!"
        // Repeat as necessary to give it more and more things to do when the event is triggered. 
        public override void RegisterEvents()
        {
            CampaignEvents.OnGameLoadFinishedEvent.AddNonSerializedListener((object)this, new Action(OnGameLoaded));
        }

        public override void SyncData(IDataStore dataStore)
        {
            //This is how you save data, seems like. I plan for this mod to not save anything to enhance compatibility,
            // so this will remain a blank function.

            ;
        }

        #region EVENT_OVERRIDES
        private void OnDailyTick() {
            
        }

        private void OnGameLoaded() {
            ModDebug.DisplayDebugMessage("OnGameLoadFinishedEvent - Here I am!", ModDebug.ModDebugModeOn);
        
        }

        #endregion
        //Calculates the maximum of a hero's build. 
        //Uses skills and attributes (e.g. OneHanded and TwoHanded, Vigor and Control)

        #region BUILD_AND_WEIGHT_CALC
        private float CalculateMaxHeroBuild(Hero hero) {
            
            int heroOneHandedSkill = hero.GetSkillValue(new SkillObject("OneHanded"));
            int heroTwoHandedSkill = hero.GetSkillValue(new SkillObject("TwoHanded"));
            int heroPolearmSkill = hero.GetSkillValue(new SkillObject("Polearm"));
            int heroAthleticsSkill = hero.GetSkillValue(new SkillObject("Athletics"));

            int heroVigor = hero.GetAttributeValue(CharacterAttributesEnum.Vigor);
            int heroEndurance = hero.GetAttributeValue(CharacterAttributesEnum.Endurance);




            return 1.0f;
        }

        #endregion
        //Sigmoid function

        #region MATH_HELPERS
        private float sigmoid(float x)
        {
            return 1.0f;
        }

        #endregion

    }
}
