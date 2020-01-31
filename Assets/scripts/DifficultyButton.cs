using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{

    private Button button;
    private Gamemanager gamemanager;
    public int diffeculty;
    

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(setDiffuculty);
        gamemanager = GameObject.Find("Gamemanager").GetComponent<Gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDiffuculty()
    {
        Debug.Log(gameObject.name + "was clicked");
        gamemanager.startGame(diffeculty);
        button.gameObject.SetActive(false);
    }
    
    
    
}
