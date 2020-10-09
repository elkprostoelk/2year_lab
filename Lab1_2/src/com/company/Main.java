/*4) Написати програму повного дослідження сукупності коренів рівняння
        a x2 + b x + c. Якщо коренів немає, то повинне бути виведене
        текстове повідомлення про це. Інакше повинні бути виведено два корені.*/
package com.company;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        float a = sc.nextFloat(), b = sc.nextFloat(), c = sc.nextFloat();
        float D = b * b - 4 * a * c;
        if (D < 0) System.out.println("Корней нет, но вы держитесь!)");
        else {
            float x1 = (float) ((-b + Math.sqrt(D)) / (2 * a)),
                    x2 = (float) ((-b - Math.sqrt(D)) / (2 * a));
            System.out.println("x1=" + x1);
            System.out.println("x2=" + x2);
        }
    }
}