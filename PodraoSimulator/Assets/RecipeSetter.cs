using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RecipeSetter : MonoBehaviour {
    [SerializeField] Player p;
    [SerializeField] Recipe rec;
    [SerializeField] TextMeshProUGUI infoT;
    [SerializeField] TextMeshProUGUI workT;
    [SerializeField] Button sell;
    [SerializeField] Button plus;
    [SerializeField] Button minus;


    void Start() {
        sell.onClick.AddListener(delegate { p.Sell(rec); });
        plus.onClick.AddListener(delegate { p.AddWorkerRec(rec); });
        minus.onClick.AddListener(delegate { p.RemoveWorkerRec(rec); });
    }

    void Update() {
        infoT.text = rec.name + " R$: " + rec.sellPrice + "\n";
        int i = 0;
        foreach(Ingredient ing in rec.ingredients) {
            infoT.text += ing.name + " x" + rec.ingQuant[i] + "\n";
            i++;
        }
        workT.text = "Funcionários : " + rec.workers; 
    }

}
