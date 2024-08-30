using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    [Header("Atack Settings")]
    [SerializeField]private Transform atackPoint;
    [SerializeField]private float radius;
    [SerializeField]private LayerMask enemyLayer;


    private Player player;
    private Animator anim;
    private Casting casting;
    private bool isHurting;
    private float recoveryTime = 1.5f;
    private float timeCount;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();   
        anim = GetComponent<Animator>();
        casting = FindObjectOfType<Casting>();
    }

    // Update is called once per frame
    void Update()
    {
       OnMove();
       OnRun();
       OnCutting();
       OnDigging();
       OnWatering();


        if (isHurting)
        {
            timeCount += Time.deltaTime;
            if (timeCount >= recoveryTime)
            {
                isHurting = false;
                timeCount = 0f;
            }
        }
    }

    #region Movement

    void OnMove()
    {
        if (player.direction.sqrMagnitude>0)
        {
            if (player.isRolling)
            {
                anim.SetTrigger("isRoll");
            }else{
                anim.SetInteger("transition", 1);
            }
        }
        else
        {

            anim.SetInteger("transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
    }

    void OnRun()
    {
        if (player.isRunning)
        {
            anim.SetInteger("transition", 2);
        }

    }

    void OnCutting()
    {
        if (player.isCutting)
        {
            anim.SetInteger("transition", 3);
        }
    }
    void OnDigging()
    {
        if (player.isDigging)
        {
            anim.SetInteger("transition", 4);
        }
    }

    void OnWatering()
    {
        if (player.isWatering)
        {
            anim.SetInteger("transition", 5);
        }
    }


    #endregion


    //É chamado quando o jogador começa a pescar
    public void OnCastingStarted()
    {
        player.isPaused = true;
        anim.SetTrigger("isCasting");
    }

    //Callback apos a animação de pescar
    public void OnCastingEnd()
    {
        casting.OnCasting();
        player.isPaused = false;
    }

    public void OnHammeringStarted()
    {
        player.isPaused = true;
        anim.SetBool("isHammering", true);
    }
    public void OnHammeringEnd()
    {
        player.isPaused = false;
        anim.SetBool("isHammering", false);
    }


#region Atack
    public void OnHit(){
        if (!isHurting)
        {
           anim.SetTrigger("hit");
           isHurting = true;
        }        
    }

    public void OnAtack()
    {
        Collider2D hit = Physics2D.OverlapCircle(atackPoint.position,radius,enemyLayer);

        if (hit != null)
        {
            //Acerta o inimigo
            hit.GetComponentInChildren<AnimationControl>().OnHit();
         
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(atackPoint.position, radius);
    }
#endregion
    
}
