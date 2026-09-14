using UnityEngine;

public class ScoreBox : MonoBehaviour
{
    public int myScore = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       // print("Hello World");  
    }

  // private void OnTriggerEnter2D(Collider2D, collison)
   /* words
    words*/
   private void OnTriggerEnter2D(Collider2D collider)
    {
        print(myScore);
    }
  
   
}
