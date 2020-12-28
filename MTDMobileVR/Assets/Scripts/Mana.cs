using UnityEngine;
using System.Collections;

public class Mana : MonoBehaviour
{
    public GameManager _gameManager;
    public GameObject manaAnchor;
    
    [Header("Time Ability:")]
    public Timer time;
    public GameObject manaButton;
    public float stapTime;
    public bool canStop;
    
    
    [Header("TA Materials:")]
    public Material cantsStopTime;
    public Material canStopTime;
    
    
    

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        time = FindObjectOfType<Timer>();
    }

    void Update()
    {
        var scale = _gameManager.mana / 100f;
        manaAnchor.transform.localScale = new Vector3(scale,1f,1f);
        CheckMaterial();
        CheckMana();
    }

    public void StopTimer()
    {
        if (canStop && !time.stopTimer) StartCoroutine(StopTime(stapTime));
    }

    void CheckMaterial()
    {
        if (canStop) manaButton.GetComponent<MeshRenderer>().material = canStopTime;
        else if(!canStop) manaButton.GetComponent<MeshRenderer>().material = cantsStopTime;
    }

    void CheckMana()
    {
        if (_gameManager.mana >= 50f) canStop = true;
        else if (_gameManager.mana < 50f) canStop = false;
    }
    
    private IEnumerator StopTime(float waitTime)
    {
        _gameManager.mana -= 50f;
        time.stopTimer = true;
        yield return new WaitForSeconds(waitTime);
        time.stopTimer = false;
    }
    
}
