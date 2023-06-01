using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float score;
    public bool isAlive;
    /// <summary>
    /// Configura a força do pulo
    /// </summary>
    public float JumpForce;

    /// <summary>
    /// Verifica se o player está tocando o jão
    /// </summary>
    [SerializeField]
    private bool isGrounded = false;

    Rigidbody2D rb;
    public Text ScoreTxt;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded) 
            {
                //Adiciona força ao salto
                rb.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = $"{score.ToString("0")}";
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Verifica se o player tocou no chão
        if (collision.gameObject.CompareTag("ground"))
        {
             if (!isGrounded)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
        }
    }
}
