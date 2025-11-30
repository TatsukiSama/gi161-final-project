using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Image bar;
    public Character target;

    void Update()
    {
        if (bar == null || target == null) return;

        float ratio = (float)target.currentMP / target.maxMP;
        bar.fillAmount = ratio;
    }
}
