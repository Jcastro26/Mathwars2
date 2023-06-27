using System;
using System.Collections;
using System.Collections.Generic;

public class CustomDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    private CustomList<TKey> keys;
    private CustomList<TValue> values;
    private int count;


    public CustomDictionary()
    {
        keys = new CustomList<TKey>();
        values = new CustomList<TValue>();
        count=0 ;
    }

    public void Add(TKey key, TValue value)
    {
        keys.AddLast(key);
        values.AddLast(value);
        count++;
    }

    public bool Remove(TKey key)
    {
        int index = keys.IndexOf(key);
        if (index >= 0)
        {
            keys.Remove(index);
            values.Remove(index);
            count--;
            return true;
        }
        return false;


    }
    public int Count {
        get { return count;}
    }


    public bool ContainsKey(TKey key)
    {        
        return keys.Exists(key);
    }

    public bool TryGetValue(TKey key, out TValue value)
    {
        int index = keys.IndexOf(key);
        if (index >= 0)
        {
        
            value = values.Get(index);
            return true;
        }
        value = default(TValue);
        return false;
    }
    
    public TValue this[TKey key]
    {
        get
        {
            int index = keys.IndexOf(key);
            if (index >= 0)
            {
                
                return values.Get(index);
            }
            throw new KeyNotFoundException("Key not found in dictionary.");
        }
        set
        {
            int index = keys.IndexOf(key);
            if (index >= 0)
            {
               value = values.Get(index);
            }
            else
            {
                keys.AddLast(key);
                values.AddLast(value);
            }
        }
    }

    public void Clear()
    {
        keys.Clear();
        values.Clear();
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        for (int i = 0; i < keys.Size(); i++)
        {
            yield return new KeyValuePair<TKey, TValue>(keys.Get(i), values.Get(i));
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /*public Dictionary<string, object> ToDictionaryWithRenamedKeys<TKey, TValue>()
{
    Dictionary<string, object> dictionary = new Dictionary<string, object>();

    foreach (KeyValuePair<string, object> kvp in this)
    {
        string oldKey = kvp.Key.ToString();
        string newKey = oldKey + "1"; // Agregar "1" al final del nombre de la llave

        dictionary[newKey] = kvp.Value;
    }

    return dictionary;
}*/
public Dictionary<string, object> ToDictionaryWithRenamedKeys()
{
    Dictionary<string, object> dictionary = new Dictionary<string, object>();

    foreach (KeyValuePair<TKey, TValue> kvp in this)
    {
        string oldKey = kvp.Key.ToString();
        string newKey = oldKey + "1"; // Agregar "1" al final del nombre de la llave

        dictionary[newKey] = kvp.Value;
    }

    return dictionary;
}


}