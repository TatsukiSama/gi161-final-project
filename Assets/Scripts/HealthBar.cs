using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    public Character target;

    void Update()
    {
        if (target == null || bar == null) return;

        float ratio = (float)target.currentHP / target.maxHP;
        bar.fillAmount = ratio;
    }
}

