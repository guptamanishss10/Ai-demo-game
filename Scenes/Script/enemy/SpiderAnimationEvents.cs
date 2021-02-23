using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvents : MonoBehaviour
{
    private Sprider spider;

    public void Start()
    {
        spider = transform.parent.GetComponent<Sprider>();
    }
   public void fire()
    {
        spider.Attack();  
    }
}
