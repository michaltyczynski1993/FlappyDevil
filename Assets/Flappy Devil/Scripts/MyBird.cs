using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MyBird : MonoBehaviour
{
    // Start is called before the first frame update
    public float upForce = 200f;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    public AudioClip birdFlap;
    public AudioClip birdDie;
    private AudioSource source;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //gameObject.SetActive(false);
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false) 
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
                source.PlayOneShot(birdFlap,1);
            }
        }
    }
    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        if (isDead != true)
        {
            source.PlayOneShot(birdDie,1);
        }
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied();
    }
}
