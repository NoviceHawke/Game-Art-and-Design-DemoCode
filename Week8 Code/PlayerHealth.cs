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
    }

    public void PlayerDeath()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayerDamange(float x) {
        GameManager.instance.DamangePlayer(x);

        if (GameManager.instance.currentLife > 0)
        {
            anim.SetTrigger("Hurt");
            StartCoroutine(NoDamage());
        }
        else {
            anim.SetTrigger("Death");
        }
       
    }
    private IEnumerator NoDamage() {
        Physics2D.IgnoreLayerCollision(3,7,true);
        for (int i = 0; i < numColorChange; i++) { 
        sr.color= Color.red;
            yield return new WaitForSeconds(iframeTime / numColorChange / 2);
			sr.color = Color.white;
			yield return new WaitForSeconds(iframeTime / numColorChange / 2);

		}

		Physics2D.IgnoreLayerCollision(3, 7, false);
	}

}
