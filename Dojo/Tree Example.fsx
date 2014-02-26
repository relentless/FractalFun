#load "FractalFunctions.fsx"
open Fractal

showForm()

let rec branch (x:float) (y:float) (length:float) (width:float) (angle:float<radians/pi>) (iteration:int) =

    if iteration < 9 then
        
        let nextX, nextY = line x y angle length width (0,0,0)

        branch nextX nextY (length*0.8) width (angle+0.1<radians/pi>) (iteration+1)
        branch nextX nextY (length*0.8) width (angle-0.1<radians/pi>) (iteration+1)

branch (formWidth/2.0) 150.0 100.0 10.0 0.5<radians/pi> 0