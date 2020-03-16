using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxiclean : MonoBehaviour
{
    private bool OnScreen = false;

    private Rigidbody2D rigidBody;

    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OnScreen)
        {
            Movement();
        }
    }

    private void Movement()
    {
        float direction = transform.localScale.x / Mathf.Abs(transform.localScale.x);
        rigidBody.velocity = new Vector2(-direction * speed, rigidBody.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Chainsaw Collide")
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameVisible()
    {
        OnScreen = true;
    }

    private void OnBecameInvisible()
    {
        OnScreen = false;
    }
}
