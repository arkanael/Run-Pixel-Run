using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    /// <summary>
    /// Configura a for�a do pulo
    /// </summary>
    public float JumpForce;

    /// <summary>
    /// Verifica se o player est� tocando o j�o
    /// </summary>
    [SerializeField]
    private bool isGrounded = false;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded) 
            {
                //Adiciona for�a ao salto
                rb.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Verifica se o player tocou no ch�o
        if (collision.gameObject.CompareTag("ground"))
        {
            if (!isGrounded)
            {
                isGrounded = true;
            }
        }
    }
}
