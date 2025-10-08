using UnityEngine;
using UnityEngine.SceneManagement;

public class sceenChanger : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("start screen");
    }
}
