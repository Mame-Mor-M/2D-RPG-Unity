using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UniversalMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool GameisPaused = false;
    public static bool skillGamePaused = false;
    public GameObject pauseUI;
    public GameObject skillUI;
    public GameObject xpBar;
    public static bool pauseMenu = false;

    // Update is called once per frame
    EnemyController enemyCtrl;
    void Start()
    {
        enemyCtrl = FindObjectOfType<EnemyController>();
    }
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameisPaused == true || skillGamePaused == true)
            {
                Resume();
                pauseUI.SetActive(false);
                skillUI.SetActive(false);
                skillGamePaused = false;
                pauseMenu = false;
            }
            else
            {
                Pause();
                pauseUI.SetActive(true);
                pauseMenu = true;
            }
        }

        
        
        if(pauseMenu == false)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (GameisPaused == true)
                {
                    Resume();
                    skillUI.SetActive(false);
                    skillGamePaused = false;
                }
                else if (GameisPaused == false)
                {
                    Pause();
                    skillUI.SetActive(true);
                    skillGamePaused = true;
                }
            }
        }
        
    }

    void Resume()
    {
        
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    void Pause()
    {
        
        Time.timeScale = 0f;
        GameisPaused = true;
    }


}
