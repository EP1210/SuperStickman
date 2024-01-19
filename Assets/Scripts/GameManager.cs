

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;




public class GameManager : MonoBehaviour
{
  public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RestartLevel()
    {
        StartCoroutine(RestartLevelCoroutine());
    }

    private IEnumerator RestartLevelCoroutine()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


