using System.Collections.Generic;
using UnityEngine;

public class Inventory<T>
{
    List<T> _item_list = new List<T>();

    public List<T> GetItems()
    {
        return _item_list;
    }

    public T GetItem(int _index)
    {
        return _item_list[_index];
    }

    public void AddItem(T item)
    {
        _item_list.Add(item);
    }

    public void AddItems(List<T> items)
    {
        _item_list.AddRange(items);
    }

    public void RemoveItems(List<T> to_remove)
    {
        for (int i = 0; i < to_remove.Count; i++)
        {
            int index = _item_list.IndexOf(to_remove[i]);
            _item_list.RemoveAt(index);
        }
    }

    public void RemoveItem(T toRemove)
    {
        _item_list.Remove(toRemove);
    }

    public int GetLength(){
        return _item_list.Count;
    }

    public T GetItemOfType(T item)
    { 
        return _item_list[_item_list.IndexOf(item)];
    }

    //TODO: Implement find function
    /*public T FindItem(T property)
    {
        _item_list.Find(x => x.)
    }*/
}
