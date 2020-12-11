using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("UI Text:")]
    [Tooltip("Assign UI Text From Canvas.")]
    public TextMeshPro timerTextObject;
    [Header("Timer Float:")]
    public float timer;
    private int iTimer;

    //Private
    private GameManager gm;

    void Start()
    {
        iTimer = (int)timer;
        gm = gameObject.GetComponent<GameManager>();

    }


    void FixedUpdate()
    {
        timer = timer - Time.deltaTime;
        iTimer = Mathf.CeilToInt(timer);
        timerTextObject.text = iTimer.ToString();

        if(iTimer <= 0)
        {
            timer = 0;
            gm.GameOver();
            return;
        }
    }
}
