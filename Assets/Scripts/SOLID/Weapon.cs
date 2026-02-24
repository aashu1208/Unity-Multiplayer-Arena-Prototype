using UnityEngine;

public interface IWeapon
{
    void Attack();
}

public class Sword : IWeapon
{
    public void Attack()
    {

        Debug.Log("Sword attack");
    }
    
}


public class Gun : IWeapon
{
    public void Attack()
    {
        
        Debug.Log("Gun attack");
    }

}

public class Enemy
{
    public virtual void Fire()
    {
        Debug.Log("Enemy fire");

    }
}

public class Boss : Enemy
{

    public override void Fire()
    {
        Debug.Log("Boss Fire");
    }
}


