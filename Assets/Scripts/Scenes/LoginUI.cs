using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.UI;
using UnityEngine.SceneManagement;

public class LoginUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartGameJoltAPI();
    }


    private void StartGameJoltAPI() => GameJoltUI.Instance.ShowSignIn(OnSignIn);

    private void OnSignIn(bool success)
    {
        if (success)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.Log("No se pudo logear");
        }
    }


}
