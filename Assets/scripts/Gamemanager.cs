using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Gamemanager : MonoBehaviour
{

    public List<GameObject> targets;
    private float spawnrate = 1.0f;
    private int score;
    public bool isGameActive;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject titlescreen;
    public Button restartButton;


    // Start is called before the first frame update
    void Start()
    { 
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Updatescore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

    public void gameover()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
        
    }

    IEnumerator Spawntarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnrate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
       
    }

    public void RestardGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void startGame(int diffeculty)
    {
        isGameActive = true;
        StartCoroutine(Spawntarget());
        score = 0;
        spawnrate = spawnrate /= diffeculty;
        Updatescore(0);
        titlescreen.gameObject.SetActive(false);
    }
}
