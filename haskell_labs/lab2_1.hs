triangleNumber 1 = 1
triangleNumber n = n + triangleNumber(n-1)

listTriangleNumbers :: Int -> [Int]
listTriangleNumbers n = [triangleNumber(i)|i<-[1..n]]