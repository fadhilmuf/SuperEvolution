using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public Button tryAgainButton;

    void Start()
    {
        tryAgainButton = GetComponent<Button>();
        tryAgainButton.onClick.AddListener(ReloadLevel);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ReloadLevel();
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene("Main");
    }
}
