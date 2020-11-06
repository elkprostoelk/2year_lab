powTwo 0 = 1
powTwo f = 2 * powTwo(f-1)

power f n=if even n then f(n `div` 2) else 2 * f((n-1) `div` 2)