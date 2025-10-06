
sumN :: Int -> Int   
sumN n = sum [1..n]

main :: IO()
main = do
    putStr "Въведи число N:"
    input <- getLine
    let n = read input :: Int
    print (sumN n)



