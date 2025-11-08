-- Задача 3.

-- Функция за произведението на две чсла
numbersMult :: IO ()
numbersMult = do
    -- Въвеждане на a и b
    line1 <- getLine
    line2 <- getLine

    -- Намиране на произведение
    let a = read line1 :: Int      --read преобразува String в число от тип Int
    let b = read line2 :: Int      --read преобразува String в число от тип Int
    let c = a * b

    -- Отпечатваме произведението
    putStrLn (show(c))             --show преобразувате числения тип в символен низ

-- Главна функция
main :: IO ()
main = do

    -- Изпълнение на фунцкия
   numbersMult