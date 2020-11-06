triangleNumber 1 = 1
triangleNumber n = n + triangleNumber(n-1)

listTriangleNumbers f n = [f(i)|i<-[1..n]]