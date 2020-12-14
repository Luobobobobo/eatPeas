<center><h1>排序算法总结</center>

## 一、冒泡排序法（Bubble Sort）

* 基本思想：两个数比较，较大的数下沉，较小的数浮起来

* 过程：

  * 比较相邻的两个数据，如果第二个数小，就交换位置。

  * 从后向前两两比较，一直比较到最前面的两个数据，最终最小数被交换到起始位置，这样第一个最小数的位置就换好了。

  * 重复上面两个步骤，依次将第2、3......n-1个最小数排好位置。

    ![冒泡排序](D:\大学\大四上学期\Typora文件\所用到的图片-数组排序\冒泡排序.png "冒泡排序")

    **冒泡排序**

* 平均时间复杂度：

  * O(n2)

* c#代码在unity中实现：  

  ```c#
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  
  //冒泡排序法
  public class bubbleSort :MonoBehaviour
  {
      //判断是否发生交换的标志
      bool isSort=false;
      public void bubble_sort(int[] arr)
      {
          for(int i=0;i<arr.Length;i++)
          {
              isSort=false;
              for(int j=arr.Length-1;j>i;j--)
              {
                  if(arr[j]<arr[j-1])
                  {
                      int temp=arr[j-1];
                      arr[j-1]=arr[j];
                      arr[j]=temp;
                      isSort=true;
                  }
              }
              //当一次比较之后，没有发生数值的交换，跳出循环
              if(!isSort)
              {
                  break;
              }
          }
      }
  }
  ```

* 优化：

  * 数据在排好之后，冒泡算法仍会进行下一次的比较，直到arr.Length-1次为止，后面的比较是没有意义的。
  * 所以在以上代码里面添加了一个bool值isSort，用来判断正在进行的这一轮比较有没有发生数值交换。
  * 如果一轮比较结束后，isSort的值仍为false，说明没有发生数值交换，即数组已经排好序了，跳出循环即可。

+++

## 二、选择排序法（Selection Sort）

* 基本思想：

  * 在长度为N的数组中，第一次遍历n-1个数，找到最小的值与第一个元素交换。
  * 第二次遍历n-2个数，找到最小的值与第二个元素交换。
  * ......
  * 第n-1次遍历，找到最小的值与第n-1个元素进行交换，排序完成。

* 过程：

  ![选择排序](D:\大学\大四上学期\Typora文件\所用到的图片-数组排序\选择排序.png "选择排序")

  **选择排序**

* 平均时间复杂度：

  * O(n2)

* c#代码在unity中实现：

  ```c#
  using System.Collections;
  using System.Collections.Generic;
  using UnityEngine;
  
  //选择排序法
  public class seclectionSort : MonoBehaviour
  {
      public void selection_sort(int [] arr)
      {
          int minNum;
          for(int i=0;i<arr.Length-1;i++)
          {
              minNum=i;
              for(int j=i+1;j<arr.Length;j++)
              {
                  if(arr[j]<arr[minNum])
                  {
                      minNum=j;
                  }
              }
              if(minNum!=i)
              {
                  int temp=arr[i];
                  arr[i]=a[minNum];
                  arr[minNum]=temp;
              }
          }
      }
  }
  ```

---

## 三、插入排序（Insertion Sort）

* 基本思想：

  * 在要排序的一组数中，假定前n-1个数已经排好，现在将第n 个数插到前面的有序数组中，使得这n个数也是排好序的。如此反复循环，直到全部排好序。

* 过程：

  ![插入排序](D:\大学\大四上学期\Typora文件\所用到的图片-数组排序\插入排序.png "插入排序")

  **插入排序**

* 平均时间复杂度：

  * O(n2)

* c#代码在unity中实现：

  ```c#
  using System.Collections;
  using System.Collections.Generic;
  using UnityEnegine;
  
  //插入排序法
  public class InsertionSort : MonoBehaviour
  {
      public void insertion_sort(int[] arr)
      {
          for(int i=0;i<arr.Length-1;i++)
          {
              for(int j=i+1;j>0;j--)
              {
                  if(arr[j]<arr[j-1])
                  {
                      int temp=arr[j-1];
                      arr[j-1]=arr[j];
                      arr[j]=temp;
                  }
                  //因为数组是已经排好序的，所以插入新的数值时，当他比前面那个数值大的时候，他一定比更前面的数值大
                  else
                  {
                      break;
                  }
              }
          }
      }
  }
  ```

+++

## 四、希尔排序（Shell Sort）

* 前言：

  * 数据数列1 :  13-17-20-42-28利用插入排序 ，13-17-20-28-42. number of swap ：1。
  * 数据列表2 ：13-17-20-42-14利用插入排序，13-14-17-20-42. number of swap ：3。
  * 如果数据列表基本有序，使用插入排序会更加高效。

