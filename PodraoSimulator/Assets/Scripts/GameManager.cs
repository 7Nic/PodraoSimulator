using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {
    public Player player;
    public Ingredient[] ingredients;
    public Recipe[] recipes;
    public TextMeshProUGUI[] ingTexts;
    public TextMeshProUGUI[] recTexts;
    public TextMeshProUGUI moneyText;




    // Update is called once per frame
    void Update() {
        int i = 0;
        foreach(Ingredient ing in ingredients) {
            ingTexts[i].text = ing.name + " R$: " + ing.price + " \n quantidade: " +ing.quantity; 
            i++;
        }
        i = 0;
        foreach(Recipe rec in recipes) {
            recTexts[i].text = rec.name + " R$: " + rec.sellPrice + "\n";
            foreach(Ingredient ing in rec.ingredients) {
                recTexts[i].text += ing.name + "\n";
            }
            i++;
        }
        moneyText.text = "Dinheiro: R$ " + player.money;
    }
}
