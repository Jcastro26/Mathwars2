using System;
using System.Collections;
using System.Collections.Generic;

public class Node<T>
{
    private T data;
    private Node<T> nextNode;

    public Node(T data)
    {
        this.data = data;
    }

    public Node(T data, Node<T> nextNode)
    {
        this.data = data;
        this.nextNode = nextNode;
    }

    public T Data
    {
        get { return data; }
        set { data = value; }
    }

    public Node<T> NextNode
    {
        get { return nextNode; }
        set { nextNode = value; }
    }
}

public class CustomList<T> : IEnumerable<T>
{
    private Node<T> first;
    private Node<T> last;
    private int size;

    public CustomList()
    {
        first = null;
        last = null;
        size = 0;
    }

    public bool IsEmpty()
    {
        return size == 0;
    }

    public int Size()
    {
        return size;
    }

    public T Get(int index)
    {
        try
        {
            if (IsEmpty() || (index < 0 || index >= Size()))
            {
                return default(T);
            }
            else if (index == 0)
            {
                return GetFirst();
            }
            else if (index == Size() - 1)
            {
                return GetLast();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        Node<T> looked = GetNode(index);
        return looked.Data;
    }

    public T GetFirst()
    {
        if (IsEmpty())
        {
            throw new Exception("Empty List 4");
        }
        else
        {
            return first.Data;
        }
    }

    public T GetLast()
    {
        if (IsEmpty())
        {
            throw new Exception("Empty List 3");
        }
        else
        {
            return last.Data;
        }
    }

    public Node<T> GetNode(int index)
    {
        if (IsEmpty() || (index < 0 || index >= Size()))
        {
            return null;
        }
        if (index == 0)
        {
            return first;
        }
        if (index == Size() - 1)
        {
            return last;
        }
        else
        {
            Node<T> looked = first;
            int counter = 0;
            while (counter < index)
            {
                counter++;
                looked = looked.NextNode;
            }
            return looked;
        }
    }

    public T AddLast(T data)
    {
        Node<T> aux;
        if (IsEmpty())
        {
            return AddFirst(data);
        }
        else
        {
            aux = new Node<T>(data);
            last.NextNode = aux;
            last = aux;
        }
        size++;
        return last.Data;
    }

    public T AddFirst(T data)
    {
        Node<T> aux;
        if (IsEmpty())
        {
            aux = new Node<T>(data);
            first = aux;
            last = aux;
        }
        else
        {
            Node<T> primeroActual = first;
            aux = new Node<T>(data, primeroActual);
            first = aux;
        }
        size++;
        return first.Data;
    }

    public T Add(T data, int index)
    {
        if (index == 0)
        {
            return AddFirst(data);
        }
        if (index == Size())
        {
            return AddLast(data);
        }
        if ((index < 0 || index >= Size()))
        {
            return default(T);
        }
        else
        {
            Node<T> buscado_anterior = GetNode(index - 1);
            Node<T> buscado_actual = GetNode(index);
            Node<T> aux = new Node<T>(data, buscado_actual);
            buscado_anterior.NextNode = aux;
            size++;
            return GetNode(index).Data;
        }
    }

    public int IndexOf(T data)
    {
        if (IsEmpty())
        {
            return -1;
        }
        else
        {
            Node<T> current = first;
            int index = 0;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return index;
                }
                current = current.NextNode;
                index++;
            }
            return -1;
        }
    }

    public bool Exists(T data)
    {
        Node<T> aux = first;
        while (aux != null)
        {
            if (data.Equals(aux.Data))
            {
                return true;
            }
            aux = aux.NextNode;
        }
        return false;
    }

    public void RemoveFirst()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Empty List 0");
        }
        else
        {
            T data = first.Data;
            Node<T> aux = first.NextNode;
            first = null;
            first = aux;
            if (Size() == 1)
            {
                last = null;
            }
            size--;
        }
    }

    public void RemoveLast()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Empty List -1");
        }
        else
        {
            T data = last.Data;
            Node<T> aux = GetNode(Size() - 2);
            if (aux == null)
            {
                last = null;
                if (Size() == 2)
                {
                    last = first;
                }
                else
                {
                    first = null;
                }
            }
            else
            {
                last = null;
                last = aux;
                last.NextNode = null;
            }
            size--;
        }
    }

    public void Remove(int index)
    {
        if (index < 0 || index >= Size())
        {
            throw new IndexOutOfRangeException("Invalid index: " + index);
        }
        else if (index == 0)
        {
            RemoveFirst();
        }
        else if (index == Size() - 1)
        {
            RemoveLast();
        }
        else
        {
            Node<T> prev = GetNode(index - 1);
            Node<T> act = prev.NextNode;
            T data = act.Data;
            Node<T> next = act.NextNode;
            prev.NextNode = next;
            act = null;
            size--;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T> current = first;
        while (current != null)
        {
            yield return current.Data;
            current = current.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public void Clear()
    {
    first = null;
    last = null;
    size = 0;
    }
}

