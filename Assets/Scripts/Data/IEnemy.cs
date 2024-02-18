
namespace v_hero
{
    public interface IEnemy
    {
        float HealthPoints { get;}

        bool IsDead { get;}

        void NormalAttack();

        void SpecialAttack();

        void InsaneAttack();

        void UpdateHealth(float health);
    }
}
