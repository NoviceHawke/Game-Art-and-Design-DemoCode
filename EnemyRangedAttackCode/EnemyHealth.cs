using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    /*READ ME: This code is only for keeping track of the enemy's Score/Health
    you may need to add extra code to make it fit the effects you want in your game
     */
    public int enemyHealth;
    public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   public void Damaged(int damage) {
    enemyHealth -= damage;
        print(enemyHealth);
        if (enemyHealth <= 0)
        {
            SpaceManager.instance.score += score;
            SpaceManager.instance.StageCheck();
            Destroy(gameObject);

        }
    }
}
