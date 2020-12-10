using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipe")]
public class Recipe : ScriptableObject {
    public string name;
    public Ingredient[] ingredients;
    public int[] ingQuant;
    public float sellPrice;
    public int workers = 0;

    public bool checkIng() {
        int i = 0;
        foreach (var ing in ingredients) {
            if(ing.quantity < ingQuant[i]) return false;
            i++;
        }
        return true;
    }

    public void makeRecipe() {
        int i = 0;
        foreach (var ing in ingredients) {
            ing.quantity -= ingQuant[i];
            i++;
        }
    }

    public void Reset() {
        workers = 0;
    }
}
