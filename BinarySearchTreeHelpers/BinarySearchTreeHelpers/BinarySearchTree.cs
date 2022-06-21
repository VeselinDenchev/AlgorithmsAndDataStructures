namespace BinarySearchTreeHelpers
{
    public class BinarySearchTree
    {
        public BinaryTreeNode root;

        public int? leftSubtreeSum;

        public int? rightSubtreeSum;

        public BinarySearchTree(int[] nodes)
        {
            this.root = null;
            InitializeBinarySearchTree(nodes);
            SetLeftSubtreeSumValue();
            SetRightSubtreeSumValue();
        }

        public bool HasLeftSubtree
        {
            get
            {
                if (this.root.leftChild is not null) return true;
                else return false;
            }
        }
        
        public bool HasRightSubtree
        {
            get
            {
                if (this.root.rightChild is not null) return true;
                else return false;
            }
        }

        public void AddNode(ref BinaryTreeNode root, int value)
        {
            BinaryTreeNode node = new BinaryTreeNode();
            node.Value = value;

            if (root is null)
            {
                root = node;
            }
            else
            {
                try
                {
                    if (value < root.Value)
                    {
                        AddNode(ref root.leftChild, value);
                    }
                    else if (value > root.Value)
                    {
                        AddNode(ref root.rightChild, value);
                    }
                    else
                    {
                        throw new ArgumentException($"{value} is already in the tree");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        public void TraverseNodeLeftRight(BinaryTreeNode parent)
        {
            if (parent is not null)
            {
                Console.Write(parent.Value + " ");
                TraverseNodeLeftRight(parent.leftChild);
                TraverseNodeLeftRight(parent.rightChild);
            }
        }

        public void TraverseLeftNodeRight(BinaryTreeNode parent)
        {
            if (parent is not null)
            {
                TraverseLeftNodeRight(parent.leftChild);
                Console.Write(parent.Value + " ");
                TraverseLeftNodeRight(parent.rightChild);
            }
        }

        public void TraverseLeftRightNode(BinaryTreeNode parent)
        {
            if (parent is not null)
            {
                TraverseLeftRightNode(parent.leftChild);
                TraverseLeftRightNode(parent.rightChild);
                Console.Write(parent.Value + " ");
            }
        }

        public void CalculateТreeSum(BinaryTreeNode root, ref int? subtreeSum)
        {
            CalculateChildSubtreeSum(root.leftChild, ref subtreeSum);

            subtreeSum += root.Value;

            CalculateChildSubtreeSum(root.rightChild, ref subtreeSum);
        }

        public void CheckDivisibility(BinaryTreeNode root, int divisor)
        {
            CheckDivisibilityOfChild(root.leftChild, divisor);

            bool isDivisible = root.Value % divisor == 0;
            if (isDivisible)
            {
                // Do something
            }

            CheckDivisibilityOfChild(root.rightChild, divisor);
        }

        public BinaryTreeNode Find(int value)
        {
            return this.Find(value, this.root);
        }

        public void Remove(int value)
        {
            this.root = Remove(this.root, value);
        }

        public int GetTreeDepth()
        {
            return this.GetTreeDepth(this.root);
        }

        private void CalculateChildSubtreeSum(BinaryTreeNode child, ref int? subtreeSum)
        {
            if (child is not null)
            {
                CalculateТreeSum(child, ref subtreeSum);
            }
        }

        private void CheckDivisibilityOfChild(BinaryTreeNode child, int divisor)
        {
            if (child is not null)
            {
                CheckDivisibility(child, divisor);
            }
        }

        private void InitializeBinarySearchTree(int[] nodes)
        {
            foreach (int node in nodes)
            {
                this.AddNode(ref this.root, node);
            }
        }

        private void SetLeftSubtreeSumValue()
        {
            if (this.HasLeftSubtree)
            {
                this.leftSubtreeSum = 0;
                CalculateТreeSum(this.root.leftChild, ref this.leftSubtreeSum);
            }
        }

        private void SetRightSubtreeSumValue()
        {
            if (this.HasRightSubtree)
            {
                this.rightSubtreeSum = 0;
                CalculateТreeSum(this.root.rightChild, ref this.rightSubtreeSum);
            }
        }

        private BinaryTreeNode Find(int value, BinaryTreeNode parent)
        {
            if (parent is not null)
            {
                if (value == parent.Value) return parent;
                if (value < parent.Value) return Find(value, parent.leftChild);
                else return Find(value, parent.rightChild);
            }

            return null;
        }

        private BinaryTreeNode Remove(BinaryTreeNode parent, int key)
        {
            if (parent == null) return parent;

            if (key < parent.Value)
            {
                parent.leftChild = Remove(parent.leftChild, key);
            }
            else if (key > parent.Value)
            {
                parent.rightChild = Remove(parent.rightChild, key);
            }

            // if value is same as parent's value, then this is the node to be deleted  
            else
            {
                bool parentHasLessThanTwoChilds = parent.leftChild == null;
                if (parentHasLessThanTwoChilds)
                {
                    return parent.rightChild;
                }   
                else if (parent.rightChild == null)
                {
                    return parent.leftChild;
                }

                // node with two children: Get the inorder successor (smallest in the right subtree)  
                parent.Value = MinValue(parent.rightChild);

                // Delete the inorder successor  
                parent.rightChild = Remove(parent.rightChild, parent.Value);
            }

            return parent;
        }

        private int MinValue(Node node)
        {
            int minv = node.Data;

            while (node.LeftNode != null)
            {
                minv = node.LeftNode.Data;
                node = node.LeftNode;
            }

            return minv;
        }

        private int GetTreeDepth(BinaryTreeNode parent)
        {
            int treeDepth = 0;

            if (parent is not null)
            {
                treeDepth = Math.Max(GetTreeDepth(parent.leftChild), GetTreeDepth(parent.rightChild)) + 1;
            }

            return treeDepth;
        }
    }
}
