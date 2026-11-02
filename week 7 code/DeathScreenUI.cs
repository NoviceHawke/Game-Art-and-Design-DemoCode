using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenUI : MonoBehaviour
{
    public void Reload() {
        GameManager.instance.RestartPlay();
        SceneManager.LoadScene(1);//this will change based on load order

    }

    public void Leave() { 
    Application.Quit(); //this code only works in build versions!!!
    }
}
