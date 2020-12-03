using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Recipe")]
public class Recipe : ScriptableObject {
    public string name;
    public Ingredient[] ingredients;
    public float sellPrice;
    public int workers = 0;

    public bool checkIng() {
        foreach (var i in ingredients) {
            if(i.quantity < 1) return false;
        }
        return true;
    }

    public void makeRecipe() {
        foreach (var i in ingredients) {
            i.quantity--;
        }
    }

    public void Reset() {
        workers = 0;
    }
}
