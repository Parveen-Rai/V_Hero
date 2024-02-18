
namespace v_hero
{
    public static class GameConstant
    {
        public enum SCREENS
        {
            MAIN_MENU,
            LEVEL_SELECT,
            GAME_SCREEN,
            NONE
        }

        public enum GAME_EVENTS
        {
            MOVE,
        }

        public static EventManager EVENT => EventManager.Instance;

        public static ScreenManager SCREEN => ScreenManager.Instance;

        public static PopUpManager POPUP => PopUpManager.Instance;

        public static TimeManager TIME => TimeManager.Instance;

        public static Player USER => Player.Instance;
    }
   

}