using System;

namespace BSTree {
    public enum Sides {
        Right, Left
    }

    public class BSTreeNode<T> where T : IComparable {
        private T data;
        private BSTreeNode<T> parent;
        private BSTreeNode<T> left;
        private BSTreeNode<T> right;

        public T Data {
            get { return data; }
            set { this.data = value; }
        }

        public BSTreeNode<T> Parent {
            get { return parent; }
            set { this.parent = value; }
        }

        public BSTreeNode<T> Left {
            get { return left; }
            set { this.left = value; }
        }

        public BSTreeNode<T> Right {
            get { return right; }
            set { this.right = value; }
        }

        public BSTreeNode(T data) {
            this.data = data;
        }

        public Sides? NodeSide =>
            parent == null ? (Sides?)null : parent.Left == this ? Sides.Left : Sides.Right;
    }
}
