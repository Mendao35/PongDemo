using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleControler : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed = 3f;

    private GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball"); //Encontra objeto Bola na Cena
        
    }

    private void Update()
    {
        if(ball != null)
        {
            //Obtem a posiçao Y da Bola e limita o valor de TargetY
            float targetY = Mathf.Clamp(ball.transform.position.y, -4.5f, 4.5f); //Limita a posiçao de Y

            //Cria um novo vetor para a posicao destino do objeto, mantem x Inalterado e ajsuta o Y para seguir a bola
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);

            //Move Gradualmente para a posiçao Y da Bola
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
        }
    }


}
