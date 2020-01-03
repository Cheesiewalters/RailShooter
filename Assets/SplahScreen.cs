using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplahScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("LoadLevel", 5f);
    }
    
    void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
    
}
