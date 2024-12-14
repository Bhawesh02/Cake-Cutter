public class NormalEnemy : Enemy
{
    protected override void Init()
    {
        //TODO:
        m_enemyType = EnemyTypes.NORMAL;
    }

    protected override void CakeCut()
    {
        base.CakeCut();
    }
    
    protected override void AttackPlayer()
    {
        //DO Nothing.
    }
}