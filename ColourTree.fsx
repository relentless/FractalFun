#load "FractalFunctions.fsx"
open Fractal

let branchAngle = 0.11
let lengthMultiplier = 5.0/6.0
let widthModifier = -0.8
let startWidth = 12.0

let startColour = (60,30,0) // brown
let endColour = (0,170,0) // green

//background 550.0 600 (30,160,30)
//background 0.0 550 (130,150,255)

let numSteps = int (startWidth / -widthModifier)
let step = colourStep startColour endColour numSteps

let rec branch x y length width colour angle =
    if width > 0.0 then
        let angleDegrees = (pi*angle)
        line x y angleDegrees length width colour
        let nextX, nextY = endpoint x y angleDegrees length

        branch nextX nextY (length*lengthMultiplier) (width+widthModifier) (colour |> next step) (angle+branchAngle)
        branch nextX nextY (length*lengthMultiplier) (width+widthModifier) (colour |> next step) (angle-branchAngle)

branch (imageCentre - startWidth/2.0) 50.0 100.0 startWidth startColour 0.5

form.ShowDialog()
