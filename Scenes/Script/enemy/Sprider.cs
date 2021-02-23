using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprider : enemy,IDamageable
{
    public GameObject AcidEffectPrefab;
    public int Health { get; set; }

   
    public override void init()
    {
        base.init();
        Health = base.health;
    }
    public override void Update()
    {
        
    }
    public void Damege()
    {
        if (Isdeath == true)
            return;
        Health--;
        if (Health < 1)
        {
            Isdeath = true;
            _anime.SetTrigger("Death"); 
            GameObject diamond = Instantiate(DiamondPrefab, transform.position, Quaternion.identity) as GameObject;
            diamond.GetComponent<Diamond>().gems = base.gems;
        }
    }
    public override void Movement()
    {
        
    }
    public void Attack()
    {
        Instantiate(AcidEffectPrefab, transform.position, Quaternion.identity);
    }
}
