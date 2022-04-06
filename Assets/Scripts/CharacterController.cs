using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed;


    protected void Move(Vector3 direction)
    {
        rb.velocity = direction * moveSpeed * Time.deltaTime;
    }
}
