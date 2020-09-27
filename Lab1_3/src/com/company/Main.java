package com.company;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner sc=new Scanner(System.in);
        float eps=sc.nextFloat(), sum=0, i=1;
        do {
            sum+=NMember(i);
            i++;
        } while(NMember(i)<eps);
        System.out.println("Сумма: "+sum);
    }
    static float NMember(float i){
        return (float) ((3*Math.pow(i,3)+10)/(8*i));
    }
}
