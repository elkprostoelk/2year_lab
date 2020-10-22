package com.company;
import java.util.Scanner;
public class Main {

    public static void main(String[] args) {
        GeometryProgr gp=new GeometryProgr();
        Scanner sc=new Scanner(System.in);
        int n=sc.nextInt();
        System.out.println(gp.value(n));
    }
}
