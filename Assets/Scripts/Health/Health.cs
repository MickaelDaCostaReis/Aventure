using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxhealth; 
    [SerializeField] private float iframestime;
    [SerializeField] private float blinks;
    [SerializeField] private Transform spawn;
    private SpriteRenderer blinkingSprite;

    
    //private Animator animation;

    private float currenthealth;

    private void Start()
    {
        currenthealth = maxhealth;
        blinkingSprite = GetComponent<SpriteRenderer>();
        //animation = GetComponent<Animator>();
    }
    public void takeDamage(float damage)
    {
        currenthealth = Mathf.Clamp(currenthealth - damage, 0, maxhealth);
        if (currenthealth > 0)
        {
            // animation.SetTrigger("Hurt");
            StartCoroutine(Invincibility());
        }
        else
        {
            //animation.SetTrigger("Death");
        }
    }

    public void takeHealthpack(float heals)
    {
        currenthealth = Mathf.Clamp(currenthealth + heals, 0, maxhealth);
    }
    
    private IEnumerator Invincibility()
    {
        Physics2D.IgnoreLayerCollision(3, 6, true);
        for (int i = 0; i < blinks; i++)
        {
            blinkingSprite.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(iframestime / (blinks * 2));
            blinkingSprite.color = Color.white;
            yield return new WaitForSeconds(iframestime / (blinks * 2));
        }
        Physics2D.IgnoreLayerCollision(3, 6, false);
    }
    public void Die()
    {
        // système de respawn obsolète, passer par un menu pls
        transform.position = spawn.position;
        takeHealthpack(maxhealth);
        //animation.ResetTrigger("Death");
        //animation.Play("Idle");
    }

    
}