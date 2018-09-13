using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    Rigidbody2D rbody;
    Vector2 movement = new Vector2(0, 0);
    Animator anim;

    public bool turn = true;
    public bool stop = false;
    bool retire = false;
    bool miss = false;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    {

        if (turn)
        {

            var number = Random.Range(1, 6);

            if (number < 4)
            {
                anim.SetBool("IsWalking", true);
                movement = new Vector2(5, 0);
                miss = false;

            }
            else
            {
                anim.SetBool("IsWalking", true);
                movement = new Vector2(5, 0);
                miss = true;
            }

            turn = false;
        }


        if (retire)
        {
            anim.SetBool("IsWalking", true);
            movement = new Vector2(-5, 0);
        }

        rbody.MovePosition(rbody.position + movement * Time.deltaTime);



        if (stop)
        {

            if (miss)
            {
                movement = new Vector2(0, 0);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsAttacking", true);
                //yield return new WaitForSeconds(1.1f);
                //collision.gameObject.GetComponent<Animator>().SetBool("IsHurt", true);
                //WaitForAnimation(collision.gameObject.GetComponent<Animation>());
                //yield return new WaitForSeconds(1f);
                anim.SetBool("IsAttacking", false);
                //rbody.MovePosition(rbody.position + new Vector2(0, 0));
                retire = true;
                stop = false;
            }
        }

    }

    public void setStop()
    {
        stop = true;
    }


    private IEnumerator WaitForAnimation(Animation animation)
    {
        do
        {
            yield return null;
        } while (animation.isPlaying);
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "Wall")
        {
            retire = false;
            anim.SetBool("IsWalking", false);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            // if (!miss)
            //  {
            movement = new Vector2(0, 0);
            anim.SetBool("IsWalking", false);
            anim.SetBool("IsAttacking", true);
            yield return new WaitForSeconds(1.1f);
            collision.gameObject.GetComponent<Animator>().SetBool("IsHurt", true);
            //WaitForAnimation(collision.gameObject.GetComponent<Animation>());
            yield return new WaitForSeconds(1f);
            anim.SetBool("IsAttacking", false);
            collision.gameObject.GetComponent<Animator>().SetBool("IsHurt", false);
            // rbody.MovePosition(rbody.position + new Vector2(0, 0));
            retire = true;
            //   }

        }

    }

}