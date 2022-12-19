using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerBuilder : MonoBehaviour

{
    public bool cheese;
    public bool ham;
    public bool onion;
    public bool cabbage;
    public bool ketchap;
    public bool mayo;
    public bool beef;
    public bool chicken;
    public Burger _burger;
    public void MakeBurger()
    {
        this._burger = new Burger();
        if (cheese) _burger.SetCheese();
        if (ham) _burger.SetHam();
        if (onion) _burger.SetOnion();
        if (cabbage) _burger.SetCabbage();
        if (ketchap) _burger.SetKetchap();
        if (mayo) _burger.SetMayo();
        if (beef) _burger.SetBeef();
        if (chicken) _burger.SetChicken();
       
        GameObject.Find("bradUp").transform.position = new Vector2(GameObject.Find("bradUp").transform.position.x + 7, GameObject.Find("bradUp").transform.position.y);
        GameObject.Find("bradDown").transform.position = new Vector2(GameObject.Find("bradDown").transform.position.x + 7, GameObject.Find("bradDown").transform.position.y);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) MakeBurger();
    }


   



}

public class Ingridient
    {
        public string name { get; set; }

        public Ingridient(string name)
        {
            this.name = name;
        }
    }
    public class Burger
    {
        public Ingridient Cheese { get; set; }
        public Ingridient Ham { get; set; }
        public Ingridient Onion { get; set; }
        public Ingridient Cabbage { get; set; }
        public Ingridient Ketchap { get; set; }
        public Ingridient Mayo { get; set; }
        public Ingridient Beef { get; set; }
        public Ingridient Chicken { get; set; }
        
        public Burger SetCheese()
        {
            this.Cheese = new Ingridient("cheese");
        GameObject.Find("cheese").transform.position = new Vector2(GameObject.Find("cheese").transform.position.x + 7, GameObject.Find("cheese").transform.position.y);
            return this;
        }
        public Burger SetHam()
        {
            this.Ham = new Ingridient("ham");
        GameObject.Find("ham").transform.position = new Vector2(GameObject.Find("ham").transform.position.x + 7, GameObject.Find("ham").transform.position.y);
        return this;
        }
        public Burger SetOnion()
        {
            this.Onion = new Ingridient("onion");
        GameObject.Find("onion").transform.position = new Vector2(GameObject.Find("onion").transform.position.x + 7, GameObject.Find("onion").transform.position.y);
        return this;
        }
        public Burger SetCabbage()
        {
            this.Cabbage = new Ingridient("cabbage");
        GameObject.Find("cabbage").transform.position = new Vector2(GameObject.Find("cabbage").transform.position.x + 7, GameObject.Find("cabbage").transform.position.y);
        return this;
        }
        public Burger SetKetchap()
        {
            this.Ketchap = new Ingridient("ketchap");
        GameObject.Find("ketchap").transform.position = new Vector2(GameObject.Find("ketchap").transform.position.x + 7, GameObject.Find("ketchap").transform.position.y);
        return this;
        }
        public Burger SetMayo()
        {
            this.Mayo = new Ingridient("mayo");
        GameObject.Find("mayo").transform.position = new Vector2(GameObject.Find("mayo").transform.position.x + 7, GameObject.Find("mayo").transform.position.y);
        return this;
        }
        public Burger SetBeef()
        {
            this.Beef = new Ingridient("beef");
        GameObject.Find("beef").transform.position = new Vector2(GameObject.Find("beef").transform.position.x + 7, GameObject.Find("beef").transform.position.y);
        return this;
        }
        public Burger SetChicken()
        {
            this.Chicken = new Ingridient("chicken");
        GameObject.Find("chicken").transform.position = new Vector2(GameObject.Find("chicken").transform.position.x + 7, GameObject.Find("chicken").transform.position.y);
        return this;
        }
    }


