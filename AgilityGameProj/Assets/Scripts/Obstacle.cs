using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Player"))
        {
            Debug.Log("You touched me, loser!");
        }
    }
}
