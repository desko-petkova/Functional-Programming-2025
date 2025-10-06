import Data.Text.Lazy.Read (double)
main :: IO ()
main = do
    putStrLn("Как се казваш")
    name <- getLine
    putStrLn("Здравей,"++name)

greet :: String
greet = "Echo!!"

--double x = x*2
squr a = a^2