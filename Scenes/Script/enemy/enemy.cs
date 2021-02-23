using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class enemy : MonoBehaviour
{
    public GameObject DiamondPrefab;
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;
    [SerializeField] protected Transform PointA;
    [SerializeField] protected Transform PointB;
    protected Vector3 _switch;
    protected Animator _anime;
    protected SpriteRenderer _mossSprite;
    protected bool ishit = false;
    
    protected player Player;
    protected bool Isdeath = false;

    public virtual void init()
    {
        
        _anime = GetComponentInChildren<Animator>();
        _mossSprite = GetComponentInChildren<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
    }
    public void Start()
    {
        init();
    }
    public virtual void Update()
    {

        if ((_anime.GetCurrentAnimatorStateInfo(0).IsName("idle")) && (_anime.GetBool("InCombat")==false))
        {
            return;
        }
        if(Isdeath == false)
            Movement();
        
    }
    public virtual void Movement()
    {
        if (_switch == PointA.position)
        {
            _mossSprite.flipX = true;
        }
        else
        {
            _mossSprite.flipX = false;
        }
        if (transform.position == PointA.position)
        {
            _switch = PointB.position;
            _anime.SetTrigger("idle");
        }
        else if (transform.position == PointB.position)
        {
            _switch = PointA.position;
            _anime.SetTrigger("idle");
        }
        if (ishit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switch, speed * Time.deltaTime);

        }

        float distance = Vector3.Distance(Player.transform.localPosition, transform.localPosition);
        if(distance > 2.0f)
        {
            ishit = false;
            _anime.SetBool("InCombat", false);

        }
       
        Vector3 Direction = Player.transform.localPosition - transform.localPosition;
        if (Direction.x > 0 && _anime.GetBool("InCombat") == true)
        {
            _mossSprite.flipX = false;
        }
        else if (Direction.x < 0 && _anime.GetBool("InCombat") == true)
        {
            _mossSprite.flipX = true;
        }

    }
}
