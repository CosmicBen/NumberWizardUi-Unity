using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] private int max = 1000;
    private int currentMax = 1000;

    [SerializeField] private int min = 1;
    private int currentMin = 1;

    private int guess = 0;
    private List<int> oldGuesses = new List<int>();

    [SerializeField] private TextMeshProUGUI guessUi;

    private void Start()
    {
        StartGame();
    }
    private void StartGame()
    {
        UpdateGuess(min, max);
    }

    private void UpdateGuess(int min, int max)
    {
        if (min == max)
            return;

        currentMin = min;
        currentMax = max;

        guess = Random.Range(currentMin, currentMax + 1);

        if (oldGuesses.Contains(guess))
        {
            UpdateGuess(min, max);
        }
        else
        {
            oldGuesses.Add(guess);
        }

        guessUi.text = guess.ToString();
    }

    public void GuessHigher()
    {
        UpdateGuess(guess, currentMax);
    }

    public void GuessLower()
    {
        UpdateGuess(currentMin, guess);
    }
}
