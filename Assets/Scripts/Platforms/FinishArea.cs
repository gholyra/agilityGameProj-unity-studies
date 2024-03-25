using UnityEngine;

[RequireComponent(typeof(Collider))]
public class FinishArea : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Timer.isTimerEnabled = false;
        UIManager.Instance.ShowWinnerText();
        PlayerBehaviour.Instance.DisableInput();
    }

}
