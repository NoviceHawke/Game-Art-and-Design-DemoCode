using UnityEngine;

public class SpaceManager : MonoBehaviour
{/*READ ME you should name this file your Game manager,*/
    public static SpaceManager instance;

    public float playerHealth;

    public int score;

    public int gameStage;
    //thus array is for the different groups of enemies in your level
    public GameObject[] Stages;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (instance != this && instance != null)
        {
            Destroy(gameObject);
        }

       
        //sets which enemy wave is active
        for (int i=0; i < Stages.Length; i++)
        {
            if (i == 0)
            {
                Stages[i].SetActive(true);
            }

            else { Stages[i].SetActive(false); }
        }
    }


//checks if your condition has been met to trigger the next stage
    public void StageCheck()
    {
        switch (gameStage)
        {

            case 0:
                if (score > 8)
                {
                    NewStage();
                }

                break;
            case 1:
                if (score > 22)
                {
                    NewStage();
                }
                print(gameStage);
                break;

            case 2:
                /*if (score > 22)
                {
                    NewStage();
                }*/
                print(gameStage);
                break;

        }
    }

    //deactivates current stage and loads the next
    public void NewStage()
    {
        Stages[gameStage].SetActive(false);
        gameStage += 1;
        Stages[gameStage].SetActive(true);
    }
}
