using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Player player;
    public Ingredient[] ingredients;
    public Recipe[] recipes;
    public Text[] ingTexts;




    // Update is called once per frame
    void Update() {
        int i = 0;
        foreach(Ingredient ing in ingredients) {
            ingTexts[i].text = ing.name + ": quantidade: " +ing.quantity; 
            i++;
        }
        
    }
}
