using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    private AudioSource source;
    public AudioClip swordSound;
    public AudioClip magicSound;

    Rigidbody2D rbody;
    Vector2 movement = new Vector2(0, 0);
    Animator anim;

    bool attacking = false;

    public bool turnEnemy = false;
    bool retire = false;
    bool miss = false;

    public int speed = 5;
    public int attackEnemyPhysChance = 4;
    public int intrevalMaxPhys = 10;
    public int attackEnemyPhysDamage = 2;
    public int attackEnemySpellCost = 5;
    public int attackEnemySpellDamage = 4;
    public int chancheMagic;

    int attackType;

    PlayerAttack scriptHero;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        scriptHero = GameObject.FindWithTag("Hero").GetComponent<PlayerAttack>();
        for (int i = 1; i < 18; ++i) {
            HideDamage(i);
        }

        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (turnEnemy)
        {
            attackType = Random.Range(0, chancheMagic);
            if (attackType != 1 || ManaBar2.player2Mana < attackEnemySpellCost)
            {
                var number = Random.Range(1, intrevalMaxPhys);

                if (number > attackEnemyPhysChance)
                {
                    miss = true;
                }
                attacking = true;
                anim.SetBool("IsWalking", true);
                movement = new Vector2(-speed, 0);
                turnEnemy = false;
            }
            else if (ManaBar2.player2Mana >= attackEnemySpellCost)
            {
                StartCoroutine("MagicAttack");
                attacking = true;
                turnEnemy = false;
            }

        }

        if (retire)
        {
            anim.SetBool("IsWalking", true);
            movement = new Vector2(speed, 0);
        }

        rbody.MovePosition(rbody.position + movement * Time.deltaTime);
    }

    IEnumerator MagicAttack()
    {
        GameObject Hero = GameObject.FindWithTag("Hero");
        Animator magicOnEnemy = Hero.transform.GetChild(0).gameObject.GetComponent<Animator>();
        anim.SetBool("IsAttacking", true);
        source.PlayOneShot(magicSound, 1f);

        yield return new WaitForSeconds(0.3f);
        magicOnEnemy.SetBool("SpellActive", true);
        ShowDamage(attackEnemySpellDamage - InitializeValues.shieldValue);
        yield return new WaitForSeconds(0.2f);
        Hero.GetComponent<Animator>().SetBool("IsHurt", true);
        HealthManager1.HurtPlayer(attackEnemySpellDamage - InitializeValues.shieldValue);
        ManaBar2.HurtPlayer(attackEnemySpellCost);
        if (InitializeValues.lifePoints <= 0)
        {
            yield return new WaitForSeconds(0.3f);
            HideDamage(attackEnemySpellDamage - InitializeValues.shieldValue);
            Hero.GetComponent<Animator>().SetBool("IsHurt", false);
            Hero.GetComponent<Animator>().SetBool("IsDead", true);
            magicOnEnemy.SetBool("SpellActive", false);
            movement = new Vector2(0, 0);
        }
        else
        {
            
            yield return new WaitForSeconds(0.7f);
            HideDamage(attackEnemySpellDamage - InitializeValues.shieldValue);
            anim.SetBool("IsAttacking", false);
            Hero.GetComponent<Animator>().SetBool("IsHurt", false);
            yield return new WaitForSeconds(0.3f);
            magicOnEnemy.SetBool("SpellActive", false);
            yield return new WaitForSeconds(0.5f);
            scriptHero.turnHero = true;
            attacking = false;
        }
    }

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Hero" && attacking)
        {
            if (!miss)
            {
                movement = new Vector2(0, 0);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsAttacking", true);
                ShowDamage(attackEnemyPhysDamage - InitializeValues.shieldValue);

                yield return new WaitForSeconds(1.1f);
                source.PlayOneShot(swordSound, 1f);
                collision.gameObject.GetComponent<Animator>().SetBool("IsHurt", true);
                HealthManager1.HurtPlayer(attackEnemyPhysDamage - InitializeValues.shieldValue);


                if (InitializeValues.lifePoints <= 0)
                {
                    yield return new WaitForSeconds(0.3f);
                    HideDamage(attackEnemyPhysDamage - InitializeValues.shieldValue);
                    collision.gameObject.GetComponent<Animator>().SetBool("IsDead", true);
                }
                else
                {
                    yield return new WaitForSeconds(0.8f);
                    HideDamage(attackEnemyPhysDamage - InitializeValues.shieldValue);
                    anim.SetBool("IsAttacking", false);
                    collision.gameObject.GetComponent<Animator>().SetBool("IsHurt", false);
                    retire = true;
                }
            }
            else
            {
                movement = new Vector2(((speed) / 3)*2, 0);
                yield return new WaitForSeconds(1.1f);
                movement = new Vector2(0, 0);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsAttacking", true);
                yield return new WaitForSeconds(1.1f);
                source.PlayOneShot(swordSound, 1f);
                yield return new WaitForSeconds(1.0f);
                anim.SetBool("IsAttacking", false);
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
            scriptHero.turnHero = true;
        }
    }


    void ShowDamage(int dmgValue) {
        GameObject.FindWithTag("DmgE"+dmgValue).transform.localScale = new Vector3(0.3f, 0.3f, 1);
    }
    void HideDamage(int dmgValue)
    {
        GameObject.FindWithTag("DmgE" + dmgValue).transform.localScale = new Vector3(0, 0, 0);
    }
}