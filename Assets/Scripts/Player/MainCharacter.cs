using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MainCharacter : MonoBehaviour
{
    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    public void MoveCharacter(Vector2 movementVector)
    {
        _body.MovePosition(_body.position + movementVector * Time.deltaTime);
    }
}
