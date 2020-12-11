using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject Dice;
    public float resetDiceTime;
    public GameObject[] spawnPosition;

    //Private
    private GameManager gm;
    private SelectedDice sDice;

    void Start()
    {
        sDice = gameObject.GetComponent<SelectedDice>();
        gm = gameObject.GetComponent<GameManager>();
        InvokeRepeating("SpawnDice", 0f, resetDiceTime);
        spawnPosition = GameObject.FindGameObjectsWithTag("Points");
    }


    void SpawnDice()
    {
        if (!gm.gameOver)
        {
            GameObject[] findOldObj;
            findOldObj = GameObject.FindGameObjectsWithTag("Dice");
            for (int i = 0; i < findOldObj.Length; i++)
            {
                findOldObj[i].GetComponent<Animator>().Play("outro");
            }
            sDice.selectedDice[0] = null;
            sDice.selectedDice[1] = null;
            sDice.selectedDice[2] = null;

            for (int i = 0; i < spawnPosition.Length; i++)
            {
                var sPos = spawnPosition[i].transform.position;
                var sRot = spawnPosition[i].transform.rotation;
                GameObject s =  Instantiate(Dice, sPos, Quaternion.identity);
                s.transform.Rotate(0f, sRot.y, 0f);
            }
        }
    }

    public void ResetDice()
    {
        CancelInvoke("SpawnDice");
        InvokeRepeating("SpawnDice", 0f, resetDiceTime);
    }
}
