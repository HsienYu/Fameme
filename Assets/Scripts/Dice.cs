using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dice : MonoBehaviour {

    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;

    // Reference to sprite renderer to change sprites
    //private SpriteRenderer rend;

    private Image rend;


    // Use this for initialization
    private void Start () {

        // Assign Renderer component
        rend = GetComponent<Image>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
	}

    void Update()
    {
        if (Input.touchCount > 0)
        {
            StartCoroutine("RollTheDice");
        }
    }

    // If you left click over the dice then RollTheDice coroutine is started
    public void DiceUp()
    {
        StartCoroutine("RollTheDice");
    }



    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        int randomDiceSide = 0;

        int finalSide = 0;

        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 5);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomDiceSide + 1;

        // Show final dice value in Console
        Debug.Log(finalSide);
    }
}
