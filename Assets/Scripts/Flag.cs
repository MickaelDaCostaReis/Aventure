using UnityEngine;
using System.Collections;
public class Flag : MonoBehaviour
{
    [SerializeField] bool toNextLevel;
    [SerializeField] string levelName;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (toNextLevel)
            {
                SceneController.instance.NextLevel();
            }
            else
            {
                SceneController.instance.LoadScene(levelName);
            }
        }
    }
}
