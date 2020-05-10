using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo
{
    public class ItemData
    {
        ItemType itemType;
        public int[][] xy;
        public int[] pagefalut;

        public ItemData(ItemType itemType)
        {
            this.itemType = itemType;
            xy = new int[itemType.arrayInt.Count][];
            for(int i = 0; i < xy.Length; i++)
            {
                xy[i] = new int[itemType.frame];
            }
            pagefalut = new int[itemType.arrayInt.Count];
            Install();
        }

        void Install()
        {
            for(int i = 0; i < xy.Length; i++)
            {
                for(int j = 0; j < xy[i].Length; j++)
                {
                    xy[i][j] = -1;
                }
            }
        }
    }
}