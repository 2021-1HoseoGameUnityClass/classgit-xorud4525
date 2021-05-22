using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float PlayerSpeed = h * moveSpeed * Time.deltaTime;
        Vector3 vector3 = new Vector3();
        vector3.x = PlayerSpeed;
        transform.Translate(vector3);
        if(h<0)
        {
            GetComponent<Animator>().SetBool("Walk", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(h==0)
        {
            GetComponent<Animator>().SetBool("Walk", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walk", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

}
