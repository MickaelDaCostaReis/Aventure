using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Start()
    {
        //permet de garder l'ojet contenant ce script...
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //... Sauf s'il existe déjà
        else
        {
            Destroy(gameObject);
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}
