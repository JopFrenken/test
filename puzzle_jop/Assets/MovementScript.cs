using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    private Rigidbody2D myrb;
    private ConstantForce2D constForce;
    private bool isActive = false;
    private Vector3 currentForce;
    private SpriteRenderer sr;
    private ParticleSystem colParticle;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0.48f, 0.45f);
        myrb = GetComponent<Rigidbody2D>();
        myrb.gravityScale = 0.0f;
        constForce = GetComponent<ConstantForce2D>();
        currentForce = constForce.force;
    }

    // Update is called once per frame
    void Update()
    {
        myrb.velocity = Vector2.ClampMagnitude(myrb.velocity, 3f);
        if(isActive == false) {

            if (Input.GetKey("down"))
            {
                isActive = true;
                /*transform.Translate(Vector3.down * Time.deltaTime * speed);*/
                currentForce.y = -3;
                constForce.force = currentForce;
            }
            else if (Input.GetKey("up"))
            {
                isActive = true;
                /*transform.Translate(Vector3.up * Time.deltaTime * speed);*/
                currentForce.y = 3;
                constForce.force = currentForce;
            }
            else if (Input.GetKey("right"))
            {
                isActive = true;
                /*transform.Translate(Vector3.right * Time.deltaTime * speed);*/
                currentForce.x = 3;
                constForce.force = currentForce;
            }
            else if (Input.GetKey("left"))
            {
                isActive = true;
                /*transform.Translate(Vector3.left * Time.deltaTime * speed);*/
                currentForce.x = -3;
                constForce.force = currentForce;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            isActive = false;
            currentForce.y = 0;
            currentForce.x = 0;
            constForce.force = currentForce;
            myrb.gravityScale = 0.0f;
            myrb.velocity = Vector2.zero;
            myrb.angularVelocity = 0f;
            Debug.Log("it works");
        }
        if(collision.gameObject.tag == "end")
        {
            SceneManager.LoadScene("EndScene");
        }
        if (collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene("DeathScene");
  /*          colParticle = GetComponent<ParticleSystem>();
            if (colParticle != null)
            {
                ParticleSystem.EmissionModule em = colParticle.emission;
                em.rateOverTime = 5.0f;
                var dur = colParticle.main.duration;
                Destroy(sr);
                Invoke(nameof(DestroyObject), dur);
            } else
            {
                
            }*/
        }
    }
}
