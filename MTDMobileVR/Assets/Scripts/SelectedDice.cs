using UnityEngine;
using System.Collections.Generic;

public class SelectedDice : MonoBehaviour
{
    public List<GameObject> selectedDice = new List<GameObject>();

    //Private
    private Combo combo;
    private GameManager gm;
    private Timer time;
    private Dice[] dice;

    [Header("SFX    ")]
    [SerializeField] private AudioClip matchDiceSFX;

    public void Start()
    {
        dice = FindObjectsOfType<Dice>();
        combo = gameObject.GetComponent<Combo>();
        gm = gameObject.GetComponent<GameManager>();
        time = gameObject.GetComponent<Timer>();
    }
    public void CheckDiceID()
    {
        if( selectedDice[0].name == selectedDice[1].name)
        {
            if(selectedDice[1].name == selectedDice[2].name)
            {
                SoundManager.Instace.PlayOneShot(matchDiceSFX);
                gm.points += 35;
                gm.mana += 5f;
                time.timer += 1f;
                gm.comboCounter += 1;
                combo.DoubleCombo();
                combo.TripleCombo();
                DestroyDice();
            }
            else
            {
                gm.comboCounter = 0;
                selectedDice[0] = null;
                selectedDice[1] = null;
                selectedDice[2].GetComponent<Dice>().OnExit();
                selectedDice[2] = null;

                for(int i = 0; i<dice.Length; i++)
                {
                    dice[i].DiSellecDice();
                }
            }
        }
        else
        {
            gm.comboCounter = 0;
        }
    }

    void DestroyDice()
    {
        for (int i = 0; i < 3; i++)
        {
            selectedDice[i].GetComponent<Animator>().Play("outro");
        }
    }
}
