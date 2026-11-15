using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Attack : MonoBehaviour
{ /* READ ME This Code should go onto your Player, you will need to create an Empty object under your Player to act as your player's
   Attack Spawn point,  this must be a child of the player or it will not move with them you should also create your Bullet
    before  you add this code or you will pass a Null */
    public Transform firePoint;
    public GameObject bulletPrefab;
    private InputAction attack;


    private void Start()
    {
        attack = InputSystem.actions.FindAction("Attack");
    }
    // Update is called once per frame
    void Update()
    {
        if (attack.WasPressedThisFrame())
        {//this ties to whatever inputs are set up in your player input system
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
