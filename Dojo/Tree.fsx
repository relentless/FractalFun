#load "FractalFunctions.fsx"
open Fractal

let rec branch (x:float) (y:float) (length:float) (width:float) (angle:float<radians>) (iteration:int) =
    if iteration < 4 then
        let angleDegrees = (pi*angle)
        line x y angleDegrees length width (0,0,0)
        let nextX, nextY = endpoint x y angleDegrees length

        branch nextX nextY (length*0.8) width (angle+0.1<radians>) (iteration+1)
        branch nextX nextY (length*0.8) width (angle-0.1<radians>) (iteration+1)

branch imageCentre 50.0 100.0 10.0 0.5<radians> 0

form.ShowDialog()
