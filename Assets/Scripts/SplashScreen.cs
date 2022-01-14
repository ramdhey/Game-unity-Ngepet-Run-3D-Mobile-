using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public float jeda = 9f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(lanjut());
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator lanjut()
    {
        yield return new WaitForSeconds(jeda);
        SceneManager.LoadScene(1);
    }

    
}
