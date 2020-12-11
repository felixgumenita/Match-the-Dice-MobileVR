using UnityEngine;

public class Combo : MonoBehaviour
{
    private Timer time;
    private GameManager gm;

    void Start()
    {
        gm = gameObject.GetComponent<GameManager>();
        time = gameObject.GetComponent<Timer>();
    }
    public void DoubleCombo()
    {
        if (gm.canCombo && gm.comboCounter == 2)
        {
            time.timer += 2f;
            Debug.Log("Double Combo");
        }
    }

    public void TripleCombo()
    {
        if (gm.canCombo && gm.comboCounter >= 3)
        {
            time.timer += 5f;
            Debug.Log("Triple Combo");
        }
    }
}
