using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackToMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
