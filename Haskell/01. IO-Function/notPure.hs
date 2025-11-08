-- Задача 2.

-- Финкция, която извършва IO действие и връща символен низ
askName :: IO String
askName = do
    putStr ("Your name:")
    getLine

-- Финкция, която приема символен низ и връща IO действие (отпечатва символния низ в конзолата)
sayHello :: String -> IO()
sayHello name = putStrLn("Hello, "++name++"!")

-- Главна функция
main:: IO()
main = do
    name <- askName
    sayHello name