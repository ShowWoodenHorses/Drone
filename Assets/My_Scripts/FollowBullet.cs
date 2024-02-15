
using UnityEngine;

public class FollowBullet : Bullet, ICanAttack
{

    private void Update()
    {
        Vector3 direction = _player.transform.position - transform.position;
        Quaternion rotate = transform.rotation;
        transform.rotation = Quaternion.RotateTowards(rotate,
            Quaternion.LookRotation(direction), 1000f);
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position,
            _speed * Time.deltaTime);
        Destroy(gameObject, 5f);
    }
}
