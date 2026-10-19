using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;

    public float maxLife;
    public float currentLife;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (instance != this && instance != null){
        Destroy(gameObject);
        }
    }

    public void AddScore(int points) {
        score += points;
        print("Score ="+score);
    }

    // h= health
    public void AddHealth(float h) {

        currentLife = Mathf.Clamp(currentLife+h,0,maxLife);
        print("Health ="+currentLife);
    }

    public void DamangePlayer(float h) {
		currentLife = Mathf.Clamp(currentLife - h, 0, maxLife);
		print("Health ="+currentLife);
	}
}
