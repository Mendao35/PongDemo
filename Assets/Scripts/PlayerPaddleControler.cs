using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddleControler : MonoBehaviour
{
    public float speed = 5f;

    public string movementAxisName = "Vertical";

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        if (isPlayer)
        {
            spriteRenderer.color = SaveControler.Instance.colorPlayer;
        }
        else
        {
            spriteRenderer.color = SaveControler.Instance.colorEnemy;
        }
            
    }
    // Update is called once per frame
    void Update()
    {
        //Captura das teclas de moviumento vertidal W e S, elas variam de 1 a -1
        float moveInput = Input.GetAxis(movementAxisName);

        //Calcula a nova posiçao da Raquete Baseada na entrada e na velocidade
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        //Limita a posiçao vertical da raquete para que ela nao saia da tela
        //CLAMP restringe um valor entre um valor minimo e maximo
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

        //Atualiza a posiçao da Raquete
        transform.position = newPosition;
    }
}
