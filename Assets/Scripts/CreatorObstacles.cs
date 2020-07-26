using System.Collections.Generic;
using UnityEngine;

public class CreatorObstacles : MonoBehaviour
{
    public float maxTime = 1.5f;
    public static float timer = 1.51f;
    public float height;

    public GameObject pipe;

    public static List<GameObject> pipes = new List<GameObject>();

    void FixedUpdate()
    {
        if (timer > maxTime)
        {
            GameObject newPipe = Instantiate(pipe);
            newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 1);
            pipes.Add(newPipe);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
