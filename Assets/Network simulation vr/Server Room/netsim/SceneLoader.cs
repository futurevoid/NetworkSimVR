using UnityEngine;
using UnityEngine.SceneManagement; // مهم عشان تتحكم بالمشاهد

public class SceneLoader : MonoBehaviour
{
    public void LoadTCPScene()
    {
        SceneManager.LoadScene("TCPScene");
    }
}
