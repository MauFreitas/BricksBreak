using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolax : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool emJogo;
    public Transform raquete;
    public float speed;
    public Transform expl;
    public GameManager gm;
    public Transform powerUp;
    public Transform powerDown;
    AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(Vector2.up * 500);
        Audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        if (!emJogo)
        {
            transform.position = raquete.position;
        }
        if (Input.GetButtonDown("Jump") && !emJogo)
        {
            emJogo = true;
            rb.AddForce(Vector2.up * speed);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Down"))
        {
            Debug.Log("Bola fora!");
            rb.velocity = Vector2.zero;
            emJogo = false;
            gm.UpdateLives(-1);

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("brick")){
            bricksScripts BricksScripts = other.gameObject.GetComponent<bricksScripts>();
            if (BricksScripts.hitsParaQuebrar > 1)
            {
                BricksScripts.BreakBrick();
            

            } else {
                int randomChance = Random.Range(1, 101);
                if (randomChance < 30)
                {
                    Instantiate(powerUp, other.transform.position, Quaternion.identity);
                }
                else if (randomChance < 40)
                {
                    Instantiate(powerDown, other.transform.position, Quaternion.identity);
                }

                Transform newexpl = Instantiate(expl, other.transform.position, Quaternion.identity);

                Destroy(newexpl.gameObject, 2.5f);
                gm.UpdateScore(BricksScripts.points);
                gm.UpdateNumberOfBricks();
                Destroy(other.gameObject);
            }
            Audio.Play();
        }
    }
}
