/*4) По заданій формулі (3*i^3+10)/(8*i) члена ряду з номером k скласти
        програму обчислення суми всіх членів ряду,
        не більших заданого числа eps.*/
package com.company;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner sc=new Scanner(System.in);
        float eps=sc.nextFloat(), sum=0, i=1;
        while(NMember(i)<eps){
            sum+=NMember(i);
            i++;
        }
        System.out.println("Сумма: "+sum);
    }
    static float NMember(float i){
        return (float) ((3*Math.pow(i,3)+10)/(8*i));
    }
}
