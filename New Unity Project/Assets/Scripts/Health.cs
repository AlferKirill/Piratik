using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    public bool bob;
    public void TakeHit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    [SerializeField] public float StratingHealth;
    public float currentHealth { get; private set; }


    private void Awake()
    {
        currentHealth = StratingHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }
    public void TakeHit(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth = damage, 0, StratingHealth);
        if (currentHealth > 0)
        {

        }
       /* if (health > 0)
        {
            StartCoroutine(Invunerability());
        }*/
    }

   /* private IEnumerator Invunerability()
    {
        bob = true;
        Physics2D.IgnoreCollision(6, 7, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));

        }
        Physics2D.IgnoreCollision(6, 7, false);
        bob = false;
    }*/
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeHit(1);
        }
    }

}
