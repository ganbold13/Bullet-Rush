
using UnityEngine;

public class EnemyControl : CharacterController
{
    
    [SerializeField] private PlayerControl player; 
    private void FixedUpdate()
    {
        Vector3 delta =  player.transform.position - transform.position ;
        delta.y = 0;
        Vector3 direction = delta.normalized;
        Move(direction);

        transform.LookAt(player.transform);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.transform.CompareTag($"Bullet")){
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}
