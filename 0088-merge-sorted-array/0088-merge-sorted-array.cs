public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
       
        int cont=0; 
       
     for(int i=nums1.Length-1;i>=0;i--){ 
           
           if(nums1[i]==0){  
               nums1[i]=nums2[cont];   
               cont++;
           }
            if(cont>=nums2.Length)
                i=-1;
       }

       for(int i=0;i<nums1.Length;i++) 
           for(int j=i+1;j<nums1.Length;j++)
               if(nums1[i]>nums1[j]){
                   int swap = nums1[j];
                   nums1[j]=nums1[i];
                   nums1[i]=swap;
               }
    }
}