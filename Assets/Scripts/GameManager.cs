using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Hero hero;
    public Monster monster;
    public int stage = 1;

    void Start()
    {
        Debug.Log("เริ่มด่าน " + stage);
    }

    public void PlayerTurn_Attack()
    {
        hero.NormalAttack(monster);
        AfterPlayerAction();
    }

    public void PlayerTurn_Skill()
    {
        hero.UseSkill(monster);
        AfterPlayerAction();
    }

    public void PlayerTurn_Guard()
    {
        hero.Guard();
        AfterPlayerAction();
    }

    void AfterPlayerAction()
    {
        if (monster.currentHP <= 0)
        {
            NextStage();
            return;
        }

        MonsterTurn();
    }

    void MonsterTurn()
    {
        monster.TakeTurn(hero);

        if (hero.currentHP <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void NextStage()
    {
        stage++;

        if (stage == 2)
            SceneManager.LoadScene("Level2");
        else if (stage == 3)
            SceneManager.LoadScene("Level3");
        else
            SceneManager.LoadScene("Win");
    }
}
