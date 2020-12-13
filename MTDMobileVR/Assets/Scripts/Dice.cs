using TMPro;
using UnityEngine;


public class Dice : MonoBehaviour
{
    public TextMeshPro[] diceText;
    public int diceID;
    public Material selectedMaterial;
    public Material hoverMaterial;
    public Material normalMaterial;
    public bool isSelected;
    public float clickTimer;

    [Header("Random Anims At Start:")]
    public AnimationClip[] Anims;


    //Private
    private GameManager gm;
    private SelectedDice sDice;
    private bool pointerEnter;
    private Animator animator;
    float Timer;
    bool startTimer;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        setDice();
        sDice = GameObject.FindObjectOfType<SelectedDice>();
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (!isSelected && !pointerEnter)
        {
            gameObject.GetComponent<MeshRenderer>().material = normalMaterial;
        }

        if (startTimer)
        {
            HoverClickTime();

            if (Timer >= clickTimer)
            {
                Invoke("OnClick", 0f);
            }
        }
    }

    void setDice()
    {
        diceID = Random.Range(0, 5);
        for(int i = 0; i < diceText.Length; i++)
        {
            diceText[i].text = diceID.ToString();
        }
        gameObject.name = diceID.ToString();

        isSelected = false;
        pointerEnter = false;

        int anim = Random.Range(0, 3);
        animator.Play(Anims[anim].name);
    }

    public void OnHover()
    {
        startTimer = true;
        pointerEnter = true;
        if (!isSelected)
        {
            gameObject.GetComponent<MeshRenderer>().material = hoverMaterial;

        }
    }

    public void OnClick()
    {
        gameObject.GetComponent<MeshRenderer>().material = selectedMaterial;
        if (!isSelected && !gm.gameOver)
        {
            if (sDice.selectedDice[0] == null)
            {
                sDice.selectedDice[0] = gameObject;
            }
            else if (sDice.selectedDice[1] == null)
            {
                sDice.selectedDice[1] = gameObject;
            }
            else if (sDice.selectedDice[2] == null)
            {
                sDice.selectedDice[2] = gameObject;
                sDice.CheckDiceID();
                DiSellecDice();
            }
        }
        isSelected = true;
    }

    public void OnExit()
    {
        Timer = 0f;
        startTimer = false;
        pointerEnter = false;
        if (!isSelected)
        {
            gameObject.GetComponent<MeshRenderer>().material = normalMaterial;
        }
    }
    public void DiSellecDice()
    {
        GameObject[] findOldObj;
        findOldObj = GameObject.FindGameObjectsWithTag("Dice");
        for (int i = 0; i < findOldObj.Length; i++)
        {
            findOldObj[i].GetComponent<Dice>().isSelected = false;
        }

        for (int g = 0; g < 3; g++)
        {
            sDice.selectedDice[g] = null;
        }
    }

    public void HoverClickTime()
    {
        Timer += Time.deltaTime;
    }
    public void destroyAnim()
    {
        Destroy(gameObject);
    }
}
