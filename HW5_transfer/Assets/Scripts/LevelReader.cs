using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class LevelReader : MonoBehaviour
{
    public GameObject floor; // the floor I made for my levels
    public GameObject wall; //the wall object
    public GameObject player; // a reference to player prefab
    public GameObject exit; // the end of the maze

    public float xOffset = 0;
    public float yOffset = 0;

    //public string fileLevel = "level0.txt"; //the name of my first level
    string fileLevel;


    private void Awake()
    {
        //fileLevel = "level" + GameManager.instance.currentLevel + ".txt";
        LoadLevel();
    }
    void Start()
    {
        //LoadLevel();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel ()
    {
        fileLevel = "level" + GameManager.instance.currentLevel + ".txt"; //load the correct level

        string fullFilePath = Application.dataPath + "/Levels/" + fileLevel; //find the level text

        print(File.ReadAllText(fullFilePath)); //reads the file contents to the debug log, is useful for testing but I liked how it looked once I added it in

        //as per the comments on the other file "Lines will be an array of strings, with each line in a different slot" which I take to mean that the file is broken up by /n 
        string[] lines = File.ReadAllLines(fullFilePath);

        //Parent Game object for the level things
        GameObject mapParent = new GameObject("Level Contents");

        //for loop through the lines from the file contents,
        for (int z = 0; z < lines.Length; z++)
        {
            string line = lines[z];
            char[] characters = line.ToCharArray(); //this is new and cool! 

            //then go thru each character on this line - also I see why y was used earlier
            for (int x = 0; x < characters.Length; x++)
            {
                GameObject newObject;

                switch (characters[x]) //when encountering a character
                {
                    case 'x': //if the character is an x
                        newObject = Instantiate<GameObject>(wall); //put the wall in
                        newObject.transform.SetParent(mapParent.transform);//put it in the game object for the leve
                        newObject.transform.position =
                            new Vector3(x + xOffset, 0, -z + yOffset);
                        break;

                    case '=': // if the character is a =
                        newObject = Instantiate<GameObject>(floor);
                        newObject.transform.SetParent(mapParent.transform); // put it in the master for the level
                        newObject.transform.position =
                            new Vector3(x + xOffset, 0, -z + yOffset);
                        break;

                    case 'P': //if the char is a p
                        newObject = Instantiate<GameObject>(player);//put the player there
                        newObject.transform.position =
                                new Vector3(x + xOffset, 0, -z + yOffset);
                        break;

                    case '*': //if the char is a * 
                        newObject = Instantiate<GameObject>(exit);//put the exit in there
                        newObject.transform.position =
                                new Vector3(x + xOffset, 0, -z + yOffset);
                        break;
                    default:
                        print("empty"); //if nothing do nothing
                        break;

                }
            }
        }

    }
}
