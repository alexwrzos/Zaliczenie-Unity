using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
[SerializeField] private float attackCooldown;
[SerializeField] private Transform FirePoint;
[SerializeField] private GameObject[] fireballs;

public Animator anim;
public  PlayerMovement  PlayerMovement;
private float cooldownTimer = Mathf.Infinity;

private void Awake()
{
   anim = GetComponent<Animator> ();
   PlayerMovement = GetComponent<PlayerMovement>();
}

    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown && PlayerMovement.canAttack())
        Attack();

        cooldownTimer += Time.deltaTime;
    }
private void Attack()
{
    anim.SetTrigger("attack");
    cooldownTimer = 0;

    fireballs[FindFireball()].transform.position = FirePoint.position;
    fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
}
private int FindFireball()
{
    for ( int i = 0; i < fireballs.Length; i++)
    {
      if(!fireballs[i].activeInHierarchy)  
      return i;
    }
    return 0;
}
}