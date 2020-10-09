//4) Поміняти місцями мінімальний і максимальний елементи масиву розміру 10.
package com.company;

public class Main {

    public static void main(String[] args) {
        int[] array = new int[10];
        for (int i = 0; i < 10; i++) {
            array[i] = (int) (Math.random() * (21 - (-20)) + (-20));
            System.out.print(array[i]+" ");
        }
        System.out.print("\n");
        int min = 0, max = 0;
        for (int i = 1; i < 10; i++) {
            if (array[i] > array[max]) max = i;
            if (array[i] < array[min]) min = i;
        }
        int temp=array[max];
        array[max]=array[min];
        array[min]=temp;
        for (int i=0; i<10; i++) {
            System.out.print(array[i]+" ");
        }
    }
}
