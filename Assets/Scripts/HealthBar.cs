using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    public Character target;

    void Update()
    {
        float ratio = (float)target.currentHP / target.maxHP;
        bar.fillAmount = ratio;
    }
}

