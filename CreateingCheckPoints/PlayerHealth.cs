
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Animator anim;

    [Header("DisableDamage")]
    public float iframeTime;
    public float numColorChange;
    private SpriteRenderer sr;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sr= GetComponent<SpriteRenderer>();
        GameManager.instance.currentCheckPoint= transform.position;
    }

    public void PlayerDamanged(float x)
    {
        GameManager.instance.DamangeHeath(x);

        if (GameManager.instance.currentLife > 0)
        {
            anim.SetTrigger("Hurt");
            StartCoroutine(NoDamage());
        }
        else
        {
            if (GameManager.instance.numRespawn > 0)
            {
                StartCoroutine(NoDamage());
                GameManager.instance.Respawn();
                transform.position = GameManager.instance.currentCheckPoint;
            }
            
            else { anim.SetTrigger("Death"); }
        }
      
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(2); 
        // NOTE the Number 2 in this code should match the load order number for your death screen
    }

    private IEnumerator NoDamage()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numColorChange; i++) {
            sr.color = Color.red;
            yield return new WaitForSeconds(iframeTime / numColorChange / 2);
            sr.color = Color.white;
            yield return new WaitForSeconds(iframeTime / numColorChange / 2);
        }

        Physics2D.IgnoreLayerCollision(6, 7, false);
    }
}
