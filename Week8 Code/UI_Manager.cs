using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class UI_Manager : MonoBehaviour
{
    [Header("HUD")]
    public TMP_Text scorebox;
    public Image totalHealth;
    public Image currentHealth;
    public float totalMaxHealth;

    [Header("Pause")]
    public GameObject pauseScreen;
    public InputAction pauseButton;

    private void Awake()
    {
        pauseScreen.SetActive(false);
        pauseButton = InputSystem.actions.FindAction("Pause");
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseButton.WasPressedThisFrame()) {
            if (pauseScreen.activeInHierarchy)
            {
                PauseGame(false);
            }
            else {
                PauseGame(true);
            }
        
        }

        scorebox.text = "Score="+GameManager.instance.score.ToString();

        currentHealth.fillAmount = GameManager.instance.currentLife / totalMaxHealth;
        totalHealth.fillAmount= GameManager.instance.maxLife / totalMaxHealth;
    }

    private void PauseGame(bool status) {
        pauseScreen.SetActive(status);

        if (status)
        {
            Time.timeScale = 0;
            GameManager.instance.isGamePaused = true;
        }
        else {
			Time.timeScale = 1;
			GameManager.instance.isGamePaused = false;
		}
    }
}
