using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

    public float maxLife;
    public float currentLife;

    public int score;

    public GameObject[] collectables;

    public bool isGamePaused;

    public int numRespawn = 3;
    public Vector3 currentCheckPoint;
    
    private void Awake()
    {
        if( instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
      else if (instance != this && instance != null)
        {
            Destroy(gameObject);
        }

        for (int i = 0; i < collectables.Length; i++) {
            collectables[i].GetComponent<AddScore>().score = Random.Range(1, 10);
        }
    }



    public void AddScore(int points)
    {
        score += points;
        print(score);
    }


    public void AddHealth( float h)
    {
        currentLife = Mathf.Clamp(currentLife + h, 0, maxLife);
        print(currentLife);
    }

    public void DamangeHeath(float h) {
        currentLife = Mathf.Clamp(currentLife - h, 0, maxLife);
        print(currentLife);
    }

    public void RestartPlay()
    {
        currentLife = maxLife;
        score = 0;
    }

  public void Respawn() {
        currentLife = maxLife;
        numRespawn--;
    
    }

    public void SetNewCheckPoint(Vector3 _newCheckPoint)
    {
        currentCheckPoint = _newCheckPoint;
    }
}
