-- зад. 5
-- Чиста функция, изчисляваща лице на кръг
areaOfCircle :: Floating a => a -> a
areaOfCircle r = pi*r*r

main :: IO ()
main = do                       -- Извършва входно-изходни действия
    line <-getLine
    -- read преобразува прочетения текст (String) в число от тип Float
    -- и го свързва с името r (immutable binding)
    let r = read line :: Float
    -- areaOfCircle е чиста функция, извиква се с r от тип Float
    -- show преобразува числовия резултат в String
    -- putStrLn извежда резултата на конзолата
    putStrLn (show (areaOfCircle r))