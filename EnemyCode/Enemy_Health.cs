using System.Collections;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{/* READ ME This Code should be added to your Enemy Object, your Main Enemy sprite
  
  */
    public int health;
    public SpriteRenderer sr;
    public float iframeTime;
    public float numColorChange;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    //applys damage to the enemy
    public void DoDamage(int _damage)
    {
        health -= _damage;
        print(health);
        StartCoroutine(WasHit());

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    //if used applys a color change to the enemy after being hit
    private IEnumerator WasHit()
    {
        for (int i = 0; i < numColorChange; i++)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(iframeTime / numColorChange / 2);
            sr.color = Color.white;
            yield return new WaitForSeconds(iframeTime / numColorChange / 2);
        }
    }
}
