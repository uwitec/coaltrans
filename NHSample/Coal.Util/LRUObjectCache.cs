using System.Collections.Generic;

namespace Coal.Util
{
    /// <summary>
    ///  Least Recently Used object Cache
    /// </summary>
    public class LRUObjectCache<K,V>
    {
        private int m_capacity = 0;
        private int m_size = 0;
        private Node<K, V> m_head = new Node<K, V>();
        private Node<K, V> m_tail = new Node<K, V>();
        private Dictionary<K,Node<K,V>> m_cache = null;

        public LRUObjectCache() : this(1024) { }
        public LRUObjectCache(int capacity)
        {
            this.m_capacity = capacity;
            this.m_head.Next = this.m_tail;
            this.m_tail.Prev = this.m_head;
            this.m_cache = new Dictionary<K,Node<K,V>>();
        }

        public V this[K id]
        {
            set{this.set_data(id, value);}
            get{return this.get_data(id);}
        }

        //link node's prev to node's next
        private void break_link(Node<K, V> node)
        {
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }

        //set node as the first node
        private void as_first_node(Node<K, V> node)
        {
            node.Next = this.m_head.Next;
            node.Prev = this.m_head;
            node.Next.Prev = node;
            node.Prev.Next = node;
        }

        private void set_data(K id, V data)
        {
            Node<K, V> node = null;

            if (this.m_cache.ContainsKey(id))
            {
                node=this.m_cache[id];
                node.Data = data;
                if (node == this.m_head.Next) return;
                break_link(node);
                as_first_node(node);
            }
            else
            {
                //hashtable capacity is sufficent,and create new node add to link
                if (this.m_size < this.m_capacity)
                {
                    node = new Node<K, V>(id, data);

                    this.m_cache[id] = node;
                    this.m_size++;

                    as_first_node(node);

                }
                else
                {
                    node = this.m_tail.Prev;
                    this.m_cache.Remove(node.ID);

                    node.ID = id;
                    node.Data = data;
                    this.m_cache[id] = node;

                    break_link(node);
                    as_first_node(node);
                }
            }
        }

        private V get_data(K id)
        {
            if (!this.m_cache.ContainsKey(id)) 
                return default(V);

            Node<K, V> node = this.m_cache[id];
            if (node != this.m_head.Next)
            {
                break_link(node);
                as_first_node(node);
            }

            return node.Data;
        }
    }

    internal class Node<K,V>
    {
        public Node<K, V> Prev;
        public Node<K, V> Next;
        public V Data;
        public K ID;
        public Node(K id, V data)
        {
            this.ID = id;
            this.Data = data;
        }
        public Node() { }
    }

}