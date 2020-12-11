using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Is Game Started:")]
    public bool inGame;
    [Header("Is Game Over:")]
    public bool gameOver;
    [Header("Combo:")]
    public bool canCombo;
    public int comboCounter;

    //Private
    private Timer timerScript;
    private Combo comboScript;
    void Start()
    {
        timerScript = gameObject.GetComponent<Timer>();
        comboScript = gameObject.GetComponent<Combo>();
        inGame = true;
    }

    void Update()
    {
        if (inGame && comboCounter == 2)
        {
            canCombo = true;
        }
        else if(comboCounter == 0)
        {
            canCombo = false;
        }
    }

    public void GameOver()
    {
        gameOver = true;
        inGame = false;
        Debug.Log("Game is Over!");
    }

    public void GameStarted()
    {

    }
}
