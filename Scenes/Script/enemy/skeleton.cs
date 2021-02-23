using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : enemy , IDamageable
{
    public int Health { get; set; }
    public override void init()
    {
        base.init();
        Health = base.health;
    }
 
    public override void Movement()
    {
        base.Movement();

    }




    public void Damege()
    {
        if (Isdeath == true)
            return;
        
        Health--;       
        _anime.SetTrigger("hit");
        ishit = true;
        _anime.SetBool("InCombat",true);
        if(Health < 1)
        {
            Isdeath = true;
            _anime.SetTrigger("Death");
            GameObject diamond = Instantiate(DiamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
        
       
    }

}   