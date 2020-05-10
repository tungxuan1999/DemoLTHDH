using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo
{
    public class ItemType
    {
        public List<int> arrayInt { get; set; }
        public int frame { get; set; }

        public ItemType(List<int> arrayInt, int frame)
        {
            this.arrayInt = arrayInt;
            this.frame = frame;
        }

        public ItemType()
        {
            arrayInt = new List<int>();
        }

        public bool setArrayIntForString(String key)
        {
            bool check = true;
            List<String> arrayStr = key.Split(' ').ToList();
            for(int i = 0; i < arrayStr.Count;i++)
            {
                try
                {
                    if (Int16.Parse(arrayStr[i]) >= 0)
                    {
                        arrayInt.Add(Int16.Parse(arrayStr[i]));
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            return check;
        }

        public bool setFrame(String key)
        {
            bool check = true;
            try
            {
                if (int.Parse(key) > 0)
                {
                    frame = int.Parse(key);
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                return false;
            }
            return check;
        }
    }
}