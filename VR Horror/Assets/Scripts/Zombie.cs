using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public float health;
   // public float speed;
    public float damage;

    private Animator anim;
 

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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

}
