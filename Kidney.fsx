#load "FractalFunctions.fsx"
open Fractal

let smallBranchAngle = 0.11
let largeBranchAngle = 0.16
let smallLengthMultiplier = 0.85
let largeLengthMultiplier = 0.9
let smallWidthModifier = -2.2
let largeWidthModifier = -1.8

let startWidth = 30.0
let startLength = 80.0

let startColour = (40,20,0) // brown
let endColour = (240,0,0) // reddish

let numSteps = int (startWidth / -largeWidthModifier)
let step = colourStep startColour endColour numSteps

let rec branch x y length width colour angle =
    if width > 0.0 then
        let angleDegrees = (pi*angle)
        line x y angleDegrees length width colour
        let nextX, nextY = endpoint x y angleDegrees length

        branch nextX nextY (length*smallLengthMultiplier) (width+smallWidthModifier) (colour |> next step) (angle+smallBranchAngle)
        branch nextX nextY (length*largeLengthMultiplier) (width+largeWidthModifier) (colour |> next step) (angle-largeBranchAngle)

branch (imageCentre - 50.0) 200.0 startLength startWidth startColour 0.5

form.ShowDialog()
