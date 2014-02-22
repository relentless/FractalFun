#load "FractalFunctions.fsx"
open Fractal

let leftBranchAngle = 0.15
let rightBranchAngle = 0.5
let lengthMultiplier = 5.5/6.0
let widthMultiplier = 5.5/6.0
let rightMultiplier = 0.5
let startWidth = 16.0
let startLength = 100.0

let rec branch x y length width colour angle =
    if width > 0.4 then
        let angleDegrees = (pi*angle)
        line x y angleDegrees length width colour
        let nextX, nextY = endpoint x y angleDegrees (length-2.0)

        branch nextX nextY (length*lengthMultiplier) (width*widthMultiplier) colour (angle+leftBranchAngle)
        branch nextX nextY (length*0.5) (width*0.5) colour (angle-rightBranchAngle)

branch (imageCentre - startWidth/2.0) 150.0 startLength startWidth (0,0,0) 0.5

form.ShowDialog()
