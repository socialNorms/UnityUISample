public class Actor
{
    int hp = 0;
    int attack = 0;
    

    public Actor(int _Hp, int _Attack)
    {
        hp = _Hp;
        attack = _Attack;
    }
    
    public int GetHp()
    {
        return hp;
    }
    public int GetAttack()
    {
        return attack;
    }
    public void SetHp(int _Hp)
    {
        hp = _Hp;   
    }
    public void SetAttack(int _Attack)
    {
        attack = _Attack;
    }
}
