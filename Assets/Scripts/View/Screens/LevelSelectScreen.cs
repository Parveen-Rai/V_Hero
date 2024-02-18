using static v_hero.GameConstant;

namespace v_hero
{
    public class LevelSelectScreen : AbstractScreen
    {
        public override void OnHide()
        {
            throw new System.NotImplementedException();
        }

        public override void Onshow(object data = null)
        {
            throw new System.NotImplementedException();
        }

        public void OnClickLevel()
        {
            SCREEN.ShowScreen((int)SCREENS.GAME_SCREEN);
        }
    }
}
