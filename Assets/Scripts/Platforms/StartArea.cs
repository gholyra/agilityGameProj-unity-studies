using UnityEngine;

[RequireComponent(typeof(Collider))]
public class StartArea : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        Timer.isTimerEnabled = true;
    }
}
