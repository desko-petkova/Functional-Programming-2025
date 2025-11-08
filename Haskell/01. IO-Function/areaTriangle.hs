-- зад. 6
import System.IO                      -- Импорт на библиотека за входно-изходни операции

main :: IO ()
main = do
    putStrLn "Enter base of triangle:"     -- Извежда съобщение на конзолата
    base <- fmap read getLine :: IO Double -- Чете ред от клавиатурата (String),
                                           -- преобразува го в Double чрез read (чиста функция)
                                           -- и свързва резултата с името base

    putStrLn "Enter height of triangle:"   -- Извежда второ съобщение
    height <- fmap read getLine :: IO Double -- Аналогично: чете и преобразува височината

    -- формула за лице на триъгълник S = (base * height) / 2
    let area = (base * height) / 2

    -- show преобразува числото (Double) в низ
    -- putStrLn отпечатва резултата в конзолата
    putStrLn ("Area of triangle is : " ++ show area)

    _ <- getLine     -- Изчаква Enter, за да не се затвори прозорецът (само пауза)
    return ()         -- Завършва главната IO функция
