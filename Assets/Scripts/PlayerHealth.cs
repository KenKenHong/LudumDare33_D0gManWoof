using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public AudioClip caughtClip;

    private Animator anim;
    private HashIDs hash;
    private PlayerController playerController;
    private LastPlayerPosition lastPlayerPosition;
    private float timer;
    private bool isCaught;

    void Awake()
    {
        anim = GetComponent<Animator>();

        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        lastPlayerPosition = GameObject.FindGameObjectWithTag("GameController").GetComponent<LastPlayerPosition>();
    }

    void Update()
    {
        if(health <= 0)
        {
            if(!isCaught)
            {
                Dying();
            }
            else
            {
                Dead();
                BackToGameScreen();
            }
        }
    }

    void Dying()
    {
        isCaught = true;

        anim.SetBool(hash.caughtBool, isCaught);

        AudioSource.PlayClipAtPoint(caughtClip, transform.position);
    }

    void Dead()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).fullPathHash == hash.caughtState)
            anim.SetBool(hash.caughtBool, false);

        playerController.enabled = false;

        lastPlayerPosition.position = lastPlayerPosition.resetPosition;
    }

	void BackToGameScreen()
    {
        timer += Time.deltaTime;

        //if(timer >= resetTimer)
            // back to main menu
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    public void HealthDamage(int amount)
    {
        health += amount;
    }
}