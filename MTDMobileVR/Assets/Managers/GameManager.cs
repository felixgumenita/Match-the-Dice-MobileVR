using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Is Game Started:")]
    public bool inGame;
    [Header("Is Game Over:")]
    public bool gameOver;

    [Header("Combo:")] 
    public bool canCombo;
    public float mana;
    private float maxMana = 100f;
    public int comboCounter;

    [Header("Points")] 
    public int points;
    public TextMeshPro pointText;

    //Private
    private Timer timerScript;
    private Combo comboScript;
    
    void Start()
    {
        timerScript = gameObject.GetComponent<Timer>();
        comboScript = gameObject.GetComponent<Combo>();
        inGame = true;
        mana = 60;
        //SoundManager.Instace.PlayMusic();
    }

    void Update()
    {
        pointText.text = points.ToString();
        if (inGame && comboCounter == 2)
        {
            canCombo = true;
        }
        else if(comboCounter == 0)
        {
            canCombo = false;
        }

        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }

    public void GameOver()
    {
        gameOver = true;
        inGame = false;
        Debug.Log("Game is Over!");
    }
}
