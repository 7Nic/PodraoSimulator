using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientSetter : MonoBehaviour {
    [SerializeField] Player p;
    [SerializeField] Ingredient ing;
    [SerializeField] TextMeshProUGUI infoT;
    [SerializeField] TextMeshProUGUI workT;
    [SerializeField] Button buy;
    [SerializeField] Button plus;
    [SerializeField] Button minus;


    void Start() {
        buy.onClick.AddListener(delegate { p.Buy(ing); });
        plus.onClick.AddListener(delegate { p.AddWorkerIng(ing); });
        minus.onClick.AddListener(delegate { p.RemoveWorkerIng(ing); });
    }

    void Update() {
        infoT.text = ing.name + " R$: " + ing.price + " \n quantidade: " + ing.quantity;
        workT.text = "Funcionários : " + ing.workers; 
    }

}
