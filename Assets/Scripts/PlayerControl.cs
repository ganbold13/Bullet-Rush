using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : CharacterController
{
    [SerializeField] private ScreenTouchController input;
    [SerializeField] private ShootController shootController;


    private List<Transform> _enemies = new List<Transform>();
    private bool isShooting;

    private void FixedUpdate()
    {
        Vector3 direction = new Vector3(input.Direction.x, 0, input.Direction.y);
        Move(direction);
    }
    private void Update()
		{
			if (_enemies.Count > 0)
				transform.LookAt(_enemies[0]);
		}

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag($"Enemy"))
        {
            if (!_enemies.Contains(other.transform))
                _enemies.Add(other.transform);

            AutoShoot();
        }
    }
    private void OnTriggerExit(Collider other)
		{
			if (other.transform.CompareTag($"Enemy"))
			{
				_enemies.Remove(other.transform);
			}
		}

    private void AutoShoot()
    {
        IEnumerator Do()
        {
            while (_enemies.Count > 0)
            {
                var enemy = _enemies[0];
                var direction = enemy.transform.position - transform.position;
                direction.y = 0;
                direction = direction.normalized;
                shootController.Shoot(direction, transform.position);
                _enemies.RemoveAt(0);
                yield return new WaitForSeconds(shootController.Delay);
            }
            isShooting = false;
        }
        if (!isShooting)
        {
            isShooting = true;
            StartCoroutine(Do());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag($"Enemy"))
        {
            Dead();
        }
    }

    private void Dead()
    {
        Time.timeScale = 0;
    }
}


