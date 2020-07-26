using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -5)
        {
            CreatorObstacles.pipes.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
