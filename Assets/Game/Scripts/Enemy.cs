using UnityEngine;

public sealed class Enemy : MonoBehaviour
{
    private int health = 30;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private GameObject bloodDrops;


    public void TakeDamage(int amount)
    {
        health -= amount;

        DamagePopUpGenerator.current.CreatePopUp(
            transform.position,
            amount.ToString(),
            Color.yellow
        );
        Instantiate(bloodDrops, this.transform.position, Quaternion.identity);

        if (health <= 0)
        {
            Die();
        }
        else
        {
            Damage();
        }
    }

    public void Damage()
    {
        this.animator.SetTrigger("IsDamageReceived");
    }

    public void Die()
    {
        this.animator.SetTrigger("Die");
    }
}
