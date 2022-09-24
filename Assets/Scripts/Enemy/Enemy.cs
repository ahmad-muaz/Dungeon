using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public GameObject diamondPrefab;

    [SerializeField]
    protected int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected int gems;
    [SerializeField]
    protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected bool isDead = false;

    protected bool isHit = false;

    //variable to store the player
    protected Player player;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        // if idle animation is playing
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("InCombat") == false)
        {
            // do nothing (return)
            return;
        }

        if(isDead == false)
            Movement();
    }

    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        //if current pos == point A
        if (transform.position == pointA.position)
        {
            // move to Point B
            currentTarget = pointB.position;
            anim.SetTrigger("Idle");
        }
        // else if current pos == point B
        else if (transform.position == pointB.position)
        {
            // move to point A
            currentTarget = pointA.position;
            anim.SetTrigger("Idle");
        }

        if(isHit == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        //check for the distance between player and enemy
        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        /*Debug.Log("Distance : " + distance + " for : " + transform.name);*/
        //if greater than 2 units
        if(distance > 2.0f)
        {
            //isHit = false
            isHit = false;
            //InCombat = false
            anim.SetBool("InCombat", false);
        }

        //Debug.Log("Distance : " + distance);

        Vector3 direction = player.transform.localPosition - transform.localPosition;

        //Debug.Log("Side : " + direction.x);

        if (direction.x > 0 && anim.GetBool("InCombat") == true)
        {
            //face right
            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("InCombat") == true)
        {
            //face left
            sprite.flipX = true;
        }
    }

    /*public abstract void Update();*/
    
}
