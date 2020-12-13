using UnityEngine;

public class Combo : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = gameObject.GetComponent<GameManager>();
    }
    public void DoubleCombo()
    {
        if (gm.canCombo && gm.comboCounter == 2)
        {
            gm.points += 65;
            gm.mana += 10f;
            Debug.Log("Double Combo");
        }
    }

    public void TripleCombo()
    {
        if (gm.canCombo && gm.comboCounter >= 3)
        {
            gm.points += 120;
            gm.mana += 15f;
            Debug.Log("Triple Combo");
        }
    }
}
