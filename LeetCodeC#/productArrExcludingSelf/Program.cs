﻿// Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the elements of nums except nums[i].

// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.

// You must write an algorithm that runs in O(n) time and without using the division operation.

 

// Example 1:

// Input: nums = [1,2,3,4]
// Output: [24,12,8,6]
// Example 2:

// Input: nums = [-1,1,0,-3,3]
// Output: [0,0,9,0,0]
 

// Constraints:

// 2 <= nums.length <= 105
// -30 <= nums[i] <= 30
// The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
 

// Follow up: Can you solve the problem in O(1) extra space complexity? (The output array does not count as extra space for space complexity analysis.)

//the point is to find the prefix product excluding self and the postfix product excluding self foreach element and then multiply them
using System;
int[] productArrExcludingSelf(int[] nums) {
    int n = nums.Length;
    int[] res = new int[n];
    int[] prefixProductExclSelf = new int[n];
    int[] postfixProductExclSelf = new int[n];

    prefixProductExclSelf[0] = 1;
    postfixProductExclSelf[n - 1] = 1;
    for (int i = 1; i < n; i++) {
        prefixProductExclSelf[i] = prefixProductExclSelf[i - 1] * nums[i - 1];
        postfixProductExclSelf[n - 1 - i] = postfixProductExclSelf[n - 1 - i + 1] * nums[n - 1 - i + 1];
    }

    for (int i = 0; i < n; i++) {
        res[i] = prefixProductExclSelf[i] * postfixProductExclSelf[i];
    }

    return res;
}

int[] nums = new int[] {1,2,3,4};
Console.WriteLine(string.Join(",", productArrExcludingSelf(nums))); //24,12,8,6