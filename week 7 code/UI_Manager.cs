using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TMP_Text scorebox;

    public Image totalHealth;
    public Image currentHealth;
    public float totalMaxHealth;

    // Update is called once per frame
    void Update()
    {
        scorebox.text = "Score="+GameManager.instance.score.ToString();

        currentHealth.fillAmount = GameManager.instance.currentLife / totalMaxHealth;
        totalHealth.fillAmount= GameManager.instance.maxLife / totalMaxHealth;
    }
}
