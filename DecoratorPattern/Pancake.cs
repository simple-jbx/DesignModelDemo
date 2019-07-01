using System;
using System.Collections.Generic;

namespace DecoratorPattern
{
    class Pancake
    {
        Dictionary<string, int> dic = new Dictionary<string, int>();

        protected string resultStr = "";
        protected double totalPrice = 0;
        public double TotalPrice { get => totalPrice; set => totalPrice = value; }

        public string showInfo()
        {
            foreach(KeyValuePair<string, int> kp in dic)
            {
                resultStr = kp.Key + " " + "x" + kp.Value + " " + resultStr;
            }
            return resultStr;
        }

        public string showPrice()
        {
            return string.Format("总价为{0}元。", totalPrice);            
        }

        public virtual void add(string key)
        {
            if(!string.IsNullOrWhiteSpace(key))
            {
                if (dic.ContainsKey(key))
                {
                    dic[key]++;
                }
                else
                {
                    dic.Add(key, 1);
                }
            }
        }
    }

    class Ingredient : Pancake
    {
        protected Pancake pancake;
        protected string name = "";
        protected double price = 0;

        public void Decorate(Pancake pancake)
        {
            this.pancake = pancake;
            add(name);
        }

        public override void add(string key)
        {
            if(pancake != null)
            {
                pancake.TotalPrice += price;
                pancake.add(key);
            }
        }
    }

    class Vegetable : Ingredient
    {
        public Vegetable()
        {
            price = 1.0;
            name = "菜";
        }

        public override void add(string key)
        {
            base.add(name);
        }
    }

    class Egg : Ingredient
    {
        public Egg()
        {
            price = 1.5;
            name = "鸡蛋";
        }

        public override void add(string key)
        {
            base.add(name);
        }
    }

    class Sausage : Ingredient
    {
        public Sausage()
        {
            price = 2.0;
            name = "火腿";
        }

        public override void add(string key)
        {
            base.add(name);
        }
    }

    class MeatFloss : Ingredient
    {
        public MeatFloss()
        {
            price = 2.5;
            name = "肉松";
        }

        public override void add(string key)
        {
            base.add(name);
        }
    }
}
