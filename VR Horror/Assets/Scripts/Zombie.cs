using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float health;
   // public float speed;
    public float damage;
    public float minSpeed, maxSpeed;
    private float speed;

    private Animator anim;
    GameObject player;
    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        speed = Random.Range(minSpeed, maxSpeed);
        agent.speed = speed;

    }

    // Update is called once per frame
    void Update()
    {
        //death
        if(health <= 0)
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 0;
            anim.SetTrigger("Death");
            Destroy(gameObject, 2.5f);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
           anim.SetTrigger("Punch");
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Punch") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.2)
                other.GetComponent<Player>().health -= 10;
            //if (GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Punch"))


        }
    }

    private void OnDestroy()
    {
        player.GetComponent<Player>().score += 100;
    }

    private void OnCollisionEnter(Collision other)
    {

          
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
        Debug.Log("Zombie hit");
        health -= other.GetComponent<Bullet>().damage;
        Destroy(other.gameObject);
        }
    }

}
