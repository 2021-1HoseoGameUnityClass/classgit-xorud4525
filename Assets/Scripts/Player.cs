using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //점프관련 
    [SerializeField]
    public float moveSpeed = 3f;
    [SerializeField]
    private float Jumpforce = 300f;

    private bool isJump = false;
    //총알관련
    [SerializeField]
    private GameObject bulletPos = null;

    [SerializeField]
    private GameObject bulletObj = null;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        if (Input.GetButtonDown("Jump"))
        {
            PlayerJump();
        }
        if(Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    private void PlayerMove()
    {
        float h = Input.GetAxis("Horizontal");
        float PlayerSpeed = h * moveSpeed * Time.deltaTime;
        Vector3 vector3 = new Vector3();
        vector3.x = PlayerSpeed;
        transform.Translate(vector3);
        if (h < 0)
        {
            GetComponent<Animator>().SetBool("Walk", true);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (h == 0)
        {
            GetComponent<Animator>().SetBool("Walk", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Walk", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void PlayerJump()
    {
        if (isJump == false)
        {
            GetComponent<Animator>().SetBool("Walk", false);
            GetComponent<Animator>().SetBool("Jump", true);

            Vector2 vector2 = new Vector2(0, Jumpforce);
            GetComponent<Rigidbody2D>().AddForce(vector2);
            isJump = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            GetComponent<Animator>().SetBool("Jump", false);
            isJump = false;
        }
        if (collision.collider.tag == "Enemy")
        {
            DetaManager.instance.playerHP -= 1;
            if(DetaManager.instance.playerHP<0)
            {
                DetaManager.instance.playerHP = 0;
            }

            UiManager.instance.PlayerHP();
        }
    }
    private void Fire()
    {
        AudioClip audioClip = Resources.Load<AudioClip>("RangedAttack") as AudioClip;
        GetComponent<AudioSource>().clip = audioClip;
        GetComponent<AudioSource>().Play();
        float direction = transform.localScale.x;
        Quaternion quaternion = new Quaternion(0, 0, 0, 0);
        Instantiate(bulletObj,bulletPos.transform.position,quaternion).GetComponent<Bullet>().InstantiateBullet(direction);
    }
}