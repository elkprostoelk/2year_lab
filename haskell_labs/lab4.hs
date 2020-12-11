type Radius = Double
type Point = (Double, Double)
type Center = (Double,Double)
type TopLeft = (Double,Double)
type BottomRight = (Double, Double)
type A = (Double, Double)
type B = (Double, Double)
type C = (Double, Double)
type BottomLeft = (Double,Double)
data Font = Lucida | Courier | Fixedsys deriving (Eq,Show)
type Name = String
type Str = String
data Figure = Circle Name Center Radius | Rectangle Name TopLeft BottomRight | Triangle Name A B C | Textarea Name BottomLeft Font Str deriving (Eq, Show)

figures :: [Figure]
figures = [Circle "1" (0,0) 4,Rectangle "2" (1,4) (5,0),Triangle "3" (3,6) (-1,1) (5,1),Textarea "4" (-4,-1) Lucida "aabbcc"]

getLetterSize :: Fractional p => Font -> p
getLetterSize f = case f of {Lucida->1.0;
    Courier->2.0;
    Fixedsys->3.0}

fixJust :: Maybe a -> a
fixJust (Just a) = a
fixJust Nothing  = error "bad value"

getTopLeftX :: Figure -> Maybe Double
getTopLeftX (Rectangle _ topleft _) =  Just (fst topleft)
getTopLeftX (Circle _ _ _) = Nothing
getTopLeftX (Triangle _ _ _ _) = Nothing
getTopLeftX (Textarea _ _ _ _) = Nothing

getTopLeftY :: Figure -> Maybe Double
getTopLeftY (Rectangle _ topleft _) =  Just (snd topleft)
getTopLeftY (Circle _ _ _) = Nothing
getTopLeftY (Triangle _ _ _ _) = Nothing
getTopLeftY (Textarea _ _ _ _) = Nothing

getBottomRightX :: Figure -> Maybe Double
getBottomRightX (Rectangle _ _ bottomright) =  Just (fst bottomright)
getBottomRightX (Circle _ _ _) = Nothing
getBottomRightX (Triangle _ _ _ _) = Nothing
getBottomRightX (Textarea _ _ _ _) = Nothing

getBottomRightY :: Figure -> Maybe Double
getBottomRightY (Rectangle _ _ bottomright) =  Just (snd bottomright)
getBottomRightY (Circle _ _ _) = Nothing
getBottomRightY (Triangle _ _ _ _) = Nothing
getBottomRightY (Textarea _ _ _ _) = Nothing

getFigure :: [Figure] -> Point -> Maybe Figure
getFigure [] point = Nothing
getFigure (fg:fs) point | ((fst point >= fixJust (getTopLeftX fg)) && (snd point <= fixJust (getTopLeftY fg)) && (fst point <= fixJust (getBottomRightX fg) && snd point >= fixJust (getBottomRightY fg))) = Just fg
                            | otherwise = getFigure fs point

area :: Figure -> Double
area (Circle _ _ radius) = pi*radius*radius
area (Rectangle _ topLeft bottomRight) = abs(fst topLeft - fst bottomRight )*abs(snd topLeft -snd bottomRight)
area (Triangle _ a b c) = let {ab=sqrt((abs(fst a - fst b))**2.0 + (abs(snd a -snd b))**2.0);
    bc=sqrt((abs(fst b -fst c))**2.0 + (abs(snd b - snd c))**2.0);
    ac=sqrt((abs(fst a -fst c))**2.0 + (abs(snd a - snd c))**2.0);
    p=(ab+bc+ac)/2.0
}
    in sqrt(p*(p-ab)*(p-bc)*(p-ac))
area (Textarea _ _ font str) = fromIntegral(length str) * getLetterSize font * getLetterSize font

getRectangles :: [Figure] -> [Figure]
getRectangles ((Rectangle name topleft bottomright):fs) = Rectangle name topleft bottomright : getRectangles fs
getRectangles ((Circle _ _ _):fs) = getRectangles fs
getRectangles ((Triangle _ _ _ _):fs) = getRectangles fs
getRectangles ((Textarea _ _ _ _):fs) = getRectangles fs

getBound :: Figure -> Figure
getBound (Circle name center radius) = Rectangle "Bound" (fst center - radius,snd center - radius) (fst center + radius, snd center + radius)
getBound (Rectangle name topleft bottomright) = Rectangle "Bound" topleft bottomright
getBound (Triangle name a b c) = Rectangle "Bound" (fst b, snd a) (fst c, snd a)
getBound (Textarea name bottomleft font str) = Rectangle "Bound" (fst bottomleft, snd bottomleft - getLetterSize font) (fst bottomleft + getLetterSize font, snd bottomleft)

getBounds :: [Figure] -> [Figure]
getBounds [] = []
getBounds (x:xs) = getBound x : getBounds xs

move :: Figure -> (Double, Double) -> Figure
move (Circle name center radius) vector = Circle name (fst(center)+fst(vector),snd(center)+snd(vector)) radius
move (Rectangle name topleft bottomright) vector = Rectangle name (fst topleft + fst vector, snd topleft + snd vector) (fst bottomright + fst vector, snd bottomright + snd vector)
move (Triangle name a b c) vector = Triangle name (fst a + fst vector, snd a+snd vector) (fst b + fst vector, snd b + snd vector) (fst c + fst vector, snd c + snd vector)
move (Textarea name bottomleft font str) vector = Textarea name (fst bottomleft + fst vector, snd bottomleft + snd vector) font str