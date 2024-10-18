using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class Scene1_Manager : MonoBehaviour
{
    private void Awake()
    {
        UniqueObjectLocator.RegisterObject(this);
    }

    private DataIO dataIO;


    [Header("Scene1 Data")]
    public List<int> intData;
    public List<string> stringData;
    public List<bool> boolData;
    

    private void SaveSceneData(bool isNewSave)
    {
        dataIO = new();
        dataIO.SaveData(isNewSave);
    }

    private void LoadSceneData()
    {
        dataIO = new();
        dataIO.LoadData();
    }


    void Update()
    {
        // Data save.
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Start normal save.");
            SaveSceneData(false);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("Start new save.");
            SaveSceneData(true);
        }
        // Data load.
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadSceneData();
        }

        // Scene swithing.
        if (Input.anyKeyDown)
        {
            switch (Input.inputString)
            {
                case "0":
                    SceneManager.LoadScene("Scene0");
                    break;
                case "1":
                    SceneManager.LoadScene("Scene1");
                    break;
                case "2":
                    SceneManager.LoadScene("Scene2");
                    break;
                default:
                    break;
            }
        }
    }
}
