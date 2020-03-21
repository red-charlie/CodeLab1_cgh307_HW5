using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //singleton status
    public int currentLevel = 0;
    

    private void Awake()
    {
        if(instance == null) //make sure you are the only instance
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeLevel ()
    {
        currentLevel++;
        Debug.Log("I am loading a new level");
        // SceneManager.LoadScene(currentLevel);
        GameObject currentMap = GameObject.Find("Level Contents");
        Destroy(currentMap);

       LevelReader newLevel = GetComponent<LevelReader>();
        newLevel.LoadLevel();
        //LevelReader.LoadLevel();

    }
}
