using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raquetex : MonoBehaviour
{
    public float speed;
    public float limiteDireita;
    public float limiteEsquerda;
    public GameManager gm;
    public Sprite paddlePowerDown;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * Time.deltaTime * speed);
        if (transform.position.x < limiteEsquerda)
        {
            transform.position = new Vector2(limiteEsquerda, transform.position.y);
        }
        if (transform.position.x > limiteDireita)
        {
            transform.position = new Vector2(limiteDireita, transform.position.y);
        }
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("extraLife"))
        {
            Debug.Log("Hit: " + other.name);
            gm.UpdateLives(1);
            Destroy(other.gameObject);
        }
        if(other.CompareTag("powerDown"))
        {
            Debug.Log("Hitii: " + other.name);
            gm.UpdateScore(-250);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("paddlePowerUp")) {
            Debug.Log("Tocou!: " + other.name);
        }
       
    }
}
