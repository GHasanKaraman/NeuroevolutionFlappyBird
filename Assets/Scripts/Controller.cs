using Mathematic;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    public GameObject bird;

    [Header("How many birds do you wanna generate?")]
    public int noOfBirds = 100;

    private int totalAge;

    public static List<Bird> birds = new List<Bird>();
    public static List<Bird> deadBirds = new List<Bird>();

    public Text genText;
    public Text pointText;

    private int gen = 0;

    void Start()
    {
        totalAge = 0;
    }

    void Update()
    {
        if (birds.Count == 0)
        {
            totalAge = 0;

            for (int i = 0; i < deadBirds.Count; i++)
            {
                totalAge += deadBirds[i].age;
            }

            for (int i = 0; i < deadBirds.Count; i++)
            {
                deadBirds[i].fitness = deadBirds[i].age / (double)totalAge;
            }

            startGame();
        }
    }

    private Bird pickOne()
    {
        if (deadBirds.Count == 0)
        {
            return bird.GetComponent<Bird>();
        }

        return deadBirds[deadBirds.Count - 1];

        /* This function gets the last bird that was survived
        int index = 0;
        double r = Random.Range(0, 1f);

        while (r > 0)
        {
            r -= deadBirds[index].fitness;
            index++;
        }

        index--;

        return deadBirds[index]; */
    }

    private List<Bird> generateBirds()
    {
        List<Bird> temp = new List<Bird>();

        for (int i = 0; i < noOfBirds; i++)
        {
            NeuralNetwork brain = pickOne().nn;
            GameObject _bird =  Instantiate(bird, transform);
            _bird.GetComponent<Bird>().generateNN(brain);
            temp.Add(_bird.GetComponent<Bird>());
        }

        return temp;
    }

    private void startGame()
    {
        genText.text = "GEN "+(++gen);

        birds = generateBirds();
        deadBirds.Clear();

        CreatorObstacles.pipes.Clear();
        foreach (var item in GameObject.FindGameObjectsWithTag("Obstacle"))
        {
            Destroy(item);
        }

        CreatorObstacles.timer = 1.51f;
    }
}