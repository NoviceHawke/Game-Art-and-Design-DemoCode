using UnityEngine;

[CreateAssetMenu(fileName = "HealthPickup", menuName = "Scriptable Objects/HealthPickup")]
public class HealthPickup : ScriptableObject
{
    public float health;
    public Sprite img;
}
