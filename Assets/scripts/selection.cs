using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class selection : MonoBehaviour
{
    private  EventSystem eventSystem;
    private List<string> ingredients = new List<string> (){
        "Salt","Pepper","Sugar","PotatoStarch","ChickenStockPowder","SoySauce",
        "ChineseChiliBeanSauce","SesameOil","Milk",
        "Water","Cabbage","ChineseCabbage","Carrot","Onion","Radish","GreenOnion",
        "Egg","Tofu","Potato","Pampkin","Cucumber","Pork","Beef","Chicken",
        "GroundBeef","GroundPork","Eggplant","BellPepper","Shrimp","Ginger","Rice"
    };
    private List<string> ingredients_ans = new List<string> (){
        "Salt","Pepper","SoySauce","Onion","GreenOnion",
        "Egg","Beef","Rice"
    };
    public Dictionary<string,bool> ingredients_activation = new Dictionary<string,bool>();
    public List<Button> ingredient_buttons = new List<Button> ();

    // Start is called before the first frame update
    void Awake(){
        eventSystem=EventSystem.current;
    }
    void Start()
    {
        foreach (string ing in ingredients){
            ingredients_activation.Add(ing,false); 
            Button ing_button = this.transform.Find("Scroll View/Viewport/Content/"+ing).gameObject.GetComponent<Button>();
            Button enter_button = this.transform.Find("EnterButton").gameObject.GetComponent<Button>();
            ing_button.onClick.AddListener(Button_clicked); 
            enter_button.onClick.AddListener(Select_enter_clicked); 
        }        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    void Button_clicked(){
        GameObject red_frame= Resources.Load("Prefabs/frame",  typeof(GameObject)) as GameObject;
        GameObject clicked_button = eventSystem.currentSelectedGameObject;
        string clicked_button_name = clicked_button.name;
        if (ingredients_activation[clicked_button_name]==false){
            GameObject instantiated_frame = Instantiate(red_frame,clicked_button.transform.position, Quaternion.identity) as GameObject;
            instantiated_frame.name = "frame";
            instantiated_frame.transform.SetParent(clicked_button.transform);
            instantiated_frame.transform.localScale = Vector3.one*1.2f;
        }
        else{
            Destroy(clicked_button.transform.Find("frame").gameObject);
        }
        ingredients_activation[clicked_button_name] = !ingredients_activation[clicked_button_name];
    }
    void Select_enter_clicked(){
        int correct_counter = 0;
        int total_ing_num = ingredients_ans.Count;
        foreach (string ing in ingredients_ans){
            if (ingredients_activation[ing] == true){
                correct_counter ++;
            }
        }
        
        Debug.Log(correct_counter.ToString() + "/"+ total_ing_num.ToString());
        
    }
}
