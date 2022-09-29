using UnityEngine;

public class CamMove : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField] private KeyCode[] inputs;
    void Update()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        Vector3 direction = Vector3.zero;

        if(Input.GetKey(inputs[0])) //frente
        {
            direction += Vector3.forward;
        }

        if (Input.GetKey(inputs[1])) //esquerda
        {
            direction += Vector3.left;
        }

        if (Input.GetKey(inputs[2])) //trás
        {
            direction += Vector3.back;
        }

        if (Input.GetKey(inputs[3])) //direita
        {
            direction += Vector3.right;
        }

        transform.position += direction * speed * Time.deltaTime;
    }
}
