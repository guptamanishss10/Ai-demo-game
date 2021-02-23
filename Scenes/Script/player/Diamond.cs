using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int gems = 1;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag == "Player")
        {
            player Player1 =other.GetComponent<player>();
            if (Player1 != null)
            {
                Player1.AddGems(gems);
                Destroy(this.gameObject);
            }
           
        }
 
    }
}
