using Mathematic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public NeuralNetwork nn;

    Rigidbody2D rb = new Rigidbody2D();

    public float velocity = 100;

    private bool died;

    public int point;

    public int age;

    public double horizontalDistance;
    public double verticalDistance;

    internal double fitness;
    void Start()
    {
        nn = new NeuralNetwork(2, 6, 1);

        rb = GetComponent<Rigidbody2D>();
        died = false;

        age = 0;
        point = 0;
        fitness = 0;
    }
    private void LateUpdate()
    {
        age++;
    }

    void Update()
    {
        if (getClosestPipe() != null)
        {
            horizontalDistance = getClosestPipe().transform.position.x - transform.position.x;
            verticalDistance = getClosestPipe().transform.position.y - transform.position.y;
        }
        else
        {
            //Debug.LogError("NULL");
        }

        double[,] input = { { horizontalDistance, verticalDistance } };

        double output = nn.Predict(input)[0, 0];

        if (output > 0.95)
        {
            rb.velocity = Vector2.up * velocity;
        }
    }

    private void FixedUpdate()
    {
        if (died)
        {
            Controller.birds.Remove(gameObject.GetComponent<Bird>());
            Controller.deadBirds.Add(gameObject.GetComponent<Bird>());
            point = 0;
            Destroy(gameObject);
        }
    }

    public void generateNN(NeuralNetwork brain)
    {
        if (brain == null)
        {
            nn = new NeuralNetwork(2, 6, 1);
        }

        else
        {
            nn = brain;
            this.Mutate();
        }
    }

    private void Mutate()
    {
        this.nn.Mutate(f);
    }

    private double f(double x)
    {
        if (Random.Range(0, 1f) < 0.1)
        {
            double offset = Random.Range(0, 1f);

            return x + offset;
        }

        return x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle" || collision.name == "Ground")
        {
            died = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "GAP")
        {
            point++;

            GameObject.Find("AI").GetComponent<Controller>().pointText.text = $"{point}";
        }
    }

    private void OnBecameInvisible()
    {
        died = true;
    }

    public GameObject getClosestPipe()
    {
        try
        {
            for (int i = 0; i < CreatorObstacles.pipes.Count; i++)
            {
                if (CreatorObstacles.pipes[i].transform.position.x > transform.position.x) 
                {
                    return CreatorObstacles.pipes[i];

                }
            }

            return null;
        }
        catch
        {
            return null;
        }
    }
}