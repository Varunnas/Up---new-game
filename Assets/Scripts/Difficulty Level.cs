using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private Button button;
    private GameManager gameManager;
    private BackgroundMove bgSpeed;
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        bgSpeed = GameObject.Find("Background").GetComponent<BackgroundMove>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetDifficulty()
    {
        if (gameObject.name == "Easy")
        {
            gameManager.StartGame(0.7f);
            bgSpeed.speed = 15f;

        }
        else if (gameObject.name == "Medium")
        {
            gameManager.StartGame(0.4f);
            bgSpeed.speed = 25f;
        }
        else if (gameObject.name == "Hard")
        {
            gameManager.StartGame(0.2f);
            bgSpeed.speed = 35f;
        }
        gameManager.titleScreen.SetActive(false);
    }
}
