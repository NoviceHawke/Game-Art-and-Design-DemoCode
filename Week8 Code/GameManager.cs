using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score;

    public float maxLife;
    public float currentLife;

    public GameObject[] collect;

    public bool isGamePaused;

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

        for (int i = 0; i < collect.Length; i++) {
            collect[i].GetComponent<AddScore>().points = Random.Range(1, 5);
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

    public void RestartPlay() { 
    score = 0;
        currentLife = maxLife;

    }
}
