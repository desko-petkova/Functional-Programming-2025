-- Задача 4.

-- Функция за намиране на лице на кръг
areaOfCircle :: IO ()
areaOfCircle = do
    -- Въвеждане на r
    line <- getLine

    -- Намиране на лице на кръга
    let r = read line :: Float      -- read преобразува String в число с плаваща запетая Float
    let s = pi * r * r

    -- Отпечатваме лице на круг
    putStrLn (show(s))

-- Главна функция
main :: IO ()
main = do

    -- Изпълнение на фунцкия
   areaOfCircle