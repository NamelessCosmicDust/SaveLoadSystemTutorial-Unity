using UnityEngine;
using UnityEngine.SceneManagement;

internal class Scene0_Manager : MonoBehaviour
{
    void Update()
    {
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
