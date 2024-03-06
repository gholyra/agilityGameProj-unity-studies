using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TextMeshProUGUI winnerText;
    [SerializeField] private TextMeshProUGUI loserText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        winnerText.gameObject.SetActive(false);
        loserText.gameObject.SetActive(false);
    }

    public void ShowWinnerText() 
    {
        winnerText.gameObject.SetActive(true);
        loserText.gameObject.SetActive(false);
    } 
    
    public void ShowLoserText() 
    {
        loserText.gameObject.SetActive(true);
        winnerText.gameObject.SetActive(false);
    }

}
