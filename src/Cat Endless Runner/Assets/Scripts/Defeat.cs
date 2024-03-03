using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Defeat : MonoBehaviour
{
    // Start is called before the first frame update
    
    void mainScene()
    {
        SceneManager.LoadScene("Main");
    }
    void Start()
    {
        Invoke("mainScene", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
