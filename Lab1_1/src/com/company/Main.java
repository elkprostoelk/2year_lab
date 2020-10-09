/*4) Одержати суму перших 20 членів арифметичної
        прогресії з першим членом А=1 і різницею d=1.5*/
package com.company;

public class Main {

    public static void main(String[] args) {
        float A=1, d=1.5f;
        float result=(2*A+d*(20-1))/2*20;
        System.out.println(result);
    }
}
