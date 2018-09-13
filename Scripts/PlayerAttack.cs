using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private AudioSource source;
    public AudioClip swordSound;
    public AudioClip magicSound;



    Rigidbody2D rbody;
    Vector2 movement = new Vector2(0, 0);
    Animator anim;

    public bool turnHero = true;

    bool attacking = false;
    bool retire = false;
    bool miss = false;

    public int speed = 5;
    int attackPlayerPhysChance = InitializeValues.strenght + InitializeValues.stamina;
    int attackPlayerPhysDamage = InitializeValues.stamina + InitializeValues.swordValue;

    int attackPlayerSpellCost = 5;
    int attackPlayerSpellDamage = InitializeValues.ability1 + InitializeValues.integrity - 9;

    int intrevalMax = 20;

    EnemyAttack scriptEnemy;


    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scriptEnemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyAttack>();
        for (int i = 1; i < 18; ++i)
        {
            HideDamage(i);
        }
        source = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    void Update()
    {
        if (turnHero)
        {
            KeyCode attack1 = KeyCode.A;
            if (Input.GetKeyDown(attack1))
            {
                var number = Random.Range(1, intrevalMax);

                if (number > attackPlayerPhysChance)
                {
                    miss = true;
                }
                attacking = true;
                anim.SetBool("IsWalking", true);
                movement = new Vector2(speed, 0);
                turnHero = false;
            }

            KeyCode magicAttack = KeyCode.S;
            if (Input.GetKeyDown(magicAttack))
            {
                if (InitializeValues.manaPoints >= attackPlayerSpellCost)
                {
                    StartCoroutine("MagicAttack");
                    attacking = true;
                    turnHero = false;
                }
            }

        }

        if (retire)
        {
            anim.SetBool("IsWalking", true);
            movement = new Vector2(-speed, 0);
        }

        rbody.MovePosition(rbody.position + movement * Time.deltaTime);
    }

    IEnumerator MagicAttack()
    {
        GameObject Enemy = GameObject.FindWithTag("Enemy");
        Animator magicOnEnemy = Enemy.transform.GetChild(0).gameObject.GetComponent<Animator>();
        anim.SetBool("IsAttacking", true);
        yield return new WaitForSeconds(0.3f);
        source.PlayOneShot(magicSound, 1f);
        magicOnEnemy.SetBool("SpellActive", true);
        ShowDamage(attackPlayerSpellDamage);
        yield return new WaitForSeconds(0.2f);
        HealthManager2.HurtPlayer(attackPlayerSpellDamage);
        ManaBar1.HurtPlayer(attackPlayerSpellCost);
        Enemy.GetComponent<Animator>().SetBool("IsHurt", true);
        if (HealthManager2.enemyHealth <= 0)
        {
            yield return new WaitForSeconds(0.3f);
            HideDamage(attackPlayerSpellDamage);
            Enemy.GetComponent<Animator>().SetBool("IsHurt", false);
            Enemy.GetComponent<Animator>().SetBool("IsDead", true);
            movement = new Vector2(0, 0);
            magicOnEnemy.SetBool("SpellActive", false);
        }
        else
        {
           
            yield return new WaitForSeconds(0.7f);
            HideDamage(attackPlayerSpellDamage);
            anim.SetBool("IsAttacking", false);
            Enemy.GetComponent<Animator>().SetBool("IsHurt", false);
            yield return new WaitForSeconds(0.3f);
            magicOnEnemy.SetBool("SpellActive", false);
            yield return new WaitForSeconds(0.5f);
            scriptEnemy.turnEnemy = true;
            attacking = false;
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy" && attacking)
        {
            if (!miss)
            {
                movement = new Vector2(0, 0);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsAttacking", true);
                ShowDamage(attackPlayerPhysDamage);
                yield return new WaitForSeconds(1.1f);
                source.PlayOneShot(swordSound, 1f);

                collision.gameObject.GetComponent<Animator>().SetBool("IsHurt", true);
                HealthManager2.HurtPlayer(attackPlayerPhysDamage);

                //WaitForAnimation(collision.gameObject.GetComponent<Animation>());

                if (HealthManager2.enemyHealth <= 0)
                {
                    yield return new WaitForSeconds(0.3f);
                    HideDamage(attackPlayerPhysDamage);
                    collision.gameObject.GetComponent<Animator>().SetBool("IsDead", true);
                }
                else {
                    yield return new WaitForSeconds(0.8f);
                    HideDamage(attackPlayerPhysDamage);

                    anim.SetBool("IsAttacking", false);
                    collision.gameObject.GetComponent<Animator>().SetBool("IsHurt", false);
                    retire = true;

                }
                // rbody.MovePosition(rbody.position + new Vector2(0, 0));
            }
            else
            {
                movement = new Vector2(-((speed)/3)*2, 0);
                yield return new WaitForSeconds(1.1f);
                movement = new Vector2(0, 0);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsAttacking", true);
                yield return new WaitForSeconds(1.1f);
                source.PlayOneShot(swordSound, 1f);
                yield return new WaitForSeconds(1.0f);
                anim.SetBool("IsAttacking", false);
                // rbody.MovePosition(rbody.position + new Vector2(0, 0));
                retire = true;
                miss = false;
            }
        }

        if (collision.gameObject.tag == "Wall")
        {
            retire = false;
            movement = new Vector2(0, 0);
            anim.SetBool("IsWalking", false);
            attacking = false;
            scriptEnemy.turnEnemy = true;
        }
    }

    void ShowDamage(int dmgValue)
    {
        GameObject.FindWithTag("Dmg" + dmgValue).transform.localScale = new Vector3(0.3f, 0.3f, 1);
    }
    void HideDamage(int dmgValue)
    {
        GameObject.FindWithTag("Dmg" + dmgValue).transform.localScale = new Vector3(0, 0, 0);
    }
}