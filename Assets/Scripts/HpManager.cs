using TMPro;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    public static HpManager instance;
    public TextMeshProUGUI hpText;

    public void ShowHealth(int hp)
    {
        hpText.text = $"{hp} points";
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        hpText.text = $"{3} points";
    }
}
