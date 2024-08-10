using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static void Reverse(this Transform parent)
    {
        if (parent == null || parent.childCount == 0) return;

        for (int i = 0; i < parent.childCount; i++)
        {
            for (int j = 0; j < parent.childCount - 1 - i; j++)
            {
                Transform child1 = parent.GetChild(j);
                Transform child2 = parent.GetChild(j + 1);
                if (child1.name.Length > child2.name.Length)
                {
                    child1.SetSiblingIndex(j + 1);
                    child2.SetSiblingIndex(j);
                }
            }
        }
    }

    public static void Reverse2(this Transform parent)
    {
        if (parent == null || parent.childCount == 0) return;
        List<Transform> list = new List<Transform>();
        for (int i = 0; i < parent.childCount; i++)
        {
            list.Add(parent.GetChild(i));
        }

        list.Sort((a, b) => a.name.Length > b.name.Length ? 1 : -1);

        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetSiblingIndex(i);
        }
        /*    list.Sort(delegate (Transform a, Transform b)
            {
                if (a.name.Length > b.name.Length)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }

            );*/
    }

    public static void Reverse3(this Transform parent)
    {
        if (parent == null || parent.childCount == 0) return;
        bool hasChanged = false;
        do
        {
            hasChanged = false;
            for (int i = 0; i < parent.childCount - 1; i++)
            {
                Transform child1 = parent.GetChild(i);
                Transform child2 = parent.GetChild(i + 1);
                if (child1.name.Length > child2.name.Length)
                {
                    child1.SetSiblingIndex(i + 1);
                    child2.SetSiblingIndex(i);
                    hasChanged = true;
                }
            }
        } while (hasChanged);
    }

    public static List<Transform> FindAllByName(this Transform parent, string name)
    {
        var list = new List<Transform>();
        if (parent == null || parent.childCount == 0) return null;

        for (int i = 0; i < parent.childCount; i++)
        {
            Transform temp = parent.GetChild(i);
            if (temp.name == name)
            {
                list.Add(temp);
            }

            if (temp.childCount > 0)
            {
                for (int j = 0; j < temp.childCount; j++)
                {
                    if (temp.GetChild(j).name == name)
                    {
                        list.Add(temp.GetChild(j));
                    }
                }
            }
        }

        return list;
    }

    public static Transform CustomFind(this Transform parent, string name)
    {
        if (parent == null || parent.childCount == 0) return null;
        Transform temp = null; ;
        temp = parent.Find(name);
        if (temp != null)
        {
            return temp;
        }

        for (int i = 0; i < parent.childCount; i++)
        {
            temp = parent.GetChild(i).CustomFind(name);
            if (temp != null)
            {
                return temp;
            }
        }

        return temp;
    }
}