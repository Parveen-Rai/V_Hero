using UnityEngine;
using static v_hero.GameConstant;


namespace v_hero
{
    public class MainMenuScreen : AbstractScreen
    {

        public override void Onshow(object data = null)
        {
            throw new System.NotImplementedException();
        }

        public override void OnHide()
        {
            throw new System.NotImplementedException();
        }

        public void OnClickPlayBtn()
        {
            SCREEN.ShowScreen((int)SCREENS.LEVEL_SELECT);
        }
    }
}
