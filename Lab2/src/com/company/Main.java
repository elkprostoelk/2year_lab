/*4. Клас «трикутник»:
        - трикутник задається довжиною трьох сторін
        - конструктор класа перевіряє, чи можна створити трикутник із заданими сторонами.
        - методи класу дозволяють знаходити периметр трикутника, площу трикутника;
        - існує метод для порівняння з іншим трикутником.*/


package com.company;

public class Main {

    public static void main(String[] args) {
        Triangle tr1=new Triangle(3,4,5);
        tr1.printTriangle();
        Triangle tr=new Triangle(0,1,1);
        tr.printTriangle();
        tr.setA(5);
        tr.setB(5);
        tr.setC(5);
        if(tr1.IsEqual(tr)) System.out.println("tr==tr2");
        else System.out.println("tr!=tr2");
        System.out.println("Периметр tr1:"+tr1.Perimeter());
        System.out.println("Периметр tr:"+tr.Perimeter());
        System.out.println("Площадь tr1:"+tr1.Area());
        System.out.println("Площадь tr:"+tr.Area());
    }
}

class Triangle {
    private double a,b,c;

    Triangle(double a, double b, double c) {
        if(a<b+c && b<a+c && c<a+b) {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        else{
            System.out.println("Невозможно создать треугольник с такими сторонами!\nУстановлены значения по умолчанию");
            this.a=0;
            this.b=0;
            this.c=0;
        }
    }

    public double getA() {
        return a;
    }

    public double getB() {
        return b;
    }

    public double getC() {
        return c;
    }

    public void setA(double a) {
        this.a = a;
    }

    public void setB(double b) {
        this.b = b;
    }

    public void setC(double c) {
        this.c = c;
    }

    public boolean IsEqual(Triangle tr2){
        return this.a == tr2.a && this.b == tr2.b && this.c == tr2.c;
    }

    public double Perimeter(){
        return this.a+this.b+this.c;
    }

    public double Area(){
        double p=this.Perimeter()/2d;
        return Math.sqrt(p*(p-this.a)*(p-this.b)*(p-this.c));
    }
    public void printTriangle() {
        System.out.println("a="+ this.getA()+" b="+ this.getB()+" c="+ this.getC());
    }
}
