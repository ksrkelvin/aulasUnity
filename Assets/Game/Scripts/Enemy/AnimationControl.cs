using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{

    [SerializeField] private Transform atackPoint;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask playerLayer;

    private Animator anim;
    private PlayerAnim playerAnim;
    private Skeleton skeleton;


    // Start is called before the first frame update
    void Start()
    {
        playerAnim = FindObjectOfType<PlayerAnim>();
        anim = GetComponent<Animator>();
        skeleton = GetComponentInParent<Skeleton>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnim(int value )
    {
        anim.SetInteger("transition", value);
    }

    public void OnHit()
    {
       
        if (skeleton.CurrentHealth <= 0)
        {
            skeleton.isDead = true;
            anim.SetTrigger("death");
            Destroy(skeleton.gameObject, 1f);
        }
        else{
            anim.SetTrigger("hit");
            skeleton.CurrentHealth--;
            skeleton.healthBar.fillAmount = skeleton.CurrentHealth /skeleton.Health; 
         
        }
    }

    public void Attack()
    {
       if (!skeleton.isDead){
            Collider2D hit = Physics2D.OverlapCircle(atackPoint.position,radius,playerLayer);

            if(hit != null)
            {
                //Acerta o player
                playerAnim.OnHit();
            }
       }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(atackPoint.position, radius);
    }

}
