-- Задача 1.

-- Функция за отпечатване на името и фамилията
firstAndLastName :: IO()
firstAndLastName = do
    firstname <- getLine                         -- Въвеждане на име
    lastname <- getLine                          -- Въвеждане на фамилия
    putStrLn (firstname ++ "  " ++ lastname)     -- Отпечатваме име и фамилие

-- Главна функция
main :: IO ()
main =
   firstAndLastName                               -- Изпълнение на фунцкия