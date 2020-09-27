package com.company;

import java.util.ArrayList;

public class Main {

    public static void main(String[] args) {
        ArrayList<Double> funcValues= new ArrayList<>();
        for (double i=0; i<=Math.PI; i+=(Math.PI/6)){
            if(DerivativeF(i)==0d) funcValues.add(Function(i));
        }
        funcValues.add(0,Function(0));
        funcValues.add(Function(Math.PI));
        int min=0;
        for (int i=1; i< funcValues.size(); i++) {
            if(funcValues.get(i) < funcValues.get(min)) min=i;
        }
        System.out.println(funcValues.get(min));
    }
    static double Function(double x) {
        return Math.sin(x)+Math.cos(x)*Math.cos(x);
    }
    static double DerivativeF(double x) {
        return Math.cos(x)-Math.sin(2*x);
    }
}
