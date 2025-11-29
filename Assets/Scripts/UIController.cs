using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameManager gm;

    public void OnAttack()
    {
        gm.PlayerTurn_Attack();
    }

    public void OnSkill()
    {
        gm.PlayerTurn_Skill();
    }

    public void OnGuard()
    {
        gm.PlayerTurn_Guard();
    }
}

