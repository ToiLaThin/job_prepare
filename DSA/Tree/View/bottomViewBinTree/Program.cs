﻿//https://geeksforgeeks.org/bottom-view-binary-tree/?ref=gcse_ind
using System;
using System.Collections.Generic;

public class Program {
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        } 
    }

    public static void bottomView(TreeNode root) {
        if (root == null) {
            return;
        }

        Queue<(TreeNode, int)> queue = new Queue<(TreeNode, int)>();
        SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
        int nodeHD = 0;
        TreeNode node;
        queue.Enqueue((root, 0));
        while (queue.Count > 0) {
            var tuple = queue.Dequeue();
            node = tuple.Item1;
            nodeHD = tuple.Item2;

            if (dict.ContainsKey(nodeHD) == false) {
                dict.Add(nodeHD, node.val);
            }
            else {
                dict[nodeHD] = node.val;
            }

            if (node.left != null) {
                queue.Enqueue((node.left, nodeHD - 1));
            }

            if (node.right != null) {
                queue.Enqueue((node.right, nodeHD + 1));
            }
        }

        var nodeKeys = dict.Values.ToList();

        for (int i = 0; i < nodeKeys.Count(); i++) {
            Console.Write(nodeKeys[i] + " ");
        }
    }

    public static void Main(string[] args) {
        TreeNode root = new TreeNode(1);
        root.right = new TreeNode(3);
        root.left = new TreeNode(2);
        root.left.right = new TreeNode(5);
        root.left.left = new TreeNode(4);
        root.right.left = new TreeNode(6);
        root.right.right = new TreeNode(7);
    //      1
    //   /     \
    //  2       3
    // /  \    / \
    //4    5  6   7

        bottomView(root);
    }
}