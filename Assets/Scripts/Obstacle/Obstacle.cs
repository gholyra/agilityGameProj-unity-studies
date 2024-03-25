using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Player"))
        {
            Debug.Log("You touched me, loser!");
            Timer.isTimerEnabled = false;
            UIManager.Instance.ShowLoserText();
            PlayerBehaviour.Instance.DisableInput();
        }
    }
}
