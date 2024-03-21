using UnityEngine;
using System.Collections;
public class Flag : MonoBehaviour
{
    [SerializeField] bool toNextLevel;
    [SerializeField] string levelName;
    //[SerializeField] Transform spawnPoint;
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (toNextLevel)
            {
                SceneController.instance.NextLevel();
                //collision.transform.position = spawnPoint.position;
            }
            else
            {
                SceneController.instance.LoadScene(levelName);
            }
        }
    }
}
