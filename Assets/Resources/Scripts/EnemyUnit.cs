using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Ghosts }
public abstract class EnemyUnit : MonoBehaviour
{
    public virtual void Initialize()
    {
        
    }

    public virtual void PhysicsRefresh()
    {
       
    }

    public virtual void PostInitialize()
    {
        
    }

    public virtual void Refresh(float dt)
    {
       
    }
}
