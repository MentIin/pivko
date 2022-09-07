using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnLevelComplete += Complete;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Complete()
    {
        LevelsManager.LevelComplete(LevelLoader.S.level);
        LevelsManager.Save();
        //PlayerPrefs.SetInt("levelId", PlayerPrefs.GetInt("levelId") + 1);
        //PlayerPrefs.SetInt("levelId", Random.Range(0, 3));
        //SceneManager.LoadSceneAsync("SelectLevel");
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("levelId", LevelLoader.S.level + 1);
        SceneManager.LoadScene("GameScene");
    }
    
}
