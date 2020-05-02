using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
  
   
    public bool playerReached = false;


   public void Initialize()
    {
    
       playerReached = false;
    
    }

    public void PostInitialize() { 
      
    }
    public void Refresh(float dt)
    {

    }
    public void PhysicsRefresh()
    {

    }    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            /*Debug.Log(other.gameObject.name);*/
            playerReached = true;
        }
    }  
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            /*Debug.Log(other.gameObject.name);*/
            playerReached = false;
        }
    }
}
