using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private Image _bar;

    private void Awake()
    {
        _bar.fillAmount = 1;
    }

    public void SetHP(float current, float total)
    {
        _bar.fillAmount = current/ total;
    }
}
