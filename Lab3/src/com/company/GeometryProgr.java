package com.company;
//находится сумма N элементов бесконечной геом. прогрессии с B1=1 и Q=0.5
public class GeometryProgr extends summa {
    @Override
    public double value(int n) {
        double sum=0;
        for(int i=0; i<=n; i++) {
            sum+=(1d/Math.pow(2,i));
        }
        return sum;
    }
}
