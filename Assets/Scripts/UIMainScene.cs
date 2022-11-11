using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainScene : MonoBehaviour
{
    public static UIMainScene Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
    }

        // Update is called once per frame
        void Update()
    {
        
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
