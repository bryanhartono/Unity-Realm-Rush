using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int starting_balance = 150;
    [SerializeField ]int current_balance;

    public int CurrentBalance { get { return current_balance; } }

    [SerializeField] TextMeshProUGUI display_balance;

    void Awake() 
    {
        current_balance = starting_balance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        current_balance += Mathf.Abs(amount); // removes any negative amount with Abs()
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        current_balance -= Mathf.Abs(amount); // removes any negative amount with Abs()
        UpdateDisplay();

        if (current_balance < 0)
        {
            // Lose the game
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        display_balance.text = $"Gold: {current_balance}";
    }

    void ReloadScene()
    {
        Scene current_scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current_scene.buildIndex);
    }
}