* 基本思想：

  * 在要排序的一组数中，根据某一增量分为若干子序列，并对子序列分别进行插入排序。
  * 然后逐渐将增量减小，并重复上数过程。直到增量为1，此时数据序列基本有序，最后进行插入排序。

* 过程：

  ![希尔排序](D:\大学\大四上学期\Typora文件\所用到的图片-数组排序\希尔排序.png "希尔排序")

  **希尔排序**

* 平均时间复杂度：

  * O(n1.5)

* c#代码在unity中实现：

  ```c#
  using System.Collections;
  using System.Collections.Generic;
  using UnityEnegine;
  
  //希尔排序法
  public class shellSort : MonoBehaviour
  {
      public void shell_sort(int[] arr)
      {
          int incre=arr.Length;
          while(true)
          {
              incre=incre/2;
              for(int k=0;k<incre;k++)
              {
                  for(int i=k+incre;i<arr.Length;i+=incre)
                  {
                      for(int j=i;j>k;j-=incre)
                      {
                          if(arr[j]<arr[j-incre])
                          {
                              int temp=arr[j-incre];
                              arr[j-incre]=arr[j];
                              arr[j]=temp;
                          }
                          //因为前面已经排好序了
                          //比如说，当arr.Length为9时，第一次进来时比较arr[4]和arr[0]
                          //第二次进来会先比较arr[8]和arr[4],再比较arr[4]和arr[0]
                          else
                          {
                              break;
                          }
                      }
                  }
              }
              if(incre==1)
              {
                  break;
              }
          }
      }
  }
  ```

___

## 五、快速排序（Quick Sort）

* 基本思想：（分治）

  * 先从数列中取出一个数作为key值；
  * 将比这个数小的数全部放在它的左边，比这个数大的数全部放在它的右边；
  * 对左右两个小数列重复第二步，直至各区间只有一个数

* 辅助理解：[挖坑填数](https://www.runoob.com/w3cnote/quick-sort.html)

  * 初始时i=0;j=9;key=72;

    由于已经将a[0]中的数保存到key中，可以为在数组的a[0]位置挖了一个坑，可以将其他的数值填充进来。

    从j开始向前，找一个比key小的数，当j=8时，符合条件，**a[0]**=**a[8]**,**i++**,即将a[8]再挖出来填到上一个坑a[0]中。

    这样一个坑a[0]就被填充上了，但又形成了一个新坑a[8]。

    这样i开始向后找一个大于key的值，当i=3时符合条件，**a[8]=a[3]**,**j--**,即将a[3]挖出再填到上一个坑a[8]中。

    > 数组：72 - 6 -57 -88 -60- 42- 83- 73- 48- 85
    >
    > ​			  0	1	2	3	4	5	6	7	8	9

  * 此时i=3；j=7；key=72

    再重复上面的步骤，先从后向前找，再从前向后找。

    从j开始向前找，当j=5，符合条件，将a[5]挖出填到上一个坑中，**a[3]**=**a[5]**,**i++**。

    从i开始向后找，当i=5时，由于i==j，退出循环。

    此时，i==j==5,而a[5]刚好又是上次挖出来的坑，因此将key填入a[5]。

    >数组：48 - 6 -57 -88 -60- 42- 83- 73- 88- 85
    >
    >​			  0	1	2	3	4	5	6	7	8	9

  * 可以看出来a[5]前面的数字都小于它，a[5]后面的数字都大于它。因此再对a[0...4]和a[6...9]这两个子区间重复上述步骤就可以了。

    >数组：48 - 6 -57 -42 -60- 72- 83- 73- 88- 85
    >
    >​			  0	1	2	3	4	5	6	7	8	9

* 平均时间复杂度：

  * O(N*logN)

* c#代码在unity中实现：

  ```c#
  using System.Collections;
  using System.Collections.Generic;
  using UnityEnegine;
  
  //快速排序法
  public class quickSort : MonoBehaviour
  {
      public void quick_sort(int[] arr,int l,int r)
      {
          //添加这个判断条件，可以使例如当第一个数值为最小值时，进行递归调用的时候数组不越界
          if(l<r)
          {
              int keyNum=arr[l];
          	int i=l;
          	int j=r;
              while(i<j)
              {
                  while(arr[j]>=keyNum&&i<j)
                  {
                      j--;
                  }
                  if(i<j)
                  {
                      arr[i]=arr[j];
                      i++;
                  }
                  while(arr[i]<keyNum&&i<j)
                  {
                      i++;
                  }
                  if(i<j)
                  {
                      arr[j]=arr[i];
                      j--;
                  }
              }
              arr[i]=keyNum;
              quick_sort(arr,l,i-1);
              quick_sort(arr,i+1,r);
          }
      }
  }
  ```

  ***key值的选取可以有多种形式，例如中间数或者随机数，分别会对算法的复杂度产生不同的影响。***

