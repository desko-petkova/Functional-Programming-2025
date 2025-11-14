
--1. Напиши чиста функция, която връща квадрата на число.
square :: Int -> Int
square x = x^2

--2. IO функция, която преобразува вход в число, подава го като параметър на чиста функция и изпечатва резултата
-- main :: IO()
-- main = do
--     putStr "Enter number: "
--     line <- getLine
--     let x = read line :: Int
--     putStrLn(show(square x))

--3. Максимум от две числа - чиста функция
maxN :: ( Ord a, Num a) => a -> a -> a
maxN x y =
    if x > y
        then x
        else y

-- 4. IO функция за задача 3
-- main :: IO()
-- main = do
--     putStr "Enter first number: "
--     line1 <- getLine
--     let x = read line1 :: Float
--     putStr "Enter second number: "
--     line2 <- getLine
--     let y = read line2 :: Float
--     putStrLn(show(maxN x y))


--5. Чиста функция, която конвертира сантиметри (cm) към инчове (inch), където 1 inch = 2.54 cm
cmToInch :: Double -> Double
cmToInch cm = cm / 2.54

--6. IO функция за задача 5
main :: IO()
main = do
    putStr "Enter cm = "
    line <- getLine
    let cm = read line :: Double
    putStrLn (show(cmToInch cm))


--7.Напиши функция, която добавя елемент към началото на списък.
addToFrond :: a -> [a] -> [a]
addToFrond x xs = x:xs

--8.Функция, която връща опашката на списък без да се интересува от първия елемент:
tail :: [a] -> [a]
tail [] = []
tail (_:xs) = xs

-- 9. Напиши функция, която взима два списъка и ги съединява.
joinLists :: [a] -> [a] -> [a]
joinLists xs ys = xs ++ ys

-- 10. Функция, която връща списък с удвоени елементи
doubleAll :: [Int] -> [Int]
doubleAll xs = map (*2) xs

-- 11. Функция, която повдига елементите на списък на квадрат и извежда общата им сума
sumOfSquares :: [Int] -> Int
sumOfSquares xs = sum(map (^2) xs)