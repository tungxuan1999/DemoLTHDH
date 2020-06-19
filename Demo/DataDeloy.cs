using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo
{
    public class DataDeloy
    {
        ItemData itemData;
        ItemType itemType;
        public int[][] loca;
        public int[] flag;

        public DataDeloy(ItemType itemType)
        {
            this.itemType = itemType;
            this.itemData = new ItemData(itemType);
        }

        public ItemData getDataFIFO()
        {
            flag = new int[itemType.arrayInt.Count];
            for (int i = 0; i < itemData.xy.Length; i++)
            {
                flag[i] = (i + 1) % itemType.frame;
                if (i == 0)
                {
                    //
                    itemData.xy[i][0] = itemType.arrayInt[i];
                    itemData.pagefalut[i] = i % itemType.frame;
                }
                else
                {
                    int asd = 0;
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (asd != itemType.frame)
                        {
                            if (itemData.pagefalut[j] != -1)
                            {
                                if (itemType.arrayInt[i] == itemType.arrayInt[j])
                                {
                                    itemData.pagefalut[i] = -1;
                                    for (int k = 0; k < itemType.frame; k++)
                                    {
                                        itemData.xy[i][k] = -2;
                                    }
                                    break;
                                }
                                else
                                {
                                    itemData.xy[i][itemData.pagefalut[j]] = itemData.xy[j][itemData.pagefalut[j]];
                                    asd++;
                                }
                            }
                        }
                        if (asd == itemType.frame || j == 0)
                        {
                            for (int k = i - 1; k >= 0; k--)
                            {
                                if (itemData.pagefalut[k] != -1)
                                {
                                    itemData.pagefalut[i] = (itemData.pagefalut[k] + 1) % itemType.frame;
                                    itemData.xy[i][itemData.pagefalut[i]] = itemType.arrayInt[i];
                                    break;
                                }
                            }
                            break;
                        }
                    }

                }
            }
            return itemData;
        }
        public ItemData getDataLRU()
        {
            loca = new int[itemType.arrayInt.Count][];
            for (int i = 0; i < loca.Length; i++)
            {
                loca[i] = new int[itemType.frame];
            }
            for (int i = 0; i < loca.Length; i++)
            {
                for (int j = 0; j < loca[i].Length; j++)
                {
                    loca[i][j] = -1;
                }
            }
            for (int i = 0; i < itemData.xy.Length; i++)
            {
                if (i == 0)
                {
                    itemData.xy[i][0] = itemType.arrayInt[i];
                    itemData.pagefalut[i] = i % itemType.frame;
                    loca[i][0] = i;
                }
                else
                {
                    //coppy loca
                    for(int k = 0; k < itemType.frame; k++)
                    {
                        loca[i][k] = loca[i - 1][k];
                    }

                    bool check = false;
                    for (int k = 0; k < itemType.frame; k++)
                    {
                        if (itemType.arrayInt[i] == itemData.xy[i - 1][k])
                        {
                            itemData.pagefalut[i] = -1;
                            for (int j = 0; j < itemType.frame; j++)
                            {
                                itemData.xy[i][j] = itemData.xy[i - 1][j];
                            }
                            check = true;
                            loca[i][k] = i;
                            break;
                        }
                        if (itemData.xy[i - 1][k] == -1)
                        {
                            itemData.pagefalut[i] = k;
                            for (int j = 0; j < itemType.frame; j++)
                            {
                                itemData.xy[i][j] = itemData.xy[i - 1][j];
                            }
                            itemData.xy[i][k] = itemType.arrayInt[i];
                            check = true;
                            loca[i][k] = i;
                            break;
                        }
                    }
                    if (check) continue;

                    int[] frame = new int[itemType.frame];
                    for (int j = i - 1; j >= 0; j--)
                    {
                        for (int k = 0; k < itemType.frame; k++)
                        {
                            if (itemType.arrayInt[j] == itemData.xy[i - 1][k])
                            {
                                frame[k]++;
                                break;
                            }
                        }
                        bool checkframe = false;
                        for (int k = 0; k < itemType.frame; k++)
                        {
                            if (frame[k] == 0)
                            {
                                checkframe = true;
                                break;
                            }
                        }
                        if (!checkframe)
                        {
                            int loca = -1;
                            for (int k = 0; k < itemType.frame; k++)
                            {
                                if (itemType.arrayInt[j] == itemData.xy[j][k])
                                {
                                    loca = k;
                                    break;
                                }
                            }
                            itemData.pagefalut[i] = loca;
                            for (int k = 0; k < itemType.frame; k++)
                            {
                                itemData.xy[i][k] = itemData.xy[i - 1][k];
                            }
                            itemData.xy[i][loca] = itemType.arrayInt[i];
                            this.loca[i][loca] = i;
                            break;
                        }
                    }
                }
            }
            return itemData;
        }
        public ItemData getDataOPT()
        {
            loca = new int[itemType.arrayInt.Count][];
            flag = new int[itemType.arrayInt.Count];
            for (int i = 0; i < loca.Length; i++)
            {
                loca[i] = new int[itemType.frame];
            }
            for (int i = 0; i < loca.Length; i++)
            {
                for (int j = 0; j < loca[i].Length; j++)
                {
                    loca[i][j] = itemType.arrayInt.Count + 1;
                }
            }
            for (int i = 0; i < itemData.xy.Length; i++)
            {
                if (i == 0)
                {
                    itemData.xy[i][0] = itemType.arrayInt[i];
                    bool check = false;
                    for (int j = i + 1; j < itemData.xy.Length; j++)
                    {
                        if (itemType.arrayInt[i] == itemType.arrayInt[j])
                        {
                            loca[i][0] = j;
                            check = true;
                            break;
                        }
                    }
                    if (!check)
                    {
                        loca[i][0] = itemType.arrayInt.Count;
                    }
                    flag[i] = 1;
                }
                else
                {
                    //coppy loca, page, flag before
                    for (int j = 0; j < itemType.frame; j++)
                    {
                        loca[i][j] = loca[i - 1][j];
                        itemData.xy[i][j] = itemData.xy[i - 1][j];
                    }
                    flag[i] = flag[i - 1];
                    //insert loca, page now
                    ////same page
                    bool checksame = false;
                    for (int j = 0; j < itemType.frame; j++)
                    {
                        if (itemType.arrayInt[i] == itemData.xy[i - 1][j])
                        {
                            for (int k = i + 1; k <= itemData.xy.Length; k++)
                            {
                                if (k == itemData.xy.Length)
                                {
                                    loca[i][j] = itemType.arrayInt.Count;
                                }
                                else
                                {
                                    if (itemType.arrayInt[i] == itemType.arrayInt[k])
                                    {
                                        loca[i][j] = k;
                                        break;
                                    }
                                }
                            }
                            itemData.pagefalut[i] = -1;
                            checksame = true;
                            break;
                        }
                    }
                    if (!checksame)
                    {
                        itemData.xy[i][flag[i]] = itemType.arrayInt[i];
                        for (int j = i + 1; j < itemData.xy.Length; j++)
                        {
                            if (itemType.arrayInt[i] == itemType.arrayInt[j])
                            {
                                loca[i][flag[i]] = j;
                                break;
                            }
                            if (j == itemData.xy.Length - 1)
                            {
                                loca[i][flag[i]] = itemType.arrayInt.Count;
                            }
                        }
                    }
                    //flag
                    int max = -1;
                    for (int j = 0; j < itemType.frame; j++)
                    {
                        if (max < loca[i][j])
                        {
                            max = loca[i][j];
                        }
                    }
                    for (int j = 0; j < itemType.frame; j++)
                    {
                        if (max == loca[i][j])
                        {
                            flag[i] = j;
                            break;
                        }
                    }
                }
            }
            return itemData;
        }
        public ItemData getDataCLOCK()
        {
            loca = new int[itemType.arrayInt.Count][];
            flag = new int[itemType.arrayInt.Count];
            for (int i = 0; i < loca.Length; i++)
            {
                loca[i] = new int[itemType.frame];
            }
            for (int i = 0; i < itemType.arrayInt.Count; i++)
            {
                if (i == 0)
                {
                    itemData.xy[i][flag[i]] = itemType.arrayInt[i];
                    flag[i] = (flag[i] + 1) % itemType.frame;
                    itemData.pagefalut[i] = 1;
                }
                else
                {
                    //coppy next, status, page before
                    for (int j = 0; j < itemType.frame; j++)
                    {
                        loca[i][j] = loca[i - 1][j];
                        itemData.xy[i][j] = itemData.xy[i - 1][j];
                    }
                    flag[i] = flag[i - 1];
                    //insert next, page now
                    ////same page
                    bool checksame = false;
                    for (int j = 0; j < itemType.frame; j++)
                    {
                        if (itemType.arrayInt[i] == itemData.xy[i - 1][j])
                        {
                            loca[i][j] = 1;
                            checksame = true;
                            itemData.pagefalut[i] = -1;
                            break;
                        }
                    }
                    ////different
                    if (!checksame)
                    {
                        while (loca[i][flag[i]] > 0)
                        {
                            loca[i][flag[i]] = 0;
                            flag[i] = (flag[i] + 1) % itemType.frame;
                        }
                        if (loca[i][flag[i]] == 0)
                        {
                            itemData.xy[i][flag[i]] = itemType.arrayInt[i];
                            flag[i] = (flag[i] + 1) % itemType.frame;
                            itemData.pagefalut[i] = 1;
                        }
                    }
                }
            }
            return itemData;
        }
    }
}