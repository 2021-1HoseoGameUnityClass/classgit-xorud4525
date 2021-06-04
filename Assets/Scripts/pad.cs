using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pad : MonoBehaviour
{
    [SerializeField]
    private string sceanName = "";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player")==true)
        {
            DetaManager.instance.currentScene = sceanName;
            DetaManager.instance.Save();
            SceneManager.LoadScene(sceanName);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
