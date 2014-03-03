#load "FractalFunctions.fsx"
open Fractal

let next colour =
    let red, green, blue = colour
    (red, green + 10, blue)

let rec branch (x:float) (y:float) (length:float) (width:float) (angle:float<radians/pi>) colour =
    if width > 0.5 then
        let nextX, nextY = line x y angle length width colour

        branch nextX nextY (length*0.85) (width*0.8) (angle+0.11<radians/pi>) (next colour)
        branch nextX nextY (length*0.85) (width*0.8) (angle-0.11<radians/pi>) (next colour)

branch (formWidth/2.0) 150.0 100.0 10.0 0.5<radians/pi> (30,10,0)

showForm()