using UnityEngine;

public class SceneAutoTransition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneLoader.LoadNextScene(3));
    }
}
