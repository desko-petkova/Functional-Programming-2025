-- Рекурсия

-- Обикновена рекурсия
repeatString :: String -> Int -> String
repeatString str 0 = ""
repeatString str n = str ++ (repeatString str (n -1)) 
-- Пример: rereatString "Echo " 5 == "Echo Echo Echo Echo Echo "

--Опашкова рекурсия
repeatStringTail :: (Eq t, Num t) => [a] -> [a] -> t -> [a]
repeatStringTail str result n =
        if n == 0
            then result
            else repeatStringTail str (result ++ str) (n-1)
-- Пеимер: repeatStringTail "ha" "" 3 == "hahaha"
 
factorial :: Int -> Int
factorial 0 = 1
factorial n = n * (factorial(n-1))

-- Опашкова рекурсия
factorialTail :: (Eq t, Num t) => t -> t
factorialTail n = go n 1
  where
    go 0 acc = acc
    go k acc = go (k - 1) (acc * k)
-- Пример: factorial 5 -> 120
--          factorialTail 5 -> 120           

-- Зад. 3 - 2 на степен n
pow2loop :: (Ord t1, Num t2, Num t1) => t1 -> t2 -> t1 -> t2
pow2loop n x i =
    if i < n
        then pow2loop n (x * 2) (i + 1)
        else x

pow2 :: (Ord t1, Num t2, Num t1) => t1 -> t2
pow2 n = pow2loop n 1 0
-- Пример: pow2 5 → 32

-- Зад. 4 - Сумиране на числа от 1 до 10
sumNumberLoop :: (Ord t, Num t) => t -> t -> t
sumNumberLoop sum index =
    if index > 10
        then sum
        else sumNumberLoop (sum+index) (index +1)

sumNumber :: Integer
sumNumber = sumNumberLoop 0 1
-- Пример: sumNumber -> 55

-- Дълбока рекурсия
fib :: Int -> Int
fib 0 = 0
fib 1 = 1
fib n = fib (n - 1) + fib (n - 2) -- двойно рекурсивно извикване (неоптимална)!!!
-- Промер: fib 25 -> 75025

-- Списък с числата от редицата на Фибоначи
fibs :: Integer -> [Integer] -- цели числа с произволна дължина
fibs 0 = [0]
fibs 1 = [0,1]
fibs n = 
    let prev = fibs (n - 1)
        next = last prev + last (init prev)
    in prev ++ [next]
-- Промер: fibs 45 -> [0,1,1,2,3,5,8,13,21,34,55,89,144,233,377,
--610,987,1597,2584,4181,6765,10946,17711,28657,46368,75025,121393,
--196418,317811,514229,832040,1346269,2178309,3524578,5702887,9227465,
--14930352,24157817,39088169,63245986,102334155,165580141,267914296,
--433494437,701408733,1134903170]