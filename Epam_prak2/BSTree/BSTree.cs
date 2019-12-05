using System;
using System.Collections.Generic;
using System.Text;

namespace BSTree {

    public class BSTree<T> where T : IComparable {
        private BSTreeNode<T> root;

        public BSTree(T root) {
            this.root = new BSTreeNode<T>(root);
        }

        public BSTreeNode<T> Root {
            get { return root; }
            set { this.root = value; }
        }

        /*event of adding el*/
        public delegate void InsertElEvent(object o, EventArgs e);
        public event InsertElEvent InsertEl;

        /*event of clearing*/
        public delegate void ClearTree(object o, EventArgs e);
        public event ClearTree clearTree;

        public void Clear() {
            root = null;
            clearTree?.Invoke(this, new EventArgs());
        }

        public void Insert(T data) {
            if(data != null) {
                Insert(new BSTreeNode<T>(data));
                InsertEl?.Invoke(this, new EventArgs());
            } else {
                throw new NullTreeNodeException();
            }
            
        }

        private void Insert(BSTreeNode<T> node, BSTreeNode<T> curNode = null) {
            if (node == null)
                throw new NullTreeNodeException();
            if (root == null) {
                node.Parent = null;
                root = node;
            } else {
                curNode = curNode ?? root;
                node.Parent = curNode;
                int comparisson = node.Data.CompareTo(curNode.Data);
                if (comparisson < 0) {
                    if (curNode.Left == null) curNode.Left = node;
                    else Insert(node, curNode.Left);
                } else if (comparisson == 0) { 
                    curNode.Data = node.Data;
                } else {
                    if (curNode.Right == null) curNode.Right = node;
                    else Insert(node, curNode.Right);
                }

            }
        }

        public IEnumerable<BSTreeNode<T>> preOrderTraversal(BSTreeNode<T> node) {
            if(node != null) {
                yield return node;
                foreach (var item in preOrderTraversal(node.Left))
                    yield return item;
                foreach (var item in preOrderTraversal(node.Right))
                    yield return item;
            }
        }

        public void Remove(T data) {
            var foundNode = FindNode(data);
            Remove(foundNode);
        }

        private void Remove(BSTreeNode<T> node) {
            if (node == null)
                throw new NullTreeNodeException("Node is null! Not aible to remove");
            var side = node.NodeSide;
            if(node.Left == null && node.Right == null) {
                if (side == Sides.Right) node.Parent.Right = null;
                else node.Parent.Left = null;
            } else if(node.Left == null) {
                if (side == Sides.Left) node.Parent.Left = node.Right;
                else node.Parent.Right = node.Right;
                node.Right.Parent = node.Parent;
            } else if(node.Right == null) {
                if (side == Sides.Right) node.Parent.Right = node.Left;
                else node.Parent.Left = node.Left;
                node.Left.Parent = node.Parent;
            } else {
                var minimalNode = MinimalNode(node.Right);
                node.Data = minimalNode.Data;
                Remove(minimalNode);
            }
        }

        public BSTreeNode<T> FindNode(T data, BSTreeNode<T> startNode = null) {
            if (data == null) throw new NullTreeNodeException();
            startNode = startNode ?? root;
            int comparisson = data.CompareTo(startNode.Data);
            if(comparisson == 0) {
                return startNode;
            } else if(comparisson < 0) {
                if (startNode.Left == null)
                    return null;
                else return FindNode(data, startNode.Left);
            } else {
                if (startNode.Right == null)
                    return null;
                else return FindNode(data, startNode.Right);
            }
        }


        public BSTreeNode<T> MinimalNode(BSTreeNode<T> node) {
            while (node.Left != null) {
                node = node.Left;
            }
            return node;
        }



    }
}
