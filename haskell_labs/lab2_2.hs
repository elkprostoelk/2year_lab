powTwo 0 = 1
powTwo f = 2 * powTwo(f-1)

powerOfTwo :: Int -> Int
powerOfTwo n = if even n then powTwo(n `div` 2) else 2 * powTwo((n - 1) `div` 2)